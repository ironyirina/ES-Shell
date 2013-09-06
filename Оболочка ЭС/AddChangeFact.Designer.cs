namespace Оболочка_ЭС
{
    partial class AddChangeFact
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
            this.comboBoxVariable = new System.Windows.Forms.ComboBox();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.buttonNewVariable = new System.Windows.Forms.Button();
            this.buttonNewValue = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddMoreThanOne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxVariable
            // 
            this.comboBoxVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVariable.FormattingEnabled = true;
            this.comboBoxVariable.Location = new System.Drawing.Point(9, 51);
            this.comboBoxVariable.Name = "comboBoxVariable";
            this.comboBoxVariable.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVariable.TabIndex = 0;
            this.comboBoxVariable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVariableSelectedIndexChanged);
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Location = new System.Drawing.Point(201, 51);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(249, 21);
            this.comboBoxValue.TabIndex = 0;
            // 
            // buttonNewVariable
            // 
            this.buttonNewVariable.Location = new System.Drawing.Point(136, 49);
            this.buttonNewVariable.Name = "buttonNewVariable";
            this.buttonNewVariable.Size = new System.Drawing.Size(40, 23);
            this.buttonNewVariable.TabIndex = 1;
            this.buttonNewVariable.Text = "+";
            this.buttonNewVariable.UseVisualStyleBackColor = true;
            this.buttonNewVariable.Click += new System.EventHandler(this.ButtonNewVariableClick);
            // 
            // buttonNewValue
            // 
            this.buttonNewValue.Location = new System.Drawing.Point(456, 49);
            this.buttonNewValue.Name = "buttonNewValue";
            this.buttonNewValue.Size = new System.Drawing.Size(40, 23);
            this.buttonNewValue.TabIndex = 1;
            this.buttonNewValue.Text = "+";
            this.buttonNewValue.UseVisualStyleBackColor = true;
            this.buttonNewValue.Click += new System.EventHandler(this.ButtonNewValueClick);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(340, 78);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(421, 78);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Переменная";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Значение";
            // 
            // buttonAddMoreThanOne
            // 
            this.buttonAddMoreThanOne.Location = new System.Drawing.Point(240, 78);
            this.buttonAddMoreThanOne.Name = "buttonAddMoreThanOne";
            this.buttonAddMoreThanOne.Size = new System.Drawing.Size(94, 23);
            this.buttonAddMoreThanOne.TabIndex = 6;
            this.buttonAddMoreThanOne.Text = "Добавить еще";
            this.buttonAddMoreThanOne.UseVisualStyleBackColor = true;
            this.buttonAddMoreThanOne.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // AddChangeFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 109);
            this.Controls.Add(this.buttonAddMoreThanOne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonNewValue);
            this.Controls.Add(this.buttonNewVariable);
            this.Controls.Add(this.comboBoxValue);
            this.Controls.Add(this.comboBoxVariable);
            this.Name = "AddChangeFact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddChangeFact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVariable;
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.Button buttonNewVariable;
        private System.Windows.Forms.Button buttonNewValue;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddMoreThanOne;
    }
}