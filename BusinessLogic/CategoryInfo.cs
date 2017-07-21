using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL = DataAccess;


namespace BusinessLogic
{
    public class CategoryInfo
    {
        public static DataSet getCategory(string conSTR)
        {

            return DAL.CategoryInfo.getCategory(conSTR);
        }

    }
}
