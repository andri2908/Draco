namespace AlphaSoft
{
    partial class membershipPointViewer
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
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.membershipPointDataGrid = new System.Windows.Forms.DataGridView();
            this.customerComboHidden = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.membershipPointDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerCombo
            // 
            this.customerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(179, 20);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(257, 26);
            this.customerCombo.TabIndex = 42;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.customerCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(55, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "Customer";
            // 
            // membershipPointDataGrid
            // 
            this.membershipPointDataGrid.AllowUserToAddRows = false;
            this.membershipPointDataGrid.AllowUserToDeleteRows = false;
            this.membershipPointDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.membershipPointDataGrid.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.membershipPointDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.membershipPointDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.membershipPointDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.membershipPointDataGrid.Location = new System.Drawing.Point(1, 68);
            this.membershipPointDataGrid.MultiSelect = false;
            this.membershipPointDataGrid.Name = "membershipPointDataGrid";
            this.membershipPointDataGrid.RowHeadersVisible = false;
            this.membershipPointDataGrid.Size = new System.Drawing.Size(517, 478);
            this.membershipPointDataGrid.TabIndex = 64;
            // 
            // customerComboHidden
            // 
            this.customerComboHidden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerComboHidden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerComboHidden.FormattingEnabled = true;
            this.customerComboHidden.Location = new System.Drawing.Point(179, 100);
            this.customerComboHidden.Name = "customerComboHidden";
            this.customerComboHidden.Size = new System.Drawing.Size(257, 26);
            this.customerComboHidden.TabIndex = 65;
            this.customerComboHidden.Visible = false;
            // 
            // membershipPointViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(519, 546);
            this.Controls.Add(this.customerComboHidden);
            this.Controls.Add(this.membershipPointDataGrid);
            this.Controls.Add(this.customerCombo);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "membershipPointViewer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Membership Point Viewer";
            this.Load += new System.EventHandler(this.membershipPointViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.membershipPointDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView membershipPointDataGrid;
        private System.Windows.Forms.ComboBox customerComboHidden;
    }
}