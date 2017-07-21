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
    /// Summary description for BookingReport.
    /// </summary>
    public partial class BookingReport : Telerik.Reporting.Report
    {
        public BookingReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtDate.Value = ReportGlobalModel.Date;
            txtBCO.Value = ReportGlobalModel.Branch;
            txtBookingStatus.Value = ReportGlobalModel.Notes;


            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}