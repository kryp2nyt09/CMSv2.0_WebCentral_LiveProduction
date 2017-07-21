using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class PaymentSummaryReport
    {
        public static DataSet GetPaymentSummaryData(DateTime? collectiondate, string bco, string revenuetype, string revenueunit, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Report_PaymentSummary", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CollectionDate", SqlDbType.Date).Value = (object)collectiondate ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Bco", SqlDbType.VarChar).Value = bco;
                da.SelectCommand.Parameters.Add("@Revenuetype", SqlDbType.VarChar).Value = revenuetype;
                da.SelectCommand.Parameters.Add("@RevenueUnit", SqlDbType.VarChar).Value = revenueunit;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetPaymentSummaryPrint(DateTime? collectiondate, string bco, string revenuetype, string revenueunit, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_PaymentSummary_Print", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CollectionDate", SqlDbType.Date).Value = (object)collectiondate ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Bco", SqlDbType.VarChar).Value = bco;
                da.SelectCommand.Parameters.Add("@Revenuetype", SqlDbType.VarChar).Value = revenuetype;
                da.SelectCommand.Parameters.Add("@RevenueUnit", SqlDbType.VarChar).Value = revenueunit;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetPaymentSummarySignature(DateTime? collectiondate, string bco, string revenuetype, string revenueunit, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_PaymentSummarySignature", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CollectionDate", SqlDbType.Date).Value = (object)collectiondate ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Bco", SqlDbType.VarChar).Value = bco;
                da.SelectCommand.Parameters.Add("@Revenuetype", SqlDbType.VarChar).Value = revenuetype;
                da.SelectCommand.Parameters.Add("@RevenueUnit", SqlDbType.VarChar).Value = revenueunit;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
