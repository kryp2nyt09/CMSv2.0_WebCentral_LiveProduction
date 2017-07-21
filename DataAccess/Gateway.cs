using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class Gateway
    {
    
        public static DataSet GetGateway(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Gateway", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        //public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        //{
        //    using (SqlConnection con = new SqlConnection(conStr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_Delete_Client", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@ClientID", SqlDbType.UniqueIdentifier).Value = ClientID;
        //            cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}


    }
}
