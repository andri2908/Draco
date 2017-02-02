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
    public partial class deliveryOrderForm : Form
    {
        private string selectedSalesInvoice = "";
        private string salesRevNo = "";
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private globalUtilities gUtil = new globalUtilities();
        private bool isPreOrderSales = false;
        private bool isLoading = false;
        private List<string> deliveryQty = new List<string>();

        public deliveryOrderForm()
        {
            InitializeComponent();
        }

        public deliveryOrderForm(string invoiceNo, string revNo)
        {
            InitializeComponent();

            selectedSalesInvoice = invoiceNo;
            salesRevNo = revNo;
        }


        private void loadInvoiceData()
        {
            string sqlCommand;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();

            // LOAD DATA HEADER
            sqlCommand = "SELECT SH.IS_PREORDER, SH.SALES_INVOICE, IFNULL(MC.CUSTOMER_FULL_NAME, 'P-UMUM') AS CUSTOMER_NAME FROM SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON (SH.CUSTOMER_ID = MC.CUSTOMER_ID) WHERE SH.SALES_INVOICE = '" + selectedSalesInvoice + "' AND SH.REV_NO = " + salesRevNo;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        noInvoiceTextBox.Text = rdr.GetString("SALES_INVOICE");
                        customerNameTextBox.Text = rdr.GetString("CUSTOMER_NAME");
                        
                        if (rdr.GetInt32("IS_PREORDER") == 1)
                            isPreOrderSales = true;
                    }
                }
            }
            rdr.Close();

            // LOAD DATA DETAIL
            sqlCommand = "SELECT SD.ID, SD.PRODUCT_ID, SD.IS_COMPLETED, IF(SD.IS_COMPLETED = 1, 'COMPLETED', 'PENDING') AS STATUS, MP.PRODUCT_NAME AS 'NAMA PRODUK', SD.PRODUCT_QTY AS 'ORDER QTY', IFNULL(TAB1.QTY, 0) AS 'DELIVERED QTY' " +
                                    "FROM SALES_DETAIL SD LEFT OUTER JOIN " +
                                    "(SELECT DH.SALES_INVOICE, DH.REV_NO, DD.PRODUCT_ID, SUM(DD.PRODUCT_QTY) AS QTY FROM DELIVERY_ORDER_HEADER DH, DELIVERY_ORDER_DETAIL DD WHERE DD.DO_ID = DH.DO_ID AND DH.SALES_INVOICE = '" + selectedSalesInvoice + "' AND DH.REV_NO = " + salesRevNo + " GROUP BY DD.PRODUCT_ID) TAB1 ON (TAB1.PRODUCT_ID = SD.PRODUCT_ID) " +
                                    ", MASTER_PRODUCT MP " +
                                    "WHERE SD.PRODUCT_ID = MP.PRODUCT_ID AND SD.SALES_INVOICE = '" + selectedSalesInvoice + "' AND SD.REV_NO = " + salesRevNo;

            isLoading = true;
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailGridView.DataSource = dt;

                    detailGridView.Columns["ID"].Visible = false;
                    detailGridView.Columns["PRODUCT_ID"].Visible = false;
                    detailGridView.Columns["IS_COMPLETED"].Visible = false;

                    detailGridView.Columns["NAMA PRODUK"].Width = 200;
                    detailGridView.Columns["NAMA PRODUK"].ReadOnly = true;

                    detailGridView.Columns["ORDER QTY"].Width = 200;
                    detailGridView.Columns["ORDER QTY"].ReadOnly = true;

                    detailGridView.Columns["DELIVERED QTY"].Width = 200;
                    detailGridView.Columns["DELIVERED QTY"].ReadOnly = true;

                    qtyColumn.Name = "qty";
                    qtyColumn.HeaderText = "QTY";
                    qtyColumn.Width = 200;
                    detailGridView.Columns.Add(qtyColumn);

                    for (int i = 0; i < detailGridView.Rows.Count; i++)
                    {
                        if (detailGridView.Rows[i].Cells["IS_COMPLETED"].Value.ToString().Equals("1"))
                            detailGridView.Rows[i].Cells["QTY"].ReadOnly = true;
                        else
                            detailGridView.Rows[i].Cells["QTY"].Style.BackColor = Color.LightBlue;

                        detailGridView.Rows[i].Cells["QTY"].Value = 0;
                        deliveryQty.Add("0");
                    }

                }
            }
            rdr.Close();

            isLoading = false;
        }

        private void detailGridViewEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailGridView.CurrentCell.OwningColumn.Name == "qty")
                && e.Control is TextBox)
            {
                TextBox qtyTextBox = e.Control as TextBox;
                //qtyTextBox.TextChanged -= qtyTextBox_TextChanged;
                //qtyTextBox.TextChanged += qtyTextBox_TextChanged;
            }
        }

        private void qtyTextBox_TextChanged(object sender, EventArgs e)
        {
            //int rowSelectedIndex = 0;
            //string cellValue = "";
            //string previousInput = "";
            //string tempString = "";
            //string columnName = "qty";
            //string productID = "";

            //DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            //rowSelectedIndex = detailGridView.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = detailGridView.Rows[rowSelectedIndex];

            //if (isLoading)
            //    return;

            //cellValue = dataGridViewTextBoxEditingControl.Text;

            //if (cellValue.Length <= 0)
            //{
            //    // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
            //    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : detailGridView_CellValueChanged , empty texbox, reset [" + columnName + "] value to 0");
            //    isLoading = true;

            //    deliveryQty[rowSelectedIndex] = "0";
            //    selectedRow.Cells[columnName].Value = "0";

            //    isLoading = false;

            //    return;
            //}

            //previousInput = deliveryQty[rowSelectedIndex];

            //isLoading = true;
            //if (previousInput == "0")
            //{
            //    tempString = cellValue;
            //    if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
            //        selectedRow.Cells[columnName].Value = tempString.Remove(tempString.IndexOf('0'), 1);

            //    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text [" + cellValue + "]");
            //}

            //if (gUtil.matchRegEx(cellValue, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
            //    && (cellValue.Length > 0 && cellValue != ".")
            //    )
            //{
            //    productID = selectedRow.Cells["PRODUCT_ID"].Value.ToString();

            //    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text pass REGEX Checking");
            //    if (gUtil.stockIsEnough(productID, Convert.ToDouble(cellValue)))
            //    {
            //        deliveryQty[rowSelectedIndex] = cellValue;
            //        errorLabel.Text = "";
            //    }
            //    else
            //    {
            //        selectedRow.Cells[columnName].Value = deliveryQty[rowSelectedIndex];
            //        errorLabel.Text = "STOK TIDAK CUKUP";
            //    }
            //}
            //else
            //{
            //    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text did not pass REGEX Checking");
            //    selectedRow.Cells[columnName].Value = previousInput;
            //    dataGridViewTextBoxEditingControl.Text = previousInput;
            //}

            //isLoading = false;
        }


        private void deliveryOrderForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            DODtPicker.Format = DateTimePickerFormat.Custom;
            DODtPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            errorLabel.Text = "";

            loadInvoiceData();

            arrButton[0] = saveButton;
            arrButton[1] = reprintButton;

            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);

            //detailGridView.EditingControlShowing += detailGridViewEditingControlShowing;
        }

        private bool dataValidated()
        {
            if (noInvoiceTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NO DO TIDAK BOLEH KOSONG";
                return false;
            }

            bool validInput = true;
            double orderQty = 0, deliveredQty = 0, qty = 0;
            int i = 0;
            string productID = "";
            string reason = "";
            for (i = 0; i < detailGridView.Rows.Count && validInput; i++)
            {
                // CHECK REGEX
                if (!gUtil.matchRegEx(detailGridView.Rows[i].Cells["QTY"].Value.ToString(), globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                { 
                    validInput = false;
                    reason = "HARUS BERUPA ANGKA";
                }

                // CHECK STOCK
                qty = Convert.ToDouble(detailGridView.Rows[i].Cells["QTY"].Value);
                productID = detailGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString();

                gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text pass REGEX Checking");
                if (!gUtil.stockIsEnough(productID, qty))
                {
                    validInput = false;
                    reason = "MELEBIHI JUMLAH STOK";
                }

                // CHECK ORDER AND DELIVERY
                orderQty = Convert.ToDouble(detailGridView.Rows[i].Cells["ORDER QTY"].Value);
                deliveredQty = Convert.ToDouble(detailGridView.Rows[i].Cells["DELIVERED QTY"].Value);

                if (qty > (orderQty - deliveredQty))
                { 
                    validInput = false;
                    reason = "MELEBIHI JUMLAH PESANAN";
                }
            }
            if (!validInput)
            {
                errorLabel.Text = "INPUT QTY PADA BARIS [" + i + "] " + reason;
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;
            string productID = "";
            double orderQty = 0;
            double deliveredQty = 0;
            double qty = 0;
            int fullfilledItem = 0;
            int status = 0;
            int lineItemID = 0;
            int locationID = gUtil.loadlocationID(2);

            string selectedDate = DODtPicker.Value.ToShortDateString();
            string DODateTime = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // INSERT DATA HEADER
                sqlCommand = "INSERT INTO DELIVERY_ORDER_HEADER (DO_ID, SALES_INVOICE, REV_NO, DO_DATE) VALUES ('" + doInvoiceTextBox.Text + "', '" + selectedSalesInvoice + "', " + salesRevNo + ", STR_TO_DATE('" + DODateTime + "', '%d-%m-%Y'))";
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // INSERT DATA DETAIL
                for (int i =0;i<detailGridView.Rows.Count;i++)
                {
                    productID = detailGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString();
                    orderQty = Convert.ToDouble(detailGridView.Rows[i].Cells["ORDER QTY"].Value);
                    deliveredQty = Convert.ToDouble(detailGridView.Rows[i].Cells["DELIVERED QTY"].Value);
                    qty = Convert.ToDouble(detailGridView.Rows[i].Cells["QTY"].Value);
                    status = Convert.ToInt32(detailGridView.Rows[i].Cells["IS_COMPLETED"].Value);
                    lineItemID = Convert.ToInt32(detailGridView.Rows[i].Cells["ID"].Value);

                    if (status == 0 && qty > 0)
                    {
                        // INSERT INTO DETAIL
                        sqlCommand = "INSERT INTO DELIVERY_ORDER_DETAIL (DO_ID, PRODUCT_ID, PRODUCT_QTY) VALUES ('" + doInvoiceTextBox.Text + "', '" + productID + "', " + qty + ")";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // REDUCE STOCK
                        if (!gUtil.productIsService(productID))
                        {
                            // REDUCE STOCK AT MASTER STOCK
                            sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + qty + " WHERE PRODUCT_ID = '" + productID + "'";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // REDUCE STOCK AT PRODUCT LOCATION
                            sqlCommand = "UPDATE PRODUCT_LOCATION SET PRODUCT_LOCATION_QTY = PRODUCT_LOCATION_QTY - " + qty + " WHERE PRODUCT_ID = '" + productID + "' AND LOCATION_ID = " + locationID;
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        if (orderQty <= deliveredQty + qty)
                        {
                            // ORDER FULFILLED
                            fullfilledItem++;

                            sqlCommand = "UPDATE SALES_DETAIL SET IS_COMPLETED = 1 WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND REV_NO = " + salesRevNo + " AND PRODUCT_QTY = " + orderQty + " AND ID = " + lineItemID;
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                    }
                    else if (status == 1)
                        fullfilledItem++;
                }

                if (fullfilledItem == detailGridView.Rows.Count)
                {
                    // WHOLE ORDER COMPLETED
                    // UPDATE SALES HEADER SET SALES ACTIVE TO 0
                    sqlCommand = "UPDATE SALES_HEADER SET SALES_ACTIVE = 0 WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND REV_NO = '" + salesRevNo + "'";
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                DS.commit();
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        private bool saveData()
        {
            if (dataValidated())
                return saveDataTransaction();

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveButton.Focus();
            if (DialogResult.Yes == MessageBox.Show("SAVE DAN PRINT OUT ? ", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                if (saveData())
                {
                    //MessageBox.Show("SUCCESS");
                    gUtil.showSuccess(1);
                    gUtil.setReadOnlyAllControls(this);
                    reprintButton.Enabled = true;

                    doInvoiceTextBox.ReadOnly = true;
                    DODtPicker.Enabled = false;

                    printOutDeliveryOrder(selectedSalesInvoice, salesRevNo);
                }
                else
                {
                    //MessageBox.Show("FAIL");
                    gUtil.showError();
                }
        }

        private bool isNoPRExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM DELIVERY_ORDER_HEADER WHERE DO_ID = '" + MySqlHelper.EscapeString(doInvoiceTextBox.Text) + "'")) > 0)
                result = true;

            return result;
        }

        private void doInvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (doInvoiceTextBox.Text.Length > 0)
                if (isNoPRExist())
                {
                    errorLabel.Text = "NO PENGIRIMAN SUDAH ADA";
                }
                else
                    errorLabel.Text = "";
        }

        private void checkQtyContent(DataGridViewCellEventArgs e)
        {
            int rowSelectedIndex = 0;
            string cellValue = "";
            string columnName = "";
            string productID = "";
            //string tempString = "", previousInput = "";
            var cell = detailGridView[e.ColumnIndex, e.RowIndex];
            DataGridViewRow selectedRow = detailGridView.Rows[e.RowIndex];

            if (isLoading)
                return;

            rowSelectedIndex = e.RowIndex;
            columnName = cell.OwningColumn.Name;

            gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : detailGridView_CellValueChanged [" + columnName + "]");

            if (null != selectedRow.Cells[columnName].Value)
                cellValue = selectedRow.Cells[columnName].Value.ToString();
            else
                cellValue = "";

            if (columnName == "qty")
            {
                //if (cellValue.Length <= 0)
                //{
                //    // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                //    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : detailGridView_CellValueChanged , empty texbox, reset [" + columnName + "] value to 0");
                //    isLoading = true;

                //    deliveryQty[rowSelectedIndex] = "0";
                //    selectedRow.Cells[columnName].Value = "0";

                //    isLoading = false;

                //    return;
                //}

                //previousInput = deliveryQty[rowSelectedIndex];

                //isLoading = true;
                //if (previousInput == "0")
                //{
                //    tempString = cellValue;
                //    if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                //        selectedRow.Cells[columnName].Value = tempString.Remove(tempString.IndexOf('0'), 1);

                //    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text [" + cellValue + "]");
                //}

                if (gUtil.matchRegEx(cellValue, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (cellValue.Length > 0 && cellValue != ".")
                    )
                {
                    productID = selectedRow.Cells["PRODUCT_ID"].Value.ToString();

                    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text pass REGEX Checking");
                    if (gUtil.stockIsEnough(productID, Convert.ToDouble(cellValue)))
                    {
   //                     deliveryQty[rowSelectedIndex] = cellValue;
                        errorLabel.Text = "";
                    }
                    else
                    {
   //                     selectedRow.Cells[columnName].Value = deliveryQty[rowSelectedIndex];
                        errorLabel.Text = "STOK TIDAK CUKUP PADA BARIS [" + rowSelectedIndex + "]";
                    }
                }
                else
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "DELIVERY ORDER : TextBox_TextChanged, dataGridViewTextBoxEditingControl.Text did not pass REGEX Checking");
                    //              selectedRow.Cells[columnName].Value = previousInput;
                    errorLabel.Text = "INPUT QTY PADA BARIS [" + rowSelectedIndex +"] SALAH";
                }
            }

            isLoading = false;
        }

        private void detailGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkQtyContent(e);
        }

        private void detailGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (detailGridView.IsCurrentCellDirty)
            {
                detailGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void detailGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            detailGridView.SuspendLayout();
        }

        private void detailGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            detailGridView.ResumeLayout();
        }

        private void reprintButton_Click(object sender, EventArgs e)
        {
            printOutDeliveryOrder(selectedSalesInvoice, salesRevNo);
        }

        private void printOutDeliveryOrder(string SONo, string revNo)
        {
            string sqlCommandx = "SELECT '1' AS 'SALES_STATUS', DH.DO_DATE AS 'TGL', DH.SALES_INVOICE AS 'INVOICE', IFNULL(MC.CUSTOMER_FULL_NAME, '') AS 'CUSTOMER_NAME', MP.PRODUCT_NAME AS 'PRODUK', DD.PRODUCT_QTY AS 'QTY' " +
                                        "FROM DELIVERY_ORDER_HEADER DH, DELIVERY_ORDER_DETAIL DD, SALES_HEADER SH LEFT OUTER JOIN MASTER_CUSTOMER MC ON (SH.CUSTOMER_ID = MC.CUSTOMER_ID) , MASTER_PRODUCT MP " +
                                        "WHERE DH.SALES_INVOICE = '" + SONo + "' AND DD.DO_ID = DH.DO_ID AND DD.PRODUCT_ID = MP.PRODUCT_ID AND DH.REV_NO = '" + revNo + "' AND SH.SALES_INVOICE = '" + SONo + "' AND SH.REV_NO = '" + revNo + "'";

            DS.writeXML(sqlCommandx, globalConstants.deliveryOrderXML);
            deliveryOrderPrintOutForm displayForm = new deliveryOrderPrintOutForm();
            displayForm.ShowDialog(this);
        }
    }
}
