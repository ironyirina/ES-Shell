using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InferentialMechanism;

namespace ExplanationComponent
{
    public partial class ExplanationForm : Form
    {
        #region Свойства

        /// <summary>
        /// Результат вывода
        /// </summary>
        public string Res
        {
            get { return textBoxResult.Text; }
            set { textBoxResult.Text = value; }
        }

        /// <summary>
        /// Рабочая память
        /// </summary>
        public List<WorkMemory> Memory
        {
            set
            {
                var s = value.Select(x => x.Variable.Name + " = " + x.Value.Name);
                foreach (var ss in s)
                    listBoxMemory.Items.Add(ss);
            }
        }

        #endregion

        #region Инициализация
        /// <summary>
        /// Компонента объяснения
        /// </summary>
        public ExplanationForm()
        {
            InitializeComponent();
        } 
        #endregion

        #region Expand&Collapse
        private void ButtonExpandClick(object sender, EventArgs e)
        {
            treeViewWorkedRules.ExpandAll();
        }

        private void ButtonCollapseClick(object sender, EventArgs e)
        {
            treeViewWorkedRules.CollapseAll();
        } 
        #endregion

        #region Добавление записи в treeView
        private delegate void Adder(
           string ruleName, IEnumerable<string> facts, IEnumerable<string> conclusions, string reason);
        public void AddRuleToTreeView(string ruleName, IEnumerable<string> facts, IEnumerable<string> conclusions,
            string reason)
        {
            if (InvokeRequired)
            {
                Adder a = AddRuleToTreeView;
                Invoke(a, new object[] { ruleName, facts, conclusions, reason });
            }
            else
            {
                //вершина с именем правила
                var rootNode = treeViewWorkedRules.Nodes.Add(ruleName);
                //вершина с посылками
                var ifNode = rootNode.Nodes.Add("Если");
                //посылки
                foreach (var f in facts)
                    ifNode.Nodes.Add(f);
                //вершина с заключениями
                var thenNode = rootNode.Nodes.Add("То");
                //заключения
                foreach (var c in conclusions)
                    thenNode.Nodes.Add(c);
                //объяснение
                rootNode.Nodes.Add(reason);
            }
        } 
        #endregion
    }
}
