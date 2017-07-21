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
    /// Summary description for BundleReport.
    /// </summary>
    public partial class BundleReport : Telerik.Reporting.Report
    {
        public BundleReport()
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
            txtBundleNumber.Value = ReportGlobalModel.SackNo;
            txtDestination.Value = ReportGlobalModel.Destination;
            txtOriginBco.Value = ReportGlobalModel.Origin;
            //txtWeight.Value = "";
            
            txtRemarks.Value = ReportGlobalModel.Remarks;
            txtScannedBy.Value = ReportGlobalModel.ScannedBy;
            txtNotes.Value = ReportGlobalModel.Notes;

            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;

        }
    }
}