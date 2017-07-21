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
    public class Department
    {
        public static DataSet GetDepartment(string conStr)
        {
           return DAL.Department.GetDepartment(conStr);
        }

        public static DataSet GetDepartmentById(Guid DepartmentId, string conStr)
        {
           return DAL.Department.GetDepartmentById(DepartmentId, conStr);
        }
    }

}
