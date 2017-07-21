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
    public class BookingStatus
    {
        public static DataSet GetBookingStatus(string conSTR)
        {
            return DAL.BookingStatus.GetBookingStatus(conSTR);
        }

        public static void DeleteBookingStatus(Guid ID, string conSTR)
        {
            DAL.BookingStatus.DeleteBookingStatus(ID, conSTR);
        }
        public static DataSet GetBookingStatusByID(Guid ID, string conSTR)
        {
            return DAL.BookingStatus.GetBookingStatusByID(ID, conSTR);
        }
        public static void UpdateBookingStatus(Guid BookingStatusId, Guid CreatedBy, string BookingStatusName, string conSTR)
        {
            DAL.BookingStatus.UpdateBookingStatus(BookingStatusId, CreatedBy, BookingStatusName, conSTR);
        }

        public static void InsertBookingStatus(Guid CreatedBy, string BookingStatusName, string conSTR)
        {
            DAL.BookingStatus.InsertBookingStatus( CreatedBy, BookingStatusName, conSTR);
        }


    }
}
