namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    using Models;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for DailyTripReport.
    /// </summary>
    public partial class DailyTripReport : Telerik.Reporting.Report
    {
        public DailyTripReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            var objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable1 = ReportGlobalModel.table1;
            objectDataSource1.DataSource = dataTable1;
            table1.DataSource = objectDataSource1;

            var objectDataSource2 = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable2 = ReportGlobalModel.table2;
            objectDataSource2.DataSource = dataTable2;
            table2.DataSource = objectDataSource2;

            var objectDataSource3 = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable3 = ReportGlobalModel.table3;
            objectDataSource3.DataSource = dataTable3;
            table3.DataSource = objectDataSource3;

            var objectDataSource4 = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable4 = ReportGlobalModel.table4;
            objectDataSource4.DataSource = dataTable4;
            table4.DataSource = objectDataSource4;

            txtDate.Value = ReportGlobalModel.Date;
            txtArea.Value = ReportGlobalModel.Area;
            txtDriver.Value = ReportGlobalModel.Driver;
            txtChecker.Value = ReportGlobalModel.Checker;
            txtPlateNo.Value = ReportGlobalModel.PlateNo;
            txtDispatch.Value = DateTime.Now.ToShortTimeString();

            txtRemarks.Value = ReportGlobalModel.Remarks;
            txtScannedBy.Value = ReportGlobalModel.ScannedBy;
            txtNotes.Value = ReportGlobalModel.Notes;

            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;
        }
    }
}