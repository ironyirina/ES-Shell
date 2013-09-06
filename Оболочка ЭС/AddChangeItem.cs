using System;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class AddChangeItem : Form
    {
        #region Свойства

        public string ItemName { get; private set; }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        #endregion

        #region Инициализация
        public AddChangeItem(string caption, string label, string tbText, bool allowManyAddings)
        {
            InitializeComponent();
            if (!allowManyAddings)
                buttonAddMoreThanOne.Visible = false;
            Text = caption;
            label1.Text = label;
            ItemName = tbText;
            textBoxName.Text = tbText;
            buttonOK.Enabled = false;
            buttonAddMoreThanOne.Enabled = false;
        } 
        #endregion
        
        #region Интерфейсик
        private void TextBoxNameTextChanged(object sender, EventArgs e)
        {
            buttonAddMoreThanOne.Enabled = buttonOK.Enabled = textBoxName.Text.Trim() != "" &&
                textBoxName.Text.Trim().ToLower() != string.Empty;
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            ItemName = textBoxName.Text.Trim();
            OnEventAddAgain(textBoxName.Text.Trim());
            textBoxName.Text = string.Empty;
            textBoxName.Focus();
        } 
        #endregion

        #region Событие при добавлении
        public event Action<string> EventAddAgain;

        public void OnEventAddAgain(string obj)
        {
            var handler = EventAddAgain;
            if (handler != null)
                handler(obj);
        } 
        #endregion
    }
}
