using System;
using System.Linq;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class AddChangeVariable : Form
    {
        #region Переменные
        private readonly Db _es;
        private readonly string _dbPath, _dbFileName; 
        #endregion
       
        #region Свойства
        public string VarName
        {
            get { return textBoxVarName.Text.Trim(); }
            set { textBoxVarName.Text = value; }
        }

        public Domains VarDomain 
        { 
            get { return _es.Domains.Single(x => x.Name == comboBoxDomain.SelectedItem.ToString()); }
            set { comboBoxDomain.SelectedItem = value.Name; }
        }

        public VarTypes VarType 
        { 
            get
            {
                var x = 1;
                if (radioButtonPut.Checked) x = 1;
                else if (radioButtonGet.Checked) x = 2;
                else if (radioButtonBoth.Checked) x = 3;
                return _es.VarTypes.Single(t => t.Id == x);
            }
            set
            {
                switch (value.Id)
                {
                    case 1:
                        radioButtonPut.Checked = true;
                        break;
                    case 2:
                        radioButtonGet.Checked = true;
                        break;
                    case 3:
                        radioButtonBoth.Checked = true;
                        break;
                }
            }
        }

        public string Question
        {
            get
            {
                if (richTextBoxQuestion.Text == "" && !radioButtonPut.Checked)
                    return VarName + "?";
                return richTextBoxQuestion.Text;
            }
            set { richTextBoxQuestion.Text = value; }
        } 

        #endregion

        #region Инициализация
        public AddChangeVariable(Db es, string path, string fileName, string caption, bool allowManyAddings)
        {
            InitializeComponent();
            buttonAddMoreThanOne.Visible = allowManyAddings;
            _es = es;
            _dbPath = path;
            _dbFileName = fileName;
            Text = caption;
            comboBoxDomain.DataSource = _es.Domains.Select(x => x.Name);
            if (comboBoxDomain.Items.Count > 0)
                comboBoxDomain.SelectedIndex = 0;
            buttonOK.Enabled = buttonAddMoreThanOne.Enabled = false;
        } 
        #endregion

        #region Контекстное пополнение домена
        private void ButtonNewDomainClick(object sender, EventArgs e)
        {
            var de = new DomainEditor(_es, _dbPath, _dbFileName);
            de.ShowDialog();
            comboBoxDomain.DataSource = _es.Domains.Select(x => x.Name);
            comboBoxDomain.SelectedIndex = comboBoxDomain.Items.Count - 1;
        } 
        #endregion

        #region RadioButtons
        private void RadioButtonPutCheckedChanged(object sender, EventArgs e)
        {
            richTextBoxQuestion.Enabled = false;
            richTextBoxQuestion.Text = "";
        }

        private void RadioButtonGetCheckedChanged(object sender, EventArgs e)
        {
            richTextBoxQuestion.Enabled = true;
            richTextBoxQuestion.Text = VarName + "?";
        }

        private void TextBoxVarNameTextChanged(object sender, EventArgs e)
        {
            buttonAddMoreThanOne.Enabled = buttonOK.Enabled = textBoxVarName.Text.Trim() != "" &&
               textBoxVarName.Text.Trim().ToLower() != string.Empty;
            if (!radioButtonPut.Checked)
                richTextBoxQuestion.Text = textBoxVarName.Text + "?";
        } 
        #endregion

        #region Интерфейсик
        private void ButtonOkClick(object sender, EventArgs e)
        {
            OnEventAddAgain(VarName, VarDomain, VarType, Question);
        } 
        #endregion

        #region Событие при добавлении
        public event Action<string, Domains, VarTypes, string> EventAddAgain;

        public void OnEventAddAgain(string name, Domains domain, VarTypes varType, string question)
        {
            var handler = EventAddAgain;
            if (handler != null) 
                handler(name, domain, varType, question);
        }

        #endregion
    }
}
