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
    public partial class stokTransferForm : Form
    {
        string selectedAsalLocation = "1";
        string selectedTujuanLocation = "2";
        string selectedProductID = "0";
        Data_Access DS = new Data_Access();
        globalUtilities gUtil = new globalUtilities();

        public stokTransferForm()
        {
            InitializeComponent();
        }

        private void loadLocationCombo()
        {
            // HARCODED FOR BINTANG TIMUR   
            asalCombo.Items.Add("TOKO");
            asalCombo.Items.Add("GUDANG");

            asalComboHidden.Items.Add("1");
            asalComboHidden.Items.Add("2");

            tujuanCombo.Items.Add("TOKO");
            tujuanCombo.Items.Add("GUDANG");

            tujuanComboHidden.Items.Add("1");
            tujuanComboHidden.Items.Add("2");
        }

        private void stokTransferForm_Load(object sender, EventArgs e)
        {
            loadLocationCombo();
        }

        private void loadLocationData(string namaProduk, DataGridView displayDataGrid, string locationID)
        {
            string sqlCommand = "";
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            sqlCommand = "SELECT MP.PRODUCT_ID, MP.PRODUCT_NAME AS 'NAMA PRODUK', PL.PRODUCT_LOCATION_QTY AS 'QTY' FROM MASTER_PRODUCT MP, PRODUCT_LOCATION PL " +
                                   "WHERE MP.PRODUCT_NAME LIKE '%" + namaProduk + "%' AND PL.LOCATION_ID = " + locationID + " AND PL.PRODUCT_ID = MP.PRODUCT_ID AND PL.PRODUCT_LOCATION_QTY > 0";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    displayDataGrid.DataSource = dt;

                    displayDataGrid.Columns["PRODUCT_ID"].Visible = false;
                    displayDataGrid.Columns["NAMA PRODUK"].Width = 200;
                    displayDataGrid.Columns["QTY"].Width = 100;
                }
            }
        }

        private void namaProdukTextBox_TextChanged(object sender, EventArgs e)
        {
            if (asalCombo.Text != "" && namaProdukTextBox.Text != "")
            {
                loadLocationData(namaProdukTextBox.Text, asalDataGrid, selectedAsalLocation);
            }
        }

        private void asalCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAsalLocation = asalComboHidden.Items[asalCombo.SelectedIndex].ToString();
        }

        private void tujuanCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTujuanLocation = tujuanComboHidden.Items[tujuanCombo.SelectedIndex].ToString();
        }

        private void asalDataGrid_DoubleClick(object sender, EventArgs e)
        {
            if (asalDataGrid.Rows.Count <= 0)
                return;

            int selectedrowindex = asalDataGrid.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = asalDataGrid.Rows[selectedrowindex];
            selectedProductID = selectedRow.Cells["PRODUCT_ID"].Value.ToString();

            labelNamaBarang.Text = gUtil.getProductName(selectedProductID);
        }

        private bool dataValidated()
        {
            if (selectedProductID == "0")
            {
                errorLabel.Text = "PRODUK BELUM DIPILIH";
                return false;
            }

            if (asalCombo.Text == "")
            {
                errorLabel.Text = "ASAL BELUM DIPILIH";
                return false;
            }

            if (tujuanCombo.Text == "")
            {
                errorLabel.Text = "TUJUAN BELUM DIPILIH";
                return false;
            }

            if (tujuanCombo.Text == asalCombo.Text)
            {
                errorLabel.Text = "ASAL DAN TUJUAN TIDAK BOLEH SAMA";
                return false;
            }

            if (jumlahTextBox.Text == "")
            {
                errorLabel.Text = "JUMLAH TIDAK BOLEH NOL";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                sqlCommand = "UPDATE PRODUCT_LOCATION SET PRODUCT_LOCATION_QTY = PRODUCT_LOCATION_QTY + " + jumlahTextBox.Text + " WHERE LOCATION_ID = " + selectedTujuanLocation + " AND PRODUCT_ID = " + selectedProductID;

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                sqlCommand = "UPDATE PRODUCT_LOCATION SET PRODUCT_LOCATION_QTY = PRODUCT_LOCATION_QTY - " + jumlahTextBox.Text + " WHERE LOCATION_ID = " + selectedAsalLocation + " AND PRODUCT_ID = " + selectedProductID;

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "INSERT");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private bool saveData()
        {
            bool result = false;

            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("SUCCESS");
                loadLocationData(namaProdukTextBox.Text, asalDataGrid, selectedAsalLocation);
            }
        }
    }
}
