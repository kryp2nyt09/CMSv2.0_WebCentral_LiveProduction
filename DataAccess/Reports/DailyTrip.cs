using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class DailyTrip
    {
        public static DataSet GetDailyTrip(string conSTR, DateTime? datefrom, DateTime? dateTo, Guid? bcoid, Guid? revenueunitid, Guid? batchid, Guid? paymentmodeid)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_DailyTripReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom ", SqlDbType.Date).Value = (object)datefrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = (object)revenueunitid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BatchId", SqlDbType.UniqueIdentifier).Value = (object)batchid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@PaymentModeid", SqlDbType.UniqueIdentifier).Value = (object)paymentmodeid ?? DBNull.Value;
                DataSet ds = new DataSet();
                da.Fill(ds);
               // Console.Write)
                return ds;
            }

        }
    }
}
