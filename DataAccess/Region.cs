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
    public class Region
    {

        public static DataSet GetRegion(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_region", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static DataSet GetRegionById(Guid RegionID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_regionbyId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RegionID", SqlDbType.UniqueIdentifier).Value = RegionID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void DeleteRegion(Guid RegionId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_region", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RegionId", SqlDbType.UniqueIdentifier).Value = RegionId;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static void UpdateRegion(Guid RegionId, Guid GroupId, Guid ModifiedBy, string regionName, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_regionbyId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RegionId", SqlDbType.UniqueIdentifier).Value = RegionId;
                    cmd.Parameters.Add("@GroupId", SqlDbType.UniqueIdentifier).Value = GroupId;
                    cmd.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@RegionName", SqlDbType.VarChar).Value = regionName;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void InsertRegion(Guid GroupId, Guid CreatedBy, string regionName, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_region", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@GroupId", SqlDbType.UniqueIdentifier).Value = GroupId;
                    cmd.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@RegionName", SqlDbType.VarChar).Value = regionName;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
