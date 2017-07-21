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
    public class Cluster
    {

        public static DataSet GetCluster(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Cluster", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetClusterbyID( Guid ClusterID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ClusterById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ClusterId", SqlDbType.UniqueIdentifier).Value = ClusterID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static DataSet UpdateCluster(Guid ClusterID, Guid BranchCorpID, Guid ModifiedBy, string ClusterName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_update_cluster", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ClusterId", SqlDbType.UniqueIdentifier).Value = ClusterID;
                da.SelectCommand.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpID;
                da.SelectCommand.Parameters.Add("@Modifiedby", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                da.SelectCommand.Parameters.Add("@ClusterName", SqlDbType.VarChar).Value = ClusterName;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }

        }

        public static DataSet InsertCluster( Guid BranchCorpID, Guid ModifiedBy, string ClusterName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Insert_cluster", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                          da.SelectCommand.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpID;
                da.SelectCommand.Parameters.Add("@Modifiedby", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                da.SelectCommand.Parameters.Add("@ClusterName", SqlDbType.VarChar).Value = ClusterName;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }

        }

        public static void DeleteCluster(Guid ClientID, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Cluster", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClusterID", SqlDbType.UniqueIdentifier).Value = ClientID;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
