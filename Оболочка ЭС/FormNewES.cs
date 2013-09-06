using System;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class FormNewES : Form
    {
        #region Переменные и свойства
        /// <summary>
        /// имя файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// полное имя файла
        /// </summary>
        public string FullName { get; set; } 
        #endregion

        #region Инициализация
        public FormNewES()
        {
            InitializeComponent();
        } 
        #endregion

        #region Интерфейсик
        private void ButtonOkClick(object sender, EventArgs e)
        {
            FileName = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }

        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxName.Text != string.Empty;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }          
        #endregion       
    }
}
