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
    /// Summary description for BranchAcceptance.
    /// </summary>
    public partial class BranchAcceptance : Telerik.Reporting.Report
    {
        public BranchAcceptance()
        {
            InitializeComponent();

            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtDate.Value = ReportGlobalModel.Date;
            txtArea.Value = ReportGlobalModel.Area; //BRANCH
            txtDriver.Value = ReportGlobalModel.Driver;
            txtChecker.Value = ReportGlobalModel.Checker;
            txtBatch.Value = ReportGlobalModel.Batch;
            txtPlateNo.Value = ReportGlobalModel.PlateNo;

            txtRemarks.Value = ReportGlobalModel.Remarks;
            txtScannedBy.Value = ReportGlobalModel.ScannedBy;
            txtNotes.Value = ReportGlobalModel.Notes;

            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;

        }
    }
}