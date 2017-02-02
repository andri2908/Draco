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
    public partial class membershipPointViewer : Form
    {
        Data_Access DS = new Data_Access();
        private int selectedCustomerID = 0;

        public membershipPointViewer()
        {
            InitializeComponent();
        }

        private void fillInCustomerCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";

            customerCombo.Items.Clear();
            customerComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        customerCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        customerComboHidden.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadMembershipPointData()
        {
            string sqlCommand = "";
            DataTable dt = new DataTable();
            MySqlDataReader rdr;

            sqlCommand = "SELECT SALES_INVOICE AS 'SALES INVOICE', DATE_FORMAT(POINTS_EXCHANGE_DATE, '%d-%M-%Y') AS 'TANGGAL', POINTS_AMOUNT AS POINT FROM MEMBERSHIP_POINT_HISTORY WHERE CUSTOMER_ID = " + selectedCustomerID + " ORDER BY TANGGAL ASC";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    membershipPointDataGrid.DataSource = null;

                    dt.Load(rdr);
                    membershipPointDataGrid.DataSource = dt;
                }
            }
        }

        private void membershipPointViewer_Load(object sender, EventArgs e)
        {
            fillInCustomerCombo();
        }

        private void customerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomerID = Convert.ToInt32(customerComboHidden.Items[customerCombo.SelectedIndex]);
            loadMembershipPointData();
        }
    }
}
