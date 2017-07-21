using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class BranchAcceptance
    {
        public static DataSet GetBranchAcceptance(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? bcoId, Guid? bsoId,string driver, Guid? BatchId)
        {
            try {
                using (SqlConnection con = new SqlConnection(conSTR))
                {

                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_BranchAcceptance", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoId ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@BsoId", SqlDbType.UniqueIdentifier).Value = (object)bsoId ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@Driver", SqlDbType.VarChar,100).Value = driver;
                    da.SelectCommand.Parameters.Add("@Batchid", SqlDbType.UniqueIdentifier).Value = BatchId;
                    
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
