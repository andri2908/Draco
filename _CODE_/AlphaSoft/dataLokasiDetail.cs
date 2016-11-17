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
    public partial class dataLokasiDetail : Form
    {
        private int selectedLocationID = 0;
        private int originModuleID = 0;
        private int options = 0;

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        public dataLokasiDetail(int moduleID, int locationID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedLocationID = locationID;
        }

        private void loadLocationDataInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT LOCATION_NAME, IFNULL(LOCATION_DESCRIPTION, '') AS LOCATION_DESCRIPTION, LOCATION_ACTIVE FROM MASTER_LOCATION WHERE ID = " + selectedLocationID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        namaGroupTextBox.Text = rdr.GetString("LOCATION_NAME");
                        deskripsiTextBox.Text = rdr.GetString("LOCATION_DESCRIPTION");

                        if (rdr.GetInt32("LOCATION_ACTIVE") == 1)
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
                errorLabel.Text = "NAMA LOKASI TIDAK BOLEH KOSONG";
                return false;
            }

            errorLabel.Text = "";

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
                    case globalConstants.NEW_LOCATION:
                        sqlCommand = "INSERT INTO MASTER_LOCATION (LOCATION_NAME, LOCATION_DESCRIPTION, LOCATION_ACTIVE) VALUES ('" + regionName + "', '" + regionDesc + "', " + regionStatus + ")";
                        break;
                    case globalConstants.EDIT_LOCATION:
                        sqlCommand = "UPDATE MASTER_LOCATION SET LOCATION_NAME = '" + regionName + "', LOCATION_DESCRIPTION= '" + regionDesc + "', LOCATION_ACTIVE = " + regionStatus + " WHERE ID = " + selectedLocationID;
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

        private void dataLokasiDetail_Load(object sender, EventArgs e)
        {
            switch (originModuleID)
            {
                case (globalConstants.NEW_LOCATION):
                    options = gutil.INS;
                    nonAktifCheckbox.Enabled = false;
                    break;
                case (globalConstants.EDIT_LOCATION):
                    options = gutil.UPD;
                    nonAktifCheckbox.Enabled = true;
                    loadLocationDataInformation();
                    break;
            }
            errorLabel.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                switch (originModuleID)
                {
                    case globalConstants.NEW_LOCATION:
                        gutil.saveUserChangeLog(globalConstants.MENU_GUDANG, globalConstants.CHANGE_LOG_INSERT, "ADD NEW LOCATION [" + namaGroupTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_LOCATION:
                        if (nonAktifCheckbox.Checked)
                            gutil.saveUserChangeLog(globalConstants.MENU_GUDANG, globalConstants.CHANGE_LOG_UPDATE, "UPDATE LOCATION [" + namaGroupTextBox.Text + "] LOCATION STATUS NON-AKTIF");
                        else
                            gutil.saveUserChangeLog(globalConstants.MENU_GUDANG, globalConstants.CHANGE_LOG_UPDATE, "UPDATE LOCATION [" + namaGroupTextBox.Text + "] LOCATION STATUS AKTIF");
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
    }
}
