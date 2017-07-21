using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Telerik.Reporting.Processing;
using BLL = BusinessLogic;
using Tools = utilities;

namespace SOA_Generation_Service
{

    public class StatementOfAccountGeneration
    {

        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();

        private string ConStr { get; set; }
        private string FileName { get { return getConstr.SoaReportsPath; } }
        private int BillPeriodDays { get; set; }
        private string StatementOfAccountNo { get; set; }

        public StatementOfAccountGeneration(int BillPeriodDays)
        {
            this.ConStr = getConstr.ConStrCMS;
            this.BillPeriodDays = BillPeriodDays;
            DataSet billingperiodDs = BLL.BillingPeriod.GetBillingPeriod(ConStr);
            DataTable dt = billingperiodDs.Tables[0];
            List<BillingPeriod> BillPeriods = new List<BillingPeriod>();

            //Get Billing Periods
            foreach (DataRow item in dt.Rows)
            {
                BillingPeriod bill = new BillingPeriod();
                bill.BillingPeriodId = Guid.Parse(item["BillingPeriodId"].ToString());
                bill.BillingPeriodName = item["BillingPeriodName"].ToString();
                bill.BillingPeriodNoOfDays = (int)item["NumberOfDays"];

                BillPeriods.Add(bill);
            }

            //Generate Soa Per Company
            switch (BillPeriodDays)
            {
                case 7:
                    GenerateSOAPerCompany(BillPeriods.Where(x => x.BillingPeriodNoOfDays == 7).FirstOrDefault());
                    break;

                case 15:

                    GenerateSOAPerCompany(BillPeriods.Where(x => x.BillingPeriodNoOfDays == 7).FirstOrDefault());
                    GenerateSOAPerCompany(BillPeriods.Where(x => x.BillingPeriodNoOfDays == 15).FirstOrDefault());
                    break;

                case 30:
                    GenerateSOAPerCompany(BillPeriods.Where(x => x.BillingPeriodNoOfDays == 7).FirstOrDefault());
                    GenerateSOAPerCompany(BillPeriods.Where(x => x.BillingPeriodNoOfDays == 15).FirstOrDefault());
                    GenerateSOAPerCompany(BillPeriods.Where(x => x.BillingPeriodNoOfDays == 30).FirstOrDefault());
                    break;

                default:
                    break;
            }



        }

        private void GenerateSOAPerCompany(BillingPeriod _billPeriod)
        {
            DataSet companyDs = BLL.Company.GetCompanyByBillingPeriodId(_billPeriod.BillingPeriodId, ConStr);
            DataTable dt = companyDs.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                GenerateSatementOfAccount generateSoa = new GenerateSatementOfAccount(FileName, ConStr);
                ThreadState state = new ThreadState();
                state.currEvent = new ManualResetEvent(false);
                state.StatementOfAccount = new StatementOfAccountModel()
                {
                    BillingPeriodFrom = DateTime.Now.AddDays(-_billPeriod.BillingPeriodNoOfDays),
                    BillingPeriodUntil = DateTime.Now.AddDays(-1),
                    BillingPeriodID = _billPeriod.BillingPeriodId,
                    CompanyID = Guid.Parse(item["CompanyID"].ToString()),
                    SoaNumber = GetNewStatementOfAccountNo(),
                    CiNo = "",
                    Remarks = ""
                };
                ThreadPool.QueueUserWorkItem(new WaitCallback(generateSoa.InsertAndPrintStatementOfAccount), state);
            }
        }

        private string GetNewStatementOfAccountNo()
        {
            if (this.StatementOfAccountNo == "")
            {
                string lastSoaNo = BLL.StatementOfAccount.GetLastStatementOfAccountNo(ConStr);
                int tempNo = Convert.ToInt32(lastSoaNo) + 1;

                switch (tempNo.ToString().Length)
                {
                    case 1:
                        StatementOfAccountNo = "0000" + tempNo.ToString();
                        break;
                    case 2:
                        StatementOfAccountNo = "000" + tempNo.ToString();
                        break;
                    case 3:
                        StatementOfAccountNo = "00" + tempNo.ToString();
                        break;
                    case 4:
                        StatementOfAccountNo = "0" + tempNo.ToString();
                        break;
                    default:
                        StatementOfAccountNo = tempNo.ToString();
                        break;
                }
            }
            else
            {
                int tempNo = Convert.ToInt32(StatementOfAccountNo) + 1;
                switch (tempNo.ToString().Length)
                {
                    case 1:
                        StatementOfAccountNo = "0000" + tempNo.ToString();
                        break;
                    case 2:
                        StatementOfAccountNo = "000" + tempNo.ToString();
                        break;
                    case 3:
                        StatementOfAccountNo = "00" + tempNo.ToString();
                        break;
                    case 4:
                        StatementOfAccountNo = "0" + tempNo.ToString();
                        break;
                    default:
                        StatementOfAccountNo = tempNo.ToString();
                        break;
                }
            }
            return StatementOfAccountNo;
        }

    }

    public class BillingPeriod
    {
        public Guid BillingPeriodId { get; set; }
        public string BillingPeriodName { get; set; }
        public int BillingPeriodNoOfDays { get; set; }
    }

    public class GenerateSatementOfAccount
    {
        private string _connStr { get; set; }
        private string _fileName { get; set; }
        public GenerateSatementOfAccount(string FileName, string ConnStr)
        {
            _connStr = ConnStr;
            _fileName = FileName;
        }
        public void InsertAndPrintStatementOfAccount(object obj)
        {
            ThreadState state = (ThreadState)obj;

            //Create Statement Of account          
            Guid soaid = BLL.StatementOfAccount.InsertStatementOfAccount(state.StatementOfAccount.BillingPeriodFrom,
                state.StatementOfAccount.BillingPeriodUntil, state.StatementOfAccount.CompanyID, state.StatementOfAccount.BillingPeriodID,
                state.StatementOfAccount.SoaNumber, state.StatementOfAccount.CiNo, state.StatementOfAccount.Remarks, _connStr);

            //Print Statement Of Account
            PrintStatementOfAccount SoaPrint = new SOA_Generation_Service.PrintStatementOfAccount(soaid, _fileName, _connStr);
            SoaPrint.Print();

            state.currEvent.Set();

        }
    }

    public class PrintStatementOfAccount
    {
        private string FileName { get; set; }
        private string ConStr { get; set; }
        private Guid SoaID { get; set; }
        public PrintStatementOfAccount(Guid SoaID, string fileName, string ConStr)
        {
            this.FileName = fileName;
            this.ConStr = ConStr;
            this.SoaID = SoaID;
        }
        public PrintStatementOfAccount( )
        {
        }
        public int Print()
        {
            ReportModel.StatementOfAccountModelReportModel model = GetSoaForPrint(SoaID);
            Report.SOAReport SoaRpt = new Report.SOAReport(model);
            SaveReport(SoaRpt, FileName + @"\" + model.AccountNo + "_" + model.CompanyName + "_" + model.StatementOfAccountNo + ".pdf");
            return 1;

        }
        private void SaveReport(Telerik.Reporting.Report report, string fileName)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = report;
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
        }

        public ReportModel.StatementOfAccountModelReportModel GetSoaForPrint(Guid SoaId)
        {
            ReportModel.StatementOfAccountModelReportModel model = new ReportModel.StatementOfAccountModelReportModel();
            DataSet data = BLL.StatementOfAccount.GetSoaForPrint(SoaId, ConStr);
            DataTable SoaDt = data.Tables[0];
            DataTable ShipmentDt = data.Tables[1];
            DataTable PreviousBillDt = data.Tables[2];
            DataTable PaymentDt = data.Tables[3];
            DataTable SoaAdjustmentDt = data.Tables[4];
            DataTable AirwayBillAdjustmentDt = data.Tables[5];

            foreach (DataRow item in SoaDt.Rows)
            {
                model.AccountNo = item["AccountNo"].ToString();
                model.BillPeriodCovered = item["BillingPeriodName"].ToString();
                model.CompanyName = item["CompanyName"].ToString();
                model.CompanyAddress = item["BillingAddress1"].ToString();
                model.CurrentBillAmount = (decimal)item["AmountDue"];
                model.SoaDate = ((DateTime)item["StatementOfAccountDate"]).ToLongDateString();
                model.SoaDueDate = ((DateTime)item["SoaDueDate"]).ToLongDateString();
                model.StatementOfAccountNo = item["StatementOfAccountNo"].ToString();
            }

            foreach (DataRow item in PreviousBillDt.Rows)
            {
                model.PreviousBillAmount = (decimal)item["AmountDue"];
                model.PreviousBillPayment = (decimal)item["PaymentAmount"];
                model.PreviousBillAdjustment = (decimal)item["AdjustmentAmount"];
                //model.CurrentSurcharge = (decimal)item["Surcharge"];
            }

            model.TotalPreviousBalance = model.PreviousBillAmount + model.PreviousBillAdjustment - model.PreviousBillPayment;
            model.TotalCurrentBill = model.CurrentSurcharge + model.CurrentBillAmount;
            model.TotalAmountDue = model.TotalPreviousBalance + model.TotalCurrentBill;

            if (model.TotalPreviousBalance >= 0)
            {
                model.CurrentSurcharge = model.TotalPreviousBalance * (decimal).5;
            }
            //Load table
            model.CurrentChargesDataTable = ShipmentDt;
            model.PreviousBillDataTable = PreviousBillDt;
            model.PaymentDetailsDataTable = PaymentDt;
            model.SoaAdjustmentDetailsDataTable = SoaAdjustmentDt;
            model.AirwayBillAdjustmentDetailsDataTable = AirwayBillAdjustmentDt;

            return model;
        }
    }

    public class ThreadState
    {
        public ManualResetEvent currEvent;
        public StatementOfAccountModel StatementOfAccount;
        public ReportModel.StatementOfAccountModelReportModel ReportModel;

    }

    public class StatementOfAccountModel
    {
        public Guid CompanyID { get; set; }
        public Guid BillingPeriodID { get; set; }
        public DateTime BillingPeriodFrom { get; set; }
        public DateTime BillingPeriodUntil { get; set; }
        public String SoaNumber { get; set; }
        public string CiNo { get; set; }
        public string Remarks { get; set; }
    }
}
