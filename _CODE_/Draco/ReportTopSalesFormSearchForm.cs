using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace AlphaSoft
{
    public partial class ReportTopSalesFormSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportTopSalesFormSearchForm()
        {
            InitializeComponent();
        }

        public ReportTopSalesFormSearchForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void ReportTopSalesFormSearchForm_Load(object sender, EventArgs e)
        {
            datefromPicker.Format = DateTimePickerFormat.Custom;
            datefromPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            datetoPicker.Format = DateTimePickerFormat.Custom;
            datetoPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            gutil.reArrangeTabOrder(this);
            LimitTextBox.Text = "1";
            switch(originModuleID)
            {
                case globalConstants.REPORT_TOPSALES_GLOBAL:
                    datetoPicker.Enabled = false;
                    datefromPicker.Enabled = false;
                    TagscomboBox.Enabled = false;
                    nonactivecheckbox.Enabled = false;
                    TagscomboBox.Text = "SEMUA";
                    break;
                case globalConstants.REPORT_TOPSALES_byDATE:
                    datetoPicker.Enabled = true;
                    datefromPicker.Enabled = true;
                    TagscomboBox.Enabled = false;
                    nonactivecheckbox.Enabled = false;
                    TagscomboBox.Text = "SEMUA";
                    break;
                case globalConstants.REPORT_TOPSALES_byTAGS:
                    datetoPicker.Enabled = false;
                    datefromPicker.Enabled = false;
                    TagscomboBox.Enabled = true;
                    nonactivecheckbox.Enabled = true;
                    loadTags();
                    break;
                case globalConstants.REPORT_TOPSALES_ByMARGIN:
                    datetoPicker.Enabled = true;
                    datefromPicker.Enabled = true;
                    TagscomboBox.Enabled = false;
                    nonactivecheckbox.Enabled = false;
                    TagscomboBox.Text = "SEMUA";
                    break;
            }
        }

        private void loadTags()
        {
            TagscomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT CATEGORY_ID AS 'ID', CATEGORY_NAME AS 'NAME' FROM MASTER_CATEGORY";
            }
            else
            {
                SQLcommand = "SELECT CATEGORY_ID AS 'ID', CATEGORY_NAME AS 'NAME' FROM MASTER_CATEGORY WHERE CATEGORY_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    TagscomboBox.DataSource = dt;
                    TagscomboBox.ValueMember = "ID";
                    TagscomboBox.DisplayMember = "NAME";
                    TagscomboBox.SelectedIndex = 0;
                }
            }
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            int cust_id = 0;
            string prod_id = "";
            bool result;
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            string sqlCommandx = "";
            string tagsClause = "";
            int limitRow = 10;

            if (LimitTextBox.Text.Length > 0)
            {
                limitRow = Convert.ToInt32(gutil.allTrim(LimitTextBox.Text));
            }

            switch (originModuleID)
            {
                case globalConstants.REPORT_TOPSALES_GLOBAL:
                    sqlCommandx = "SELECT MB.BRANCH_NAME, MP.PRODUCT_NAME AS 'PRODUCT', SUM(SD.PRODUCT_QTY) AS 'QTY' " +
                                    "FROM SALES_DETAIL SD INNER JOIN (SELECT SALES_INVOICE, MAX(REV_NO) AS MAX FROM SALES_DETAIL GROUP BY SALES_INVOICE) MAX_SD ON SD.SALES_INVOICE = MAX_SD.SALES_INVOICE AND SD.REV_NO = MAX_SD.MAX, " +
                                    "MASTER_PRODUCT MP, MASTER_BRANCH MB " +
                                    "WHERE SD.PRODUCT_ID = MP.PRODUCT_ID " +
                                    "GROUP BY BRANCH_NAME, SD.PRODUCT_ID " +
                                    "ORDER BY QTY DESC " +
                                    "LIMIT " + limitRow;

                    DS.writeXML(sqlCommandx, globalConstants.TopSalesGlobalXML);
                    ReportTopSalesGlobalForm displayedForm1 = new ReportTopSalesGlobalForm(globalConstants.REPORT_TOPSALES_GLOBAL);
                    displayedForm1.ShowDialog(this);
                    break;
                case globalConstants.REPORT_TOPSALES_byDATE:
                    sqlCommandx = "SELECT '' AS BRANCH_NAME, MP.PRODUCT_NAME AS 'PRODUCT', SUM(SD.PRODUCT_QTY) AS 'QTY' " +
                                    "FROM SALES_HEADER SH, MASTER_PRODUCT MP, " +
                                    "SALES_DETAIL SD INNER JOIN (SELECT SALES_INVOICE, MAX(REV_NO) AS MAX FROM SALES_DETAIL GROUP BY SALES_INVOICE) MAX_SD ON SD.SALES_INVOICE = MAX_SD.SALES_INVOICE AND SD.REV_NO = MAX_SD.MAX " +
                                    "WHERE SH.REV_NO = SD.REV_NO AND SD.PRODUCT_ID = MP.PRODUCT_ID AND SD.SALES_INVOICE = SH.SALES_INVOICE AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY BRANCH_NAME, SD.PRODUCT_ID " +
                                    "ORDER BY QTY DESC " +
                                    "LIMIT " + limitRow;
                    DS.writeXML(sqlCommandx, globalConstants.TopSalesbyDateXML);
                    ReportTopSalesGlobalForm displayedForm2 = new ReportTopSalesGlobalForm(globalConstants.REPORT_TOPSALES_byDATE);
                    displayedForm2.setDateReport(dateTo, dateFrom);
                    displayedForm2.ShowDialog(this);
                    break;
                case globalConstants.REPORT_TOPSALES_byTAGS:
                    if (TagscomboBox.Visible == true && TagscomboBox.SelectedValue.ToString() != "0")
                    {
                        tagsClause = "AND MC.CATEGORY_ID = " + TagscomboBox.SelectedValue.ToString();
                    }

                    sqlCommandx = "SELECT '' AS BRANCH_NAME, MC.CATEGORY_ID AS 'ID', MC.CATEGORY_NAME AS 'NAME', MP.PRODUCT_NAME AS 'PRODUCT', SUM(SD.PRODUCT_QTY) AS 'QTY' " +
                                        "FROM SALES_DETAIL SD INNER JOIN (SELECT SALES_INVOICE, MAX(REV_NO) AS MAX FROM SALES_DETAIL GROUP BY SALES_INVOICE) MAX_SD ON SD.SALES_INVOICE = MAX_SD.SALES_INVOICE AND SD.REV_NO = MAX_SD.MAX " +
                                        ", MASTER_PRODUCT MP, PRODUCT_CATEGORY PC, MASTER_CATEGORY MC " +
                                        "WHERE MC.CATEGORY_ID = PC.CATEGORY_ID AND MP.PRODUCT_ID = PC.PRODUCT_ID AND PC.PRODUCT_ID = SD.PRODUCT_ID " + tagsClause + " " +
                                        "GROUP BY BRANCH_NAME, PRODUCT, ID " +
                                        "ORDER BY PRODUCT " + "LIMIT " + limitRow;
                    DS.writeXML(sqlCommandx, globalConstants.TopSalesbyTagsXML);
                    ReportTopSalesbyTagsForm displayedForm3 = new ReportTopSalesbyTagsForm();
                    //displayedForm3.setTags(TagscomboBox.GetItemText(TagscomboBox.SelectedItem));
                    displayedForm3.ShowDialog(this);
                    break;
                case globalConstants.REPORT_TOPSALES_ByMARGIN:
                    sqlCommandx = "SELECT '' AS BRANCH_NAME, MP.PRODUCT_NAME AS 'PRODUCT', SUM(SD.PRODUCT_QTY) AS 'QTY', SUM(SD.SALES_SUBTOTAL-(SD.PRODUCT_QTY*MP.PRODUCT_BASE_PRICE)) AS 'LABA' " +
                                        "FROM SALES_HEADER SH, MASTER_PRODUCT MP, " +
                                        "SALES_DETAIL SD INNER JOIN (SELECT SALES_INVOICE, MAX(REV_NO) AS MAX FROM SALES_DETAIL GROUP BY SALES_INVOICE) MAX_SD ON SD.SALES_INVOICE = MAX_SD.SALES_INVOICE AND SD.REV_NO = MAX_SD.MAX " +
                                        "WHERE SH.REV_NO = SD.REV_NO AND SD.PRODUCT_ID = MP.PRODUCT_ID AND SD.SALES_INVOICE = SH.SALES_INVOICE AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "' " +
                                        "GROUP BY BRANCH_NAME, SD.PRODUCT_ID " +
                                        "ORDER BY LABA DESC " +
                                        "LIMIT " + limitRow;
                    DS.writeXML(sqlCommandx, globalConstants.TopSalesbyMarginXML);
                    ReportTopSalesbyMarginForm displayedForm4 = new ReportTopSalesbyMarginForm();
                    displayedForm4.ShowDialog(this);
                    break;
            }

        }

        private void nonactivecheckbox_CheckedChanged(object sender, EventArgs e)
        {
            loadTags();
        }
    }
}
