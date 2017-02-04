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
    public partial class dataSalesInvoice : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private int customerID = 0;

        private int originModuleID = 0;

        public dataSalesInvoice()
        {
            InitializeComponent();
        }

        public dataSalesInvoice(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void fillInCustomerCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";

            customerCombo.Items.Clear();
            customerHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        customerCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        customerHiddenCombo.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadInvoiceData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noInvoiceParam = "";
            string whereClause1 = "";
            string sqlClause1 = "";
            string sqlClause2 = "";

            DS.mySqlConnect();

            if (originModuleID == globalConstants.SALES_QUOTATION)
            {
                sqlClause1  = "SELECT IF(SQ_APPROVED = 1, 'APPROVED', IF(SQ_APPROVED = -1, 'REJECTED', 'PENDING')) AS STATUS, ID, SQ_INVOICE AS 'NO INVOICE', CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(SQ_DATE, '%d-%M-%Y')  AS 'TGL INVOICE', (SQ_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL', SQ_APPROVED " +
                                       "FROM SALES_QUOTATION_HEADER SQ, MASTER_CUSTOMER MC " +
                                       "WHERE SQ.CUSTOMER_ID = MC.CUSTOMER_ID";

                sqlClause2 = "SELECT IF(SQ_APPROVED = 1, 'APPROVED', IF(SQ_APPROVED = -1, 'REJECTED', 'PENDING')) AS STATUS, ID, SQ_INVOICE AS 'NO INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(SQ_DATE, '%d-%M-%Y') AS 'TGL INVOICE', (SQ_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL', SQ_APPROVED " +
                                       "FROM SALES_QUOTATION_HEADER SQ " +
                                       "WHERE SQ.CUSTOMER_ID = 0";
            }
            else if (originModuleID == globalConstants.SALES_ORDER_REVISION)
            {
                sqlClause1 = "SELECT REV_NO, ID, SALES_INVOICE AS 'NO INVOICE', CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y')  AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH, MASTER_CUSTOMER MC " +
                                       "WHERE SH.CUSTOMER_ID = MC.CUSTOMER_ID AND SH.SALES_VOID = 0 AND SH.SALES_ACTIVE = 1 AND SH.IS_PREORDER = 0";

                sqlClause2 = "SELECT REV_NO, ID, SALES_INVOICE AS 'NO INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y') AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH " +
                                       "WHERE SH.CUSTOMER_ID = 0 AND SH.SALES_VOID = 0 AND SH.SALES_ACTIVE = 1 AND SH.IS_PREORDER = 0";
            }
            else if (originModuleID == globalConstants.DELIVERY_ORDER)
            {
                sqlClause1 = "SELECT REV_NO, ID, SALES_INVOICE AS 'NO INVOICE', CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y')  AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH, MASTER_CUSTOMER MC " +
                                       "WHERE SH.CUSTOMER_ID = MC.CUSTOMER_ID AND SH.SALES_ACTIVE = 1 AND SH.SALES_VOID = 0";

                sqlClause2 = "SELECT REV_NO, ID, SALES_INVOICE AS 'NO INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y') AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH " +
                                       "WHERE SH.CUSTOMER_ID = 0 AND SH.SALES_ACTIVE = 1 AND SH.SALES_VOID = 0";
            }
            else if (originModuleID  == globalConstants.COPY_DELIVERY_ORDER)
            {
                sqlClause1 = "SELECT DH.DO_ID AS 'NO DO', DH.SALES_INVOICE AS 'NO INVOICE', DH.REV_NO, MC.CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(DH.DO_DATE, '%d-%M-%Y')  AS 'TGL DO' " +
                                       "FROM DELIVERY_ORDER_HEADER DH, SALES_HEADER SH, MASTER_CUSTOMER MC " +
                                       "WHERE SH.CUSTOMER_ID = MC.CUSTOMER_ID AND DH.SALES_INVOICE = SH.SALES_INVOICE AND DH.REV_NO = SH.REV_NO";

                sqlClause2 = "SELECT DH.DO_ID AS 'NO DO', DH.SALES_INVOICE AS 'NO INVOICE', DH.REV_NO, 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(DH.DO_DATE, '%d-%M-%Y') AS 'TGL DO' " +
                                       "FROM DELIVERY_ORDER_HEADER DH, SALES_HEADER SH " +
                                       "WHERE SH.CUSTOMER_ID = 0 AND DH.SALES_INVOICE = SH.SALES_INVOICE AND DH.REV_NO = SH.REV_NO";
            }
            else if (originModuleID == globalConstants.PRE_ORDER_SALES)
            {
                sqlClause1 = "SELECT REV_NO, ID, SALES_INVOICE AS 'NO INVOICE', CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y')  AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH, MASTER_CUSTOMER MC " +
                                       "WHERE SH.CUSTOMER_ID = MC.CUSTOMER_ID AND SH.SALES_VOID = 0 AND SH.SALES_ACTIVE = 1 AND SH.IS_PREORDER = 1";

                sqlClause2 = "SELECT REV_NO, ID, SALES_INVOICE AS 'NO INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y') AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH " +
                                       "WHERE SH.CUSTOMER_ID = 0 AND SH.SALES_VOID = 0 AND SH.SALES_ACTIVE = 1 AND SH.IS_PREORDER = 1";
            }

            if (!showAllCheckBox.Checked)
            {
                if (noInvoiceTextBox.Text.Length > 0)
                {
                    noInvoiceParam = MySqlHelper.EscapeString(noInvoiceTextBox.Text);
                    if (originModuleID == globalConstants.SALES_QUOTATION)
                        whereClause1 = whereClause1 + " AND SQ.SQ_INVOICE LIKE '%" + noInvoiceParam + "%'";
                    else if (originModuleID == globalConstants.SALES_ORDER_REVISION || originModuleID == globalConstants.DELIVERY_ORDER || originModuleID == globalConstants.COPY_DELIVERY_ORDER)
                        whereClause1 = whereClause1 + " AND SH.SALES_INVOICE LIKE '%" + noInvoiceParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));

                if (originModuleID == globalConstants.SALES_QUOTATION)
                    whereClause1 = whereClause1 + " AND DATE_FORMAT(SQ.SQ_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(SQ.SQ_DATE, '%Y%m%d')  <= '" + dateTo + "'";
                else if (originModuleID == globalConstants.SALES_ORDER_REVISION || 
                            originModuleID == globalConstants.DELIVERY_ORDER ||
                            originModuleID == globalConstants.PRE_ORDER_SALES)
                    whereClause1 = whereClause1 + " AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "'";
                else if (originModuleID == globalConstants.COPY_DELIVERY_ORDER)
                    whereClause1 = whereClause1 + " AND DATE_FORMAT(DH.DO_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(DH.DO_DATE, '%Y%m%d')  <= '" + dateTo + "'";

                if (customerID > 0)
                {
                    if (originModuleID == globalConstants.SALES_QUOTATION)
                        sqlCommand = sqlClause1 + whereClause1 + " AND AND SQ.CUSTOMER_ID = " + customerID;
                    else if (originModuleID == globalConstants.SALES_ORDER_REVISION || 
                                originModuleID == globalConstants.DELIVERY_ORDER ||
                                originModuleID == globalConstants.PRE_ORDER_SALES ||
                                originModuleID == globalConstants.COPY_DELIVERY_ORDER 
                                )
                        sqlCommand = sqlClause1 + whereClause1 + " AND AND SH.CUSTOMER_ID = " + customerID;
                }
                else
                {
                    sqlCommand = sqlClause1 + whereClause1 + " UNION " + sqlClause2 + whereClause1;
                }
            }
            else
            {
                sqlCommand = sqlClause1 + " UNION " + sqlClause2;
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPenerimaanBarang.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPenerimaanBarang.DataSource = dt;
                    
                    if (originModuleID == globalConstants.SALES_QUOTATION)
                        dataPenerimaanBarang.Columns["SQ_APPROVED"].Visible = false;

                    if (originModuleID == globalConstants.SALES_ORDER_REVISION || originModuleID == globalConstants.DELIVERY_ORDER || originModuleID == globalConstants.COPY_DELIVERY_ORDER)
                        dataPenerimaanBarang.Columns["REV_NO"].Visible = false;

                    dataPenerimaanBarang.Columns["NO INVOICE"].Width = 200;
                    dataPenerimaanBarang.Columns["CUSTOMER"].Width = 200;

                    if (originModuleID != globalConstants.COPY_DELIVERY_ORDER)
                    {
                        dataPenerimaanBarang.Columns["ID"].Visible = false;
                        dataPenerimaanBarang.Columns["TGL INVOICE"].Width = 200;
                        dataPenerimaanBarang.Columns["TOTAL"].Width = 200;
                        dataPenerimaanBarang.Columns["TOTAL"].DefaultCellStyle.FormatProvider = culture;
                        dataPenerimaanBarang.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                    }
                    else if (originModuleID == globalConstants.COPY_DELIVERY_ORDER)
                    {
                        dataPenerimaanBarang.Columns["TGL DO"].Width = 200;
                    }
                }

                rdr.Close();
            }
        }

        private void dataSalesInvoice_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[2];

            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            fillInCustomerCombo();

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_SALES_QUOTATION, gUtil.getUserGroupID());

            if (userAccessOption == 1)
                newInvoiceButton.Visible = true;
            else
                newInvoiceButton.Visible = false;

            if (originModuleID == globalConstants.DELIVERY_ORDER || originModuleID == globalConstants.COPY_DELIVERY_ORDER)
                newInvoiceButton.Visible = false;

            arrButton[0] = displayButton;
            arrButton[1] = newInvoiceButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);

            noInvoiceTextBox.Select();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadInvoiceData();
        }

        private void customerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(customerHiddenCombo.Items[customerCombo.SelectedIndex].ToString());
        }

        private void printOutDeliveryOrder(string SONo, string revNo, string DO_ID)
        {
            //string sqlCommandx = "SELECT '" + salesActiveStatus + "' AS 'SALES_STATUS', SH.SALES_DATE AS 'TGL', SH.SALES_INVOICE AS 'INVOICE', IFNULL(MC.CUSTOMER_FULL_NAME, '') AS 'CUSTOMER_NAME', MP.PRODUCT_NAME AS 'PRODUK', SD.PRODUCT_QTY AS 'QTY' " +
            //                            "FROM SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON (SH.CUSTOMER_ID = MC.CUSTOMER_ID) , SALES_DETAIL SD, MASTER_PRODUCT MP " +
            //                            "WHERE SH.SALES_INVOICE = '" + SONo + "' AND SD.SALES_INVOICE = SH.SALES_INVOICE AND SD.PRODUCT_ID = MP.PRODUCT_ID AND SD.REV_NO = '" + revNo + "' AND SH.REV_NO = '" + revNo + "'";

            string sqlCommandx = "SELECT '0' AS 'SALES_STATUS', DH.DO_DATE AS 'TGL', DH.DO_ID AS 'INVOICE', IFNULL(MC.CUSTOMER_FULL_NAME, 'P-UMUM') AS 'CUSTOMER_NAME', MP.PRODUCT_NAME AS 'PRODUK', DD.PRODUCT_QTY AS 'QTY' " +
                            "FROM DELIVERY_ORDER_HEADER DH, DELIVERY_ORDER_DETAIL DD, SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON (SH.CUSTOMER_ID = MC.CUSTOMER_ID) , MASTER_PRODUCT MP " +
                            "WHERE DH.DO_ID = '" + DO_ID + "' AND DH.SALES_INVOICE = '" + SONo + "' AND DD.DO_ID = DH.DO_ID AND DD.PRODUCT_ID = MP.PRODUCT_ID AND DH.REV_NO = '" + revNo + "' AND SH.SALES_INVOICE = '" + SONo + "' AND SH.REV_NO = '" + revNo + "'";


            DS.writeXML(sqlCommandx, globalConstants.deliveryOrderXML);
            deliveryOrderPrintOutForm displayForm = new deliveryOrderPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private bool processSalesOrderToDO(string noInvoice, string revNo, int salesActiveStatus)
        {
            bool result = false;
            //string sqlCommand = "";
            //MySqlException internalEX = null;
            //int locationID = 0;
            //MySqlDataReader rdr;
            //List<string> productIDList = new List<string>();
            //List<string> productIDQty = new List<string>();

            //if (salesActiveStatus == 0)
            //    return true;

            //DS.beginTransaction();

            //try
            //{
            //    DS.mySqlConnect();

            //    // UPDATE SALES HEADER SET SALES ACTIVE TO 0
            //    sqlCommand = "UPDATE SALES_HEADER SET SALES_ACTIVE = 0 WHERE SALES_INVOICE = '" + noInvoice + "' AND REV_NO = '" + revNo + "'";
            //    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
            //        throw internalEX;

            //    // GET LIST OF PRODUCT ID
            //    productIDList.Clear();
            //    productIDQty.Clear();

            //    sqlCommand = "SELECT PRODUCT_ID, PRODUCT_QTY FROM SALES_DETAIL WHERE SALES_INVOICE = '" + noInvoice + "' AND REV_NO = '" + revNo + "'";
            //    using (rdr = DS.getData(sqlCommand))
            //    {
            //        if (rdr.HasRows)
            //        {
            //            while (rdr.Read())
            //            {
            //                productIDList.Add(rdr.GetString("PRODUCT_ID"));
            //                productIDQty.Add(rdr.GetString("PRODUCT_QTY"));
            //            }
            //        }
            //    }
            //    rdr.Close();

            //    locationID = gUtil.loadlocationID(2);

            //    for (int i =0;i<productIDList.Count;i++)
            //    {
            //        // REDUCE STOCK AT MASTER STOCK
            //        if (!gUtil.productIsService(productIDList[i].ToString()))
            //        { 
            //            sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + productIDQty[i].ToString() + " WHERE PRODUCT_ID = '" + productIDList[i].ToString() + "'";
            //            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
            //                throw internalEX;

            //            // REDUCE STOCK AT PRODUCT LOCATION
            //            sqlCommand = "UPDATE PRODUCT_LOCATION SET PRODUCT_LOCATION_QTY = PRODUCT_LOCATION_QTY - " + productIDQty[i].ToString() + " WHERE PRODUCT_ID = '" + productIDList[i].ToString() + "' AND LOCATION_ID = " + locationID;
            //            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
            //                throw internalEX;
            //        }
            //    }

            //    DS.commit();
            //    result = true;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            return result;
        }

        private void displaySpecificForm(string noInvoice, string revNo = "", string doID = "")
        {
            int salesActiveStatus = 0;
            string dialogMessage = "";
            switch(originModuleID)
            {
                case globalConstants.SALES_QUOTATION:
                        cashierForm displayedForm = new cashierForm(globalConstants.EDIT_SALES_QUOTATION, noInvoice);
                        displayedForm.ShowDialog(this);
                    break;
                case globalConstants.SALES_ORDER_REVISION:
                        cashierForm cashierFormDisplay= new cashierForm(noInvoice, revNo);
                        cashierFormDisplay.ShowDialog(this);
                    break;
                case globalConstants.DELIVERY_ORDER:
                    //salesActiveStatus = Convert.ToInt32(DS.getDataSingleValue("SELECT SALES_ACTIVE FROM SALES_HEADER WHERE SALES_INVOICE = '" + noInvoice + "' AND REV_NO = '" + revNo + "'"));
                    //if (salesActiveStatus == 1)
                    //{
                    //    dialogMessage = "TERBITKAN DELIVERY ORDER ?";
                    //}
                    //else
                    //{
                    //    dialogMessage = "TERBITKAN COPY DELIVERY ORDER ?";
                    //}

                    //if (DialogResult.Yes == MessageBox.Show(dialogMessage, "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    //{
                        //// UPDATE SALES HEADER SET TO NON ACTIVE AND REDUCE STOCK
                        //if (processSalesOrderToDO(noInvoice, revNo, salesActiveStatus))
                        //    printOutDeliveryOrder(noInvoice, revNo, salesActiveStatus);
                        //if (salesActiveStatus == 1)
                        //{ 
                            deliveryOrderForm DOForm = new deliveryOrderForm(noInvoice, revNo);
                            DOForm.ShowDialog(this);
                        //}
                        //else
                        //{
                        //    printOutDeliveryOrder(noInvoice, revNo);
                        //}
                    //}
                    break;
                case globalConstants.COPY_DELIVERY_ORDER:
                        dialogMessage = "TERBITKAN COPY DELIVERY ORDER ?";
                        if (DialogResult.Yes == MessageBox.Show(dialogMessage, "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            printOutDeliveryOrder(noInvoice, revNo, doID);
                        }
                        break;
                case globalConstants.PRE_ORDER_SALES:
                    cashierForm cashierFormDisplayPreOrder = new cashierForm(noInvoice, revNo, globalConstants.PRE_ORDER_SALES_REVISION);
                    cashierFormDisplayPreOrder.ShowDialog(this);
                    break;

            }

           loadInvoiceData();
        }

        private void dataPenerimaanBarang_DoubleClick(object sender, EventArgs e)
        {
            string noInvoice = "";
            string revNo = "";
            string status = "";

            if (dataPenerimaanBarang.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
            noInvoice = selectedRow.Cells["NO INVOICE"].Value.ToString();

            if (originModuleID == globalConstants.SALES_QUOTATION)
            {
                status = selectedRow.Cells["SQ_APPROVED"].Value.ToString();

                if (status == "0")
                    displaySpecificForm(noInvoice);
            }
            else if (originModuleID == globalConstants.SALES_ORDER_REVISION || 
                originModuleID == globalConstants.DELIVERY_ORDER || 
                originModuleID == globalConstants.PRE_ORDER_SALES)
            {
                revNo = selectedRow.Cells["REV_NO"].Value.ToString();
                displaySpecificForm(noInvoice, revNo);
            }
            else if (originModuleID == globalConstants.COPY_DELIVERY_ORDER)
            {
                displaySpecificForm(noInvoice, revNo, selectedRow.Cells["NO DO"].Value.ToString());
            }
        }

        private void dataPenerimaanBarang_KeyDown(object sender, KeyEventArgs e)
        {
            string noInvoice = "";
            string status = "";
            string revNo = "";

            if (e.KeyCode == Keys.Enter)
            {
                int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
                noInvoice = selectedRow.Cells["NO INVOICE"].Value.ToString();

                if (originModuleID == globalConstants.SALES_QUOTATION)
                {
                    status = selectedRow.Cells["SQ_APPROVED"].Value.ToString();

                    if (status == "0")
                        displaySpecificForm(noInvoice);
                }
                else if (originModuleID == globalConstants.SALES_ORDER_REVISION || 
                    originModuleID == globalConstants.DELIVERY_ORDER || 
                    originModuleID == globalConstants.PRE_ORDER_SALES)
                {
                    revNo = selectedRow.Cells["REV_NO"].Value.ToString();
                    displaySpecificForm(noInvoice, revNo);
                }
                else if (originModuleID == globalConstants.COPY_DELIVERY_ORDER)
                {
                    displaySpecificForm(noInvoice, revNo, selectedRow.Cells["NO DO"].Value.ToString());
                }
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.SALES_QUOTATION || originModuleID == globalConstants.PRE_ORDER_SALES)
            { 
                cashierForm displayedForm = new cashierForm(originModuleID, true);
                displayedForm.ShowDialog(this);
            }
            else if (originModuleID == globalConstants.SALES_ORDER_REVISION)
            {
                cashierForm cashierDisplayForm = new cashierForm(1);
                cashierDisplayForm.ShowDialog(this);
            }
        }
    }
}
