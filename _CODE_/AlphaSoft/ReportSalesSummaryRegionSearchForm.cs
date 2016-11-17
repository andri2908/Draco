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
    public partial class ReportSalesSummaryRegionSearchForm : Form
    {
        Data_Access DS = new Data_Access();
        string selectedRegionID = "0";
        private CultureInfo culture = new CultureInfo("id-ID");

        public ReportSalesSummaryRegionSearchForm()
        {
            InitializeComponent();
        }
            
        private void loadRegionData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            sqlCommand = "SELECT ID, REGION_NAME FROM MASTER_REGION WHERE REGION_ACTIVE = 1";

            regionCombo.Items.Clear();
            regionComboHidden.Items.Clear();

            regionCombo.Items.Add("ALL");
            regionComboHidden.Items.Add("0");

            selectedRegionID = "0";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        regionCombo.Items.Add(rdr.GetString("REGION_NAME"));
                        regionComboHidden.Items.Add(rdr.GetString("ID"));
                    }
                }
            }
            regionCombo.Text = regionCombo.Items[0].ToString();
        }

        private void ReportSalesSummaryRegionForm_Load(object sender, EventArgs e)
        {
            datefromPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            datetoPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            loadRegionData();
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            string sqlCommandx = "";

            if (selectedRegionID != "0")
            {
                sqlCommandx = "SELECT R.REGION_NAME, SALES_INVOICE AS 'INVOICE', C.CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE',S.SALES_TOTAL AS 'TOTAL', IF(C.CUSTOMER_GROUP=1,'RETAIL',IF(C.CUSTOMER_GROUP=2,'GROSIR','PARTAI')) AS 'GROUP', IF(S.SALES_PAID = 1, 'LUNAS', 'BELUM LUNAS') AS STATUS " +
                                         "FROM SALES_HEADER S,MASTER_CUSTOMER C, MASTER_REGION R " +
                                         "WHERE S.CUSTOMER_ID = C.CUSTOMER_ID AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "' AND C.REGION_ID = R.REGION_ID AND R.ID = " + selectedRegionID;
            }
            else
            {
                sqlCommandx = "SELECT R.REGION_NAME, SALES_INVOICE AS 'INVOICE', C.CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE',S.SALES_TOTAL AS 'TOTAL', IF(C.CUSTOMER_GROUP=1,'RETAIL',IF(C.CUSTOMER_GROUP=2,'GROSIR','PARTAI')) AS 'GROUP', IF(S.SALES_PAID = 1, 'LUNAS', 'BELUM LUNAS') AS STATUS " +
                                         "FROM SALES_HEADER S,MASTER_CUSTOMER C, MASTER_REGION R " +
                                         "WHERE S.CUSTOMER_ID = C.CUSTOMER_ID AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "' AND C.REGION_ID = R.ID";
            }

            DS.writeXML(sqlCommandx, globalConstants.penjualanRegionXML);
            ReportSalesSummaryRegionForm displayedForm1 = new ReportSalesSummaryRegionForm();
            displayedForm1.ShowDialog(this);
        }

        private void regionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRegionID = regionComboHidden.Items[regionCombo.SelectedIndex].ToString();
        }
    }
}
