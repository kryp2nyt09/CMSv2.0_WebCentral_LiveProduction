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
    public class BookingRemark
    {
        public static DataSet GetBookingRemark(string conSTR)
        {
            return DAL.BookingRemark.GetBookingRemark(conSTR);
        }
        public static void DeleteBookingRemark(Guid ID, string conSTR)
        {
            DAL.BookingRemark.DeleteBookingRemark(ID, conSTR);
        }
        public static DataSet GetPaymentModeByID(Guid ID, string conSTR)

        {
            return DAL.BookingRemark.GetPaymentModeByID(ID, conSTR);
        }

        public static void UpdateBookingRemark(Guid BookingRemarkID, Guid CreatedBy, string BookingRemarkName, string conSTR)
        {
             DAL.BookingRemark.UpdateBookingRemark(BookingRemarkID, CreatedBy, BookingRemarkName, conSTR);
        
            }
        public static void InsertBookingRemark(Guid CreatedBy, string BookingRemarkName, string conSTR)
        {
            DAL.BookingRemark.InsertBookingRemark( CreatedBy, BookingRemarkName, conSTR);
        }
    }
}
