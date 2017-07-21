using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class PickupCargoManifest
    {
        public static DataSet GetPickupCargoManifest(string conSTR, DateTime? dateFrom, DateTime? DateTo, Guid? bcoId, Guid? destbcoId, Guid? revenueUnitTypeId, Guid? revenueUnitId, string AwbNumber)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_PickupCargoManifest", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = dateFrom;
                //da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = DateTo;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)DateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)destbcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@RevenueUnitTypeId", SqlDbType.UniqueIdentifier).Value = (object)revenueUnitTypeId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = (object)revenueUnitId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@AwbNumber", SqlDbType.VarChar).Value = AwbNumber;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        //public static DataSet GetPickupCargoManifest(string conSTR , string Area, string AWB, string Date , string BCO , string CheckerStr)
        //{
        //    using (SqlConnection con = new SqlConnection(conSTR))
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_PickupCargoManifest", con);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.Add("@AREA", SqlDbType.VarChar).Value = Area;
        //        da.SelectCommand.Parameters.Add("@AWB", SqlDbType.VarChar).Value = AWB;
        //        da.SelectCommand.Parameters.Add("@DATE", SqlDbType.VarChar).Value = Date;
        //        da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCO;
        //        da.SelectCommand.Parameters.Add("@CHECKER", SqlDbType.VarChar).Value = CheckerStr;
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;
        //    }

        //}
    }
}
