using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Reports
{
    public class GatewayInbound
    {
        public static DataSet GetGatewayInbound(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? destbcoid, Guid? originbcoid, string gateway, Guid? commoditytypeid, string flightno, string mawb)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayInbound", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)destbcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@OriginBcoId", SqlDbType.UniqueIdentifier).Value = (object)originbcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Gateway", SqlDbType.VarChar, 100).Value = gateway;
                da.SelectCommand.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = (object)commoditytypeid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@FlightNo", SqlDbType.VarChar, 100).Value = flightno;
                da.SelectCommand.Parameters.Add("@Mawb", SqlDbType.VarChar, 20).Value = mawb;

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
