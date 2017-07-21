using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class BookingReport
    {
        public static DataSet GetBookingReportData(string conSTR, DateTime? dateFrom, DateTime? DateTo, Guid? bcoId, Guid? bookingstatusid)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Report_Booking", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)DateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BookingStatusId", SqlDbType.UniqueIdentifier).Value = (object)bookingstatusid ?? DBNull.Value;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
