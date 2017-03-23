namespace AlphaSoft
{
    partial class POSSearchProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.dataProdukGridView = new System.Windows.Forms.DataGridView();
            this.panelImage = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nama Produk";
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(145, 29);
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(260, 27);
            this.namaProdukTextBox.TabIndex = 37;
            this.namaProdukTextBox.TextChanged += new System.EventHandler(this.namaProdukTextBox_TextChanged);
            this.namaProdukTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.namaProdukTextBox_KeyPress);
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
            this.dataProdukGridView.Location = new System.Drawing.Point(1, 88);
            this.dataProdukGridView.MultiSelect = false;
            this.dataProdukGridView.Name = "dataProdukGridView";
            this.dataProdukGridView.ReadOnly = true;
            this.dataProdukGridView.RowHeadersVisible = false;
            this.dataProdukGridView.Size = new System.Drawing.Size(416, 351);
            this.dataProdukGridView.TabIndex = 39;
            this.dataProdukGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProdukGridView_CellEnter);
            this.dataProdukGridView.DoubleClick += new System.EventHandler(this.dataProdukGridView_DoubleClick);
            this.dataProdukGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataProdukGridView_KeyDown);
            // 
            // panelImage
            // 
            this.panelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImage.Location = new System.Drawing.Point(432, 149);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(219, 175);
            this.panelImage.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(429, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "Gambar Produk";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(432, 32);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(86, 27);
            this.newButton.TabIndex = 43;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // POSSearchProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(672, 441);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelImage);
            this.Controls.Add(this.dataProdukGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaProdukTextBox);
            this.MaximizeBox = false;
            this.Name = "POSSearchProductForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nama Produk";
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.DataGridView dataProdukGridView;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newButton;
    }
}