using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class Bundle
    {
        public static DataSet GetBundle(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? bcoId, Guid? destbcoId, string sackNumber)
        {
            using (SqlConnection con = new SqlConnection(conSTR ))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_Bundle", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)destbcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@SackNumber", SqlDbType.VarChar,20).Value = sackNumber;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetBundleNumber(string conSTR, string date)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GetBundleNumber", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = date;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
