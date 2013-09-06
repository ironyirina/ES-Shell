namespace Оболочка_ЭС
{
    partial class AddChangeVariable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVarName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDomain = new System.Windows.Forms.ComboBox();
            this.buttonNewDomain = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonGet = new System.Windows.Forms.RadioButton();
            this.radioButtonPut = new System.Windows.Forms.RadioButton();
            this.Вопрос = new System.Windows.Forms.GroupBox();
            this.richTextBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddMoreThanOne = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Вопрос.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя переменной:";
            // 
            // textBoxVarName
            // 
            this.textBoxVarName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVarName.Location = new System.Drawing.Point(115, 30);
            this.textBoxVarName.Name = "textBoxVarName";
            this.textBoxVarName.Size = new System.Drawing.Size(227, 20);
            this.textBoxVarName.TabIndex = 1;
            this.textBoxVarName.TextChanged += new System.EventHandler(this.TextBoxVarNameTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Домен:";
            // 
            // comboBoxDomain
            // 
            this.comboBoxDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDomain.FormattingEnabled = true;
            this.comboBoxDomain.Location = new System.Drawing.Point(115, 66);
            this.comboBoxDomain.Name = "comboBoxDomain";
            this.comboBoxDomain.Size = new System.Drawing.Size(177, 21);
            this.comboBoxDomain.TabIndex = 3;
            // 
            // buttonNewDomain
            // 
            this.buttonNewDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewDomain.Location = new System.Drawing.Point(298, 64);
            this.buttonNewDomain.Name = "buttonNewDomain";
            this.buttonNewDomain.Size = new System.Drawing.Size(44, 23);
            this.buttonNewDomain.TabIndex = 4;
            this.buttonNewDomain.Text = "+";
            this.buttonNewDomain.UseVisualStyleBackColor = true;
            this.buttonNewDomain.Click += new System.EventHandler(this.ButtonNewDomainClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonBoth);
            this.groupBox1.Controls.Add(this.radioButtonGet);
            this.groupBox1.Controls.Add(this.radioButtonPut);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип";
            // 
            // radioButtonBoth
            // 
            this.radioButtonBoth.AutoSize = true;
            this.radioButtonBoth.Location = new System.Drawing.Point(55, 66);
            this.radioButtonBoth.Name = "radioButtonBoth";
            this.radioButtonBoth.Size = new System.Drawing.Size(163, 17);
            this.radioButtonBoth.TabIndex = 2;
            this.radioButtonBoth.TabStop = true;
            this.radioButtonBoth.Text = "Выводимо-запрашиваемая";
            this.radioButtonBoth.UseVisualStyleBackColor = true;
            this.radioButtonBoth.CheckedChanged += new System.EventHandler(this.RadioButtonGetCheckedChanged);
            // 
            // radioButtonGet
            // 
            this.radioButtonGet.AutoSize = true;
            this.radioButtonGet.Location = new System.Drawing.Point(55, 43);
            this.radioButtonGet.Name = "radioButtonGet";
            this.radioButtonGet.Size = new System.Drawing.Size(108, 17);
            this.radioButtonGet.TabIndex = 1;
            this.radioButtonGet.TabStop = true;
            this.radioButtonGet.Text = "Запрашиваемая";
            this.radioButtonGet.UseVisualStyleBackColor = true;
            this.radioButtonGet.CheckedChanged += new System.EventHandler(this.RadioButtonGetCheckedChanged);
            // 
            // radioButtonPut
            // 
            this.radioButtonPut.AutoSize = true;
            this.radioButtonPut.Location = new System.Drawing.Point(55, 19);
            this.radioButtonPut.Name = "radioButtonPut";
            this.radioButtonPut.Size = new System.Drawing.Size(84, 17);
            this.radioButtonPut.TabIndex = 0;
            this.radioButtonPut.TabStop = true;
            this.radioButtonPut.Text = "Выводимая";
            this.radioButtonPut.UseVisualStyleBackColor = true;
            this.radioButtonPut.CheckedChanged += new System.EventHandler(this.RadioButtonPutCheckedChanged);
            // 
            // Вопрос
            // 
            this.Вопрос.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Вопрос.Controls.Add(this.richTextBoxQuestion);
            this.Вопрос.Location = new System.Drawing.Point(15, 208);
            this.Вопрос.Name = "Вопрос";
            this.Вопрос.Size = new System.Drawing.Size(327, 99);
            this.Вопрос.TabIndex = 6;
            this.Вопрос.TabStop = false;
            this.Вопрос.Text = "Вопрос";
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxQuestion.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.Size = new System.Drawing.Size(321, 80);
            this.richTextBoxQuestion.TabIndex = 0;
            this.richTextBoxQuestion.Text = "";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(186, 313);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(267, 313);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAddMoreThanOne
            // 
            this.buttonAddMoreThanOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddMoreThanOne.Location = new System.Drawing.Point(83, 313);
            this.buttonAddMoreThanOne.Name = "buttonAddMoreThanOne";
            this.buttonAddMoreThanOne.Size = new System.Drawing.Size(97, 23);
            this.buttonAddMoreThanOne.TabIndex = 7;
            this.buttonAddMoreThanOne.Text = "Добавить еще";
            this.buttonAddMoreThanOne.UseVisualStyleBackColor = true;
            this.buttonAddMoreThanOne.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // AddChangeVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 344);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddMoreThanOne);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.Вопрос);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonNewDomain);
            this.Controls.Add(this.comboBoxDomain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxVarName);
            this.Controls.Add(this.label1);
            this.Name = "AddChangeVariable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddChangeVariable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Вопрос.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVarName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDomain;
        private System.Windows.Forms.Button buttonNewDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.RadioButton radioButtonGet;
        private System.Windows.Forms.RadioButton radioButtonPut;
        private System.Windows.Forms.GroupBox Вопрос;
        private System.Windows.Forms.RichTextBox richTextBoxQuestion;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddMoreThanOne;
    }
}