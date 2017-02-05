using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace AlphaSoft
{
    public partial class POSSearchProductForm : Form
    {
        private int originModuleID = 0;
        private int selectedProductID = 0;
        private string selectedkodeProduct = "";
        private string selectedProductName = "";
        private int selectedRowIndex = -1;

        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        private cashierForm parentCashierForm;
        private dataReturPenjualanForm parentReturJualForm;
        private dataReturPermintaanForm parentReturBeliForm;
        private penerimaanBarangForm parentPenerimaanBarangForm;
        private permintaanProdukForm parentPermintaanProdukForm;
        private purchaseOrderDetailForm parentPurchaseOrderForm;

        public POSSearchProductForm()
        {
            InitializeComponent();
        }

        public POSSearchProductForm(int moduleID, cashierForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentCashierForm = thisParentForm;
        }

        public POSSearchProductForm(int moduleID, cashierForm thisParentForm, string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentCashierForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            
            namaProdukTextBox.Text = productName;
            selectedRowIndex = rowIndex;
        }

        public POSSearchProductForm(int moduleID, dataReturPenjualanForm thisParentForm, string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentReturJualForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only

            namaProdukTextBox.Text = productName;
            selectedRowIndex = rowIndex;
        }

        public POSSearchProductForm(int moduleID, dataReturPermintaanForm thisParentForm, string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentReturBeliForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only

            namaProdukTextBox.Text = productName;
            selectedRowIndex = rowIndex;
        }

        public POSSearchProductForm(int moduleID, penerimaanBarangForm thisParentForm, string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPenerimaanBarangForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only

            namaProdukTextBox.Text = productName;
            selectedRowIndex = rowIndex;
        }

        public POSSearchProductForm(int moduleID, permintaanProdukForm thisParentForm, string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPermintaanProdukForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only

            namaProdukTextBox.Text = productName;
            selectedRowIndex = rowIndex;
        }

        public POSSearchProductForm(int moduleID, purchaseOrderDetailForm thisParentForm, string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPurchaseOrderForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only

            namaProdukTextBox.Text = productName;
            selectedRowIndex = rowIndex;
        }

        private void loadProdukData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string namaProductParam = "";
            string kodeProductParam = "";
            int locationID = 0;

            DS.mySqlConnect();

            namaProductParam = MySqlHelper.EscapeString(namaProdukTextBox.Text);
            locationID = gutil.loadlocationID(2);

            sqlCommand = "SELECT PRODUCT_PHOTO_1, ID, PRODUCT_ID AS 'PRODUK ID', PRODUCT_NAME AS 'NAMA PRODUK', PRODUCT_DESCRIPTION AS 'DESKRIPSI PRODUK' FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_IS_SERVICE = 0 AND PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND PRODUCT_NAME LIKE '%" + namaProductParam + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataProdukGridView.DataSource = dt;

                    dataProdukGridView.Columns["ID"].Visible = false;
                    dataProdukGridView.Columns["PRODUCT_PHOTO_1"].Visible = false;
                    
                    dataProdukGridView.Columns["PRODUK ID"].Visible = false;
                    dataProdukGridView.Columns["NAMA PRODUK"].Width = 200;
                    dataProdukGridView.Columns["DESKRIPSI PRODUK"].Width = 300;
                }
            }
        }

        private void namaProdukTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dataProdukGridView.Focus();
            }
        }

        private void executeSpecificForm(string selectedkodeProduct, string selectedProductName, int selectedRowIndex)
        {
            switch (originModuleID)
            {
                case globalConstants.CASHIER_MODULE:
                    parentCashierForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    break;

                case globalConstants.RETUR_PENJUALAN:
                    parentReturJualForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    break;

                case globalConstants.RETUR_PEMBELIAN:
                    parentReturBeliForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    break;

                case globalConstants.PENERIMAAN_BARANG:
                    parentPenerimaanBarangForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    break;

                case globalConstants.PERMINTAAN_BARANG:
                    parentPermintaanProdukForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    break;

                case globalConstants.PURCHASE_ORDER_DARI_RO:
                    parentPurchaseOrderForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    break;
            }

        }

        private void dataProdukGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataProdukGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
            selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            selectedProductName = selectedRow.Cells["NAMA PRODUK"].Value.ToString();
            selectedkodeProduct = selectedRow.Cells["PRODUK ID"].Value.ToString();

            executeSpecificForm(selectedkodeProduct, selectedProductName, selectedRowIndex);

            this.Close();
        }

        private void dataProdukGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // Enter
            {
                if (dataProdukGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
                selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                selectedProductName = selectedRow.Cells["NAMA PRODUK"].Value.ToString();
                selectedkodeProduct = selectedRow.Cells["PRODUK ID"].Value.ToString();

                executeSpecificForm(selectedkodeProduct, selectedProductName, selectedRowIndex);

                this.Close();
            }
        }

        private void dataProdukGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string selectedProductPhoto = "";

            if (!dataProdukGridView.Focused)
                return;

            if (dataProdukGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];

            selectedProductPhoto = selectedRow.Cells["PRODUCT_PHOTO_1"].Value.ToString();

            if (selectedProductPhoto.Length > 0)
            {
                string imagePath = Application.StartupPath + "\\PRODUCT_PHOTO\\" + selectedProductPhoto;

                try
                {
                    panelImage.BackgroundImageLayout = ImageLayout.Stretch;
                    panelImage.BackgroundImage = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    gutil.saveSystemDebugLog(0, "[POS SEARCH PRODUCT] " + ex.Message);
                    //MessageBox.Show(ex.Message);
                }
            }
            else
            {
                panelImage.BackgroundImage = null;
            }

        }

        private void namaProdukTextBox_TextChanged(object sender, EventArgs e)
        {
            loadProdukData();
        }
    }
}
