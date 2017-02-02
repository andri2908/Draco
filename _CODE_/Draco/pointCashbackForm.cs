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
    public partial class pointCashbackForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private membershipPointUtil memUtil = new membershipPointUtil();
        private double currentPointValue = 0;
        private double maxCashBackPoints = 0;

        private int selectedCustomerID = 0;
        private double totalSalesValue = 0;

        private cashierForm originForm = null;

        public pointCashbackForm()
        {
            InitializeComponent();
        }

        public pointCashbackForm(int customerID, double totalSales, cashierForm parentForm)
        {
            InitializeComponent();

            selectedCustomerID = customerID;
            totalSalesValue = totalSales;
            originForm = parentForm;
        }

        private void pointCashbackForm_Load(object sender, EventArgs e)
        {
            currentPointValue = memUtil.getCurrentPoints(selectedCustomerID);
            maxCashBackPoints = memUtil.getMaxCashBackPoint(currentPointValue, totalSalesValue);

            currentPoint.Text = currentPointValue.ToString();
            maxPoint.Text = maxCashBackPoints.ToString();

            errorLabel.Text = "";
            pointValue.Text = "0";
        }

        private void pointValue_TextChanged(object sender, EventArgs e)
        {
            double pointTextValue = 0;
            string pointValueAmount = pointValue.Text.Trim();
            if (pointValue.Text.Length > 0)
            {
                pointTextValue = Convert.ToDouble(pointValueAmount);
                cashbackValue.Text = memUtil.calculateCashbackPoint(pointTextValue).ToString();
            }
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            double newPointValue = 0;
            double exchangedPoint = 0;
            exchangedPoint = Convert.ToDouble(pointValue.Text);
            newPointValue = currentPointValue - exchangedPoint;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                sqlCommand = "UPDATE MEMBERSHIP_POINT SET POINTS_AMOUNT = " + newPointValue + " WHERE CUSTOMER_ID = " + selectedCustomerID;

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

        private bool dataValidated()
        {
            if (selectedCustomerID == 0)
            {
                errorLabel.Text = "PELANGGAN KOSONG";
                return false;
            }

            if (pointValue.Text.Length < 0)
            {
                errorLabel.Text = "POIN TIDAK BOLEH KOSONG";
                return false;
            }

            if (maxCashBackPoints < Convert.ToDouble(pointValue.Text))
            {
                errorLabel.Text = "PENUKARAN POIN MELEBIHI BATAS";
                return false;
            }

            return true;
        }

        private bool saveData()
        {
            bool result = false;
            double exchangedPoint = 0;
            exchangedPoint = Convert.ToDouble(pointValue.Text);

            if (dataValidated())
            {
                originForm.setPointsToExchangeValue(exchangedPoint);
                result = true;
            }
//                result = saveDataTransaction();

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
                this.Close();

            //if (DialogResult.Yes == MessageBox.Show("TUKARKAN POIN ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            //{
            //    if (saveData())
            //    {
            //        MessageBox.Show("PENUKARAN POIN BERHASIL");
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("PENUKARAN POIN GAGAL");
            //    }
            //}
        }

        private void pointValue_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                pointValue.SelectAll();
            });
        }
    }
}
