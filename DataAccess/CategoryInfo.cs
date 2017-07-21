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
    public class CategoryInfo
    {
        public static DataSet getCategory(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                SqlDataAdapter da = new SqlDataAdapter("sp_GetCategoryInfo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }
    }
}
