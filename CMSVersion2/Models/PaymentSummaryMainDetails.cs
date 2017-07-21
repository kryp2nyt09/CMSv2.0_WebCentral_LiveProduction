using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public class PaymentSummaryMainDetails
    {
        //public string BCO { get; set; }
        //public string Area { get; set; }
        //public string CollectionDate { get; set; }
        //public string ValidatedBy { get; set; }
        //public decimal TotalCashReceived { get; set; }
        //public decimal TotalCheckReceived { get; set; }
        //public decimal TotalAmountReceived { get; set; }
        //public decimal TotalTaxWithheld { get; set; }
        public string RemittedBy { get; set; }
        public byte[] Signature { get; set; }
    }
}