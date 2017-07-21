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
    public class ApprovingAuthority
    {

        public static DataSet GetApprovingAuthority(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ApprovingAuthority", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetApprovingAuthorityByID(string conSTR, Guid CompanyId)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_AppprovingAuthorityByCompanyId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_AppprovingAuthorityByCompanyId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Companyid", SqlDbType.UniqueIdentifier).Value = CompanyId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetApprovingAuthorityDetailsByID(string conSTR, Guid AuthorityId)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_ApprovingAuthorityByAuthId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_ApprovingAuthorityByAuthId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ApprovingAuthorityId", SqlDbType.UniqueIdentifier).Value = AuthorityId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static void DeleteApprovingAuthority(Guid ApprovingAuthorityId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_ApprovingAuthority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ApprovingAuthorityId", SqlDbType.UniqueIdentifier).Value = ApprovingAuthorityId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateApprovingAuthorityDetails(Guid ApprovingAuthorityId, string FirstName, string Lastname, string title, string position, 
                        string department, string ContactNo, string Mobile, string Fax, string Email, 
                        Guid CompanyId,  Guid ModifiedBy, string conStr)

        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_ApprovingAuthority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lastname;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = position;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = department;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = ContactNo;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Mobile;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = CompanyId;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@ApprovingAuthorityId", SqlDbType.UniqueIdentifier).Value = ApprovingAuthorityId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertApprovingAuthorityDetails(string FirstName, string Lastname, string title, string position, string department,
                    string ContactNo, string Mobile, string Fax, string Email, Guid CompanyId, Guid CreatedBy, string conStr)

        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_ApprovingAuthority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lastname;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = position;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = department;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = ContactNo;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Mobile;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = CompanyId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
