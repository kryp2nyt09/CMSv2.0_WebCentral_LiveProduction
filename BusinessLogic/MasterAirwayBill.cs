using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class MasterAirwayBill
    {
        public static DataSet GetMasterAirwayBill(string conSTR)
        {
            return DAL.MasterAirwayBill.GetMasterAirwayBill(conSTR);
        }

        public static DataSet GetMasterAirwayBillBySearch(string mawb, string conSTR)
        {
            return DAL.MasterAirwayBill.GetMasterAirwayBillBySearch(mawb, conSTR);
        }
    }
}
