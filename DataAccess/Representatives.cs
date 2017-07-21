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
    public class Representatives
    {

        public static DataSet GetRepresentatives(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_representatives", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        
        public static DataSet GetRepresentativesByCompandId(string conSTR, Guid CompanyId)
{
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_representativesByCompany", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_representativesByCompany", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@companyid", SqlDbType.UniqueIdentifier).Value = CompanyId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetRepresentativesByClientId(string conSTR, Guid clientId)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_representativesById", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_representativesById", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = clientId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static void InsertRepresentatives(string firstName, string lastName, string contactNo, string mobile, string fax,
                                                    string email, string address1, string address2, Guid cityId, string zipCode,
                                                    string title, string department, string remarks, Guid? companyId, Guid areaId,
                                                    string street, string barangay, Guid createdBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Representatives", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirsName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastName;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = contactNo;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mobile;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@Address1", SqlDbType.NVarChar).Value = address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.NVarChar).Value = address2;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = cityId;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = zipCode;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = department;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = remarks;
                    //cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = (object)companyId ?? DBNull.Value;
                    cmd.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = areaId;
                    cmd.Parameters.Add("@Street", SqlDbType.NVarChar).Value = street;
                    cmd.Parameters.Add("@Barangay", SqlDbType.NVarChar).Value = barangay;
                    cmd.Parameters.Add("@CreatedModifiedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRepresentatives(Guid clientId, string firstName, string lastName, string contactNo, string mobile, string fax,
                                                    string email, string address1, string address2, Guid cityId, string zipCode,
                                                    string title, string department, string remarks, Guid? companyId, Guid areaId,
                                                    string street, string barangay, Guid createdBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Representatives", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = clientId;
                    cmd.Parameters.Add("@FirsName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastName;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = contactNo;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mobile;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@Address1", SqlDbType.NVarChar).Value = address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.NVarChar).Value = address2;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = cityId;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = zipCode;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = department;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = remarks;
                    //cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = (object)companyId ?? DBNull.Value;
                    cmd.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = areaId;
                    cmd.Parameters.Add("@Street", SqlDbType.NVarChar).Value = street;
                    cmd.Parameters.Add("@Barangay", SqlDbType.NVarChar).Value = barangay;
                    cmd.Parameters.Add("@CreatedModifiedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
