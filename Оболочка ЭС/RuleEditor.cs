using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class RuleEditor : Form
    {
        #region Переменные
        private Db _es, _esCopy;
        private readonly string _dbFullName;
        private readonly string _dbFileName;
        private readonly string _dbCopyFullName;
        private readonly string _filePath;
        private readonly string _dbCopyFileName;
        private bool _somethingChanged;
        private Rules _selectedRule;
        #endregion

        #region Инициализация
        public RuleEditor(Db es, string filePath, string fileName)
        {
            InitializeComponent();
            //создание БД и ее копии
            _es = es;
            _dbFullName = es.Connection.DataSource;
            _dbFileName = fileName;
            _dbCopyFullName = filePath + "\\~" + fileName + ".sdf";
            File.Copy(_dbFullName, _dbCopyFullName, true);
            _esCopy = new Db(filePath + "\\~" + fileName + ".sdf");
            _filePath = filePath;
            _dbCopyFileName = "~" + fileName;
            FillListViewRules();
        }

        private void AddRuleToListView(Rules r, int index)
        {
            var listOfFacts = (from f in _esCopy.Facts
                               join var in _esCopy.Variables on f.VariableID equals var.Id
                               join val in _esCopy.Values on f.ValueID equals val.Id
                               join rule in _esCopy.Rules on f.RuleID equals rule.Id
                               where rule.Name == r.Name
                               select new { value = val.Name, variable = var.Name }).ToList();
            var listOfConclusions = (from c in _esCopy.Conclusions
                                     join var in _esCopy.Variables on c.VariableID equals var.Id
                                     join val in _esCopy.Values on c.ValueID equals val.Id
                                     join rule in _esCopy.Rules on c.RuleID equals rule.Id
                                     where rule.Name == r.Name
                                     select new { value = val.Name, variable = var.Name }).ToList();
            if (listOfFacts.Count == 0 || listOfConclusions.Count == 0) return;
            var s = string.Format("Если {0} = {1} ", listOfFacts[0].variable, listOfFacts[0].value);
            for (var i = 1; i < listOfFacts.Count; i++)
            {
                s += string.Format("И {0} = {1} ", listOfFacts[i].variable, listOfFacts[i].value);
            }
            s += string.Format("То {0} = {1} ", listOfConclusions[0].variable, listOfConclusions[0].value);
            for (var i = 1; i < listOfConclusions.Count; i++)
            {
                s += string.Format("И {0} = {1} ", listOfConclusions[i].variable, listOfConclusions[i].value);
            }
            listViewRules.Items.Insert(index, new ListViewItem(new[] { r.Number.ToString(), r.Name, s }));
        }

        private void DelRuleFromListView(Rules r)
        {
            ListViewItem itemINeed = listViewRules.Items.Cast<ListViewItem>().Single(x => x.SubItems[1].Text == r.Name);
            listViewRules.Items.Remove(itemINeed);
        }

        /// <summary>
        /// Заполнение listView текстами правил
        /// </summary>
        private void FillListViewRules()
        {
            listViewRules.Items.Clear();
            foreach (var r in _esCopy.Rules.OrderBy(x => x.Number))
            {
                if (r.Number != null) AddRuleToListView(r, (int)r.Number - 1);
            }
        } 

        private void ListViewRulesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRules.SelectedItems.Count == 0) return;
            _selectedRule = _esCopy.Rules.SingleOrDefault(x => x.Name == listViewRules.SelectedItems[0].SubItems[1].Text);
        }
        #endregion

        #region Применить/Отменить/Закрыть
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
            FillListViewRules();
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

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RuleEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            var res = DialogResult.None;
            if (_somethingChanged)
            {
                res = MessageBox.Show("Сохранить изменения?", "Редактор правил", MessageBoxButtons.YesNoCancel);
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
        /// <summary>
        /// Добавление нового правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddClick(object sender, EventArgs e)
        {
            //Открывается форма добавления
            var f = new AddChangeRule(_esCopy, _filePath, _dbCopyFileName, "Добавление правила",
                                      new List<AddChangeRule.Fact>(), new List<AddChangeRule.Fact>(), string.Empty,
                                      string.Empty);
            if (f.ShowDialog() != DialogResult.OK) return;
            var same = _esCopy.Rules.Where(x => x.Name.ToLower() == f.RuleName.ToLower());
            if (same.Any())
            {
                MessageBox.Show("Правило с таким именем уже существует");
                return;
            }
            //Если все ок, то добавляем правило в копию БД
            //добавляем в rules
            var r = new Rules
            {
                Name = f.RuleName,
                Explain = f.Explanation,
                Number = listViewRules.Items.Count + 1
            };
            _esCopy.Rules.InsertOnSubmit(r);
            _esCopy.SubmitChanges();
            var ruleID = r.Id;
            //добавляем посылки
            AddFacts(f.InFact, ruleID);
            //добавляем заключения
            AddConclusions(f.InConclusion, ruleID);
            //заполнение listViewRules
            //FillListViewRules();
            if (_selectedRule != null && _selectedRule.Number != null)
                AddRuleToListView(r, (int)_selectedRule.Number);
            else AddRuleToListView(r, listViewRules.Items.Count);
            RenumberRules();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        } 
        #endregion

        #region Изменение
        /// <summary>
        /// Изменение выбранного правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeClick(object sender, EventArgs e)
        {
            if (_selectedRule == null) return;
            //удаляем запись об этом правиле из листвью
            int index = 0;
            if (_selectedRule.Number != null)
            {
                index = (int)_selectedRule.Number;
            }
            var oldRule = new Rules
                              {
                                  Name = _selectedRule.Name,
                                  Id = _selectedRule.Id,
                                  Number = _selectedRule.Number,
                                  Explain = _selectedRule.Explain
                              };
            //DelRuleFromListView(_selectedRule);
            //список посылок правила
            var factList = _esCopy.Facts.Where(x => x.RuleID == _selectedRule.Id).
                Select(ff => new AddChangeRule.Fact
                                 {
                                     ValName = ff.Values.Name,
                                     VarName = ff.Variables.Name,
                                     Num = ff.Number
                                 }).ToList();
            //список заключений правила
            var concList = _esCopy.Conclusions.Where(x => x.RuleID == _selectedRule.Id).
                Select(cc => new AddChangeRule.Fact
                                 {
                                     ValName = cc.Values.Name,
                                     VarName = cc.Variables.Name,
                                     Num = cc.Number
                                 }).ToList();
            //открываем форму изменения
            var f = new AddChangeRule(_esCopy, _filePath, _dbCopyFileName, "Изменение правила",
                                      factList, concList, _selectedRule.Name, _selectedRule.Explain);

            if (f.ShowDialog() != DialogResult.OK) return;
            //Если все ок, то добавляем правило в копию БД
            //добавляем в rules
            _selectedRule.Name = f.RuleName;
            _selectedRule.Explain = f.Explanation;
            //добавляем посылки
            var factsInSelectedRule = _esCopy.Facts.Where(x => x.Rules == _selectedRule);
            foreach (Facts facts in factsInSelectedRule)
            {
                _esCopy.Facts.DeleteOnSubmit(facts);
                _esCopy.SubmitChanges();
            }
            AddFacts(f.InFact, _selectedRule.Id);
            //добавляем заключения
            var conclusionsInSelectedRule = _esCopy.Conclusions.Where(x => x.Rules == _selectedRule);
            foreach(var conc in conclusionsInSelectedRule)
            {
                _esCopy.Conclusions.DeleteOnSubmit(conc);
                _esCopy.SubmitChanges();
            }
            AddConclusions(f.InConclusion, _selectedRule.Id);
            //заполнение listViewRules
            //FillListViewRules();
            DelRuleFromListView(oldRule);
            AddRuleToListView(_selectedRule, index - 1);
            RenumberRules();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        } 
        #endregion

        #region Удаление
        /// <summary>
        /// Удаление выбраного правила
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelClick(object sender, EventArgs e)
        {
            if (_selectedRule == null) return;
            if (MessageBox.Show(string.Format("Вы действительно хотите удалить правило {0}? ", _selectedRule.Name),
                                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes) return;

            //сначала удаляем все факты
            foreach (var ff in _esCopy.Facts.Where(x => x.RuleID == _selectedRule.Id))
            {
                _esCopy.Facts.DeleteOnSubmit(ff);
            }
            //удаляем все заключения
            foreach(var cc in _esCopy.Conclusions.Where(x => x.RuleID == _selectedRule.Id))
            {
                _esCopy.Conclusions.DeleteOnSubmit(cc);
            }
            _esCopy.SubmitChanges();
            //удаляем само правило
            _esCopy.Rules.DeleteOnSubmit(_selectedRule);
            _esCopy.SubmitChanges();
            //отображаем изменения
            //listViewRules.Items.RemoveAt((int)_selectedRule.Number - 1);
            DelRuleFromListView(_selectedRule);
            //перенумеровываем все правила
            RenumberRules();
            _selectedRule = null;
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        } 
        #endregion

        #region Drag&Drop

        private void ListViewRulesMouseDown(object sender, MouseEventArgs e)
        {
            listViewRules.DoDragDrop(listViewRules.SelectedItems, DragDropEffects.Move);
        }

        private void ListViewRulesDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListViewRulesDragDrop(object sender, DragEventArgs e)
        {
            if (listViewRules.SelectedItems.Count == 0) return;
            Point cp = listViewRules.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = listViewRules.GetItemAt(cp.X, cp.Y); //куда
            if (dragToItem == null) return;
            if (dragToItem.Index == -1) return;
            var sel = listViewRules.SelectedItems[0]; //откуда
            if (sel == dragToItem) return;
            listViewRules.Items.Remove(sel);
            listViewRules.Items.Insert(dragToItem.Index, sel);
            RenumberRules();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        #endregion

        #region Дополнительно

        /// <summary>
        /// Перенумеровывание правил после удаления или перетаскивания
        /// </summary>
        private void RenumberRules()
        {
            foreach (ListViewItem lvi in listViewRules.Items)
            {
                _esCopy.Rules.Single(x => x.Name == lvi.SubItems[1].Text).Number = lvi.Index + 1;
            }
            _esCopy.SubmitChanges();
        }

        /// <summary>
        /// Добавление фактов в таблицу фактов
        /// </summary>
        /// <param name="facts">Спискок фактов, которые надо добавить</param>
        /// <param name="ruleID">Номер правила, которому принадлежат эти факты</param>
        private void AddFacts(IEnumerable<AddChangeRule.Fact> facts, int ruleID )
        {
            foreach (var fact in 
                facts.Select(vif => new Facts
                    {
                        VariableID = _esCopy.Variables.Single(x => x.Name == vif.VarName).Id,
                        ValueID = _esCopy.Values.Single(x => x.Name == vif.ValName
                                                            && x.DomainID == _esCopy.Variables.
                                                            Single(v => v.Name == vif.VarName).DomainID).Id,
                        RuleID = ruleID,
                        Number = vif.Num
                    }))
            {
                _esCopy.Facts.InsertOnSubmit(fact);
                _esCopy.SubmitChanges();
            }
        }

        /// <summary>
        /// Добавление заключений в таблицу заключений
        /// </summary>
        /// <param name="conclusions">Список заключений, которые надо добавить</param>
        /// <param name="ruleID">Номер правила, которому принадлежат эти заключения</param>
        private void AddConclusions(IEnumerable<AddChangeRule.Fact> conclusions, int ruleID )
        {
            foreach (AddChangeRule.Fact vic in conclusions)
            {
                var varID = _esCopy.Variables.Single(x => x.Name == vic.VarName);
                var valID = _esCopy.Values.Single(x => x.Name == vic.ValName && x.Domains == varID.Domains);
                var conc = new Conclusions
                               {
                                   VariableID = varID.Id, 
                                   ValueID = valID.Id, 
                                   RuleID = ruleID, 
                                   Number = vic.Num
                               };
                _esCopy.Conclusions.InsertOnSubmit(conc);
                _esCopy.SubmitChanges();
            }
        }

        #endregion
    
    }
}
