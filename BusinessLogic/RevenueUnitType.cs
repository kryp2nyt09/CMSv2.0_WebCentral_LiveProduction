using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class RevenueUnitType
    {
        public static DataSet GetRevenueUnitType(string conSTR)
        {
            return DAL.RevenueUnitType.GetRevenueUnitType(conSTR);
        }
    }
}
