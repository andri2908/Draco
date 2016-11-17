namespace BintangTimur
{
    partial class dataSalesTargetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataSalesTarget = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.periodeBulanCombo = new System.Windows.Forms.ComboBox();
            this.periodeTahunCombo = new System.Windows.Forms.ComboBox();
            this.targetPenjualanTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.displayButton = new System.Windows.Forms.Button();
            this.commissionValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSalesTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSalesTarget
            // 
            this.dataSalesTarget.AllowUserToAddRows = false;
            this.dataSalesTarget.AllowUserToDeleteRows = false;
            this.dataSalesTarget.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataSalesTarget.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataSalesTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSalesTarget.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataSalesTarget.Location = new System.Drawing.Point(0, 161);
            this.dataSalesTarget.MultiSelect = false;
            this.dataSalesTarget.Name = "dataSalesTarget";
            this.dataSalesTarget.RowHeadersVisible = false;
            this.dataSalesTarget.Size = new System.Drawing.Size(525, 393);
            this.dataSalesTarget.TabIndex = 64;
            this.dataSalesTarget.DoubleClick += new System.EventHandler(this.dataSalesTarget_DoubleClick);
            this.dataSalesTarget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataSalesTarget_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Periode";
            // 
            // periodeBulanCombo
            // 
            this.periodeBulanCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.periodeBulanCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.periodeBulanCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodeBulanCombo.FormattingEnabled = true;
            this.periodeBulanCombo.Items.AddRange(new object[] {
            "JANUARI",
            "FEBRUARI",
            "MARET",
            "APRIL",
            "MEI",
            "JUNI",
            "JULI",
            "AGUSTUS",
            "SEPTEMBER",
            "OKTOBER",
            "NOVEMBER",
            "DESEMBER"});
            this.periodeBulanCombo.Location = new System.Drawing.Point(15, 47);
            this.periodeBulanCombo.Name = "periodeBulanCombo";
            this.periodeBulanCombo.Size = new System.Drawing.Size(196, 26);
            this.periodeBulanCombo.TabIndex = 66;
            // 
            // periodeTahunCombo
            // 
            this.periodeTahunCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.periodeTahunCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.periodeTahunCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodeTahunCombo.FormattingEnabled = true;
            this.periodeTahunCombo.Items.AddRange(new object[] {
            "JANUARI",
            "FEBRUARI",
            "MARET",
            "APRIL",
            "MEI",
            "JUNI",
            "JULI",
            "AGUSTUS",
            "SEPTEMBER",
            "OKTOBER",
            "NOVEMBER",
            "DESEMBER"});
            this.periodeTahunCombo.Location = new System.Drawing.Point(229, 47);
            this.periodeTahunCombo.Name = "periodeTahunCombo";
            this.periodeTahunCombo.Size = new System.Drawing.Size(120, 26);
            this.periodeTahunCombo.TabIndex = 67;
            // 
            // targetPenjualanTextBox
            // 
            this.targetPenjualanTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPenjualanTextBox.Location = new System.Drawing.Point(15, 110);
            this.targetPenjualanTextBox.Mask = "000000000000000";
            this.targetPenjualanTextBox.Name = "targetPenjualanTextBox";
            this.targetPenjualanTextBox.Size = new System.Drawing.Size(180, 27);
            this.targetPenjualanTextBox.TabIndex = 68;
            this.targetPenjualanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 69;
            this.label1.Text = "Target Penjualan";
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(415, 47);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 70;
            this.displayButton.Text = "SAVE";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // commissionValue
            // 
            this.commissionValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.commissionValue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commissionValue.Location = new System.Drawing.Point(229, 110);
            this.commissionValue.MaxLength = 5;
            this.commissionValue.Name = "commissionValue";
            this.commissionValue.Size = new System.Drawing.Size(120, 27);
            this.commissionValue.TabIndex = 71;
            this.commissionValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.commissionValue.TextChanged += new System.EventHandler(this.convertValueTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(226, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 72;
            this.label3.Text = "Komisi (%)";
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(12, 6);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 73;
            this.errorLabel.Text = "   ";
            // 
            // dataSalesTargetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(522, 553);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commissionValue);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetPenjualanTextBox);
            this.Controls.Add(this.periodeTahunCombo);
            this.Controls.Add(this.periodeBulanCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataSalesTarget);
            this.MaximizeBox = false;
            this.Name = "dataSalesTargetForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Sales Target";
            this.Load += new System.EventHandler(this.dataSalesTargetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSalesTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataSalesTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox periodeBulanCombo;
        private System.Windows.Forms.ComboBox periodeTahunCombo;
        private System.Windows.Forms.MaskedTextBox targetPenjualanTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.TextBox commissionValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorLabel;
    }
}