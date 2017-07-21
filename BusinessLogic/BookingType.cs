using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;
namespace BusinessLogic
{
    public class BookingType
    {
        public static DataSet GetBookingType(string conSTR)
        {
            return DAL.BookingType.GetBookingType(conSTR);
        }
    }
}
