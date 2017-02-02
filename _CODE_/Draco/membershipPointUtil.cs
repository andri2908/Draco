using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSoft
{
    class membershipPointUtil
    {
        private globalUtilities gUtil = new globalUtilities();

        private const double pointExchangeParam = 100000;
        public const double cashBackExchangeParam = 2500;
        private const double minSalesNominal = 500000;
        private const double maxCashBackExchangePercentage = 50;

        private Data_Access DS = new Data_Access();

        public double calculateMembershipPoint(double salesNominal)
        {
            double result = 0;

            if (salesNominal >= minSalesNominal)
                result = Math.Round(salesNominal / pointExchangeParam);

            return result; 
        }

        public double calculateCashbackPoint(double pointNominal)
        {
            double result = 0;

            result = pointNominal * cashBackExchangeParam;

            return result;
        }

        public bool isCustomerExist(int selectedPelangganID)
        {
            bool result;
            string sqlCommand = "";

            sqlCommand = "SELECT EXISTS(SELECT 1 FROM MEMBERSHIP_POINT WHERE CUSTOMER_ID = " + selectedPelangganID +")";

            result = Convert.ToBoolean(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        public double getCurrentPoints(int selectedPelangganID)
        {
            double result = 0;
            string sqlCommand = "";

            sqlCommand = "SELECT IFNULL(POINTS_AMOUNT, 0) FROM MEMBERSHIP_POINT WHERE CUSTOMER_ID = " + selectedPelangganID;

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        public double getMaxCashBackPoint(double currentPoint, double totalSalesValue)
        {
            double result = 0;
            double maxCashBackValue = 0;
            double maxCashBackPoint = 0;

            maxCashBackValue = Math.Round(totalSalesValue * maxCashBackExchangePercentage / 100);
            maxCashBackPoint = Math.Round(maxCashBackValue / cashBackExchangeParam);

            if (maxCashBackPoint > currentPoint)
                result = currentPoint;
            else
                result = maxCashBackPoint;

            return result;
        }

        public void checkMembershipPointExpiryDate(int customerID)
        {
            int lastUpdatedMonth = 0;
            int currentMonth = 0;
            DateTime currentDate = DateTime.Now;
            string sqlCommand;            

            if (customerID == 0)
                return;

            sqlCommand = "SELECT MONTH(LAST_UPDATE_DATE) FROM MEMBERSHIP_POINT WHERE CUSTOMER_ID = " + customerID;

            lastUpdatedMonth = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));
            currentMonth = currentDate.Month;

            if (lastUpdatedMonth != currentMonth)
            {
                // RESET POIN
                DS.beginTransaction();

                try
                {
                    sqlCommand = "UPDATE MEMBERSHIP_POINT SET POINTS_AMOUNT = 0, LAST_UPDATE_DATE = STR_TO_DATE('" + currentDate + "', '%d-%m-%Y') WHERE CUSTOMER_ID = " + customerID;

                    DS.executeNonQueryCommand(sqlCommand);
                    DS.commit();

                    gUtil.saveSystemDebugLog(0, "UPDATE POIN SUCCESS");
                }
                catch (Exception ex)
                {
                    gUtil.saveSystemDebugLog(0, "UPDATE POIN FAILED");
                }
            }
        }
    }
}
