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
    public class AccountStatus
    {
    
        public static DataSet GetAccountStatus(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AccountStatus", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeleteAccountStatuse(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_AccountStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountStatusID", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetAccountStatusById(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AccountStatusById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AccountStatusID", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void UpdateAccountStatus(Guid AccountStatusID, Guid CreatedBy, string AccountStatusName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_AccountStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountStatusID ", SqlDbType.UniqueIdentifier).Value = AccountStatusID;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@AccountStatusName", SqlDbType.VarChar).Value = AccountStatusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public static void InsertAccountStatus( Guid CreatedBy, string AccountStatusName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_AccountStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@AccountStatusName", SqlDbType.VarChar).Value = AccountStatusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }


    }
}
