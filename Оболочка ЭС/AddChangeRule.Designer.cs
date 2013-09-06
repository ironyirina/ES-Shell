namespace Оболочка_ЭС
{
    partial class AddChangeRule
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
            this.textBoxRuleName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelFact = new System.Windows.Forms.Button();
            this.buttonChangeFact = new System.Windows.Forms.Button();
            this.buttonAddFact = new System.Windows.Forms.Button();
            this.listViewFacts = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewConclusions = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelConclusion = new System.Windows.Forms.Button();
            this.buttonChangeConclusion = new System.Windows.Forms.Button();
            this.buttonAddConclusion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBoxExplanation = new System.Windows.Forms.RichTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя правила";
            // 
            // textBoxRuleName
            // 
            this.textBoxRuleName.Location = new System.Drawing.Point(91, 23);
            this.textBoxRuleName.Name = "textBoxRuleName";
            this.textBoxRuleName.Size = new System.Drawing.Size(208, 20);
            this.textBoxRuleName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonDelFact);
            this.groupBox1.Controls.Add(this.buttonChangeFact);
            this.groupBox1.Controls.Add(this.buttonAddFact);
            this.groupBox1.Controls.Add(this.listViewFacts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Посылка";
            // 
            // buttonDelFact
            // 
            this.buttonDelFact.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDelFact.Location = new System.Drawing.Point(243, 168);
            this.buttonDelFact.Name = "buttonDelFact";
            this.buttonDelFact.Size = new System.Drawing.Size(75, 23);
            this.buttonDelFact.TabIndex = 2;
            this.buttonDelFact.Text = "Удалить";
            this.buttonDelFact.UseVisualStyleBackColor = true;
            this.buttonDelFact.Click += new System.EventHandler(this.ButtonDelFactClick);
            // 
            // buttonChangeFact
            // 
            this.buttonChangeFact.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonChangeFact.Location = new System.Drawing.Point(162, 168);
            this.buttonChangeFact.Name = "buttonChangeFact";
            this.buttonChangeFact.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeFact.TabIndex = 2;
            this.buttonChangeFact.Text = "Изменить";
            this.buttonChangeFact.UseVisualStyleBackColor = true;
            this.buttonChangeFact.Click += new System.EventHandler(this.ButtonChangeFactClick);
            // 
            // buttonAddFact
            // 
            this.buttonAddFact.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddFact.Location = new System.Drawing.Point(81, 168);
            this.buttonAddFact.Name = "buttonAddFact";
            this.buttonAddFact.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFact.TabIndex = 2;
            this.buttonAddFact.Text = "Добавить";
            this.buttonAddFact.UseVisualStyleBackColor = true;
            this.buttonAddFact.Click += new System.EventHandler(this.ButtonAddFactClick);
            // 
            // listViewFacts
            // 
            this.listViewFacts.AllowDrop = true;
            this.listViewFacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewFacts.FullRowSelect = true;
            this.listViewFacts.Location = new System.Drawing.Point(45, 19);
            this.listViewFacts.Name = "listViewFacts";
            this.listViewFacts.Size = new System.Drawing.Size(317, 140);
            this.listViewFacts.TabIndex = 1;
            this.listViewFacts.UseCompatibleStateImageBehavior = false;
            this.listViewFacts.View = System.Windows.Forms.View.Details;
            this.listViewFacts.SelectedIndexChanged += new System.EventHandler(this.ListViewFactsSelectedIndexChanged);
            this.listViewFacts.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListViewFactsDragDrop);
            this.listViewFacts.DragOver += new System.Windows.Forms.DragEventHandler(this.ListViewFactsDragOver);
            this.listViewFacts.DoubleClick += new System.EventHandler(this.ButtonChangeFactClick);
            this.listViewFacts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListViewFactsMouseDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "№";
            this.columnHeader7.Width = 30;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Переменная";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "=";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Значение";
            this.columnHeader3.Width = 130;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Если";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewConclusions);
            this.groupBox2.Controls.Add(this.buttonDelConclusion);
            this.groupBox2.Controls.Add(this.buttonChangeConclusion);
            this.groupBox2.Controls.Add(this.buttonAddConclusion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 194);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заключение";
            // 
            // listViewConclusions
            // 
            this.listViewConclusions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewConclusions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewConclusions.FullRowSelect = true;
            this.listViewConclusions.Location = new System.Drawing.Point(32, 16);
            this.listViewConclusions.Name = "listViewConclusions";
            this.listViewConclusions.Size = new System.Drawing.Size(337, 140);
            this.listViewConclusions.TabIndex = 3;
            this.listViewConclusions.UseCompatibleStateImageBehavior = false;
            this.listViewConclusions.View = System.Windows.Forms.View.Details;
            this.listViewConclusions.SelectedIndexChanged += new System.EventHandler(this.ListViewConclusionsSelectedIndexChanged);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "№";
            this.columnHeader8.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Переменная";
            this.columnHeader4.Width = 133;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "=";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 30;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Значение";
            this.columnHeader6.Width = 130;
            // 
            // buttonDelConclusion
            // 
            this.buttonDelConclusion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDelConclusion.Location = new System.Drawing.Point(259, 168);
            this.buttonDelConclusion.Name = "buttonDelConclusion";
            this.buttonDelConclusion.Size = new System.Drawing.Size(75, 23);
            this.buttonDelConclusion.TabIndex = 2;
            this.buttonDelConclusion.Text = "Удалить";
            this.buttonDelConclusion.UseVisualStyleBackColor = true;
            this.buttonDelConclusion.Click += new System.EventHandler(this.ButtonDelConclusionClick);
            // 
            // buttonChangeConclusion
            // 
            this.buttonChangeConclusion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonChangeConclusion.Location = new System.Drawing.Point(178, 168);
            this.buttonChangeConclusion.Name = "buttonChangeConclusion";
            this.buttonChangeConclusion.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeConclusion.TabIndex = 2;
            this.buttonChangeConclusion.Text = "Изменить";
            this.buttonChangeConclusion.UseVisualStyleBackColor = true;
            this.buttonChangeConclusion.Click += new System.EventHandler(this.ButtonChangeConclusionClick);
            // 
            // buttonAddConclusion
            // 
            this.buttonAddConclusion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddConclusion.Location = new System.Drawing.Point(97, 168);
            this.buttonAddConclusion.Name = "buttonAddConclusion";
            this.buttonAddConclusion.Size = new System.Drawing.Size(75, 23);
            this.buttonAddConclusion.TabIndex = 2;
            this.buttonAddConclusion.Text = "Добавить";
            this.buttonAddConclusion.UseVisualStyleBackColor = true;
            this.buttonAddConclusion.Click += new System.EventHandler(this.ButtonAddConclusionClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "То";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.richTextBoxExplanation);
            this.groupBox3.Location = new System.Drawing.Point(13, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(790, 145);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Объяснение";
            // 
            // richTextBoxExplanation
            // 
            this.richTextBoxExplanation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExplanation.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxExplanation.Name = "richTextBoxExplanation";
            this.richTextBoxExplanation.Size = new System.Drawing.Size(784, 126);
            this.richTextBoxExplanation.TabIndex = 0;
            this.richTextBoxExplanation.Text = "";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(728, 411);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(647, 411);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(788, 205);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 6;
            // 
            // AddChangeRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 443);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBoxRuleName);
            this.Controls.Add(this.label1);
            this.Name = "AddChangeRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddChangeRule";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRuleName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelFact;
        private System.Windows.Forms.Button buttonChangeFact;
        private System.Windows.Forms.Button buttonAddFact;
        private System.Windows.Forms.ListView listViewFacts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDelConclusion;
        private System.Windows.Forms.Button buttonChangeConclusion;
        private System.Windows.Forms.Button buttonAddConclusion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBoxExplanation;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView listViewConclusions;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}