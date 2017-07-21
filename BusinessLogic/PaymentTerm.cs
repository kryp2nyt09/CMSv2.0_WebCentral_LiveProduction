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
    public class PaymentTerm
    {
        public static DataSet GetPaymentTerm(string conSTR)
        {
            return DAL.PaymentTerm.GetPaymentTerm(conSTR);
        }
        public static DataSet GetPaymentTermById(Guid ID, string conSTR)
        {
            return DAL.PaymentTerm.GetPaymentTermByID(ID, conSTR);

        }

        public static void DeletePaymentTerms(Guid ID, string conSTR)
        {
            DAL.PaymentTerm.DeletePaymentTerms(ID, conSTR);
        }

        public static void UpdatePaymentTerm(Guid PaymentTermId, Guid CreatedBy, string PaymentTermName, int NumberOfDays, string conSTR)
        {

            DAL.PaymentTerm.UpdatePaymentTerm(PaymentTermId, CreatedBy, PaymentTermName, NumberOfDays, conSTR);

        }

        public static void InsertPaymentTerm( Guid CreatedBy, string PaymentTermName, int NumberOfDays, string conSTR)
        {

            DAL.PaymentTerm.InsertPaymentTerm( CreatedBy, PaymentTermName, NumberOfDays, conSTR);

        }
    }
}
