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
    public class OrganizationType
    {

        public static DataSet GetOrganizationType(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_OrganizationType", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void Delete(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_OrganizationType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrganizationTypeID", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetById(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_OrganizationTypeById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@OrganizationTypeID", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }



        public static void Update(Guid OrganizationTypeID, Guid CreatedBy, string OrganizationTypeName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_OrganizationType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrganizationTypeID", SqlDbType.UniqueIdentifier).Value = OrganizationTypeID;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@OrganizationTypeName", SqlDbType.VarChar).Value = OrganizationTypeName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }


        public static void Insert( Guid CreatedBy, string OrganizationTypeName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_OrganizationType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@OrganizationTypeName", SqlDbType.VarChar).Value = OrganizationTypeName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }



    }
}
