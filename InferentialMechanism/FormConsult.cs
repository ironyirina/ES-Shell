using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InferentialMechanism
{
    public partial class FormConsult : Form
    {
        #region Переменные
        private Db _es;
        /// <summary>
        /// база данных, где хранятся все переменные, домены, правила и тд
        /// </summary>
        public Db Es
        {
            get { return _es; }
            set
            {
                _es = value; comboBoxGoal.DataSource =
              _es.Variables.Where(x => x.VarTypes.Name == "Выводимая" || x.VarTypes.Name == "Выводимо-запрашиваемая").
                  Select(x => x.Name);
            }
        }

        /// <summary>
        /// Цель консультации
        /// </summary>
        private Variables _goal;

        /// <summary>
        /// Результат консультации
        /// </summary>
        private Values _result;

 
        #endregion

        #region Свойства

        public string Goal
        {
            get { return _goal == null ? string.Empty : _goal.Name; }
        }

        public string Result
        {
            get { return _result == null ? "Ответ не найден" : _result.Name; }
        }

        /// <summary>
        /// Функция, выводящая информацию о сработавшем правиле на форму объяснения
        /// </summary>
        public Action<string, IEnumerable<string>, IEnumerable<string>, string> AddToExplanation { get; set; }

        /// <summary>
        /// Рабочая память
        /// </summary>
        public List<WorkMemory> WorkMemory { get; private set; }

        #endregion

        #region Инициализация
        public FormConsult()
        {
            InitializeComponent();
            WorkMemory = new List<WorkMemory>();
        } 
        #endregion

        #region Интерфейсик
        private void ButtonOkClick(object sender, EventArgs e)
        {
            try
            {
                Hide();
                _goal = _es.Variables.Single(x => x.Name == comboBoxGoal.SelectedItem.ToString());
                _result = ProveGoal(_goal);
                MessageBox.Show(Result);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        } 
        #endregion

        #region МЛВ
        /// <summary>
        /// Означивание переменной
        /// </summary>
        private void SetValue(Variables variable)
        {
            //если переменная не означена, то ее нет в _workMemory
            if (WorkMemory.All(x => x.Variable != variable))
            {
                //если переменная запрашиваемая, то выводим форму с вопросом
                if (variable.VarTypes.Name == "Запрашиваемая")
                {
                    var askForm = new FormAsk(_es, variable);
                    if (askForm.ShowDialog() == DialogResult.OK)
                    {
                        //означиваем переменную, т.е. заносим ее в рабочую память
                        Values answer = askForm.GivenAnswer;
                        WorkMemory.Add(new WorkMemory { Variable = variable, Value = answer, HasBeenAsked = true });
                    }
                }
                //если переменная выводимая или выводимо-запрашиваемая, рекурсивно доказываем подцель
                else
                {
                    ProveGoal(variable);
                }
            }
            //если переменная означена, то выводим форму с вопросом, если эта переменная выводимо-запрашиваемая
            //и про нее раньше не спрашивали
            else if (variable.VarTypes.Name == "Выводимо-запрашиваемая" &&
                !WorkMemory.Single(x => x.Variable == variable).HasBeenAsked)
            {
                //спрашиваем
                var askForm = new FormAsk(_es, variable);
                if (askForm.ShowDialog() == DialogResult.OK)
                {
                    //означиваем переменную, т.е. заносим ее в рабочую память
                    Values answer = askForm.GivenAnswer;
                    var wm = WorkMemory.Single(x => x.Variable == variable);
                    wm.HasBeenAsked = true;
                    wm.Value = answer;
                }
            }
        }

        private Values ProveGoal(Variables varToProve)
        {
            //Строим горячий набор правил
            var r = _es.Conclusions.Where(x => x.VariableID == varToProve.Id);
            var hotSetOfRules = r.Select(rr => rr.Rules).OrderBy(x => x.Number).ToList();
            Rules workedRule = null;
            int ruleNum = 0;
            while (ruleNum < hotSetOfRules.Count() && workedRule == null)
            {
                var rule = hotSetOfRules[ruleNum];
                //факты из посылки текущего правила
                var listOfVariablesInFact = _es.Facts.Where(x => x.RuleID == rule.Id).OrderBy(x => x.Number);
                //означиваем посылку
                bool goodRule = true;
                int i = 0;
                while (i < listOfVariablesInFact.Count() && goodRule)
                {
                    var fact = listOfVariablesInFact.ToList()[i];
                    var variable = fact.Variables;
                    //означиваем переменную
                    SetValue(variable);
                    //теперь, когда переменная означена, проверяем, совпадает ли ее значение со значением в правиле
                    //если совпадает, то все ок
                    //если не совпадает, переходим на следующее правило
                    var ss = WorkMemory.SingleOrDefault(x => x.Variable == variable);
                    Values v1 = ss == null ? null : ss.Value;
                    var v2 = fact.Values;
                    if (v1 != v2)
                        goodRule = false;
                    i++;
                }
                if (goodRule) //все ок, правило срабатывает
                {
                    workedRule = rule;
                }
                else //правило не сработало, берем следующее
                {
                    ruleNum++;
                }
            }
            //если есть сработавшее правило, то означиваем заключение
            //заносим в рабочую память все переменные и значения из заключения правила
            if (workedRule != null)
            {
                var listOfVariablesInConclusion = _es.Conclusions.Where(x => x.RuleID == workedRule.Id).
                    Select(x => x.Variables);
                foreach (var variableC in listOfVariablesInConclusion)
                {
                    WorkMemory.Add(new WorkMemory
                                        {
                                            Variable = variableC,
                                            Value = _es.Conclusions.Single(x => x.RuleID == workedRule.Id
                                                                                && x.Variables == variableC).Values,
                                            HasBeenAsked = false
                                        });
                }
                //поясняем
                //1) Имя правила
                var rName = workedRule.Name;
                //2) Список посылок в виде "Переменная = значение"
                var factList =
                    _es.Facts.Where(x => x.Rules == workedRule).Select(x => x.Variables.Name + " = " + x.Values.Name);
                //3) список заключений
                var concList =
                    _es.Conclusions.Where(x => x.Rules == workedRule).Select(
                        x => x.Variables.Name + " = " + x.Values.Name);
                //4) Объяснение
                var exp = workedRule.Explain;
                AddToExplanation(rName, factList, concList, exp);
            }
            //Ищем ответ
            var coolAnswer = WorkMemory.SingleOrDefault(x => x.Variable == varToProve);
            if (coolAnswer != null)
                return (coolAnswer.Value);
            if (varToProve.VarTypes.Name != "Выводимая")
            {
                var fquestion = new FormAsk(_es, varToProve);
                if (fquestion.ShowDialog() == DialogResult.OK)
                {
                    Values answer = fquestion.GivenAnswer;
                    WorkMemory.Add(new WorkMemory { Variable = varToProve, Value = answer, HasBeenAsked = true});
                    return answer;
                }
            }
            //throw new ArgumentException("Ответ не найден");
            return null;
        } 
        #endregion
    }
}
