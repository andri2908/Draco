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
using System.Globalization;

namespace BintangTimur
{
    public partial class dataSalesTargetForm : Form
    {
        string currentYear = "";
        int numericCurrentYear = 0;
        string currentMonth = "";
        int numericMonth = 0;
        private string previousInput = "";
        private bool isLoading = false;

        private Data_Access DS = new Data_Access();

        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public dataSalesTargetForm()
        {
            InitializeComponent();
        }

        private void loadSalesTargetData(int currentYear, bool loadAll = true)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            int currentMonth = 0;
            int numRows = 0;

            // LOAD DATAGRID
            sqlCommand = "SELECT TARGET_MONTH, TARGET_YEAR AS TAHUN, SUBSTRING('JAN FEB MAR APR MAY JUN JUL AUG SEP OCT NOV DEC ', (TARGET_MONTH * 4) - 3, 3) AS BULAN, TARGET_AMOUNT AS TARGET FROM MASTER_SALES_TARGET WHERE TARGET_YEAR >= " + (currentYear - 10) + " AND TARGET_YEAR <= " + (currentYear + 10) + " ORDER BY TARGET_YEAR, TARGET_MONTH ASC";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataSalesTarget.DataSource = dt;
                    dataSalesTarget.Columns["TARGET_MONTH"].Visible = false;
                    dataSalesTarget.Columns["TAHUN"].Width = 100;
                    dataSalesTarget.Columns["BULAN"].Width = 100;
                    dataSalesTarget.Columns["TARGET"].Width = 200;
                }
            }

            if (!loadAll)
                return;

            // LOAD CURRENT MONTH DATA, IF ANY
            currentMonth = periodeBulanCombo.SelectedIndex + 1;
            sqlCommand = "SELECT COUNT(1) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + currentYear + " AND TARGET_MONTH = " + currentMonth;
            numRows = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

            if (numRows > 0)
            {
                sqlCommand = "SELECT IFNULL(TARGET_AMOUNT, 0) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + currentYear + " AND TARGET_MONTH = " + currentMonth;
                targetPenjualanTextBox.Text = DS.getDataSingleValue(sqlCommand).ToString();

                sqlCommand = "SELECT IFNULL(SALES_COMMISSION, 0) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + currentYear + " AND TARGET_MONTH = " + currentMonth;
                commissionValue.Text = DS.getDataSingleValue(sqlCommand).ToString();
            }
            else
            { 
                targetPenjualanTextBox.Text = "0";
                commissionValue.Text = "1";
            }
        }

        private bool dataValidated()
        {
            if (commissionValue.Text.Length <= 0)
            {
                errorLabel.Text = "NILAI KOMISI TIDAK BOLEH KOSONG";
                return false;
            }

            if (targetPenjualanTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NILAI TARGET PENJUALAN TIDAK BOLEH KOSONG";
                return false;
            }

            errorLabel.Text = "";
            return true;
        }

        private bool saveDataTransaction()
        {
            string sqlCommand = "";
            int numRows;
            bool result = false;
            MySqlException internalEX = null;
            int selectedMonth = 0;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // CHECK FOR CURRENT ENTRY
                sqlCommand = "SELECT COUNT(1) FROM MASTER_SALES_TARGET WHERE TARGET_YEAR = " + periodeTahunCombo.Text + " AND TARGET_MONTH = " + periodeBulanCombo.SelectedIndex + 1;
                numRows = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

                if (numRows > 0)
                {
                    // UPDATE DATA SALES TARGET
                    sqlCommand = "UPDATE MASTER_SALES_TARGET SET SALES_COMMISSION = " + commissionValue.Text + ", TARGET_AMOUNT = " + targetPenjualanTextBox.Text + " WHERE TARGET_YEAR = " + periodeTahunCombo.Text + " AND TARGET_MONTH = " + selectedMonth;
                }
                else
                {
                    // INSERT NEW DATA SALES TARGET
                    selectedMonth = periodeBulanCombo.SelectedIndex + 1;
                    sqlCommand = "INSERT INTO MASTER_SALES_TARGET (TARGET_MONTH, TARGET_YEAR, TARGET_AMOUNT, SALES_COMMISSION) VALUES (" + selectedMonth + ", " + periodeTahunCombo.Text + ", " + targetPenjualanTextBox.Text + ", " + commissionValue.Text + ")";
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception EX)
            {
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
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private void dataSalesTargetForm_Load(object sender, EventArgs e)
        {
            currentYear = String.Format(culture, "{0:yyyy}", DateTime.Now); ;
            numericCurrentYear = Convert.ToInt32(currentYear);

            currentMonth = String.Format(culture, "{0:MM}", DateTime.Now); ;
            numericMonth = Convert.ToInt32(currentMonth);
            
                // FILL IN YEAR COMBO
            periodeTahunCombo.Items.Clear();
            for (int i = numericCurrentYear - 10; i<=numericCurrentYear+10;i++)
            {
                periodeTahunCombo.Items.Add(i.ToString());
            }
            periodeTahunCombo.SelectedIndex = 10;
            periodeTahunCombo.Text = currentYear;

            // FILL IN MONTH COMBO
            periodeBulanCombo.SelectedIndex = numericMonth-1;
            periodeBulanCombo.Text = periodeBulanCombo.Items[periodeBulanCombo.SelectedIndex].ToString();

            loadSalesTargetData(numericCurrentYear);
            errorLabel.Text = "";

            gutil.reArrangeTabOrder(this);
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            if (saveData())
                MessageBox.Show("DONE");
            else
                MessageBox.Show("FAILED TO SAVE DATA");

            loadSalesTargetData(Convert.ToInt32(periodeTahunCombo.Text), false);
        }

        private void dataSalesTarget_DoubleClick(object sender, EventArgs e)
        {
            int selectedMonth = 0;
            string selectedYear = "";
            string selectedAmount = "";

            if (dataSalesTarget.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataSalesTarget.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataSalesTarget.Rows[rowSelectedIndex];
            selectedMonth = Convert.ToInt32(selectedRow.Cells["TARGET_MONTH"].Value.ToString());
            selectedYear = selectedRow.Cells["TAHUN"].Value.ToString();
            selectedAmount = selectedRow.Cells["TARGET"].Value.ToString();

            periodeBulanCombo.SelectedIndex = selectedMonth - 1;
            periodeBulanCombo.Text = periodeBulanCombo.Items[selectedMonth - 1].ToString();

            periodeTahunCombo.Text = selectedYear;

            targetPenjualanTextBox.Text = selectedAmount;
        }

        private void dataSalesTarget_KeyDown(object sender, KeyEventArgs e)
        {
            int selectedMonth = 0;
            string selectedYear = "";
            string selectedAmount = "";

            if (e.KeyCode == Keys.Enter)
            {
                if (dataSalesTarget.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = (dataSalesTarget.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataSalesTarget.Rows[rowSelectedIndex];
                selectedMonth = Convert.ToInt32(selectedRow.Cells["TARGET_MONTH"].Value.ToString());
                selectedYear = selectedRow.Cells["TAHUN"].Value.ToString();
                selectedAmount = selectedRow.Cells["TARGET"].Value.ToString();

                periodeBulanCombo.SelectedIndex = selectedMonth - 1;
                periodeBulanCombo.Text = periodeBulanCombo.Items[selectedMonth - 1].ToString();

                periodeTahunCombo.Text = selectedYear;

                targetPenjualanTextBox.Text = selectedAmount;
            }
        }

        private void convertValueTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString = "";

            if (isLoading)
                return;

            isLoading = true;
            if (commissionValue.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                previousInput = "0";
                commissionValue.Text = "0";

                commissionValue.SelectionStart = commissionValue.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (commissionValue.Text.IndexOf('0') == 0 && commissionValue.Text.Length > 1 && commissionValue.Text.IndexOf("0.") < 0)
            {
                tempString = commissionValue.Text;
                commissionValue.Text = tempString.Remove(0, 1);
            }

            if (gutil.matchRegEx(commissionValue.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
            {
                previousInput = commissionValue.Text;
            }
            else
            {
                commissionValue.Text = previousInput;
            }

            commissionValue.SelectionStart = commissionValue.Text.Length;

            isLoading = false;

        }
    }
}
