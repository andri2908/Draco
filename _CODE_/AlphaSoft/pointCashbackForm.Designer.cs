namespace AlphaSoft
{
    partial class pointCashbackForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.currPointTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointValue = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentPoint = new System.Windows.Forms.Label();
            this.maxPoint = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cashbackValue = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 29);
            this.panel1.TabIndex = 27;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 6);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 25;
            this.errorLabel.Text = "   ";
            // 
            // currPointTitle
            // 
            this.currPointTitle.AutoSize = true;
            this.currPointTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currPointTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currPointTitle.Location = new System.Drawing.Point(74, 49);
            this.currPointTitle.Name = "currPointTitle";
            this.currPointTitle.Size = new System.Drawing.Size(163, 18);
            this.currPointTitle.TabIndex = 28;
            this.currPointTitle.Text = "POIN YANG ADA :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "MAX PENUKARAN POIN :";
            // 
            // pointValue
            // 
            this.pointValue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointValue.Location = new System.Drawing.Point(239, 103);
            this.pointValue.Mask = "000000000000";
            this.pointValue.Name = "pointValue";
            this.pointValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pointValue.Size = new System.Drawing.Size(149, 27);
            this.pointValue.TabIndex = 30;
            this.pointValue.Text = "0";
            this.pointValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pointValue.ValidatingType = typeof(int);
            this.pointValue.TextChanged += new System.EventHandler(this.pointValue_TextChanged);
            this.pointValue.Enter += new System.EventHandler(this.pointValue_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(23, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "POIN YANG DITUKAR  :";
            // 
            // currentPoint
            // 
            this.currentPoint.AutoSize = true;
            this.currentPoint.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPoint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currentPoint.Location = new System.Drawing.Point(236, 49);
            this.currentPoint.Name = "currentPoint";
            this.currentPoint.Size = new System.Drawing.Size(41, 18);
            this.currentPoint.TabIndex = 32;
            this.currentPoint.Text = "100";
            // 
            // maxPoint
            // 
            this.maxPoint.AutoSize = true;
            this.maxPoint.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPoint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.maxPoint.Location = new System.Drawing.Point(236, 76);
            this.maxPoint.Name = "maxPoint";
            this.maxPoint.Size = new System.Drawing.Size(41, 18);
            this.maxPoint.TabIndex = 33;
            this.maxPoint.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(118, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "CASHBACK  :";
            // 
            // cashbackValue
            // 
            this.cashbackValue.AutoSize = true;
            this.cashbackValue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashbackValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cashbackValue.Location = new System.Drawing.Point(236, 135);
            this.cashbackValue.Name = "cashbackValue";
            this.cashbackValue.Size = new System.Drawing.Size(19, 18);
            this.cashbackValue.TabIndex = 35;
            this.cashbackValue.Text = "0";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(170, 173);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 36;
            this.saveButton.Text = "TUKAR";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pointCashbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(434, 222);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cashbackValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxPoint);
            this.Controls.Add(this.currentPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pointValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currPointTitle);
            this.Controls.Add(this.panel1);
            this.Name = "pointCashbackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASHBACK FORM";
            this.Load += new System.EventHandler(this.pointCashbackForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label currPointTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox pointValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentPoint;
        private System.Windows.Forms.Label maxPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cashbackValue;
        private System.Windows.Forms.Button saveButton;
    }
}