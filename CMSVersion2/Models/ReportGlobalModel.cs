using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public static class ReportGlobalModel
    {
        public static DataTable table1 { get; set; }
        public static String Date { get; set; }
        public static String Area { get; set; }
        public static String Origin { get; set; }
        public static String SackNo { get; set; }
        public static String Gateway { get; set; }
        public static String Driver { get; set; }
        public static String Checker { get; set; }
        public static String AirwayBillNo { get; set; }
        public static String PlateNo { get; set; }
        public static String Batch { get; set; }
        public static String ScannedBy { get; set; }
        public static String Remarks { get; set; }
        public static String Notes { get; set; }
        public static String Branch { get; set; }
        public static String Destination { get; set; }
        public static String Weight { get; set; }
        public static String FlightNo { get; set; }
        public static String CommodityType { get; set; }
        public static String Report { get; set; }
        public static DataTable table2 { get; set; }
        public static DataTable table3 { get; set; }
        public static DataTable table4 { get; set; }

        public static String User { get; set; }

        public static String ShipMode { get; set; }
        public static String PayMode { get; set; }
        public static String ShipperName { get; set; }
        public static String Quantity { get; set; }
        public static String SignedBy { get; set; }
        public static String DeliveryStatus { get; set; }
        public static byte[] Signature { get; set; }
        public static String Consignee { get; set; }


        //PaymentSummary
        public static List<PaymentSummaryDetails> PaymentSummaryDetails { get; set; }
        public static List<PaymentSummaryMainDetails> PaymentSummaryMainDetails { get; set; }
        public static string BCO { get; set; }
        public static string CollectionDate { get; set; }
        public static string ValidatedBy { get; set; }
        public static decimal TotalCashReceived { get; set; }
        public static decimal TotalCheckReceived { get; set; }
        public static decimal TotalAmountReceived { get; set; }
        public static decimal TotalTaxWithheld { get; set; }
        public static string RemittedBy { get; set; }

        //GrandManifest
        public static String ServiceMode { get; set; }
        public static String ServiceType { get; set; }
    }
}