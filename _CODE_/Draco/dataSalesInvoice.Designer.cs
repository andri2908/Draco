namespace AlphaSoft
{
    partial class dataSalesInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.customerHiddenCombo = new System.Windows.Forms.ComboBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.noInvoiceTextBox = new System.Windows.Forms.TextBox();
            this.PODtPicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.PODtPicker_2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.displayButton = new System.Windows.Forms.Button();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newInvoiceButton = new System.Windows.Forms.Button();
            this.dataPenerimaanBarang = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPenerimaanBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // customerHiddenCombo
            // 
            this.customerHiddenCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerHiddenCombo.FormattingEnabled = true;
            this.customerHiddenCombo.Location = new System.Drawing.Point(566, 273);
            this.customerHiddenCombo.Name = "customerHiddenCombo";
            this.customerHiddenCombo.Size = new System.Drawing.Size(311, 26);
            this.customerHiddenCombo.TabIndex = 66;
            this.customerHiddenCombo.Visible = false;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(400, 95);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(187, 37);
            this.newButton.TabIndex = 65;
            this.newButton.Text = "NEW INVOICE";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(402, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tanggal Invoice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "No Invoice";
            // 
            // noInvoiceTextBox
            // 
            this.noInvoiceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.noInvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noInvoiceTextBox.Location = new System.Drawing.Point(130, 21);
            this.noInvoiceTextBox.Name = "noInvoiceTextBox";
            this.noInvoiceTextBox.Size = new System.Drawing.Size(257, 27);
            this.noInvoiceTextBox.TabIndex = 36;
            // 
            // PODtPicker_1
            // 
            this.PODtPicker_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_1.Location = new System.Drawing.Point(556, 21);
            this.PODtPicker_1.Name = "PODtPicker_1";
            this.PODtPicker_1.Size = new System.Drawing.Size(144, 27);
            this.PODtPicker_1.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(706, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "-";
            // 
            // PODtPicker_2
            // 
            this.PODtPicker_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_2.Location = new System.Drawing.Point(726, 21);
            this.PODtPicker_2.Name = "PODtPicker_2";
            this.PODtPicker_2.Size = new System.Drawing.Size(145, 27);
            this.PODtPicker_2.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Customer";
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(393, 104);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 64;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // customerCombo
            // 
            this.customerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(130, 54);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(257, 26);
            this.customerCombo.TabIndex = 40;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.customerCombo_SelectedIndexChanged);
            // 
            // showAllCheckBox
            // 
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showAllCheckBox.Location = new System.Drawing.Point(130, 86);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(101, 22);
            this.showAllCheckBox.TabIndex = 47;
            this.showAllCheckBox.Text = "Show All";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newInvoiceButton);
            this.groupBox1.Controls.Add(this.showAllCheckBox);
            this.groupBox1.Controls.Add(this.customerCombo);
            this.groupBox1.Controls.Add(this.displayButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PODtPicker_2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PODtPicker_1);
            this.groupBox1.Controls.Add(this.noInvoiceTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 150);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // newInvoiceButton
            // 
            this.newInvoiceButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newInvoiceButton.Location = new System.Drawing.Point(504, 104);
            this.newInvoiceButton.Name = "newInvoiceButton";
            this.newInvoiceButton.Size = new System.Drawing.Size(146, 37);
            this.newInvoiceButton.TabIndex = 65;
            this.newInvoiceButton.Text = "NEW INVOICE";
            this.newInvoiceButton.UseVisualStyleBackColor = true;
            this.newInvoiceButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // dataPenerimaanBarang
            // 
            this.dataPenerimaanBarang.AllowUserToAddRows = false;
            this.dataPenerimaanBarang.AllowUserToDeleteRows = false;
            this.dataPenerimaanBarang.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPenerimaanBarang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataPenerimaanBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPenerimaanBarang.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataPenerimaanBarang.Location = new System.Drawing.Point(0, 159);
            this.dataPenerimaanBarang.MultiSelect = false;
            this.dataPenerimaanBarang.Name = "dataPenerimaanBarang";
            this.dataPenerimaanBarang.RowHeadersVisible = false;
            this.dataPenerimaanBarang.Size = new System.Drawing.Size(921, 478);
            this.dataPenerimaanBarang.TabIndex = 63;
            this.dataPenerimaanBarang.DoubleClick += new System.EventHandler(this.dataPenerimaanBarang_DoubleClick);
            this.dataPenerimaanBarang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataPenerimaanBarang_KeyDown);
            // 
            // dataSalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(920, 637);
            this.Controls.Add(this.customerHiddenCombo);
            this.Controls.Add(this.dataPenerimaanBarang);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "dataSalesInvoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA SALES INVOICE";
            this.Load += new System.EventHandler(this.dataSalesInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPenerimaanBarang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox customerHiddenCombo;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noInvoiceTextBox;
        private System.Windows.Forms.DateTimePicker PODtPicker_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker PODtPicker_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.ComboBox customerCombo;
        private System.Windows.Forms.CheckBox showAllCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button newInvoiceButton;
        private System.Windows.Forms.DataGridView dataPenerimaanBarang;
    }
}