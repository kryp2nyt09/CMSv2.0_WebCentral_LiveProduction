using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GPS
    {
        public static DataSet GetAllTrackInfo( string Constr)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("Proc_GetAllCar", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

    }
}
