using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InferentialMechanism
{
    public partial class FormAsk : Form
    {
        #region Переменные
        private readonly Db _es;
        private readonly Variables _varIAmAskingAbout;
        private readonly List<RadioButton> _variantsOfAnswer = new List<RadioButton>();  
        #endregion

        #region Свойства
        public Values GivenAnswer
        {
            get
            {
                return _es.Values.Single(x => x.Name == _variantsOfAnswer.Find(rb => rb.Checked).Text
                    && x.DomainID == _varIAmAskingAbout.DomainID);
            }
        } 
        #endregion

        #region Инициализация
        public FormAsk(Db es, Variables varIAmAskingAbout)
        {
            InitializeComponent();
            _es = es;
            _varIAmAskingAbout = varIAmAskingAbout;
            //добавляем вопрос
            groupBoxQuestion.Text = _varIAmAskingAbout.Question;
            const int xPoint = 7;
            const int yPoint = 20;
            const int dy = 24;
            var i = 0;
            //добавляем варианты ответов
            foreach (var value in _es.Values.Where(x => x.DomainID == _varIAmAskingAbout.DomainID).OrderBy(x => x.Number))
            {
                var rb = new RadioButton
                {
                    Name = string.Format("rb{0}", value.Name),
                    Size = new Size(10000, 20),
                    Text = value.Name,
                    Location = new Point(xPoint, yPoint + dy * (i++))
                };
                groupBoxQuestion.Controls.Add(rb);
                _variantsOfAnswer.Add(rb);
            }
            var rb0 = (RadioButton) groupBoxQuestion.Controls[0];
            rb0.Checked = true;
        } 
        #endregion

        #region Интерфейсик
        private void ButtonStopClick(object sender, System.EventArgs e)
        {
            throw new ArgumentException("Консультация прервана");
        } 
        #endregion
    }
}
