using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class SalesPerClient
    {
        public static DataSet GetSalesPerClient(string conSTR, string client ,DateTime? date1, DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_SalesPerClient", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CLIENT", SqlDbType.NVarChar).Value = client;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
