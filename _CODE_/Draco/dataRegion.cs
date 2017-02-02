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
    public partial class dataRegion : Form
    {
        private int selectedRegionID = 0;
        private int originModuleID = 0;

        private Data_Access DS = new Data_Access();

        private globalUtilities gutil = new globalUtilities();

        public dataRegion()
        {
            InitializeComponent();
        }

        private void loadRegionData(string regionNameParam)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string regionName = MySqlHelper.EscapeString(regionNameParam);

            DS.mySqlConnect();
            if (cabangnonactiveoption.Checked)
            {
                sqlCommand = "SELECT ID, REGION_NAME AS 'NAMA REGION', REGION_DESCRIPTION AS 'DESKRIPSI' FROM MASTER_REGION WHERE REGION_NAME LIKE '%" + regionName + "%'";
            }
            else
            {
                sqlCommand = "SELECT ID, REGION_NAME AS 'NAMA REGION', REGION_DESCRIPTION AS 'DESKRIPSI' FROM MASTER_REGION WHERE REGION_ACTIVE = 1 AND REGION_NAME LIKE '%" + regionName + "%'";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataCabangGridView.DataSource = dt;

                    dataCabangGridView.Columns["ID"].Visible = false;
                    dataCabangGridView.Columns["NAMA REGION"].Width = 200;
                    dataCabangGridView.Columns["DESKRIPSI"].Width = 200;
                }
            }
        }

        private void dataRegion_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PELANGGAN, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            namaBranchTextbox.Select();
        }

        private void namaBranchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaBranchTextbox.Text.Equals(""))
                loadRegionData(namaBranchTextbox.Text);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataRegionDetail displayedForm = new dataRegionDetail(globalConstants.NEW_REGION, 0);
            displayedForm.ShowDialog(this);
            dataCabangGridView.DataSource = null;

            if (!namaBranchTextbox.Text.Equals(""))
                loadRegionData(namaBranchTextbox.Text);
        }

        private void dataCabangGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataCabangGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataCabangGridView.Rows[selectedrowindex];
            selectedRegionID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            dataRegionDetail displayedForm = new dataRegionDetail(globalConstants.EDIT_REGION, selectedRegionID);
            displayedForm.ShowDialog(this);
        }

        private void dataRegion_Activated(object sender, EventArgs e)
        {
            if (!namaBranchTextbox.Text.Equals(""))
                loadRegionData(namaBranchTextbox.Text);
        }

        private void dataCabangGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = dataCabangGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataCabangGridView.Rows[selectedrowindex];
                selectedRegionID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                gutil.saveSystemDebugLog(0, "CREATE DATA REGION DETAIL, REGION ID [" + selectedRegionID + "]");
                dataRegionDetail displayedForm = new dataRegionDetail(globalConstants.EDIT_REGION, selectedRegionID);
                displayedForm.ShowDialog(this);
            }
        }
    }
}
