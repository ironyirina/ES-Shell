using System;
using System.Linq;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    public partial class AddChangeFact : Form
    {
        #region Переменные
        private Db _es;
        private readonly string _dbPath, _dbFileName;
        private Variables _selectedVariable;
        #endregion

        #region Свойства
        /// <summary>
        /// Имя переменной, написанное в комбобоксе
        /// </summary>
        public Variables Var
        {
            get 
            {
                if (comboBoxVariable.SelectedItem != null)    
                    return _es.Variables.Single(x => x.Name == comboBoxVariable.SelectedItem.ToString()); 
                throw new ArgumentException("Переменных пока нет");
            }
            set { comboBoxVariable.SelectedItem = value.Name; }
        }

        /// <summary>
        /// Имя значения
        /// </summary>
        public Values Val
        {
            get
            {
                if (comboBoxValue.SelectedItem != null)
                {
                    var t = _es.Values.Single(x => (x.Name == comboBoxValue.SelectedItem.ToString()
                                && x.DomainID == Var.DomainID));
                    return t;
                }
                throw new ArgumentException("Значений пока нет");
            }
            set { comboBoxValue.SelectedItem = value.Name; }
        }
        #endregion

        #region Инициализация
        public AddChangeFact(Db es, string path, string fileName, string caption, bool allowManyAddings, 
            bool allowGetVariables)
        {
            InitializeComponent();
            _es = es;
            _dbPath = path;
            _dbFileName = fileName;
            Text = caption;
            if (allowGetVariables)
                comboBoxVariable.DataSource = _es.Variables.Select(x => x.Name);
            else
                comboBoxVariable.DataSource = _es.Variables.Where(x => x.VarTypes.Name == "Выводимая" ||
                                                                       x.VarTypes.Name == "Выводимо-запрашиваемая").
                    Select(x => x.Name);
            if (comboBoxVariable.Items.Count > 0)
                comboBoxVariable.SelectedIndex = 0;
            if (comboBoxValue.Items.Count > 0)
                comboBoxValue.SelectedIndex = 0;
            buttonAddMoreThanOne.Visible = allowManyAddings;
        }

        private void ComboBoxVariableSelectedIndexChanged(object sender, EventArgs e)
         {
            _selectedVariable = _es.Variables.Single(x => x.Name == comboBoxVariable.SelectedItem.ToString());
            comboBoxValue.DataSource =
                _es.Values.Where(x => x.DomainID == _selectedVariable.DomainID).OrderBy(x => x.Number).
                    Select(x => x.Name);
         }
        #endregion

        #region Пополнение переменных и доменов
        private void ButtonNewVariableClick(object sender, EventArgs e)
        {
            var ve = new VariableEditor(ref _es, _dbPath, _dbFileName);
            ve.ShowDialog();
            comboBoxVariable.DataSource = _es.Variables.Select(x => x.Name);
            comboBoxVariable.SelectedIndex = comboBoxVariable.Items.Count - 1;
            comboBoxValue.DataSource =
                _es.Values.Where(x => x.DomainID == _selectedVariable.DomainID).Select(x => x.Name);
        }

        private void ButtonNewValueClick(object sender, EventArgs e)
        {
            var de = new DomainEditor(_es, _dbPath, _dbFileName);
            de.ShowDialog();
            if (_selectedVariable != null)
            {
                comboBoxValue.DataSource =
                    _es.Values.Where(x => x.DomainID == _selectedVariable.DomainID).Select(x => x.Name);
            }
            comboBoxValue.SelectedIndex = comboBoxValue.Items.Count - 1;
        } 
        #endregion

        #region Интерфейсик
        private void ButtonOkClick(object sender, EventArgs e)
        {
            OnEventAddAgain(Var, Val);
        } 
        #endregion

        #region Событие при добавлении
        public event Action<Variables, Values> EventAddAgain;

        public void OnEventAddAgain(Variables var, Values val)
        {
            var handler = EventAddAgain;
            if (handler != null)
                handler(var, val);
        }
        #endregion

    }
}
