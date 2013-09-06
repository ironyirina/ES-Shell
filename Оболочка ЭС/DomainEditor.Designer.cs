namespace Оболочка_ЭС
{
    partial class DomainEditor
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
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxDomains = new System.Windows.Forms.GroupBox();
            this.listBoxDomains = new System.Windows.Forms.ListBox();
            this.buttonChangeDomain = new System.Windows.Forms.Button();
            this.buttonDeleteDomain = new System.Windows.Forms.Button();
            this.buttonAddDomain = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxValues = new System.Windows.Forms.ListBox();
            this.buttonChangeValue = new System.Windows.Forms.Button();
            this.buttonDeleteValue = new System.Windows.Forms.Button();
            this.buttonAddValue = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxDomains.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(337, 446);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(418, 446);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(499, 446);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // groupBoxDomains
            // 
            this.groupBoxDomains.Controls.Add(this.listBoxDomains);
            this.groupBoxDomains.Controls.Add(this.buttonChangeDomain);
            this.groupBoxDomains.Controls.Add(this.buttonDeleteDomain);
            this.groupBoxDomains.Controls.Add(this.buttonAddDomain);
            this.groupBoxDomains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDomains.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDomains.Name = "groupBoxDomains";
            this.groupBoxDomains.Size = new System.Drawing.Size(287, 440);
            this.groupBoxDomains.TabIndex = 4;
            this.groupBoxDomains.TabStop = false;
            this.groupBoxDomains.Text = "Домены";
            // 
            // listBoxDomains
            // 
            this.listBoxDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDomains.FormattingEnabled = true;
            this.listBoxDomains.Location = new System.Drawing.Point(7, 20);
            this.listBoxDomains.Name = "listBoxDomains";
            this.listBoxDomains.Size = new System.Drawing.Size(274, 381);
            this.listBoxDomains.TabIndex = 4;
            this.listBoxDomains.SelectedIndexChanged += new System.EventHandler(this.ListBoxDomainsSelectedIndexChanged);
            this.listBoxDomains.DoubleClick += new System.EventHandler(this.ButtonChangeDomainClick);
            // 
            // buttonChangeDomain
            // 
            this.buttonChangeDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChangeDomain.Location = new System.Drawing.Point(87, 411);
            this.buttonChangeDomain.Name = "buttonChangeDomain";
            this.buttonChangeDomain.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeDomain.TabIndex = 3;
            this.buttonChangeDomain.Text = "Изменить";
            this.buttonChangeDomain.UseVisualStyleBackColor = true;
            this.buttonChangeDomain.Click += new System.EventHandler(this.ButtonChangeDomainClick);
            // 
            // buttonDeleteDomain
            // 
            this.buttonDeleteDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteDomain.Location = new System.Drawing.Point(168, 411);
            this.buttonDeleteDomain.Name = "buttonDeleteDomain";
            this.buttonDeleteDomain.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteDomain.TabIndex = 2;
            this.buttonDeleteDomain.Text = "Удалить";
            this.buttonDeleteDomain.UseVisualStyleBackColor = true;
            this.buttonDeleteDomain.Click += new System.EventHandler(this.ButtonDeleteDomainClick);
            // 
            // buttonAddDomain
            // 
            this.buttonAddDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddDomain.Location = new System.Drawing.Point(6, 411);
            this.buttonAddDomain.Name = "buttonAddDomain";
            this.buttonAddDomain.Size = new System.Drawing.Size(75, 23);
            this.buttonAddDomain.TabIndex = 1;
            this.buttonAddDomain.Text = "Добавить";
            this.buttonAddDomain.UseVisualStyleBackColor = true;
            this.buttonAddDomain.Click += new System.EventHandler(this.ButtonAddDomainClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxValues);
            this.groupBox1.Controls.Add(this.buttonChangeValue);
            this.groupBox1.Controls.Add(this.buttonDeleteValue);
            this.groupBox1.Controls.Add(this.buttonAddValue);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 440);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Значения";
            // 
            // listBoxValues
            // 
            this.listBoxValues.AllowDrop = true;
            this.listBoxValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxValues.FormattingEnabled = true;
            this.listBoxValues.Location = new System.Drawing.Point(7, 20);
            this.listBoxValues.MultiColumn = true;
            this.listBoxValues.Name = "listBoxValues";
            this.listBoxValues.Size = new System.Drawing.Size(281, 381);
            this.listBoxValues.TabIndex = 4;
            this.listBoxValues.SelectedIndexChanged += new System.EventHandler(this.ListBoxValuesSelectedIndexChanged);
            this.listBoxValues.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxValuesDragDrop);
            this.listBoxValues.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxValuesDragEnter);
            this.listBoxValues.DragOver += new System.Windows.Forms.DragEventHandler(this.ListBoxValuesDragOver);
            this.listBoxValues.DoubleClick += new System.EventHandler(this.ButtonChangeValueClick);
            this.listBoxValues.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxValuesMouseDown);
            // 
            // buttonChangeValue
            // 
            this.buttonChangeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChangeValue.Location = new System.Drawing.Point(87, 411);
            this.buttonChangeValue.Name = "buttonChangeValue";
            this.buttonChangeValue.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeValue.TabIndex = 3;
            this.buttonChangeValue.Text = "Изменить";
            this.buttonChangeValue.UseVisualStyleBackColor = true;
            this.buttonChangeValue.Click += new System.EventHandler(this.ButtonChangeValueClick);
            // 
            // buttonDeleteValue
            // 
            this.buttonDeleteValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteValue.Location = new System.Drawing.Point(168, 411);
            this.buttonDeleteValue.Name = "buttonDeleteValue";
            this.buttonDeleteValue.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteValue.TabIndex = 2;
            this.buttonDeleteValue.Text = "Удалить";
            this.buttonDeleteValue.UseVisualStyleBackColor = true;
            this.buttonDeleteValue.Click += new System.EventHandler(this.ButtonDeleteValueClick);
            // 
            // buttonAddValue
            // 
            this.buttonAddValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddValue.Location = new System.Drawing.Point(6, 411);
            this.buttonAddValue.Name = "buttonAddValue";
            this.buttonAddValue.Size = new System.Drawing.Size(75, 23);
            this.buttonAddValue.TabIndex = 1;
            this.buttonAddValue.Text = "Добавить";
            this.buttonAddValue.UseVisualStyleBackColor = true;
            this.buttonAddValue.Click += new System.EventHandler(this.ButtonAddValueClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxDomains);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(585, 440);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 6;
            // 
            // DomainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 476);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Name = "DomainEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор доменов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DomainEditorFormClosing);
            this.groupBoxDomains.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxDomains;
        private System.Windows.Forms.Button buttonChangeDomain;
        private System.Windows.Forms.Button buttonDeleteDomain;
        private System.Windows.Forms.Button buttonAddDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonChangeValue;
        private System.Windows.Forms.Button buttonDeleteValue;
        private System.Windows.Forms.Button buttonAddValue;
        private System.Windows.Forms.ListBox listBoxDomains;
        private System.Windows.Forms.ListBox listBoxValues;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}