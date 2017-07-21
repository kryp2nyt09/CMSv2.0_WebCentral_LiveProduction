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
    public class PaymentMode
    {

        public static DataSet GetPaymentMode(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_PaymentMode", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeletePaymentMode(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_PaymentMode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PaymentModeId", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetPaymentModeByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_View_PaymentModeById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@PaymentModeId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void UpdatePaymentMode(Guid PaymentModeId, Guid CreatedBy, string PaymentModeName, string PaymentCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_PaymentMode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PaymentModeId", SqlDbType.UniqueIdentifier).Value = PaymentModeId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@PaymentModeName ", SqlDbType.VarChar).Value = PaymentModeName;
                    cmd.Parameters.Add("@PaymentModeCode", SqlDbType.VarChar).Value = PaymentCode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertPaymentMode( Guid CreatedBy, string PaymentModeName, string PaymentCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_PaymentMode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@PaymentModeName ", SqlDbType.VarChar).Value = PaymentModeName;
                    cmd.Parameters.Add("@PaymentModeCode", SqlDbType.VarChar).Value = PaymentCode;
                    con.Open();
                   cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
