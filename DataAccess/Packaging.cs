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
    public class Packaging
    {

        public static DataSet GetPackaging(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Packaging", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetPackagingByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_PackagingById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@PackagingId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void UpdatePacking(Guid CratingId, string CratingName, decimal Multiplier, int BaseMinimum,
      int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_Packaging", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PackagingId", SqlDbType.UniqueIdentifier).Value = CratingId;
                    cmd.Parameters.Add("@PackagingName", SqlDbType.VarChar).Value = CratingName;
                    cmd.Parameters.Add("@Multiplier", SqlDbType.Decimal).Value = Multiplier;
                    cmd.Parameters.Add("@BaseMinimum", SqlDbType.Int).Value = BaseMinimum;
                    cmd.Parameters.Add("@BaseMaximum", SqlDbType.Int).Value = BaseMaximum;
                    cmd.Parameters.Add("@BaseFee", SqlDbType.Decimal).Value = basefee;
                    cmd.Parameters.Add("@ExcessCost", SqlDbType.Decimal).Value = excesscoast;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void InsertPacking(string CratingName, decimal Multiplier, int BaseMinimum,
   int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Packaging", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PackagingName", SqlDbType.VarChar).Value = CratingName;
                    cmd.Parameters.Add("@Multiplier", SqlDbType.Decimal).Value = Multiplier;
                    cmd.Parameters.Add("@BaseMinimum", SqlDbType.Int).Value = BaseMinimum;
                    cmd.Parameters.Add("@BaseMaximum", SqlDbType.Int).Value = BaseMaximum;
                    cmd.Parameters.Add("@basefee", SqlDbType.Decimal).Value = basefee;
                    cmd.Parameters.Add("@ExcessCost", SqlDbType.Decimal).Value = excesscoast;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeletePacking(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Packaging", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PackagingId", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
