using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class Segregation
    {
        public static DataSet GetSegregation(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? destbcoid , Guid? originbcoid, string driver, string plateno, Guid? batchid)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_Segregation", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)destbcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@OriginBcoId", SqlDbType.UniqueIdentifier).Value = (object)originbcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Driver", SqlDbType.VarChar, 100).Value = driver;
                da.SelectCommand.Parameters.Add("@PlateNo", SqlDbType.VarChar, 100).Value = plateno;
                da.SelectCommand.Parameters.Add("@BatchId", SqlDbType.UniqueIdentifier).Value = (object)batchid ?? DBNull.Value;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
