using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class Reason
    {
        public static void InsertReason(Guid statusId, string reasonCode, string reasonName, Guid CreatedBy,int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Reason", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StatusId", SqlDbType.UniqueIdentifier).Value = statusId;
                    cmd.Parameters.Add("@ReasonCode", SqlDbType.VarChar).Value = reasonCode;
                    cmd.Parameters.Add("@ReasonName", SqlDbType.VarChar).Value = reasonName;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateReason(Guid reasonId, Guid statusId, string reasonName, Guid ModifiedBy , int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Reason", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReasonID", SqlDbType.UniqueIdentifier).Value = reasonId;
                    cmd.Parameters.Add("@StatusID", SqlDbType.UniqueIdentifier).Value = statusId;
                    cmd.Parameters.Add("@ReasonName", SqlDbType.VarChar).Value = reasonName;
                    cmd.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteReason(Guid reasonId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Reason", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReasonId", SqlDbType.UniqueIdentifier).Value = reasonId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetReasonByReasonId(Guid reasonId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ReasonByReasonId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ReasonID", SqlDbType.UniqueIdentifier).Value = reasonId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

    }
}
