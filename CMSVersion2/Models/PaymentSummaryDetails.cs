using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public class PaymentSummaryDetails
    {
        public string AirwayBillNo { get; set; }
        public string Client { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TaxWithheld { get; set; }
        public string OrNo { get; set; }
        public string PrNo { get; set; }
        public string ValidatedBy { get; set; }
        public string PaymentModeName { get; set; }
    }
}