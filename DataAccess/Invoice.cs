using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Invoice
    {
        public static DataSet GetInvoice(DateTime start, DateTime end, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("GetInvoices", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@start", SqlDbType.Date).Value = start;
                da.SelectCommand.Parameters.Add("@end", SqlDbType.Date).Value = end;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
