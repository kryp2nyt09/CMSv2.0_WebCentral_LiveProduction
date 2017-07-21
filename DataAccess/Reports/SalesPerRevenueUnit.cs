using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class SalesPerRevenueUnit
    {
        public static DataSet GetSalesPerRevenueUnit(string conSTR, string bcostr,DateTime? date1,DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_SalesPerRevenueUnit", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.NVarChar).Value = bcostr;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
