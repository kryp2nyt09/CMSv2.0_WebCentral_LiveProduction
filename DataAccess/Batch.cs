using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Batch
    {
        public static void InsertBatchName(string batchName, string batchCode, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Batch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BatchName", SqlDbType.VarChar).Value = batchName;
                    cmd.Parameters.Add("@BatchCode", SqlDbType.VarChar).Value = batchCode;
                    cmd.Parameters.Add("@Createdby", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBatchName(Guid batchId, string batchName, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Batch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BatchID", SqlDbType.UniqueIdentifier).Value = batchId;
                    cmd.Parameters.Add("@BatchName", SqlDbType.VarChar).Value = batchName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteBatchName(Guid batchId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Batch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BatchID", SqlDbType.UniqueIdentifier).Value = batchId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetBatchByBatchID(string conStr, Guid batchId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_BatchByBatchId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_BatchByBatchId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@BatchID", SqlDbType.UniqueIdentifier).Value = batchId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetBatchByBatchCode(string conStr, string Code)
        {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_view_BatchByBatchCode", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter("sp_view_BatchByBatchCode", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@BatchCode", SqlDbType.VarChar).Value = Code;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
        }

        public static DataSet GetBranchAcceptanceDriver(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_BranchAcceptanceDriver", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_BranchAcceptanceDriver", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
