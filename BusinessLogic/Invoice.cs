using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{    
    public class Invoice
    {
        public string AcceptedArea { get; set; }
        public string AcceptedBy { get; set; }
        public decimal ActualGrossWeight { get; set; }
        public string AirwayBillNo { get; set; }
        public decimal AwbFee { get; set; }
        public string Branch { get; set; }
        public decimal ChargeableWeight { get; set; }
        public string Consignee { get; set; }
        public decimal CratingFee { get; set; }
        public decimal DangerousFee { get; set; }
        public DateTime DateAccepted { get; set; }
        public decimal  DeclaredValue { get; set; }
        public decimal DeliveryFee { get; set; }
        public string  DestinationArea { get; set; }
        public decimal Discount { get; set; }
        public decimal FreightCollectCharge { get; set; }
        public decimal FuelSurcharge { get; set; }
        public string HasAwbFee { get; set; }
        public string HasFreightCollectCharge { get; set; }
        public string HasNonVatInsurance { get; set; }
        public string HasNonVatWeightCharge { get; set; }
        public string HasPerishableGoods { get; set; }
        public decimal Insurance { get; set; }
        public string IsNonVatValuation { get; set; }
        public string IsNonVatable { get; set; }
        public string OriginArea { get; set; }
        public decimal OtherChargesAmount { get; set; }
        public string OtherChargesDesc { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public decimal PeracFee { get; set; }
        public string Quantity { get; set; }
        public string ServiceMode { get; set; }
        public string Shipper { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal  ValuationAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal WeightCharge { get; set; }

        public static List<Invoice> GetInvoices(DateTime start, DateTime end, string ConnectionString)
        {
            //DataTable dt = DAL.Invoice.GetInvoice(start, end, ConnectionString).Tables[0];
            //dt.TableName = "Invoice";
            //System.IO.StringWriter writer = new System.IO.StringWriter();
            //dt.WriteXml(writer, true);
            
            //return writer.ToString();
            return Invoices( DAL.Invoice.GetInvoice(start, end, ConnectionString));


        }

        private static List<Invoice> Invoices(DataSet data)
        {
            List<Invoice> invoices = new List<Invoice>();
            DataTable convertdata = new DataTable();

            convertdata = data.Tables[0];
            foreach (DataRow invoice in convertdata.Rows)
            {
                Invoice _invoice = new Invoice();
                _invoice.AcceptedArea = invoice["AcceptedArea"].ToString();
                _invoice.AcceptedBy = invoice["AcceptedBy"].ToString();
                _invoice.ActualGrossWeight = (decimal)invoice["ActualGrossWeight"];
                _invoice.AirwayBillNo = invoice["AirwayBillNo"].ToString();
                _invoice.AwbFee = (decimal)invoice["AwbFee"];
                _invoice.Branch = invoice["Branch"].ToString();
                _invoice.ChargeableWeight = (decimal)invoice["ChargeableWeight"];
                _invoice.Consignee = invoice["Consignee"].ToString();
                _invoice.CratingFee = (decimal)invoice["CratingFee"];
                _invoice.DangerousFee = (decimal)invoice["DangerousFee"];
                _invoice.DateAccepted = (DateTime)invoice["DateAccepted"];
                _invoice.DeclaredValue = (decimal)invoice["DeclaredValue"];
                _invoice.DeliveryFee = (decimal)invoice["DeliveryFee"];
                _invoice.DestinationArea = invoice["DestinationArea"].ToString();
                _invoice.Discount = (decimal)invoice["Discount"];
                _invoice.FreightCollectCharge = (decimal)invoice["FreightCollectCharge"];
                _invoice.FuelSurcharge = (decimal)invoice["FuelSurcharge"];
                _invoice.HasAwbFee = invoice["HasAwbFee"].ToString();
                _invoice.HasFreightCollectCharge = invoice["HasFreightCollectCharge"].ToString();
                _invoice.HasNonVatInsurance = invoice["HasNonVatInsurance"].ToString();
                _invoice.HasNonVatWeightCharge = invoice["hasNonVatWeightCharge"].ToString();
                _invoice.HasPerishableGoods = invoice["HasPerishableGoods"].ToString();
                _invoice.Insurance = (decimal)invoice["Insurance"];
                _invoice.IsNonVatable = invoice["IsNonVatable"].ToString();
                _invoice.IsNonVatValuation = invoice["IsNonVatValuation"].ToString();
                _invoice.OriginArea = invoice["OriginArea"].ToString();
                _invoice.OtherChargesAmount = (decimal)invoice["OtherChargesAmount"];
                _invoice.OtherChargesDesc = invoice["OtherChargesDesc"].ToString();
                _invoice.PaymentMode = invoice["PaymentMode"].ToString();
                _invoice.PaymentTerm = invoice["PaymentTerm"].ToString();
                _invoice.PeracFee = (decimal)invoice["PeracFee"];
                _invoice.Quantity = invoice["Quantity"].ToString();
                _invoice.ServiceMode = invoice["ServiceMode"].ToString();
                _invoice.Shipper = invoice["Shipper"].ToString();
                _invoice.SubTotal = (decimal)invoice["SubTotal"];
                _invoice.TotalAmount = (decimal)invoice["TotalAmount"];
                _invoice.ValuationAmount = (decimal)invoice["ValuationAmount"];
                _invoice.VatAmount = (decimal)invoice["VatAmount"];
                _invoice.WeightCharge = (decimal)invoice["WeightCharge"];

                invoices.Add(_invoice);
            }

            return invoices;
        }

        private static void AddInvoice(Object obj)
        {
            State state = (State)obj;

            Invoice invoice = new Invoice();
            invoice.AcceptedArea = state.invoice["AcceptedArea"].ToString();
            invoice.AcceptedBy = state.invoice["AcceptedBy"].ToString();
            invoice.ActualGrossWeight = (decimal)state.invoice["ActualGrossWeight"];
            invoice.AirwayBillNo = state.invoice["AirwayBillNo"].ToString();
            invoice.AwbFee = (decimal)state.invoice["AwbFee"];
            invoice.Branch = state.invoice["Branch"].ToString();
            invoice.ChargeableWeight = (decimal)state.invoice["ChargeableWeight"];
            invoice.Consignee = state.invoice["Consignee"].ToString();
            invoice.CratingFee = (decimal)state.invoice["CratingFee"];
            invoice.DangerousFee = (decimal)state.invoice["DangerousFee"];
            invoice.DateAccepted = (DateTime)state.invoice["DateAccepted"];
            invoice.DeclaredValue = (decimal)state.invoice["DeclaredValue"];
            invoice.DeliveryFee = (decimal)state.invoice["DeliveryFee"];
            invoice.DestinationArea = state.invoice["DestinationArea"].ToString();
            invoice.Discount = (decimal)state.invoice["Discount"];
            invoice.FreightCollectCharge = (decimal)state.invoice["FreightCollectCharge"];
            invoice.FuelSurcharge = (decimal)state.invoice["FuelSurcharge"];
            invoice.HasAwbFee = state.invoice["HasAwbFee"].ToString();
            invoice.HasFreightCollectCharge = state.invoice["HasFreightCollectCharge"].ToString();
            invoice.HasNonVatInsurance = state.invoice["HasNonVatInsurance"].ToString();
            invoice.HasNonVatWeightCharge = state.invoice["hasNonVatWeightCharge"].ToString();
            invoice.HasPerishableGoods = state.invoice["HasPerishableGoods"].ToString();
            invoice.Insurance = (decimal)state.invoice["Insurance"];
            invoice.IsNonVatable = state.invoice["IsNonVatable"].ToString();
            invoice.IsNonVatValuation = state.invoice["IsNonVatValuation"].ToString();
            invoice.OriginArea = state.invoice["OriginArea"].ToString();
            invoice.OtherChargesAmount = (decimal)state.invoice["OtherChargesAmount"];
            invoice.OtherChargesDesc = state.invoice["OtherChargesDesc"].ToString();
            invoice.PaymentMode = state.invoice["PaymentMode"].ToString();
            invoice.PaymentTerm = state.invoice["PaymentTerm"].ToString();
            invoice.PeracFee = (decimal)state.invoice["PeracFee"];
            invoice.Quantity = state.invoice["Quantity"].ToString();
            invoice.ServiceMode = state.invoice["ServiceMode"].ToString();
            invoice.Shipper = state.invoice["Shipper"].ToString();
            invoice.SubTotal = (decimal)state.invoice["SubTotal"];
            invoice.TotalAmount = (decimal)state.invoice["TotalAmount"];
            invoice.ValuationAmount = (decimal)state.invoice["ValuationAmount"];
            invoice.VatAmount = (decimal)state.invoice["VatAmount"];
            invoice.WeightCharge = (decimal)state.invoice["WeightCharge"];

            state.invoices.Add(invoice);
            state.reset.Set();
        }
    }

     class State
    {
         public List<Invoice> invoices;
         public ManualResetEvent reset;
         public DataRow invoice;
    }
}
