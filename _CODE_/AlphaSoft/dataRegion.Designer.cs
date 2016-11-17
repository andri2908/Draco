namespace AlphaSoft
{
    partial class dataRegion
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
            this.cabangnonactiveoption = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.namaBranchTextbox = new System.Windows.Forms.TextBox();
            this.dataCabangGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataCabangGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cabangnonactiveoption
            // 
            this.cabangnonactiveoption.AutoSize = true;
            this.cabangnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cabangnonactiveoption.Location = new System.Drawing.Point(81, 54);
            this.cabangnonactiveoption.Name = "cabangnonactiveoption";
            this.cabangnonactiveoption.Size = new System.Drawing.Size(185, 19);
            this.cabangnonactiveoption.TabIndex = 39;
            this.cabangnonactiveoption.Text = "Tampilkan Region Non Aktif?";
            this.cabangnonactiveoption.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nama";
            // 
            // namaBranchTextbox
            // 
            this.namaBranchTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaBranchTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaBranchTextbox.Location = new System.Drawing.Point(81, 21);
            this.namaBranchTextbox.Name = "namaBranchTextbox";
            this.namaBranchTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaBranchTextbox.TabIndex = 37;
            this.namaBranchTextbox.TextChanged += new System.EventHandler(this.namaBranchTextbox_TextChanged);
            // 
            // dataCabangGridView
            // 
            this.dataCabangGridView.AllowUserToAddRows = false;
            this.dataCabangGridView.AllowUserToDeleteRows = false;
            this.dataCabangGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCabangGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataCabangGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataCabangGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataCabangGridView.Location = new System.Drawing.Point(0, 117);
            this.dataCabangGridView.MultiSelect = false;
            this.dataCabangGridView.Name = "dataCabangGridView";
            this.dataCabangGridView.ReadOnly = true;
            this.dataCabangGridView.RowHeadersVisible = false;
            this.dataCabangGridView.Size = new System.Drawing.Size(403, 431);
            this.dataCabangGridView.TabIndex = 35;
            this.dataCabangGridView.DoubleClick += new System.EventHandler(this.dataCabangGridView_DoubleClick);
            this.dataCabangGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataCabangGridView_KeyDown);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(19, 48);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 28);
            this.newButton.TabIndex = 38;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cabangnonactiveoption);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.namaBranchTextbox);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 90);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // dataRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(402, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataCabangGridView);
            this.MaximizeBox = false;
            this.Name = "dataRegion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA REGION";
            this.Activated += new System.EventHandler(this.dataRegion_Activated);
            this.Load += new System.EventHandler(this.dataRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataCabangGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cabangnonactiveoption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaBranchTextbox;
        private System.Windows.Forms.DataGridView dataCabangGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}