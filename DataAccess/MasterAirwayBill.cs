using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MasterAirwayBill
    {
        public static DataSet GetMasterAirwayBill(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_MasterAirwayBill", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetMasterAirwayBillBySearch(string mawb, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Search_MasterAirwayBill", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Mawb", SqlDbType.NVarChar).Value = mawb;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        
    }
}
