using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class Status
    {
        public static void InsertStatusName(string statusName, string statusCode, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Status", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StatusName", SqlDbType.VarChar).Value = statusName;
                    cmd.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = statusCode;
                    cmd.Parameters.Add("@Createdby", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateStatusName(Guid statusId, string statusName, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Status", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StatusID", SqlDbType.UniqueIdentifier).Value = statusId;
                    cmd.Parameters.Add("@StatusName", SqlDbType.VarChar).Value = statusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteStatusName(Guid statusId, int Flag, string conStr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Status", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StatusID", SqlDbType.UniqueIdentifier).Value = statusId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    cmd.Parameters.Add("@rowCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    //count = cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@rowCount"].Value);
                }
            }

            return countRowsAffected;
        }



        public static DataSet GetStatusByStatusID(string conStr, Guid statusId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_StatusByStatusId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_StatusByStatusId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StatusID", SqlDbType.UniqueIdentifier).Value = statusId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetStatusByStatusCode(string conStr, string statusCode)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_StatusByStatusCode", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_StatusByStatusCode", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = statusCode;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
