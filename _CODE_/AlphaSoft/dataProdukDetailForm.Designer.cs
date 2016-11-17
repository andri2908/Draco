namespace AlphaSoft
{
    partial class dataProdukDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataProdukDetailForm));
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.produkJasaCheckbox = new System.Windows.Forms.CheckBox();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelImage = new System.Windows.Forms.Panel();
            this.nonAktifCheckbox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.stokAwalTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.limitStokTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.merkTextBox = new System.Windows.Forms.TextBox();
            this.searchUnitButton = new System.Windows.Forms.Button();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.produkKategoriTextBox = new System.Windows.Forms.TextBox();
            this.searchKategoriButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.produkDescTextBox = new System.Windows.Forms.TextBox();
            this.hppTextBox = new System.Windows.Forms.TextBox();
            this.hargaEcerTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.hargaPartaiTextBox = new System.Windows.Forms.TextBox();
            this.hargaGrosirTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.detailLokasiDataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.resetbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.detailLokasiDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(11, 420);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(167, 18);
            this.label15.TabIndex = 77;
            this.label15.Text = "GAMBAR PRODUK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "NAMA";
            // 
            // produkJasaCheckbox
            // 
            this.produkJasaCheckbox.AutoSize = true;
            this.produkJasaCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkJasaCheckbox.Location = new System.Drawing.Point(242, 57);
            this.produkJasaCheckbox.Name = "produkJasaCheckbox";
            this.produkJasaCheckbox.Size = new System.Drawing.Size(238, 17);
            this.produkJasaCheckbox.TabIndex = 34;
            this.produkJasaCheckbox.Text = "Produk Jasa / Servis (non-inventory)";
            this.produkJasaCheckbox.UseVisualStyleBackColor = true;
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(242, 27);
            this.namaProdukTextBox.MaxLength = 50;
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(620, 27);
            this.namaProdukTextBox.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(342, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 30);
            this.button1.TabIndex = 39;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelImage
            // 
            this.panelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImage.Location = new System.Drawing.Point(242, 419);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(94, 79);
            this.panelImage.TabIndex = 40;
            // 
            // nonAktifCheckbox
            // 
            this.nonAktifCheckbox.AutoSize = true;
            this.nonAktifCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonAktifCheckbox.Location = new System.Drawing.Point(384, 419);
            this.nonAktifCheckbox.Name = "nonAktifCheckbox";
            this.nonAktifCheckbox.Size = new System.Drawing.Size(164, 22);
            this.nonAktifCheckbox.TabIndex = 51;
            this.nonAktifCheckbox.Text = "Non Aktif Produk";
            this.nonAktifCheckbox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(11, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "JUMLAH STOK AWAL";
            // 
            // stokAwalTextBox
            // 
            this.stokAwalTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stokAwalTextBox.Location = new System.Drawing.Point(242, 212);
            this.stokAwalTextBox.Name = "stokAwalTextBox";
            this.stokAwalTextBox.ReadOnly = true;
            this.stokAwalTextBox.Size = new System.Drawing.Size(161, 27);
            this.stokAwalTextBox.TabIndex = 71;
            this.stokAwalTextBox.Text = "0";
            this.stokAwalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stokAwalTextBox.TextChanged += new System.EventHandler(this.stokAwalTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(477, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(203, 18);
            this.label13.TabIndex = 70;
            this.label13.Text = "JUMLAH LIMIT STOK :";
            // 
            // limitStokTextBox
            // 
            this.limitStokTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitStokTextBox.Location = new System.Drawing.Point(686, 212);
            this.limitStokTextBox.Name = "limitStokTextBox";
            this.limitStokTextBox.Size = new System.Drawing.Size(176, 27);
            this.limitStokTextBox.TabIndex = 72;
            this.limitStokTextBox.Text = "0";
            this.limitStokTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limitStokTextBox.TextChanged += new System.EventHandler(this.limitStokTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(11, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "MERK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(11, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "SATUAN UNIT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(11, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "KATEGORI ";
            // 
            // merkTextBox
            // 
            this.merkTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.merkTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.merkTextBox.Location = new System.Drawing.Point(242, 179);
            this.merkTextBox.MaxLength = 50;
            this.merkTextBox.Name = "merkTextBox";
            this.merkTextBox.Size = new System.Drawing.Size(287, 27);
            this.merkTextBox.TabIndex = 17;
            // 
            // searchUnitButton
            // 
            this.searchUnitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchUnitButton.BackgroundImage")));
            this.searchUnitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchUnitButton.Location = new System.Drawing.Point(535, 147);
            this.searchUnitButton.Name = "searchUnitButton";
            this.searchUnitButton.Size = new System.Drawing.Size(23, 25);
            this.searchUnitButton.TabIndex = 38;
            this.searchUnitButton.UseVisualStyleBackColor = true;
            this.searchUnitButton.Click += new System.EventHandler(this.searchUnitButton_Click);
            // 
            // unitTextBox
            // 
            this.unitTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitTextBox.Location = new System.Drawing.Point(242, 146);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.ReadOnly = true;
            this.unitTextBox.Size = new System.Drawing.Size(287, 27);
            this.unitTextBox.TabIndex = 17;
            // 
            // produkKategoriTextBox
            // 
            this.produkKategoriTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkKategoriTextBox.Location = new System.Drawing.Point(242, 113);
            this.produkKategoriTextBox.Name = "produkKategoriTextBox";
            this.produkKategoriTextBox.ReadOnly = true;
            this.produkKategoriTextBox.Size = new System.Drawing.Size(489, 27);
            this.produkKategoriTextBox.TabIndex = 17;
            // 
            // searchKategoriButton
            // 
            this.searchKategoriButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchKategoriButton.BackgroundImage")));
            this.searchKategoriButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchKategoriButton.Location = new System.Drawing.Point(737, 113);
            this.searchKategoriButton.Name = "searchKategoriButton";
            this.searchKategoriButton.Size = new System.Drawing.Size(24, 24);
            this.searchKategoriButton.TabIndex = 18;
            this.searchKategoriButton.UseVisualStyleBackColor = true;
            this.searchKategoriButton.Click += new System.EventHandler(this.searchKategoriButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(767, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 24);
            this.button2.TabIndex = 19;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(11, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 73;
            this.label8.Text = "DESKRIPSI";
            // 
            // produkDescTextBox
            // 
            this.produkDescTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.produkDescTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkDescTextBox.Location = new System.Drawing.Point(242, 80);
            this.produkDescTextBox.MaxLength = 100;
            this.produkDescTextBox.Name = "produkDescTextBox";
            this.produkDescTextBox.Size = new System.Drawing.Size(620, 27);
            this.produkDescTextBox.TabIndex = 33;
            // 
            // hppTextBox
            // 
            this.hppTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hppTextBox.Location = new System.Drawing.Point(242, 353);
            this.hppTextBox.Name = "hppTextBox";
            this.hppTextBox.Size = new System.Drawing.Size(159, 27);
            this.hppTextBox.TabIndex = 49;
            this.hppTextBox.Text = "0";
            this.hppTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hppTextBox.TextChanged += new System.EventHandler(this.hppTextBox_TextChanged);
            // 
            // hargaEcerTextBox
            // 
            this.hargaEcerTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaEcerTextBox.Location = new System.Drawing.Point(703, 353);
            this.hargaEcerTextBox.Name = "hargaEcerTextBox";
            this.hargaEcerTextBox.Size = new System.Drawing.Size(159, 27);
            this.hargaEcerTextBox.TabIndex = 49;
            this.hargaEcerTextBox.Text = "0";
            this.hargaEcerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hargaEcerTextBox.TextChanged += new System.EventHandler(this.hargaEcerTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(514, 356);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 18);
            this.label11.TabIndex = 27;
            this.label11.Text = "HARGA JUAL ECER :";
            // 
            // hargaPartaiTextBox
            // 
            this.hargaPartaiTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaPartaiTextBox.Location = new System.Drawing.Point(242, 386);
            this.hargaPartaiTextBox.Name = "hargaPartaiTextBox";
            this.hargaPartaiTextBox.Size = new System.Drawing.Size(159, 27);
            this.hargaPartaiTextBox.TabIndex = 49;
            this.hargaPartaiTextBox.Text = "0";
            this.hargaPartaiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hargaPartaiTextBox.TextChanged += new System.EventHandler(this.hargaPartaiTextBox_TextChanged);
            // 
            // hargaGrosirTextBox
            // 
            this.hargaGrosirTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaGrosirTextBox.Location = new System.Drawing.Point(703, 386);
            this.hargaGrosirTextBox.Name = "hargaGrosirTextBox";
            this.hargaGrosirTextBox.Size = new System.Drawing.Size(159, 27);
            this.hargaGrosirTextBox.TabIndex = 49;
            this.hargaGrosirTextBox.Text = "0";
            this.hargaGrosirTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hargaGrosirTextBox.TextChanged += new System.EventHandler(this.hargaGrosirTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(489, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 18);
            this.label7.TabIndex = 72;
            this.label7.Text = "HARGA JUAL GROSIR :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(11, 389);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 18);
            this.label14.TabIndex = 64;
            this.label14.Text = "HARGA JUAL PARTAI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(11, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "HARGA POKOK (HPP)";
            // 
            // detailLokasiDataGridView
            // 
            this.detailLokasiDataGridView.AllowUserToAddRows = false;
            this.detailLokasiDataGridView.AllowUserToDeleteRows = false;
            this.detailLokasiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailLokasiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.locationName,
            this.locationQty});
            this.detailLokasiDataGridView.Location = new System.Drawing.Point(242, 249);
            this.detailLokasiDataGridView.Name = "detailLokasiDataGridView";
            this.detailLokasiDataGridView.RowHeadersVisible = false;
            this.detailLokasiDataGridView.Size = new System.Drawing.Size(620, 98);
            this.detailLokasiDataGridView.TabIndex = 78;
            // 
            // ID
            // 
            this.ID.HeaderText = "locationID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // locationName
            // 
            this.locationName.HeaderText = "NAMA LOKASI";
            this.locationName.Name = "locationName";
            this.locationName.ReadOnly = true;
            this.locationName.Width = 300;
            // 
            // locationQty
            // 
            this.locationQty.HeaderText = "JUMLAH";
            this.locationQty.Name = "locationQty";
            this.locationQty.Width = 200;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(319, 521);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, -37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 29);
            this.panel1.TabIndex = 10;
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
            this.errorLabel.TabIndex = 26;
            this.errorLabel.Text = "   ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // resetbutton
            // 
            this.resetbutton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbutton.Location = new System.Drawing.Point(464, 521);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(95, 37);
            this.resetbutton.TabIndex = 11;
            this.resetbutton.Text = "RESET";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.hppTextBox);
            this.groupBox1.Controls.Add(this.resetbutton);
            this.groupBox1.Controls.Add(this.hargaEcerTextBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nonAktifCheckbox);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.hargaGrosirTextBox);
            this.groupBox1.Controls.Add(this.panelImage);
            this.groupBox1.Controls.Add(this.hargaPartaiTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.limitStokTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.stokAwalTextBox);
            this.groupBox1.Controls.Add(this.merkTextBox);
            this.groupBox1.Controls.Add(this.searchUnitButton);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.unitTextBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.searchKategoriButton);
            this.groupBox1.Controls.Add(this.produkKategoriTextBox);
            this.groupBox1.Controls.Add(this.produkDescTextBox);
            this.groupBox1.Controls.Add(this.namaProdukTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.produkJasaCheckbox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.detailLokasiDataGridView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 572);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATA PRODUK";
            // 
            // dataProdukDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(880, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataProdukDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA PRODUK ";
            this.Activated += new System.EventHandler(this.dataProdukDetailForm_Activated);
            this.Load += new System.EventHandler(this.dataProdukDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailLokasiDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox produkJasaCheckbox;
        private System.Windows.Forms.Button searchKategoriButton;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox merkTextBox;
        private System.Windows.Forms.TextBox hargaEcerTextBox;
        private System.Windows.Forms.TextBox hppTextBox;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.TextBox produkKategoriTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button searchUnitButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox produkDescTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.TextBox hargaPartaiTextBox;
        private System.Windows.Forms.TextBox hargaGrosirTextBox;
        private System.Windows.Forms.TextBox stokAwalTextBox;
        private System.Windows.Forms.TextBox limitStokTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox nonAktifCheckbox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.DataGridView detailLokasiDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationQty;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}