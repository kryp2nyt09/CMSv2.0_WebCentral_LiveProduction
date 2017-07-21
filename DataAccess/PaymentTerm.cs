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
    public class PaymentTerm
    {
    
        public static DataSet GetPaymentTerm(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_PaymentTerm", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static void DeletePaymentTerms(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_PaymentTermById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PaymentTermId", SqlDbType.UniqueIdentifier).Value = ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetPaymentTermByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_PaymentTermById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@PaymentTermId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void UpdatePaymentTerm(Guid PaymentTermId, Guid CreatedBy, string PaymentTermName, int NumberOfDays, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_PaymentTerm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PaymentTermId", SqlDbType.UniqueIdentifier).Value = PaymentTermId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@PaymentTermName", SqlDbType.VarChar).Value = PaymentTermName;
                    cmd.Parameters.Add("@NumberOfDays", SqlDbType.VarChar).Value = NumberOfDays;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertPaymentTerm( Guid CreatedBy, string PaymentTermName, int NumberOfDays, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_PaymentTerm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@PaymentTermName", SqlDbType.VarChar).Value = PaymentTermName;
                    cmd.Parameters.Add("@NumberOfDays", SqlDbType.VarChar).Value = NumberOfDays;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
