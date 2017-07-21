using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class HoldCargo
    {
        public static DataSet GetGatewayOutbound(string conSTR, DateTime dateFrom, DateTime dateTo, string bco)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_HoldCargo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = dateFrom;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = dateTo;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = bco;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
