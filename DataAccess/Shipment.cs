using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Shipment
    {
        public static DataSet GetShipmentsAndPaymentsBySoaId(Guid soaid, string Constr)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ShipmentByStatementOfAccount", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@soaid", SqlDbType.UniqueIdentifier).Value = soaid;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetShipmentTonnageByUser(Guid userid,string Constr)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ShipmentTonnageByUser", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@userid", SqlDbType.UniqueIdentifier).Value = userid;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetShipmentTonnageByArea(Guid AreaID, string Constr)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ShipmentTonnageByArea", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = AreaID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
