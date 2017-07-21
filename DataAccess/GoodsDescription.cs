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
    public class GoodsDescription
    {

        public static DataSet GetGoodsDescription(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_GoodsDescription", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetGoodsDescriptionById(Guid GoodDescId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_GoodsDescriptionByID", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@GoodsDescId", SqlDbType.UniqueIdentifier).Value = GoodDescId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void DeleteGoodsDesc(Guid GoodDescId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_GoodDesc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GoodsDescId", SqlDbType.UniqueIdentifier).Value = GoodDescId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void InsertGoodsDesc(Guid CreatedBy, string GoodDescName, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_GoodsDesc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GoodsDescName", SqlDbType.VarChar).Value = GoodDescName;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateGoodsDesc(Guid GoodDescId, Guid CreatedBy, string GoodDescName, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_GoodsDesc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GoodsDescName", SqlDbType.VarChar).Value = GoodDescName;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@GoodDescId", SqlDbType.UniqueIdentifier).Value = GoodDescId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
