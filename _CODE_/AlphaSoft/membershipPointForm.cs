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

namespace AlphaSoft
{
    public partial class membershipPointForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        private string startDate = "";
        private string endDate = "";
        private string startDateString = "";
        private string endDateString = "";

        private string previousInput = "";
        bool isLoading = false;
        //private string calculationParam = "0";
        private int originModule = 0;
        private string selectedID = "0";

        public membershipPointForm()
        {
            InitializeComponent();
        }

        public membershipPointForm(int moduleID)
        {
            InitializeComponent();
            originModule = moduleID;

            if (originModule == globalConstants.SALES_COMMISSION)
            {
                this.Text = "KOMISI SALES";
                label1.Text = "Sales";
            }
            else if (originModule == globalConstants.MEMBERSHIP_POINT)
            {
                this.Text = "MEMBERSHIP POINT";
                label1.Text = "Member";
            }

        }

        private void membershipPointForm_Load(object sender, EventArgs e)
        {
            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            if (originModule == globalConstants.SALES_COMMISSION)
            {
                loadSalesPerson();
            }
            else if (originModule == globalConstants.MEMBERSHIP_POINT)
            {
                loadCustomer();
            }
        }

        private void loadSalesPerson()
        {
            string sqlCommand = "";
            MySqlDataReader rdr;

            nameCombo.Items.Clear();
            nameComboHidden.Items.Clear();

            nameCombo.Items.Add("ALL");
            nameComboHidden.Items.Add("0");

            sqlCommand = "SELECT MU.ID, MU.USER_FULL_NAME FROM USER_ACCESS_MANAGEMENT UAM, MASTER_USER MU WHERE UAM.MODULE_ID = 52 AND UAM.USER_ACCESS_OPTION = 1 AND MU.GROUP_ID = UAM.GROUP_ID AND MU.USER_ACTIVE = 1";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        nameCombo.Items.Add(rdr.GetString("USER_FULL_NAME"));
                        nameComboHidden.Items.Add(rdr.GetString("ID"));
                    }
                }
            }
            rdr.Close();

            nameCombo.Text = "ALL";
            nameCombo.SelectedIndex = 0;
        }

        private void loadCustomer()
        {
            string sqlCommand = "";
            MySqlDataReader rdr;

            nameCombo.Items.Clear();
            nameComboHidden.Items.Clear();

            nameCombo.Items.Add("ALL");
            nameComboHidden.Items.Add("0");

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        nameCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        nameComboHidden.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
            rdr.Close();

            nameCombo.Text = "ALL";
            nameCombo.SelectedIndex = 0;
        }


        private bool dataValidated()
        {
            if (PODtPicker_1.Value > PODtPicker_2.Value)
            {
                MessageBox.Show("PERIODE AWAL LEBIH BESAR DARI PERIODE AKHIR"); 
                return false;
            }

            if (parameterInputTextBox.Text.Length <= 0)
            {
                MessageBox.Show("PROSENTASE TIDAK BOLEH KOSONG");
                return false;
            }

            return true;
        }

        private double getTotalCashTransaction(string customerID)
        {
            string sqlCommand = "";
            double result = 0;


            if (originModule == globalConstants.MEMBERSHIP_POINT)
            { 
                sqlCommand = "SELECT IFNULL(SUM(SALES_TOTAL - SALES_DISCOUNT_FINAL), 0) FROM SALES_HEADER WHERE CUSTOMER_ID = " + customerID + " AND SALES_TOP = 1 AND DATE_FORMAT(SALES_DATE, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(SALES_DATE, '%Y%m%d')  <= '" + endDate + "' AND SALES_VOID = 0";
            }
            else if (originModule == globalConstants.SALES_COMMISSION)
            {
                sqlCommand = "SELECT IFNULL(SUM(SH.SALES_TOTAL - SH.SALES_DISCOUNT_FINAL), 0) " +
                                       "FROM SALES_HEADER SH, SALES_QUOTATION_HEADER SQH " +
                                       "WHERE SH.SQ_INVOICE = SQH.SQ_INVOICE AND SQH.SALESPERSON_ID = " + customerID + " AND SH.SALES_VOID = 0 AND SH.SALES_TOP = 1 AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + endDate + "'";
            }

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getTotalPaidTransaction(string customerID)
        {
            string sqlCommand = "";
            double result = 0;

            if (originModule == globalConstants.MEMBERSHIP_POINT)
            {
                sqlCommand = "SELECT IFNULL(SUM(SH.SALES_TOTAL - SH.SALES_DISCOUNT_FINAL), 0) " +
                                               "FROM SALES_HEADER SH, " +
                                               "(SELECT C.SALES_INVOICE, C.CREDIT_ID, MAX(PC.PAYMENT_CONFIRMED_DATE) AS LAST_PAYMENT " +
                                                "FROM CREDIT C, PAYMENT_CREDIT PC " +
                                                "WHERE C.CREDIT_PAID = 1 AND PC.CREDIT_ID = C.CREDIT_ID) TAB1 " +
                                                "WHERE SH.SALES_TOP = 0 AND SH.SALES_PAID = 1 AND SH.SALES_INVOICE = TAB1.SALES_INVOICE AND SH.SALES_VOID = 0 AND TAB1.LAST_PAYMENT <= SH.SALES_TOP_DATE " +
                                                "AND SH.CUSTOMER_ID = " + customerID + " " +
                                                "AND DATE_FORMAT(SALES_DATE, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(SALES_DATE, '%Y%m%d')  <= '" + endDate + "'";
            }
            else if (originModule == globalConstants.SALES_COMMISSION)
            {
                sqlCommand = "SELECT IFNULL(SUM(SH.SALES_TOTAL - SH.SALES_DISCOUNT_FINAL), 0) " +
                                               "FROM SALES_HEADER SH, " +
                                               "SALES_QUOTATION_HEADER SQH, " +
                                               "(SELECT C.SALES_INVOICE, C.CREDIT_ID, MAX(PC.PAYMENT_CONFIRMED_DATE) AS LAST_PAYMENT " +
                                                "FROM CREDIT C, PAYMENT_CREDIT PC " +
                                                "WHERE C.CREDIT_PAID = 1 AND PC.CREDIT_ID = C.CREDIT_ID) TAB1 " +
                                                "WHERE SH.SALES_TOP = 0 AND SH.SALES_PAID = 1 AND SH.SALES_INVOICE = TAB1.SALES_INVOICE AND SH.SALES_VOID = 0 AND TAB1.LAST_PAYMENT <= SH.SALES_TOP_DATE " +
                                                "AND SH.SQ_INVOICE = SQH.SQ_INVOICE AND SQH.SALESPERSON_ID = " + customerID + " " +
                                                "AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + endDate + "'";
            }

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getTotalReturTransaction(string customerID)
        {
            string sqlCommand = "";
            double result = 0;

            if (originModule == globalConstants.MEMBERSHIP_POINT)
            { 
                sqlCommand = "SELECT IFNULL(SUM(RS_TOTAL), 0) FROM RETURN_SALES_HEADER WHERE CUSTOMER_ID = " + customerID + " AND DATE_FORMAT(RS_DATETIME, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(RS_DATETIME, '%Y%m%d')  <= '" + endDate + "'";
            }
            else if (originModule == globalConstants.SALES_COMMISSION)
            {
                sqlCommand = "SELECT IFNULL(SUM(RS_TOTAL), 0) " +
                                       "FROM RETURN_SALES_HEADER RSH, SALES_HEADER SH, SALES_QUOTATION_HEADER SQH " +
                                       "WHERE SH.SQ_INVOICE = SQH.SQ_INVOICE AND SQH.SALESPERSON_ID = " + customerID + " AND RSH.SALES_INVOICE = SH.SALES_INVOICE " +
                                       "AND DATE_FORMAT(RSH.RS_DATETIME, '%Y%m%d')  >= '" + startDate + "' AND DATE_FORMAT(RSH.RS_DATETIME, '%Y%m%d')  <= '" + endDate + "'";
            }

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private bool saveDataTransaction()
        {
            double totalPaidTransaction = 0;
            double totalCashTransaction = 0;
            double totalReturTransaction = 0;
            double nettTransactionAmount = 0;
            double pointsAmount = 0;
            string sqlCommand = "";


            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                if (originModule == globalConstants.SALES_COMMISSION)
                {
                    if (selectedID == "0") // ALL MEMBER
                    {
                        for (int i = 1; i < nameComboHidden.Items.Count; i++)
                        {
                            totalCashTransaction = getTotalCashTransaction(nameComboHidden.Items[i].ToString());
                            totalPaidTransaction = getTotalPaidTransaction(nameComboHidden.Items[i].ToString());
                            totalReturTransaction = getTotalReturTransaction(nameComboHidden.Items[i].ToString());

                            nettTransactionAmount = totalCashTransaction + totalPaidTransaction - totalReturTransaction;
                            pointsAmount = Math.Round(nettTransactionAmount * Convert.ToDouble(parameterInputTextBox.Text) / 100, 2);

                            if (pointsAmount > 0)
                            { 
                                sqlCommand = "INSERT INTO SALES_COMMISSION (DATE_START, DATE_END, SALES_ID, SALES_PARAMETER, COMMISSION_AMOUNT) VALUES " +
                                                    "(STR_TO_DATE('" + startDateString + "', '%d-%m-%Y'), STR_TO_DATE('" + endDateString + "', '%d-%m-%Y')," + nameComboHidden.Items[i].ToString() + ", " + parameterInputTextBox.Text + ", " + pointsAmount + ")";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }
                    }
                    else
                    {
                        totalCashTransaction = getTotalCashTransaction(selectedID);
                        totalPaidTransaction = getTotalPaidTransaction(selectedID);
                        totalReturTransaction = getTotalReturTransaction(selectedID);

                        nettTransactionAmount = totalCashTransaction + totalPaidTransaction - totalReturTransaction;
                        pointsAmount = Math.Round(nettTransactionAmount * Convert.ToDouble(parameterInputTextBox.Text) / 100, 2);

                        if (pointsAmount > 0)
                        {
                            sqlCommand = "INSERT INTO SALES_COMMISSION (DATE_START, DATE_END, SALES_ID, SALES_PARAMETER, COMMISSION_AMOUNT) VALUES " +
                                                "(STR_TO_DATE('" + startDateString + "', '%d-%m-%Y'), STR_TO_DATE('" + endDateString + "', '%d-%m-%Y')," + selectedID + ", " + parameterInputTextBox.Text + ", " + pointsAmount + ")";

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                    }
                }
                else if (originModule == globalConstants.MEMBERSHIP_POINT)
                {
                    if (selectedID == "0") // ALL MEMBER
                    {
                        for (int i = 1;i<nameComboHidden.Items.Count;i++)
                        {
                            totalCashTransaction = getTotalCashTransaction(nameComboHidden.Items[i].ToString());
                            totalPaidTransaction = getTotalPaidTransaction(nameComboHidden.Items[i].ToString());
                            totalReturTransaction = getTotalReturTransaction(nameComboHidden.Items[i].ToString());

                            nettTransactionAmount = totalCashTransaction + totalPaidTransaction - totalReturTransaction;
                            pointsAmount = Math.Round(nettTransactionAmount * Convert.ToDouble(parameterInputTextBox.Text) / 100, 2);

                            if (pointsAmount > 0)
                            {
                                sqlCommand = "INSERT INTO MEMBERSHIP_POINT (DATE_START, DATE_END, CUSTOMER_ID, POINTS_PARAMETER, POINTS_AMOUNT) VALUES " +
                                                "(STR_TO_DATE('" + startDateString + "', '%d-%m-%Y'), STR_TO_DATE('" + endDateString + "', '%d-%m-%Y')," + nameComboHidden.Items[i].ToString() + ", " + parameterInputTextBox.Text + ", " + pointsAmount + ")";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }
                    }
                    else
                    {
                        totalCashTransaction = getTotalCashTransaction(selectedID);
                        totalPaidTransaction = getTotalPaidTransaction(selectedID);
                        totalReturTransaction = getTotalReturTransaction(selectedID);

                        nettTransactionAmount = totalCashTransaction + totalPaidTransaction - totalReturTransaction;
                        pointsAmount = Math.Round(nettTransactionAmount * Convert.ToDouble(parameterInputTextBox.Text) / 100, 2);

                        if (pointsAmount > 0)
                        {
                            sqlCommand = "INSERT INTO MEMBERSHIP_POINT (DATE_START, DATE_END, CUSTOMER_ID, POINTS_PARAMETER, POINTS_AMOUNT) VALUES " +
                                                "(STR_TO_DATE('" + startDateString + "', '%d-%m-%Y'), STR_TO_DATE('" + endDateString + "', '%d-%m-%Y')," + selectedID + ", " + parameterInputTextBox.Text + ", " + pointsAmount + ")";

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                    }
                }

                DS.commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        private bool saveData()
        {
            bool result = false;

            if (dataValidated())
                if (!saveDataTransaction())
                    MessageBox.Show("Failed");
            else
                    result = true;

            return result;
        }

        private void printOutReport()
        {
            string sqlCommandx = "";
            string dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
            string dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));

            if (originModule == globalConstants.SALES_COMMISSION)
            {
                if (nameCombo.SelectedIndex == 0)
                {
                    // PRINT OUT ALL SALES PERSON
                    sqlCommandx = "SELECT '1' AS TYPE, MAX(SC.ID), DATE_FORMAT(SC.DATE_START, '%d-%M-%Y') as DATE_START, DATE_FORMAT(SC.DATE_END, '%d-%M-%Y') as DATE_END, MU.USER_FULL_NAME AS NAME, SC.COMMISSION_AMOUNT AS AMOUNT " +
                                             "FROM MASTER_USER MU, SALES_COMMISSION SC " +
                                             "WHERE SC.SALES_ID = MU.ID AND MU.USER_ACTIVE = 1 " +
                                             "AND DATE_FORMAT(SC.DATE_START, '%Y%m%d')  = '" + dateFrom + "' AND DATE_FORMAT(SC.DATE_END, '%Y%m%d')  = '" + dateTo + "' " +
                                             "GROUP BY SC.DATE_START, SC.DATE_END, MU.ID";

                    DS.writeXML(sqlCommandx, globalConstants.allSalesCommissionXML);
                    salesCommissionAllPrintOutForm displayForm = new salesCommissionAllPrintOutForm();
                    displayForm.ShowDialog(this);
                }
                else
                {
                    // PRINT OUT SPECIFIC SALES PERSON
                    // PRINT OUT ALL SALES PERSON
                    sqlCommandx = "SELECT '1' AS TYPE, MAX(SC.ID), DATE_FORMAT(SC.DATE_START, '%d-%M-%Y') as DATE_END, DATE_FORMAT(SC.DATE_END, '%d-%M-%Y') as DATE_END, MU.USER_FULL_NAME AS NAME, SC.COMMISSION_AMOUNT AS AMOUNT" +
                                             "FROM MASTER_USER MU, SALES_COMMISSION SC " +
                                             "WHERE SC.SALES_ID = MU.ID AND MU.USER_ACTIVE = 1 AND MU.ID = " + selectedID + " " +
                                             "AND DATE_FORMAT(SC.DATE_START, '%Y%m%d')  = '" + dateFrom + "' AND DATE_FORMAT(SC.DATE_END, '%Y%m%d')  = '" + dateTo + "' " +
                                             "GROUP BY SC.DATE_START, SC.DATE_END";

                    DS.writeXML(sqlCommandx, globalConstants.allSalesCommissionXML);
                    salesCommissionAllPrintOutForm displayForm = new salesCommissionAllPrintOutForm();
                    displayForm.ShowDialog(this);
                }
            }
            else if (originModule == globalConstants.MEMBERSHIP_POINT)
            {
                if (nameCombo.SelectedIndex == 0)
                {
                    // PRINT OUT ALL MEMBER
                    sqlCommandx = "SELECT '2' AS TYPE, MAX(MP.ID), DATE_FORMAT(MP.DATE_START, '%d-%M-%Y') as DATE_START, DATE_FORMAT(MP.DATE_END, '%d-%M-%Y') as DATE_END, MC.CUSTOMER_FULL_NAME AS NAME, MP.POINTS_AMOUNT AS AMOUNT " +
                                             "FROM MASTER_CUSTOMER MC, MEMBERSHIP_POINT MP " +
                                             "WHERE MP.CUSTOMER_ID = MC.CUSTOMER_ID AND MC.CUSTOMER_ACTIVE = 1 " +
                                             "AND DATE_FORMAT(MP.DATE_START, '%Y%m%d')  = '" + dateFrom + "' AND DATE_FORMAT(MP.DATE_END, '%Y%m%d')  = '" + dateTo + "' " +
                                             "GROUP BY MP.DATE_START, MP.DATE_END, MC.CUSTOMER_ID";

                    DS.writeXML(sqlCommandx, globalConstants.allSalesCommissionXML);
                    salesCommissionAllPrintOutForm displayForm = new salesCommissionAllPrintOutForm();
                    displayForm.ShowDialog(this);
                }
                else
                {
                    // PRINT OUT SPECIFIC SALES PERSON
                    // PRINT OUT ALL SALES PERSON
                    sqlCommandx = "SELECT '2' AS TYPE, MAX(MP.ID), DATE_FORMAT(MP.DATE_START, '%d-%M-%Y') as DATE_END, DATE_FORMAT(MP.DATE_END, '%d-%M-%Y') as DATE_END, MC.CUSTOMER_FULL_NAME AS NAME, MP.POINTS_AMOUNT AS AMOUNT" +
                                             "FROM MASTER_CUSTOMER MC, MEMBERSHIP_POINT MP " +
                                             "WHERE MP.CUSTOMER_ID = MC.CUSTOMER_ID AND MC.CUSTOMER_ACTIVE = 1 AND MC.CUSTOMER_ID = " + selectedID + " " +
                                             "AND DATE_FORMAT(MP.DATE_START, '%Y%m%d')  = '" + dateFrom + "' AND DATE_FORMAT(MP.DATE_END, '%Y%m%d')  = '" + dateTo + "' " +
                                             "GROUP BY MP.DATE_START, MP.DATE_END";

                    DS.writeXML(sqlCommandx, globalConstants.allSalesCommissionXML);
                    salesCommissionAllPrintOutForm displayForm = new salesCommissionAllPrintOutForm();
                    displayForm.ShowDialog(this);
                }

            }
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            startDate = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
            endDate = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));

            startDateString = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(PODtPicker_1.Value));
            endDateString = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(PODtPicker_2.Value));

            if (saveData())
            {
                //MessageBox.Show("DONE");
                printOutReport();
            }
        }

        private void noPOInvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString = "";

            if (isLoading)
                return;

            isLoading = true;
            if (parameterInputTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                previousInput = "0";
                parameterInputTextBox.Text = "0";

                parameterInputTextBox.SelectionStart = parameterInputTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (parameterInputTextBox.Text.IndexOf('0') == 0 && parameterInputTextBox.Text.Length > 1 && parameterInputTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = parameterInputTextBox.Text;
                parameterInputTextBox.Text = tempString.Remove(0, 1);
            }

            if (gUtil.matchRegEx(parameterInputTextBox.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
            {
                previousInput = parameterInputTextBox.Text;
            }
            else
            {
                parameterInputTextBox.Text = previousInput;
            }

            parameterInputTextBox.SelectionStart = parameterInputTextBox.Text.Length;

            isLoading = false;
        }

        private void nameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedID = nameComboHidden.Items[nameCombo.SelectedIndex].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printOutReport();
        }
    }
}
