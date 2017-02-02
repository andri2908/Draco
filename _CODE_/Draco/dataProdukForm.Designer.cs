namespace AlphaSoft
{
    partial class dataProdukForm
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
            this.dataProdukGridView = new System.Windows.Forms.DataGridView();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.produknonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataProdukGridView
            // 
            this.dataProdukGridView.AllowUserToAddRows = false;
            this.dataProdukGridView.AllowUserToDeleteRows = false;
            this.dataProdukGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataProdukGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataProdukGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataProdukGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataProdukGridView.Location = new System.Drawing.Point(0, 116);
            this.dataProdukGridView.MultiSelect = false;
            this.dataProdukGridView.Name = "dataProdukGridView";
            this.dataProdukGridView.ReadOnly = true;
            this.dataProdukGridView.RowHeadersVisible = false;
            this.dataProdukGridView.Size = new System.Drawing.Size(669, 432);
            this.dataProdukGridView.TabIndex = 0;
            this.dataProdukGridView.DoubleClick += new System.EventHandler(this.tagProdukDataGridView_DoubleClick);
            this.dataProdukGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataProdukGridView_KeyDown);
            this.dataProdukGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tagProdukDataGridView_KeyPress);
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(139, 23);
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(260, 27);
            this.namaProdukTextBox.TabIndex = 6;
            this.namaProdukTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.namaProdukTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.namaProdukTextBox_KeyPress);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(417, 22);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 27);
            this.newButton.TabIndex = 7;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama Produk";
            // 
            // produknonactiveoption
            // 
            this.produknonactiveoption.AutoSize = true;
            this.produknonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produknonactiveoption.Location = new System.Drawing.Point(139, 55);
            this.produknonactiveoption.Name = "produknonactiveoption";
            this.produknonactiveoption.Size = new System.Drawing.Size(184, 19);
            this.produknonactiveoption.TabIndex = 35;
            this.produknonactiveoption.Text = "Tampilkan Produk Non Aktif?";
            this.produknonactiveoption.UseVisualStyleBackColor = true;
            this.produknonactiveoption.CheckedChanged += new System.EventHandler(this.produknonactiveoption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.namaProdukTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.produknonactiveoption);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(89, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 87);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // dataProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(669, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataProdukGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA PRODUK";
            this.Activated += new System.EventHandler(this.dataProdukForm_Activated);
            this.Load += new System.EventHandler(this.dataProdukForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataProdukGridView;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox produknonactiveoption;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}