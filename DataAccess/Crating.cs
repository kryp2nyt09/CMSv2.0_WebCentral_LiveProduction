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
    public class Crating
    {

        public static DataSet GetCrating(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Crating", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static DataSet GetCratingByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                SqlDataAdapter da = new SqlDataAdapter("sp_view_CratingById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CratindId ", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void UpdateCrating(Guid CratingId, string CratingName, decimal Multiplier, int BaseMinimum,
            int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_Crating", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CratingId", SqlDbType.UniqueIdentifier).Value = CratingId;
                    cmd.Parameters.Add("@CratingName", SqlDbType.VarChar).Value = CratingName;
                    cmd.Parameters.Add("@Multiplier", SqlDbType.Decimal).Value = Multiplier;
                    cmd.Parameters.Add("@BaseMinimum", SqlDbType.Int).Value = BaseMinimum;
                    cmd.Parameters.Add("@BaseMaximum", SqlDbType.Int).Value = BaseMaximum;
                    cmd.Parameters.Add("@basefee", SqlDbType.Decimal).Value = basefee;
                    cmd.Parameters.Add("@excesscost", SqlDbType.Decimal).Value = excesscoast;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertCrating(string CratingName, decimal Multiplier, int BaseMinimum,
         int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Crating", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CratingName", SqlDbType.VarChar).Value = CratingName;
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


        public static void DeleteCrating(Guid CratingID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Crating", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CratingId", SqlDbType.UniqueIdentifier).Value = CratingID;
                
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
