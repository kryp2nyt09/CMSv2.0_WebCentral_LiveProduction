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
    public class ServiceMode
    {

        public static DataSet GetServiceMode(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ServiceMode", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeleteServiceMode(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_ServiceMode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ServiceModeId  ", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetServiceModeID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ServiceModeById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ServiceModeId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }



 

        public static void UpdateServiceMode(Guid @ServiceModeId, Guid CreatedBy, string servicemodecode, string servicename, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_ServiceMode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("ServiceModeId", SqlDbType.UniqueIdentifier).Value = ServiceModeId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@ServiceModeName ", SqlDbType.VarChar).Value = servicename;
                    cmd.Parameters.Add("@ServiceModeCode", SqlDbType.VarChar).Value = servicemodecode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static void InsertServiceMode( Guid CreatedBy, string servicemodecode, string servicename, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_ServiceMode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@ServiceModeName ", SqlDbType.VarChar).Value = servicename;
                    cmd.Parameters.Add("@ServiceModeCode", SqlDbType.VarChar).Value = servicemodecode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
