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
    public partial class dataRegionDetail : Form
    {
        private int selectedRegionID = 0;
        private int originModuleID = 0;
        private int options = 0;

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        public dataRegionDetail()
        {
            InitializeComponent();
        }

        public dataRegionDetail(int moduleID, int regionID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedRegionID = regionID;
        }

        private void loadRegionDataInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_REGION WHERE ID = " + selectedRegionID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        namaGroupTextBox.Text = rdr.GetString("REGION_NAME");
                        deskripsiTextBox.Text = rdr.GetString("REGION_DESCRIPTION");

                        if (rdr.GetString("REGION_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private bool dataValidated()
        {
            if (namaGroupTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA REGION TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string regionName = MySqlHelper.EscapeString(namaGroupTextBox.Text.Trim());
            string regionDesc = MySqlHelper.EscapeString(deskripsiTextBox.Text.Trim());
            byte regionStatus = 0;

            if (nonAktifCheckbox.Checked)
                regionStatus = 0;
            else
                regionStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_REGION:
                        sqlCommand = "INSERT INTO MASTER_REGION (REGION_NAME, REGION_DESCRIPTION, REGION_ACTIVE) VALUES ('" + regionName + "', '" + regionDesc + "', " + regionStatus + ")";
                        break;
                    case globalConstants.EDIT_REGION:
                        sqlCommand = "UPDATE MASTER_REGION SET REGION_NAME = '" + regionName + "', REGION_DESCRIPTION = '" + regionDesc + "', REGION_ACTIVE = " + regionStatus + " WHERE ID = " + selectedRegionID;
                        break;
                }

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
                        gutil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gutil.showDBOPError(e, "INSERT");
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
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                result = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                switch (originModuleID)
                {
                    case globalConstants.NEW_GROUP_USER:
                        gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_INSERT, "ADD NEW GROUP USER [" + namaGroupTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_GROUP_USER:
                        if (nonAktifCheckbox.Checked)
                            gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE GROUP USER [" + namaGroupTextBox.Text + "] GROUP STATUS NON-AKTIF");
                        else
                            gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE GROUP USER [" + namaGroupTextBox.Text + "] GROUP STATUS AKTIF");
                        break;
                }

                gutil.showSuccess(options);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void dataRegionDetail_Load(object sender, EventArgs e)
        {
            switch (originModuleID)
            {
                case (globalConstants.NEW_REGION):
                    options = gutil.INS;
                    nonAktifCheckbox.Enabled = false;
                    break;
                case (globalConstants.EDIT_REGION):
                    options = gutil.UPD;
                    nonAktifCheckbox.Enabled = true;
                    loadRegionDataInformation();
                    break;
            }
            errorLabel.Text = "";
        }
    }
}
