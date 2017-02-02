namespace AlphaSoft
{
    partial class stokTransferForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.asalCombo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.asalDataGrid = new System.Windows.Forms.DataGridView();
            this.tujuanCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNamaBarang = new System.Windows.Forms.Label();
            this.jumlahTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.asalComboHidden = new System.Windows.Forms.ComboBox();
            this.tujuanComboHidden = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asalDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 29);
            this.panel1.TabIndex = 15;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 5);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 25;
            this.errorLabel.Text = "   ";
            // 
            // asalCombo
            // 
            this.asalCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asalCombo.FormattingEnabled = true;
            this.asalCombo.Location = new System.Drawing.Point(81, 13);
            this.asalCombo.Name = "asalCombo";
            this.asalCombo.Size = new System.Drawing.Size(213, 26);
            this.asalCombo.TabIndex = 77;
            this.asalCombo.SelectedIndexChanged += new System.EventHandler(this.asalCombo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(24, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 18);
            this.label13.TabIndex = 78;
            this.label13.Text = "Asal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "Nama :";
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(81, 48);
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(213, 27);
            this.namaProdukTextBox.TabIndex = 80;
            this.namaProdukTextBox.TextChanged += new System.EventHandler(this.namaProdukTextBox_TextChanged);
            // 
            // asalDataGrid
            // 
            this.asalDataGrid.AllowUserToAddRows = false;
            this.asalDataGrid.AllowUserToDeleteRows = false;
            this.asalDataGrid.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.asalDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.asalDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.asalDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.asalDataGrid.Location = new System.Drawing.Point(8, 124);
            this.asalDataGrid.MultiSelect = false;
            this.asalDataGrid.Name = "asalDataGrid";
            this.asalDataGrid.ReadOnly = true;
            this.asalDataGrid.RowHeadersVisible = false;
            this.asalDataGrid.Size = new System.Drawing.Size(479, 205);
            this.asalDataGrid.TabIndex = 81;
            this.asalDataGrid.DoubleClick += new System.EventHandler(this.asalDataGrid_DoubleClick);
            // 
            // tujuanCombo
            // 
            this.tujuanCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tujuanCombo.FormattingEnabled = true;
            this.tujuanCombo.Location = new System.Drawing.Point(89, 13);
            this.tujuanCombo.Name = "tujuanCombo";
            this.tujuanCombo.Size = new System.Drawing.Size(213, 26);
            this.tujuanCombo.TabIndex = 82;
            this.tujuanCombo.SelectedIndexChanged += new System.EventHandler(this.tujuanCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Tujuan :";
            // 
            // labelNamaBarang
            // 
            this.labelNamaBarang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNamaBarang.AutoSize = true;
            this.labelNamaBarang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaBarang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelNamaBarang.Location = new System.Drawing.Point(9, 47);
            this.labelNamaBarang.Name = "labelNamaBarang";
            this.labelNamaBarang.Size = new System.Drawing.Size(60, 18);
            this.labelNamaBarang.TabIndex = 85;
            this.labelNamaBarang.Text = "NAMA";
            // 
            // jumlahTextBox
            // 
            this.jumlahTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.jumlahTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumlahTextBox.Location = new System.Drawing.Point(89, 74);
            this.jumlahTextBox.Name = "jumlahTextBox";
            this.jumlahTextBox.Size = new System.Drawing.Size(161, 27);
            this.jumlahTextBox.TabIndex = 86;
            this.jumlahTextBox.Text = "0";
            this.jumlahTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 87;
            this.label3.Text = "Jumlah";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.asalCombo);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.namaProdukTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 81);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tujuanCombo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelNamaBarang);
            this.groupBox2.Controls.Add(this.jumlahTextBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 109);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(347, 382);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(121, 37);
            this.saveButton.TabIndex = 90;
            this.saveButton.Text = "TRANSFER";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // asalComboHidden
            // 
            this.asalComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asalComboHidden.FormattingEnabled = true;
            this.asalComboHidden.Location = new System.Drawing.Point(267, 136);
            this.asalComboHidden.Name = "asalComboHidden";
            this.asalComboHidden.Size = new System.Drawing.Size(213, 26);
            this.asalComboHidden.TabIndex = 91;
            this.asalComboHidden.Visible = false;
            // 
            // tujuanComboHidden
            // 
            this.tujuanComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tujuanComboHidden.FormattingEnabled = true;
            this.tujuanComboHidden.Location = new System.Drawing.Point(274, 290);
            this.tujuanComboHidden.Name = "tujuanComboHidden";
            this.tujuanComboHidden.Size = new System.Drawing.Size(213, 26);
            this.tujuanComboHidden.TabIndex = 92;
            this.tujuanComboHidden.Visible = false;
            // 
            // stokTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(492, 454);
            this.Controls.Add(this.tujuanComboHidden);
            this.Controls.Add(this.asalComboHidden);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.asalDataGrid);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "stokTransferForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOK TRANSFER";
            this.Load += new System.EventHandler(this.stokTransferForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asalDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.ComboBox asalCombo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.DataGridView asalDataGrid;
        private System.Windows.Forms.ComboBox tujuanCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNamaBarang;
        private System.Windows.Forms.TextBox jumlahTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox asalComboHidden;
        private System.Windows.Forms.ComboBox tujuanComboHidden;
    }
}