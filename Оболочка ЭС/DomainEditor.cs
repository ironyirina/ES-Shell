using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class DomainEditor : Form
    {
        #region Переменные
        private Db _es, _esCopy;
        private readonly string _dbFullName;
        private readonly string _dbCopyFullName;
        private bool _somethingChanged;
        private Domains _selectedDomain;
        private Values _selectedValue; 
        #endregion

        #region Инициализация

        public DomainEditor(Db es, string filePath, string fileName)
        {
            InitializeComponent();
            //создание БД и ее копии
            _es = es;
            _dbFullName = es.Connection.DataSource;
            _dbCopyFullName = filePath + "\\~" + fileName + ".sdf";
            File.Copy(_dbFullName, _dbCopyFullName, true);
            _esCopy = new Db(filePath + "\\~" + fileName + ".sdf");
            listBoxDomains.DataSource = _esCopy.Domains.Select(x => x.Name);
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
            listBoxDomains.DataSource = _esCopy.Domains.Select(x => x.Name);
            if (_selectedDomain != null)
                listBoxValues.DataSource =
                    _esCopy.Values.Where(x => x.DomainID == _selectedDomain.Id).Select(x => x.Name);
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

        private void DomainEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            var res = DialogResult.None;
            if (_somethingChanged)
            {
                res = MessageBox.Show("Сохранить изменения?", "Редактор доменов", MessageBoxButtons.YesNoCancel);
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

        #region Работа с доменами

        /// <summary>
        /// Добавление домена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDomainClick(object sender, EventArgs e)
        {
            //1. Открывается форма добавления
            var f = new AddChangeItem("Добавление домена", "Имя домена:", "", true);
            f.EventAddAgain += EventHandlerDomains;
            f.ShowDialog();
            f.EventAddAgain -= EventHandlerDomains;

        }
        
        /// <summary>
        /// Изменение домена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeDomainClick(object sender, EventArgs e)
        {
            //1. Открывается форма изменения
            if (_selectedDomain == null) return;
            var f = new AddChangeItem("Изменение домена", "Имя домена:", _selectedDomain.Name, false);
            if (f.ShowDialog() != DialogResult.OK) return;
            //2. Если ОК, то выполняется проверка на совпадение
            var same = _esCopy.Domains.Where(x => x.Name.ToLower() == f.ItemName.ToLower()).Select(x => x);
            if (same.Any())
            {
                MessageBox.Show("Домен с таким именем уже существует.");
                return;
            }
            //3. Если Не совпадает, то новый домен добавляется в копию БД
            _selectedDomain.Name = f.ItemName;
            _esCopy.SubmitChanges();
            listBoxDomains.DataSource = _esCopy.Domains.Select(x => x.Name);
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        /// <summary>
        /// Удаление домена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteDomainClick(object sender, EventArgs e)
        {
            if (_selectedDomain == null) return;
            //Запрещаем удаление, если существует переменная, использующая этот домен
            //Проверяем, существует ли переменная, использующая этот домен
            var badVariable = _esCopy.Variables.Where(x => x.DomainID == _selectedDomain.Id).ToList();
            if (badVariable.Any())
            {
                var s = string.Empty;
                //Переменная существует
                MessageBox.Show(String.Format("Нельзя удалить домен, так как он используется в переменных: {0}",
                                              badVariable.Aggregate(s, (current, o) => current + "\n" + o.Name)),
                                string.Format("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить домен {0}? ", _selectedDomain.Name),
                                    string.Format("Подтверждение удаления"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes)
                {
                    return;
                }
                //удаляем домен
                _esCopy.Domains.DeleteOnSubmit(_selectedDomain);
                _esCopy.SubmitChanges();
                listBoxDomains.DataSource = _esCopy.Domains.Select(x => x.Name);
                _selectedDomain = null;
                if (!_somethingChanged) Text += "*";
                _somethingChanged = true;
            }
        }

        private void ListBoxDomainsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDomains.SelectedItem == null) return;
            //Выводим значения
            _selectedDomain = _esCopy.Domains.Single(x => x.Name == listBoxDomains.SelectedItem.ToString());
            //listBoxValues.DataSource = _esCopy.Values.Where(x => x.DomainID == _selectedDomain.Id).Select(x => x.Name);
            FillListBoxValues();
        }

        private void EventHandlerDomains(string s)
        {
            //2. Если ОК, то выполняется проверка на совпадение
            var same = _esCopy.Domains.Where(x => x.Name.ToLower() == s.ToLower()).Select(x => x);
            if (same.Any())
            {
                MessageBox.Show("Домен с таким именем уже существует.");
                return;
            }
            //3. Если Не совпадает, то новый домен добавляется  в копию БД
            var domain = new Domains { Name = s };
            _esCopy.Domains.InsertOnSubmit(domain);
            _esCopy.SubmitChanges();
            listBoxDomains.DataSource = _esCopy.Domains.Select(x => x.Name);
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        #endregion

        #region Работа со значениями

        private void FillListBoxValues()
        {
            if (_selectedDomain == null)
                return;
            listBoxValues.Items.Clear();
            var valuesINeed =
                _esCopy.Values.Where(x => x.Domains == _selectedDomain).OrderBy(x => x.Number).Select(x => x.Name);
            //listBoxValues.Items.AddRange( valuesINeed.ToArray());
            foreach (var v in valuesINeed)
            {
                listBoxValues.Items.Add(v);
            }
            //перенумеровываем значения
            RenumberValues();
        }

        private void RenumberValues()
        {
            foreach (var s in listBoxValues.Items)
            {
                _esCopy.Values.Single(x => x.Name == s.ToString() && x.Domains == _selectedDomain).Number =
                        listBoxValues.Items.IndexOf(s);
            }
            _esCopy.SubmitChanges();
        }

        private void ListBoxValuesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedDomain == null || listBoxValues.SelectedItem == null) return;
            _selectedValue = _esCopy.Values.Single(x => x.Name == listBoxValues.SelectedItem.ToString()
                && x.DomainID == _selectedDomain.Id);
        }

        /// <summary>
        /// Добавление значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddValueClick(object sender, EventArgs e)
        {
            //1. Открывается форма добавления
            if (_selectedDomain == null) return;
            var f = new AddChangeItem("Добавление значения",
                                      string.Format("Домен: {0}. Значение:", _selectedDomain.Name),
                                      "", true);
            f.EventAddAgain += EventHandlerValues;
            f.ShowDialog();
            f.EventAddAgain -= EventHandlerValues;
        }

        private void ButtonChangeValueClick(object sender, EventArgs e)
        {
            //1. Открывается форма изменения
            if (_selectedValue == null) return;
            var f = new AddChangeItem("Изменение значения", string.Format("Имя домена: {0}. Значение:", _selectedDomain.Name),
                _selectedValue.Name, false);
            if (f.ShowDialog() != DialogResult.OK) return;
            //2. Если ОК, то выполняется проверка на совпадение
            var same = _esCopy.Values.Where(x => x.Name.ToLower() == f.ItemName.ToLower()
                && x.DomainID == _selectedDomain.Id).Select(x => x);
            if (same.Any())
            {
                MessageBox.Show("Такое значение уже существует.");
                return;
            }
            //предупреждаем пользователя о том, что изменения произойдут каскадно
            if (MessageBox.Show(@"При изменении значений домена изменения произойдут во всех переменных, использующих
                    этот домен", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) !=
                DialogResult.OK) return;
            //3. Если Не совпадает, то новое значение добавляется в копию БД
            _selectedValue.Name = f.ItemName;
            _esCopy.SubmitChanges();
            //listBoxValues.DataSource = _esCopy.Values.Where(x => x.DomainID == _selectedDomain.Id).Select(x => x.Name);
            FillListBoxValues();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        private void EventHandlerValues(string s)
        {
            var same = _esCopy.Values.Where(x => x.DomainID == _selectedDomain.Id &&
                                                            x.Name.ToLower() == s.ToLower()).Select(x => x);
            if (same.Any())
            {
                MessageBox.Show("Такое значение уже существует.");
                return;
            }
            //3. Если Не совпадает, то новое значение добавляется  в копию БД
            var value = new Values { Name = s, DomainID = _selectedDomain.Id };
            _esCopy.Values.InsertOnSubmit(value);

            _esCopy.SubmitChanges();
            //listBoxValues.DataSource = _esCopy.Values.Where(x => x.DomainID == _selectedDomain.Id).Select(x => x.Name);
            FillListBoxValues();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        private void ButtonDeleteValueClick(object sender, EventArgs e)
        {
            if (_selectedDomain == null || _selectedValue == null) return;
            //нельзя удалить значение, если оно используется в посылке или заключении правил
            //проверяем это
            var badRuleFact = _esCopy.Facts.Where(x => x.ValueID == _selectedValue.Id).ToList();
            var badRuleConclusion = _esCopy.Conclusions.Where(x => x.ValueID == _selectedValue.Id).ToList();
            if (badRuleFact.Any() || badRuleConclusion.Any())
            {
                //печаль, значение используется
                var s = string.Format("Нельзя удалить значение, так как оно используется ");
                string tmp;
                if (badRuleFact.Any())
                {
                    tmp = string.Empty;
                    tmp = string.Format("\nв посылке правил: {0}",
                                       (from v in _esCopy.Values
                                        join f in _esCopy.Facts on v.Id equals f.ValueID
                                        join r in _esCopy.Rules on f.RuleID equals r.Id
                                        where v.Id == _selectedValue.Id
                                        select r.Name).ToList().Aggregate(tmp, (current, x) => current + "\n" + x));
                    s += tmp;
                }
                if (badRuleConclusion.Any())
                {
                    tmp = string.Empty;
                    tmp = string.Format("\nв заключении правил: {0}",
                                       (from v in _esCopy.Values
                                        join c in _esCopy.Conclusions on v.Id equals c.ValueID
                                        join r in _esCopy.Rules on c.RuleID equals r.Id
                                        where v.Id == _selectedValue.Id
                                        select r.Name).ToList().Aggregate(tmp, (current, x) => current + "\n" + x));
                    s += tmp;
                }
                MessageBox.Show(s, string.Format("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //предупреждаем пользователя о том, что изменения произойдут каскадно
                if (MessageBox.Show(@"При удалении значений домена изменения произойдут во всех переменных, использующих
                    этот домен", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) !=
                    DialogResult.OK) return;
                //удаляем значение
                _esCopy.Values.DeleteOnSubmit(_selectedValue);
                _esCopy.SubmitChanges();
                listBoxDomains.DataSource = _esCopy.Domains.Select(x => x.Name);
                //listBoxValues.DataSource = _esCopy.Values.Where(x => x.DomainID == _selectedDomain.Id).Select(x => x.Name);
                FillListBoxValues();
                _selectedDomain = null;
                if (!_somethingChanged) Text += "*";
                _somethingChanged = true;
            }
        }
        #endregion

        #region Drag&Drop в значениях

        private void ListBoxValuesDragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListBoxValuesMouseDown(object sender, MouseEventArgs e)
        {
            ListBoxValuesSelectedIndexChanged(sender, e);
            int indexOfItem = listBoxValues.IndexFromPoint(e.X, e.Y);
            if (indexOfItem >= 0 && indexOfItem < listBoxValues.Items.Count)  // check we clicked down on a string
            {
                // Set allowed DragDropEffect to Copy selected 
                // from DragDropEffects enumberation of None, Move, All etc.
                listBoxValues.DoDragDrop(listBoxValues.Items[indexOfItem], DragDropEffects.Move);
            }

        }

        private void ListBoxValuesDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListBoxValuesDragOver(object sender, DragEventArgs e)
        {
            if (listBoxValues.SelectedItems.Count == 0) return;
            Point cp = listBoxValues.PointToClient(new Point(e.X, e.Y));
            int toIndex = listBoxValues.IndexFromPoint(cp); //куда
            if (toIndex == -1) return;
            var fromIndex = listBoxValues.SelectedIndex; //откуда
            if (fromIndex == toIndex) return;
            var sel = listBoxValues.Items[fromIndex];
            listBoxValues.Items.RemoveAt(fromIndex);
            listBoxValues.Items.Insert(toIndex, sel);
            RenumberValues();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        #endregion


    }
}
