using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Remarks
    {
        public static void InsertRemarkName(string remarkName, string remarkCode, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Remarks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RemarkName", SqlDbType.VarChar).Value = remarkName;
                    cmd.Parameters.Add("@RemarkCode", SqlDbType.VarChar).Value = remarkCode;
                    cmd.Parameters.Add("@Createdby", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRemarkName(Guid remarkId, string remarkName, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Remarks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RemarkID", SqlDbType.UniqueIdentifier).Value = remarkId;
                    cmd.Parameters.Add("@RemarkName", SqlDbType.VarChar).Value = remarkName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void DeleteRemarkName(Guid remarkId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Remarks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RemarkID", SqlDbType.UniqueIdentifier).Value = remarkId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetRemarkByRemarkID(string conStr, Guid remarkId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_RemarksByRemarkId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_RemarksByRemarkId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RemarkID", SqlDbType.UniqueIdentifier).Value = remarkId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
