using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Airlines
    {
        public static void InsertAirlines(string airlineName , string airlineCode, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Airlines", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AirlineCode", SqlDbType.VarChar).Value = airlineCode;
                    cmd.Parameters.Add("@AirlineName", SqlDbType.VarChar).Value = airlineName;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static void UpdateAirlines(Guid airlineId, string airlineName, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Airlines", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AirlineID", SqlDbType.UniqueIdentifier).Value = airlineId;
                    cmd.Parameters.Add("@AirlineName", SqlDbType.VarChar).Value = airlineName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAirlines(Guid airlineId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Airlines", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AirlineID", SqlDbType.UniqueIdentifier).Value = airlineId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static DataSet GetAirlineByAirlineID(string conStr, Guid airlineId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_AirlinesByAirlineId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_AirlinesByAirlineId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AirlineID", SqlDbType.UniqueIdentifier).Value = airlineId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        
        public static DataSet GetAllAirlines(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_GetAllAirlines", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
