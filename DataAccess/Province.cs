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
    public class Province
    {

        public static DataSet GetProvince(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_province", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static DataSet GetProvinceById(Guid ProvinceID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_provincebyId", con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ProvinceId", SqlDbType.UniqueIdentifier).Value = ProvinceID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void DeleteProvince(Guid ProvinceId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_province", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProvinceId", SqlDbType.UniqueIdentifier).Value = ProvinceId;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateProvince(Guid ProvinceId, Guid RegionId, Guid ModifiedBy, string ProvinceName, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_provincebyId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProvinceID", SqlDbType.UniqueIdentifier).Value = ProvinceId;
                    cmd.Parameters.Add("@RegionId", SqlDbType.UniqueIdentifier).Value = RegionId;
                    cmd.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@ProvinceName", SqlDbType.VarChar).Value = ProvinceName;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static void InsertProvince(Guid RegionId, Guid ModifiedBy, string ProvinceName, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_provincebyId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RegionId", SqlDbType.UniqueIdentifier).Value = RegionId;
                    cmd.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@ProvinceName", SqlDbType.VarChar).Value = ProvinceName;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
