namespace AlphaSoft
{
    partial class membershipPointForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.PODtPicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.PODtPicker_2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.displayButton = new System.Windows.Forms.Button();
            this.parameterInputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameCombo = new System.Windows.Forms.ComboBox();
            this.nameComboHidden = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Periode";
            // 
            // PODtPicker_1
            // 
            this.PODtPicker_1.AllowDrop = true;
            this.PODtPicker_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_1.Location = new System.Drawing.Point(125, 12);
            this.PODtPicker_1.Name = "PODtPicker_1";
            this.PODtPicker_1.Size = new System.Drawing.Size(144, 27);
            this.PODtPicker_1.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(275, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "-";
            // 
            // PODtPicker_2
            // 
            this.PODtPicker_2.AllowDrop = true;
            this.PODtPicker_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_2.Location = new System.Drawing.Point(297, 12);
            this.PODtPicker_2.Name = "PODtPicker_2";
            this.PODtPicker_2.Size = new System.Drawing.Size(145, 27);
            this.PODtPicker_2.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 49;
            this.label3.Text = "Prosentase";
            // 
            // displayButton
            // 
            this.displayButton.AllowDrop = true;
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(459, 12);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(116, 37);
            this.displayButton.TabIndex = 54;
            this.displayButton.Text = "GENERATE";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // parameterInputTextBox
            // 
            this.parameterInputTextBox.AllowDrop = true;
            this.parameterInputTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.parameterInputTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterInputTextBox.Location = new System.Drawing.Point(125, 77);
            this.parameterInputTextBox.MaxLength = 5;
            this.parameterInputTextBox.Name = "parameterInputTextBox";
            this.parameterInputTextBox.Size = new System.Drawing.Size(102, 27);
            this.parameterInputTextBox.TabIndex = 56;
            this.parameterInputTextBox.TextChanged += new System.EventHandler(this.noPOInvoiceTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 57;
            this.label1.Text = "Member";
            // 
            // nameCombo
            // 
            this.nameCombo.AllowDrop = true;
            this.nameCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nameCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameCombo.FormattingEnabled = true;
            this.nameCombo.Location = new System.Drawing.Point(125, 45);
            this.nameCombo.Name = "nameCombo";
            this.nameCombo.Size = new System.Drawing.Size(317, 26);
            this.nameCombo.TabIndex = 58;
            this.nameCombo.SelectedIndexChanged += new System.EventHandler(this.nameCombo_SelectedIndexChanged);
            // 
            // nameComboHidden
            // 
            this.nameComboHidden.AllowDrop = true;
            this.nameComboHidden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameComboHidden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nameComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameComboHidden.FormattingEnabled = true;
            this.nameComboHidden.Location = new System.Drawing.Point(264, 107);
            this.nameComboHidden.Name = "nameComboHidden";
            this.nameComboHidden.Size = new System.Drawing.Size(311, 26);
            this.nameComboHidden.TabIndex = 59;
            this.nameComboHidden.Visible = false;
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(459, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 37);
            this.button1.TabIndex = 60;
            this.button1.Text = "REPRINT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // membershipPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(587, 123);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nameComboHidden);
            this.Controls.Add(this.nameCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parameterInputTextBox);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PODtPicker_1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PODtPicker_2);
            this.Name = "membershipPointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEMBERSHIP POINTS";
            this.Load += new System.EventHandler(this.membershipPointForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker PODtPicker_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker PODtPicker_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.TextBox parameterInputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nameCombo;
        private System.Windows.Forms.ComboBox nameComboHidden;
        private System.Windows.Forms.Button button1;
    }
}