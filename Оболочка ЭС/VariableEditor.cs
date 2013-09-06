using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Оболочка_ЭС
{
    public partial class VariableEditor : Form
    {
        #region Переменные
        private Db _es, _esCopy;
        private readonly string _dbFullName;
        private readonly string _dbCopyFullName;
        private readonly string _filePath;
        private readonly string _dbCopyFileName;
        private bool _somethingChanged;
        private Variables _selectedVariable;
        #endregion

        #region Инициализация
        public VariableEditor(ref Db es, string filePath, string fileName)
        {
            InitializeComponent();
            //создание БД и ее копии
            _es = es;
            _dbFullName = es.Connection.DataSource;
            _dbCopyFullName = filePath + "\\~" + fileName + ".sdf";
            File.Copy(_dbFullName, _dbCopyFullName, true);
            _esCopy = new Db(filePath + "\\~" + fileName + ".sdf");
            _filePath = filePath;
            _dbCopyFileName = "~" + fileName;
            FillListViewVariables();
        }
 
        private void FillListViewVariables()
        {
            listViewVariables.Items.Clear();
            var d = _esCopy.Variables.Select(x => new
            {
                a1 = x.Name,
                a2 = x.Domains.Name,
                a3 = x.VarTypes.Name,
                a4 = x.Question
            });
            foreach(var dd in d)
            {
                listViewVariables.Items.Add(new ListViewItem(new[] {dd.a1, dd.a2, dd.a3, dd.a4}));
            }
            if (listViewVariables.Items.Count > 0)
                listViewVariables.Items[0].Selected = true;
        }

        private void ListViewVariablesSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (listViewVariables.SelectedItems.Count == 0) return;
                _selectedVariable = _esCopy.Variables.Single(x =>
                                                             x.Name ==
                                                             listViewVariables.SelectedItems[0].SubItems[0].Text &&
                                                             x.Domains.Name ==
                                                             listViewVariables.SelectedItems[0].SubItems[1].Text &&
                                                             x.VarTypes.Name ==
                                                             listViewVariables.SelectedItems[0].SubItems[2].Text &&
                                                             x.Question ==
                                                             listViewVariables.SelectedItems[0].SubItems[3].Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Применить/Отменить/Выйти

        /// <summary>
        /// Применить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonApplyClick(object sender, EventArgs e)
        {
            if (!_somethingChanged) return;
            File.Copy(_dbCopyFullName, _dbFullName, true);
            _es = new Db(_esCopy.Connection.DataSource);
            Text = Text.Substring(0, Text.Length - 1);
            _somethingChanged = false;
        }

        /// <summary>
        /// Отменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if (!_somethingChanged) return;
            File.Copy(_dbFullName, _dbCopyFullName, true);
            _esCopy = new Db(_es.Connection.DataSource);
            FillListViewVariables();
            Text = Text.Substring(0, Text.Length - 1);
            _somethingChanged = false;
        }

        /// <summary>
        /// Закрыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void VariableEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            var res = DialogResult.None;
            if (_somethingChanged)
            {
                res = MessageBox.Show("Сохранить изменения?", "Редактор переменных", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                    ButtonApplyClick(sender, e);
            }
            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            if (File.Exists(_dbCopyFullName))
                File.Delete(_dbCopyFullName);
        }

        #endregion

        #region Добавление
        private void ButtonAddClick(object sender, EventArgs e)
        {
            //1. Открывается форма добавления
            var f = new AddChangeVariable(_esCopy, _filePath, _dbCopyFileName, "Добавление переменной", true) 
            { VarName = "", VarType = new VarTypes { Id = 1 }, Question = "" };
            f.EventAddAgain += FOnEventAddAgain;
            f.ShowDialog();
            f.EventAddAgain -= FOnEventAddAgain;
        }

        private void FOnEventAddAgain(string name, Domains domains, VarTypes varTypes, string question)
        {
            //2. Если ОК, то выполняется проверка на совпадение
            var same = _esCopy.Variables.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => x);
            if (same.Any())
            {
                MessageBox.Show("Переменная с таким именем уже существует.");
                return;
            }
            //3. Если Не совпадает, то новая переменная добавляется  в копию БД
            var variable = new Variables { Name = name, Domains = domains, VarTypes = varTypes, Question = question };
            _esCopy.Variables.InsertOnSubmit(variable);
            _esCopy.SubmitChanges();
            FillListViewVariables();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        #endregion

        #region Изменение
        private void ButtonChangeClick(object sender, EventArgs e)
        {
            //1. Открывается форма изменения
            if (_selectedVariable == null) return;
            var f = new AddChangeVariable(_esCopy, _filePath, _dbCopyFileName, "Изменение переменной", false)
                        {
                            VarName = _selectedVariable.Name,
                            VarDomain = _selectedVariable.Domains,
                            VarType = _selectedVariable.VarTypes,
                            Question = _selectedVariable.Question
                        };
            if (f.ShowDialog() != DialogResult.OK) return;
            //2. Если ОК, то выполняется проверка на совпадение
            var same = _esCopy.Variables.Where(x => x.Name.ToLower() == f.VarName.ToLower() &&
                x.Domains == f.VarDomain && x.VarTypes == f.VarType && x.Question == f.Question).Select(x => x);
            if (same.Any())
            {
                MessageBox.Show(string.Format("Переменная с таким именем уже существует."));
                return;
            }
            //3. Если переменная используется в правилах, то нельзя менять ее домен
            var error = VariableIsInRule(_selectedVariable);
            if (error != string.Empty && _selectedVariable.Domains != f.VarDomain)
            {
                MessageBox.Show(error, string.Format("Нельзя изменить домен переменной"), 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //4. Если переменная используется в заключении правил, то нельзя менять ее тип на запрашиваемый
            error = VariablesInConclusion(_selectedVariable);
            if (error != string.Empty && f.VarType.Name == "Запрашиваемая")
            {
                MessageBox.Show(error, string.Format("Нельзя изменить тип переменной на запрашиваемый"),
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //5. Если все ок, то новая переменная добавляется в копию БД
            _selectedVariable.Name = f.VarName;
            _selectedVariable.Domains = f.VarDomain;
            _selectedVariable.VarTypes = f.VarType;
            _selectedVariable.Question = f.Question;
            _esCopy.SubmitChanges();
            FillListViewVariables();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        } 
        #endregion

        #region Удаление
        private void ButtonDelClick(object sender, EventArgs e)
        {
            if (_selectedVariable == null) return;
            //нельзя удалить переменную, если она используется в правилах
            //проверяем это
            var error = VariableIsInRule(_selectedVariable);
            if (error != string.Empty)
            {
                MessageBox.Show(error, string.Format("Нельзя удалить переменную"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (MessageBox.Show(string.Format("Вы действительно хотите удалить переменную {0}? ", _selectedVariable.Name), 
                                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes)
            {
                return;
            }
            //удаляем переменную
            _esCopy.Variables.DeleteOnSubmit(_selectedVariable);
            _esCopy.SubmitChanges();
            FillListViewVariables();
            _selectedVariable = null;
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        } 
        #endregion

        #region Проверка использования переменной в правилах
        string VariableIsInRule(Variables varToCheck)
        {
            var s = string.Empty;
            var badRuleFact = _esCopy.Facts.Where(x => x.VariableID == varToCheck.Id).ToList();
            var badRuleConclusion = _esCopy.Conclusions.Where(x => x.VariableID == varToCheck.Id).ToList();
            if (badRuleFact.Any() || badRuleConclusion.Any())
            {
                //печаль, значение используется
                s = string.Format("Переменная используется ");
                string tmp;
                if (badRuleFact.Any())
                {
                    tmp = string.Empty;
                    tmp = string.Format("\nв посылке правил: {0}",
                                      (from v in _esCopy.Variables
                                       join f in _esCopy.Facts on v.Id equals f.VariableID
                                       join r in _esCopy.Rules on f.RuleID equals r.Id
                                       where v.Id == varToCheck.Id
                                       select r.Name).ToList().Aggregate(tmp, (current, x) => current + "\n" + x));
                    s += tmp;
                }
                if (badRuleConclusion.Any())
                {
                    tmp = string.Empty;
                    tmp = string.Format("\nв заключении правил: {0}",
                                      (from v in _esCopy.Variables
                                       join c in _esCopy.Conclusions on v.Id equals c.VariableID
                                       join r in _esCopy.Rules on c.RuleID equals r.Id
                                       where v.Id == varToCheck.Id
                                       select r.Name).ToList().Aggregate(tmp, (current, x) => current + "\n" + x));
                    s += tmp;
                }
            }
            return s;
        }

        string VariablesInConclusion(Variables varToCheck)
        {
            var s = string.Empty;
            var badRuleConclusion = _esCopy.Conclusions.Where(x => x.VariableID == varToCheck.Id).ToList();
            if (badRuleConclusion.Any())
            {
                s = string.Format("Переменная используется");
                var tmp = string.Empty;
                tmp = string.Format("\nв заключении правил: {0}",
                                    (from v in _esCopy.Variables
                                     join c in _esCopy.Conclusions on v.Id equals c.VariableID
                                     join r in _esCopy.Rules on c.RuleID equals r.Id
                                     where v.Id == varToCheck.Id
                                     select r.Name).ToList().Aggregate(tmp, (current, x) => current + "\n" + x));
                s += tmp;
            }
            return s;
        }
        #endregion
    }
}
