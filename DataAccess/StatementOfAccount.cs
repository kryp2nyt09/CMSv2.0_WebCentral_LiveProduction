using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StatementOfAccount
    {
        public static DataSet GetAll(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_StatementOfAccounts", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public static DataSet GetSOADetails(Guid SOAID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_StatementOfAccountDetails", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = SOAID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static Guid InsertStatementOfAccount(DateTime BillingPeriodFrom, DateTime BillingPeriodTo, Guid CompanyId, Guid BillingPeriodId, string SoaNumber, string CiNo, string Remarks, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                using (SqlCommand command = new SqlCommand("sp_insert_StatementOfAccount", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@start", SqlDbType.DateTime).Value = BillingPeriodFrom;
                    command.Parameters.Add("@end", SqlDbType.DateTime).Value = BillingPeriodTo;
                    command.Parameters.Add("@companyid", SqlDbType.UniqueIdentifier).Value = CompanyId;
                    command.Parameters.Add("@billingperiodid", SqlDbType.UniqueIdentifier).Value = BillingPeriodId;
                    command.Parameters.Add("@soanumber", SqlDbType.VarChar).Value = SoaNumber;
                    command.Parameters.Add("@cino", SqlDbType.UniqueIdentifier).Value = CiNo;
                    command.Parameters.Add("@remarks", SqlDbType.UniqueIdentifier).Value = Remarks;
                    command.Parameters.Add("@statementofaccountid", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                    con.Open();
                    return Guid.Parse(command.ExecuteScalar().ToString());
                }

            }

        }

        public static DataSet GetBySOAID(string SOAId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_StatementOfAccount_by_soaId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = SOAId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetSoaForPrint(Guid SoaId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_print_StatementOfAccount", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = SoaId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static String GetLastStateOfAccountNo(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_Latest_StatementOfAccountNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }


    }
}
