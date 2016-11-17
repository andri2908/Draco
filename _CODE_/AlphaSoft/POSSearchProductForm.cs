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

        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        private cashierForm parentCashierForm;

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

        private void dataProdukGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataProdukGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
            selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            selectedProductName = selectedRow.Cells["NAMA PRODUK"].Value.ToString();
            selectedkodeProduct = selectedRow.Cells["PRODUK ID"].Value.ToString();

            parentCashierForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName);
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

                parentCashierForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName);
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
                    MessageBox.Show(ex.Message);
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
