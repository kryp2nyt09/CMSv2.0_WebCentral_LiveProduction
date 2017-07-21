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
    public class PaymentMode
    {
        public static DataSet GetPaymentMode(string conSTR)
        {
            return DAL.PaymentMode.GetPaymentMode(conSTR);
        }
        public static DataSet GetPaymentModeByID(Guid ID, string conSTR)
        {
            return DAL.PaymentMode.GetPaymentModeByID(ID, conSTR);
        }

        public static void DeletePaymentModeByID(Guid ID, string conSTR)
        {
             DAL.PaymentMode.DeletePaymentMode(ID, conSTR);
        }

        public static void UpdatePaymentMode(Guid PaymentModeId, Guid CreatedBy, string PaymentModeName, string PaymentCode, string conSTR)
        {
             DAL.PaymentMode.UpdatePaymentMode(PaymentModeId, CreatedBy, PaymentModeName, PaymentCode, conSTR);
        }

        public static void InsertPaymentMode( Guid CreatedBy, string PaymentModeName, string PaymentCode, string conSTR)
        {
            DAL.PaymentMode.InsertPaymentMode( CreatedBy, PaymentModeName, PaymentCode, conSTR);
        }



    }
}
