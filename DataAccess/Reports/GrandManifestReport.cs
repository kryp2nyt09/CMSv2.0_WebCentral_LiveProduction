using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class GrandManifestReport
    {
        public static DataSet GetGrandManifestData(string conSTR, DateTime dateFrom, DateTime DateTo, string originbco, string destbco, string servicemode, string paymentmode, string servicetype, string shipmode)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GrandManifest", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)DateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@OriginBco", SqlDbType.VarChar).Value = originbco;
                da.SelectCommand.Parameters.Add("@DestBco", SqlDbType.VarChar).Value = destbco;
                da.SelectCommand.Parameters.Add("@ServiceMode", SqlDbType.VarChar).Value = servicemode;
                da.SelectCommand.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = paymentmode;
                da.SelectCommand.Parameters.Add("@ServiceType", SqlDbType.VarChar).Value = servicetype;
                da.SelectCommand.Parameters.Add("@ShipMode", SqlDbType.VarChar).Value = shipmode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
