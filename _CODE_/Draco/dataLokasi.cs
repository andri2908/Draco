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
    public partial class dataLokasi : Form
    {
        private int selectedLocationID = 0;
        private int originModuleID = 0;
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        public dataLokasi()
        {
            InitializeComponent();
        }

        private void loadLocationData(string locationNameParam)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string locationName = MySqlHelper.EscapeString(locationNameParam);

            DS.mySqlConnect();
            if (locationNonActiveOption.Checked)
            {
                sqlCommand = "SELECT ID, LOCATION_NAME AS 'NAMA LOKASI', LOCATION_DESCRIPTION AS 'DESKRIPSI', LOCATION_TOTAL_QTY AS 'TOTAL QTY' FROM MASTER_LOCATION WHERE LOCATION_NAME LIKE '%" + locationName + "%'";
            }
            else
            {
                sqlCommand = "SELECT ID, LOCATION_NAME AS 'NAMA LOKASI', LOCATION_DESCRIPTION AS 'DESKRIPSI', LOCATION_TOTAL_QTY AS 'TOTAL QTY' FROM MASTER_LOCATION WHERE LOCATION_ACTIVE = 1 AND LOCATION_NAME LIKE '%" + locationName + "%'";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataCabangGridView.DataSource = dt;

                    dataCabangGridView.Columns["ID"].Visible = false;
                    dataCabangGridView.Columns["NAMA LOKASI"].Width = 200;
                    dataCabangGridView.Columns["DESKRIPSI"].Width = 200;
                }
            }
        }

        private void dataLokasi_Load(object sender, EventArgs e)
        {
            namaBranchTextbox.Select();
        }

        private void namaBranchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaBranchTextbox.Text.Equals(""))
                loadLocationData(namaBranchTextbox.Text);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataLokasiDetail displayedForm = new dataLokasiDetail(globalConstants.NEW_LOCATION, 0);
            displayedForm.ShowDialog(this);
            dataCabangGridView.DataSource = null;

            if (!namaBranchTextbox.Text.Equals(""))
                loadLocationData(namaBranchTextbox.Text);

            if (namaBranchTextbox.Text.Length > 0)
                loadLocationData(namaBranchTextbox.Text);
        }

        private void dataCabangGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataCabangGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataCabangGridView.Rows[selectedrowindex];
            selectedLocationID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            dataLokasiDetail displayedForm = new dataLokasiDetail(globalConstants.EDIT_LOCATION, selectedLocationID);
            displayedForm.ShowDialog(this);

            if (namaBranchTextbox.Text.Length > 0)
                loadLocationData(namaBranchTextbox.Text);
        }

        private void dataLokasi_Activated(object sender, EventArgs e)
        {
            if (namaBranchTextbox.Text.Length > 0)
                loadLocationData(namaBranchTextbox.Text);
        }

        private void dataLokasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = dataCabangGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataCabangGridView.Rows[selectedrowindex];
                selectedLocationID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                gutil.saveSystemDebugLog(0, "CREATE DATA LOKASI DETAIL, LOKASI ID [" + selectedLocationID + "]");
                dataLokasiDetail displayedForm = new dataLokasiDetail(globalConstants.EDIT_REGION, selectedLocationID);
                displayedForm.ShowDialog(this);

                if (namaBranchTextbox.Text.Length > 0)
                    loadLocationData(namaBranchTextbox.Text);
            }
        }
    }
}
