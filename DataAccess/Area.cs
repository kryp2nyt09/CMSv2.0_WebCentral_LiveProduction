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
    public class Area
    {

        public static DataSet GetArea(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Area", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetAreaById(Guid AreaId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AreaById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = AreaId;
           
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static void DeleteArea(Guid RevenueUnitId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Area", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteRevenueUnitType(Guid RevenueUnitId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_RevenueTypeId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RevenuTypeId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void InsertArea( Guid RevenueUnitTypeId, Guid CityId, Guid ClusterId, Guid Createdby,
            string ContactNo1, string ContactNo2, string fax, string zipcode,
            string RevenueUnitName, string StreedAddress, string Description, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Area", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;
               
                    cmd.Parameters.Add("@RevenueUnitTypeId", SqlDbType.UniqueIdentifier).Value = RevenueUnitTypeId;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = CityId;
                    cmd.Parameters.Add("@ClusterId", SqlDbType.UniqueIdentifier).Value = ClusterId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = Createdby;
                    cmd.Parameters.Add("@StreedAddress", SqlDbType.VarChar).Value = StreedAddress;
                    cmd.Parameters.Add("@ContactNo1", SqlDbType.VarChar).Value = ContactNo1;
                    cmd.Parameters.Add("@ContactNo2", SqlDbType.VarChar).Value = ContactNo2;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = fax;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = zipcode;
                    cmd.Parameters.Add("@RevenueUnitName", SqlDbType.VarChar).Value = RevenueUnitName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateArea(Guid RevenueUnitId, Guid RevenueUnitTypeId, Guid CityId, Guid ClusterId, Guid Createdby,
       string ContactNo1, string ContactNo2, string fax, string zipcode,
       string RevenueUnitName, string StreedAddress, string Description, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Area", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;
                    cmd.Parameters.Add("@RevenueUnitName", SqlDbType.VarChar).Value = RevenueUnitName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
                    cmd.Parameters.Add("@RevenueUnitTypeId", SqlDbType.UniqueIdentifier).Value = RevenueUnitTypeId;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = CityId;
                    cmd.Parameters.Add("@ClusterId", SqlDbType.UniqueIdentifier).Value = ClusterId;
                    cmd.Parameters.Add("@StreedAddress", SqlDbType.VarChar).Value = StreedAddress;
                    cmd.Parameters.Add("@ContactNo1", SqlDbType.VarChar).Value = ContactNo1;
                    cmd.Parameters.Add("@ContactNo2", SqlDbType.VarChar).Value = ContactNo2;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = fax;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = zipcode;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = Createdby;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
