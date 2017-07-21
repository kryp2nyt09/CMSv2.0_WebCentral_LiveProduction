using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class CargoTransfer
    {
        public static DataSet GetCargoTransfer(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? originbcoid, Guid? desctbcoid, Guid? revenuetypeid, Guid? revenueunitid, string plateNo, Guid? batchid)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoTransfer", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@OriginBcoId", SqlDbType.UniqueIdentifier).Value = (object)originbcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)desctbcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@RevenueTypeId", SqlDbType.UniqueIdentifier).Value = (object)revenuetypeid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@RevenueunitId", SqlDbType.UniqueIdentifier).Value = (object)revenueunitid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@PlateNo", SqlDbType.VarChar, 100).Value = plateNo;
                da.SelectCommand.Parameters.Add("@BatchId", SqlDbType.UniqueIdentifier).Value = (object)batchid ?? DBNull.Value;
                
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


    }
}
