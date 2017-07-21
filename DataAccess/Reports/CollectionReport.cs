using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Reports
{
    public class CollectionReport
    {
        public static DataSet GetCollection(string conSTR,string bcostr ,string type,DateTime? date1,DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_Collection", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = bcostr;
                da.SelectCommand.Parameters.Add("@TYPE", SqlDbType.VarChar).Value = type;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
