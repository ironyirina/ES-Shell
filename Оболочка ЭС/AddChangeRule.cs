using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class AddChangeRule : Form
    {

        #region Переменные
        public struct Fact
        {
            public int? Num;
            public string VarName;
            public string ValName;
        }
        private readonly Db _es;
        private readonly string _dbFullName;
        private readonly string _dbFileName;
        private readonly string _filePath;

        private Fact _selectedFact;
        private Fact _selectedConclusion;
        #endregion

        #region Свойства
        /// <summary>
        /// Имя правила
        /// </summary>
        public string RuleName
        {
            get { return textBoxRuleName.Text.Trim(); }
            set { textBoxRuleName.Text = value; }
        }

        /// <summary>
        /// Список вида "имя переменной - значение" в посылке правила
        /// </summary>
        public List<Fact> InFact { get; set; }

        /// <summary>
        /// Список вида "имя переменной - значение" в заключении правила
        /// </summary>
        public List<Fact> InConclusion { get; set; }

        public string Explanation
        {
            get { return richTextBoxExplanation.Text; }
            set { richTextBoxExplanation.Text = value; }
        }
        #endregion

        #region Инициализация
        public AddChangeRule(Db es, string filePath, string fileName, string caption, List<Fact> inFact,
            List<Fact> inConclusion, string ruleName, string explanation)
        {
            InitializeComponent();
            _es = es;
            _dbFullName = es.Connection.DataSource;
            _dbFileName = fileName;
            _filePath = filePath;
            Text = caption;
            InFact = inFact;
            InConclusion = inConclusion;
            RuleName = ruleName;
            Explanation = explanation;
            InFact = inFact;
            InConclusion = inConclusion;
            FillListViewFacts();
            FillListViewConclusions();
        } 
        #endregion

        #region Работа с посылками
        /// <summary>
        /// Добавление посылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddFactClick(object sender, EventArgs e)
        {
            //открывается форма добавления
            var f = new AddChangeFact(_es, _filePath, _dbFileName, "Добавление посылки", true, true);
            f.EventAddAgain += FEventAddFact;
            f.ShowDialog();
            f.EventAddAgain -= FEventAddFact;
        }

        void FEventAddFact(Variables var, Values val)
        {
            //Если ОК, то выполняется проверка на совпадение
            var same = InFact.Where(x => x.VarName == var.Name && x.ValName == val.Name);
            if (same.Any())
            {
                MessageBox.Show("Такая посылка уже есть в этом правиле");
                return;
            }
            //Если не совпадает, то новая посылка добавляется в список
            try
            {
                InFact.Add(new Fact { VarName = var.Name, ValName = val.Name, Num = InFact.Count + 1 });
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            FillListViewFacts();
        }


        /// <summary>
        /// Изменение посылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeFactClick(object sender, EventArgs e)
        {
            if (_selectedFact.ValName == null && _selectedFact.VarName == null) return;
            //открывается форма добавления
            var f = new AddChangeFact(_es, _filePath, _dbFileName, "Изменение посылки", false, true)
                        {
                            Var = _es.Variables.Single(x => x.Name == _selectedFact.VarName),
                            Val = _es.Values.Single(x => x.Name == _selectedFact.ValName
                                && x.DomainID == _es.Variables.Single(v => v.Name == _selectedFact.VarName).DomainID)
                        };
            if (f.ShowDialog() != DialogResult.OK) return;
            //2. Если ОК, то выполняется проверка на совпадение
            var same = InFact.Where(x => x.VarName == f.Var.Name && x.ValName == f.Val.Name);
            if (same.Any())
            {
                MessageBox.Show("Такая посылка уже есть в этом правиле");
                return;
            }
            //3. Если не совпадает, то новая посылка добавляется в список
            InFact.Remove(_selectedFact);
            try
            {
                _selectedFact.VarName = f.Var.Name;
                _selectedFact.ValName = f.Val.Name;
                _selectedFact.Num = InFact.Count + 1;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            InFact.Add(_selectedFact);
            FillListViewFacts();
        }

        /// <summary>
        /// Удаление посылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelFactClick(object sender, EventArgs e)
        {
            if (_selectedFact.ValName == null && _selectedFact.VarName == null) return;
            //вроде незачем спрашивать у пользователя подтверждение удаления посылки
            InFact.Remove(_selectedFact);
            FillListViewFacts();
        }

        /// <summary>
        /// Выбор посылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewFactsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFacts.SelectedItems.Count == 0) return;
            _selectedFact = new Fact
            {
                VarName = listViewFacts.SelectedItems[0].SubItems[1].Text,
                ValName = listViewFacts.SelectedItems[0].SubItems[3].Text,
                Num = Int32.Parse(listViewFacts.SelectedItems[0].SubItems[0].Text)
            };
        }

        /// <summary>
        /// Заполнение listViewFacts + сортировка по Number
        /// </summary>
        private void FillListViewFacts()
        {
            listViewFacts.Items.Clear();
            foreach (var varF in InFact.OrderBy(x => x.Num))
            {
                listViewFacts.Items.Add(new ListViewItem(new[] {varF.Num.ToString(), varF.VarName, "=", varF.ValName}));
            }
        }

        #endregion

        #region Работа с заключениями
        private void ButtonAddConclusionClick(object sender, EventArgs e)
        {
            //открывается форма добавления
            var f = new AddChangeFact(_es, _filePath, _dbFileName, "Добавление заключения", true, false);
            f.EventAddAgain += FOnEventAddConclusion;
            f.ShowDialog();
            f.EventAddAgain -= FOnEventAddConclusion;
        }

        private void FOnEventAddConclusion(Variables var, Values val)
        {
            //Если ОК, то выполняется проверка на совпадение
            var same = InConclusion.Where(x => x.VarName == var.Name && x.ValName == val.Name);
            if (same.Any())
            {
                MessageBox.Show("Такое заключение уже есть в этом правиле");
                return;
            }
            //Если не совпадает, то новая посылка добавляется в список
            try
            {
                InConclusion.Add(new Fact { VarName = var.Name, ValName = val.Name, Num = InConclusion.Count + 1 });
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            FillListViewConclusions();
        }

        private void ButtonChangeConclusionClick(object sender, EventArgs e)
        {
            if (_selectedConclusion.ValName == null && _selectedConclusion.VarName == null) return;
            //открывается форма добавления
            var f = new AddChangeFact(_es, _filePath, _dbFileName, "Изменение заключения", false, false)
                        {
                            Var = _es.Variables.Single(x => x.Name == _selectedConclusion.VarName),
                            Val = _es.Values.Single(x => x.Name == _selectedConclusion.ValName),
                        };
            if (f.ShowDialog() != DialogResult.OK) return;
            //2. Если ОК, то выполняется проверка на совпадение
            var same = InConclusion.Where(x => x.VarName == f.Var.Name && x.ValName == f.Val.Name);
            if (same.Any())
            {
                MessageBox.Show("Такое заключение уже есть в этом правиле");
                return;
            }
            //3. Если не совпадает, то новая посылка добавляется в список
            InConclusion.Remove(_selectedConclusion);
            try
            {
                _selectedConclusion.VarName = f.Var.Name;
                _selectedConclusion.ValName = f.Val.Name;
                _selectedConclusion.Num = InConclusion.Count + 1;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            InConclusion.Add(_selectedConclusion);
            FillListViewConclusions();
        }


        private void ButtonDelConclusionClick(object sender, EventArgs e)
        {
            if (_selectedConclusion.ValName == null && _selectedConclusion.VarName == null) return;
            InConclusion.Remove(_selectedConclusion);
            FillListViewConclusions();
        }

        private void ListViewConclusionsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewConclusions.SelectedItems.Count == 0) return;
            _selectedConclusion = new Fact
            {
                VarName = listViewConclusions.SelectedItems[0].SubItems[1].Text,
                ValName = listViewConclusions.SelectedItems[0].SubItems[3].Text,
                Num = Int32.Parse(listViewConclusions.SelectedItems[0].SubItems[0].Text)
            };
        }

        private void FillListViewConclusions()
        {
            listViewConclusions.Items.Clear();
            foreach (var varC in InConclusion)
            {
                listViewConclusions.Items.Add(new ListViewItem(new[] { varC.Num.ToString(),
                    varC.VarName, "=", varC.ValName }));
            }
        }
        #endregion

        #region Закрытие
        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (InFact.Count == 0)
            {
                MessageBox.Show("Посылка должна содержать хотя бы один факт");
                return;
            }
            if (InConclusion.Count == 0)
            {
                MessageBox.Show("Заключение должно содержать хотя бы один факт");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        } 
        #endregion

        #region Drag&Drop в посылках

        private void ListViewFactsMouseDown(object sender, MouseEventArgs e)
        {
            listViewFacts.DoDragDrop(listViewFacts.SelectedItems, DragDropEffects.Move);
        }

        private void ListViewFactsDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListViewFactsDragDrop(object sender, DragEventArgs e)
        {
            if (listViewFacts.SelectedItems.Count == 0) return;
            Point cp = listViewFacts.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = listViewFacts.GetItemAt(cp.X, cp.Y); //куда
            if (dragToItem == null) return;
            int dragIndex = dragToItem.Index; //номер строки, куда
            var sel = new ListViewItem[listViewFacts.SelectedItems.Count]; //что
            for (int i = 0; i < listViewFacts.SelectedItems.Count; i++)
            {
                sel[i] = listViewFacts.SelectedItems[i];
            }
            foreach (ListViewItem lvi in sel)
            {
                if (dragIndex == lvi.Index) continue; //если ничего никуда не перетаскивается
                var v1 = InFact.Single(x => x.VarName == dragToItem.SubItems[1].Text &&
                                            x.ValName == dragToItem.SubItems[3].Text);
                InFact.Remove(v1);
                v1.Num = lvi.Index + 1;
                InFact.Add(v1);
                var v2 = InFact.Single(x => x.VarName == lvi.SubItems[1].Text &&
                                            x.ValName == lvi.SubItems[3].Text);
                InFact.Remove(v2);
                v2.Num = dragIndex + 1;
                InFact.Add(v2);
            }
            FillListViewFacts();
        }

        #endregion
    }
}
