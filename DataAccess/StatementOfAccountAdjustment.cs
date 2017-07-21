using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StatementOfAccountAdjustment
    {
        public static void AddStatementOfAccountAdjustment(Guid SOAID, Guid ReasonID, string AirwayBillNo, decimal Amount, Guid AdjustedBy, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_StatementOfAccountAdjustment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@statementOfAccountId", SqlDbType.UniqueIdentifier).Value = SOAID;
                    cmd.Parameters.Add("@adjustmentReasonId", SqlDbType.UniqueIdentifier).Value = ReasonID;
                    cmd.Parameters.Add("@airwabillNo", SqlDbType.VarChar).Value = AirwayBillNo;
                    cmd.Parameters.Add("@amount", SqlDbType.Decimal).Value = Amount;
                    cmd.Parameters.Add("@adjustedBy", SqlDbType.UniqueIdentifier).Value = AdjustedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
