using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InferentialMechanism;
using ExplanationComponent;

namespace Оболочка_ЭС
{
    public partial class FormMain : Form
    {
        #region Переменные

        /// <summary>
        /// база данных, содержащая домены, переменные, правила ЭС
        /// </summary>
        private Db _es;

        /// <summary>
        /// Копия БД, создается при создании бд, все изменения проводятся над копией
        /// </summary>
        private Db _esCopy;

        /// <summary>
        /// Имя файла БД
        /// </summary>
        private string _dbFileName;

        /// <summary>
        /// Путь к БД
        /// </summary>
        private string _dbPath;

        /// <summary>
        /// Путь по умолчанию
        /// </summary>
        private const string DBPathDefault = ".\\TmpDBs\\";

        private const string DefaultExtension = ".sdf";

        /// <summary>
        /// Имя файла с копией БД
        /// </summary>
        private string _dbCopyFileName;

        /// <summary>
        /// true, если копия бд отличается от бд
        /// </summary>
        private bool _somethingChanged;

        #endregion

        #region Инициализация
        public FormMain()
        {
            InitializeComponent();
            NormalizeStatusStrip();
        } 
        #endregion

        #region Красивый интерфейсик

        #region StatusStrip
        void NormalizeStatusStrip()
        {
            toolStripStatusLabel1.Text = "Готово";
            statusStrip1.BackColor = Color.LightGreen;
        }

        void ErrorStatusStrip(string errText)
        {
            toolStripStatusLabel1.Text = errText;
            statusStrip1.BackColor = Color.Red;
        }

        void ChangeStatusStrip(string text)
        {
            toolStripStatusLabel1.Text = text;
            statusStrip1.BackColor = Color.LightSkyBlue;
        }
        #endregion

        /// <summary>
        /// Заполнение полей с информацией о количестве доменов, переменных и правил
        /// </summary>
        void ChangeStatistics()
        {
            //количество доменов
            textBoxDomains.Text = _esCopy.Domains.Count().ToString();
            //количество переменных
            textBoxVariables.Text = _esCopy.Variables.Count().ToString();
            //количество правил
            textBoxRules.Text = _esCopy.Rules.Count().ToString();
        }

        void EnableAfterOpening(string esName)
        {
            Text += " - " + esName;
            groupBox1.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            domainsToolStripMenuItem.Enabled = true;
            variablesToolStripMenuItem.Enabled = true;
            rulesToolStripMenuItem.Enabled = true;
            startConsultationToolStripMenuItem.Enabled = true;
            textBoxName.Text = esName;
            ChangeStatistics();
        } 

        void DisableAfterClosing()
        {
            Text = "Оболочка ЭС";
            groupBox1.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            domainsToolStripMenuItem.Enabled = false;
            variablesToolStripMenuItem.Enabled = false;
            rulesToolStripMenuItem.Enabled = false;
            startConsultationToolStripMenuItem.Enabled = false;
            textBoxName.Text = string.Empty;
            textBoxDomains.Text = string.Empty;
            textBoxVariables.Text = string.Empty;
            textBoxRules.Text = string.Empty;
        }
        #endregion

        #region Меню ЭС

        #region Создать ЭС
        private void CreateToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeStatusStrip("Создание новой ЭС");
            //спросить у пользователя название ЭС
            var f = new FormNewES();
            if (f.ShowDialog() != DialogResult.OK)
            {
                NormalizeStatusStrip();
                return;
            }
            _dbFileName = f.FileName; //узнали имя новой бд
            _dbCopyFileName = string.Format("~{0}", _dbFileName); //имя копии
            _dbPath = DBPathDefault;
            //создаем файл с заданным именем в директории по умолчанию
            File.Copy("db.sdf", string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension), true); 
            //создаем бд
            _es = new Db(string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension));
            //создаем копию файла
            File.Copy("db.sdf", string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension), true);
            _esCopy = new Db(string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension));
            EnableAfterOpening(_dbFileName);
            _somethingChanged = true;
            Text += "*";
            NormalizeStatusStrip();
        }
        #endregion

        #region Открыть ЭС
        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeStatusStrip("Открытие БД");
            openFileDialog1.Filter = "Файлы Экспертных Систем|*.sdf";
            var res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
            {
                NormalizeStatusStrip();
                return;
            }
            _dbFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName); //имя бд
            _dbCopyFileName = string.Format("~{0}", _dbFileName); //имя копии
            _dbPath = string.Format("{0}\\", Path.GetDirectoryName(openFileDialog1.FileName)); //путь к файлу
            //копируем файлы и создаем бд
            File.Copy(string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension),
                      string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension), true);
            _es = new Db(string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension));
            _esCopy = new Db(string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension));

            EnableAfterOpening(_dbFileName); //имя файла без расширения
            NormalizeStatusStrip();
        }
        #endregion

        #region Закрыть ЭС
        private void CloseToolStripMenuItemClick(object sender, EventArgs e)
        {
            var res = DialogResult.None;
            if (_somethingChanged)
            {
                res = MessageBox.Show("Сохранить изменения?", "Оболочка ЭС", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                    SaveToolStripMenuItemClick(sender, e);
            }
            if (res == DialogResult.Cancel) return;
            //удаляем файл копии
            if (File.Exists(string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension)))
                File.Delete(string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension));
            DisableAfterClosing();
            _somethingChanged = false;
        }
        #endregion

        #region Сохранить
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!_somethingChanged) return;
            _somethingChanged = false;
            if (_dbPath == DBPathDefault) //эс еще ни разу не сохраняли
                SaveAsToolStripMenuItemClick(sender, e); //сохраняем Как
            else //заменяем бд копией бд
            {
                File.Copy(string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension), 
                    string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension), true);
                _es = new Db(_esCopy.Connection.DataSource);
                Text = Text.Substring(0, Text.Length - 1);
            }
        } 
        #endregion

        #region Сохранить как
        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = _dbFileName;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = DefaultExtension;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            //копируем файл копии бд из директории по умолчанию в выбранную директорию
            string dbOldPath = _dbPath, dbOldName = _dbFileName, dbOldCopyName = _dbCopyFileName;
            _dbPath = string.Format("{0}\\", Path.GetDirectoryName(saveFileDialog1.FileName));
            _dbFileName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);

            File.Copy(string.Format("{0}{1}{2}", dbOldPath, dbOldCopyName, DefaultExtension), 
                string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension), true);
            _es = new Db(string.Format("{0}{1}{2}", _dbPath, _dbFileName, DefaultExtension));
            //создаем еще одну копию
            _dbCopyFileName = string.Format("~{0}", _dbFileName);
            File.Copy(string.Format("{0}{1}{2}", dbOldPath, dbOldCopyName, DefaultExtension),
                string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension), true);
            _esCopy = new Db(string.Format("{0}{1}{2}", _dbPath, _dbCopyFileName, DefaultExtension));
            //удаляем все файлы из директории по умолчанию
            if (File.Exists(string.Format("{0}{1}{2}", DBPathDefault, dbOldName, DefaultExtension)))
                File.Delete(string.Format("{0}{1}{2}", DBPathDefault, dbOldName, DefaultExtension));
            if (File.Exists(string.Format("{0}{1}{2}", DBPathDefault, dbOldCopyName, DefaultExtension)))
                File.Delete(string.Format("{0}{1}{2}", DBPathDefault, dbOldCopyName, DefaultExtension));
            if (_somethingChanged)
                Text = Text.Substring(0, Text.Length - 1);
            _somethingChanged = false;
        } 
        #endregion

        #region Выход
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            CloseToolStripMenuItemClick(sender, e);
            Close();
        }

        private void FormMainFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseToolStripMenuItemClick(sender, e);
        }
        #endregion 

        #endregion

        #region Меню Редактирование
        private void DomainsToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeStatusStrip("Редактирование доменов");
            var de = new DomainEditor(_esCopy, _dbPath, _dbCopyFileName);
            de.ShowDialog();
            ChangeStatistics();
            NormalizeStatusStrip();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        private void VariablesToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeStatusStrip("Редактирование переменных");
            var ve = new VariableEditor(ref _esCopy, _dbPath, _dbCopyFileName);
            ve.ShowDialog();
            ChangeStatistics();
            NormalizeStatusStrip();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }

        private void RulesToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeStatusStrip("Редактирование правил");
            var re = new RuleEditor(_esCopy, _dbPath, _dbCopyFileName);
            re.ShowDialog();
            ChangeStatistics();
            NormalizeStatusStrip();
            if (!_somethingChanged) Text += "*";
            _somethingChanged = true;
        }
        #endregion

        #region Меню Консультация
        /// <summary>
        /// Начать консультацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartConsultationToolStripMenuItemClick(object sender, EventArgs e)
        {
            //сразу же инициализируем форму объяснения
            var formExplain = new ExplanationForm();
            //вызываем форму консультации
            var formConsult = new FormConsult
                                  {
                                      Es = new InferentialMechanism.Db(_esCopy.Connection),
                                      AddToExplanation = formExplain.AddRuleToTreeView
                                  };
            formConsult.ShowDialog();
            //показываем форму объяснения
            formExplain.Res = formConsult.Goal + " = " + formConsult.Result;
            formExplain.Memory = formConsult.WorkMemory;
            formExplain.ShowDialog();
            //Обновляем listView
            listViewConsultations.Items.Add(
                new ListViewItem(new [] {DateTime.Now.Date.ToShortDateString(), formConsult.Goal, formConsult.Result}));
        } 
        #endregion
        
    }
}
