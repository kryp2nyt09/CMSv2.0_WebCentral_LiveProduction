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
    public class Position
    {
        public static DataSet GetPosition(string conStr)
        {
            return DAL.Position.GetPosition(conStr);
        }

        public static DataSet GetPositionById(Guid PositionId, string conStr)
        {
            return DAL.Position.GetPositionById( PositionId, conStr);
        }
    }
}
