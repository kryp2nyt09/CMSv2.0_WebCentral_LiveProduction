using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class GatewayOutbound
    {
         public static DataSet GetGatewayOutbound(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? originbcoId, Guid? destbcoId, string driver, string gateway, Guid? batchid, Guid? commoditytypeid, string mawb)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayOutbound", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@OriginBcoId", SqlDbType.UniqueIdentifier).Value = (object)originbcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)destbcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Driver", SqlDbType.VarChar, 100).Value = driver;
                da.SelectCommand.Parameters.Add("@Gateway", SqlDbType.VarChar, 100).Value = gateway;
                da.SelectCommand.Parameters.Add("@BatchId", SqlDbType.UniqueIdentifier).Value = (object)batchid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = (object)commoditytypeid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Mawb", SqlDbType.VarChar, 100).Value = mawb;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
