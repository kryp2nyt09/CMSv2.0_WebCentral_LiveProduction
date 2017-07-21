using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class MasterSales
    {
        public static DataSet GetMasterSales(string conSTR, DateTime date1, DateTime date2, string BCOShipperStr, string BCOConsigneeStr, string ShipModeStr, string ComTypeStr, string ServiceModeStr, string PayModeStr, string UserStr)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_MasterSales", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                da.SelectCommand.Parameters.Add("@BCOShipper", SqlDbType.VarChar).Value = BCOShipperStr;
                da.SelectCommand.Parameters.Add("@BCOConsignee", SqlDbType.VarChar).Value = BCOConsigneeStr;
                da.SelectCommand.Parameters.Add("@SHIPMODE", SqlDbType.VarChar).Value = ShipModeStr;
                da.SelectCommand.Parameters.Add("@COMTYPE", SqlDbType.VarChar).Value = ComTypeStr;
                da.SelectCommand.Parameters.Add("@SERVICEMODE", SqlDbType.VarChar).Value = ServiceModeStr;
                da.SelectCommand.Parameters.Add("@PAYMODE", SqlDbType.VarChar).Value = PayModeStr;
                da.SelectCommand.Parameters.Add("@USER", SqlDbType.VarChar).Value = UserStr;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
