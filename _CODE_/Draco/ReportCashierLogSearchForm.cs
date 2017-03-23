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
    public partial class ReportCashierLogSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();

        public ReportCashierLogSearchForm()
        {
            InitializeComponent();
        }

        private void LoadUserID()
        {
            UserIDCombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT ID AS 'ID', USER_FULL_NAME AS 'NAME' FROM MASTER_USER";
            }
            else
            {
                SQLcommand = "SELECT ID AS 'ID', USER_FULL_NAME AS 'NAME' FROM MASTER_USER WHERE USER_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    UserIDCombobox.Visible = true;
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);
                    UserIDCombobox.DataSource = dt;
                    UserIDCombobox.ValueMember = "ID";
                    UserIDCombobox.DisplayMember = "NAME";
                    UserIDCombobox.SelectedIndex = 0;
                }
                else
                {
                    UserIDCombobox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void ReportCashierLogSearchForm_Load(object sender, EventArgs e)
        {
            datefromPicker.Format = DateTimePickerFormat.Custom;
            datefromPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            datetoPicker.Format = DateTimePickerFormat.Custom;
            datetoPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            gutil.reArrangeTabOrder(this);
            ErrorLabel.Text = "";
            LoadUserID();
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;

            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));

            DS.mySqlConnect();

            string sqlCommandx = "";
            string user_id = "";
            string maxSHTableQuery = "";

            if (ErrorLabel.Visible == false)
            {
                user_id = "AND CL.USER_ID = " + UserIDCombobox.SelectedValue + " ";
            }

            maxSHTableQuery = "(SELECT SH.* FROM SALES_HEADER SH INNER JOIN (SELECT SALES_INVOICE, MAX(REV_NO)AS MAX FROM SALES_HEADER GROUP BY SALES_INVOICE) MAX_SD ON SH.SALES_INVOICE = MAX_SD.SALES_INVOICE AND SH.REV_NO = MAX_SD.MAX)";

            sqlCommandx = "MU.USER_FULL_NAME AS 'USERID', CL.DATE_LOGIN AS 'LOGIN',CL.DATE_LOGOUT AS 'LOGOUT', CL.AMOUNT_START AS 'START', CL.AMOUNT_END AS 'END', " +
                            "CL.COMMENT AS 'COMMENT', CL.TOTAL_CASH_TRANSACTION AS 'CASH', CL.TOTAL_NON_CASH_TRANSACTION AS 'NONCASH',CL.TOTAL_OTHER_TRANSACTION AS 'OTHER', " +
                            "SH.SALES_INVOICE AS 'INVOICE', SH.SALES_DATE AS 'TGLTRANS', IF(SH.SALES_TOP = 1, 'TUNAI', IF(SH.SALES_TOP = 0, 'CREDIT', '')) AS 'TOP', SH.SALES_TOTAL AS 'TOTAL' " +
                            "FROM MASTER_USER MU, " +
                            "CASHIER_LOG CL LEFT OUTER JOIN " + maxSHTableQuery + " SH ON (SH.SALES_DATE >= CL.DATE_LOGIN AND SH.SALES_DATE <= CL.DATE_LOGOUT) " +
                            "WHERE DATE_FORMAT(CL.DATE_LOGIN, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(CL.DATE_LOGIN, '%Y%m%d')  <= '" + dateTo + "' " +
                            "AND CL.USER_ID = MU.ID " + user_id + " " +
                            "GROUP BY BRANCH_NAME, LOGIN, INVOICE " +
                            "ORDER BY TGLTRANS ASC";

            DS.writeXML(sqlCommandx, globalConstants.CashierLogXML);

            ReportCashierLogForm displayedForm1 = new ReportCashierLogForm();
            displayedForm1.ShowDialog(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
