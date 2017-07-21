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
    /// Summary description for GatewayOutboundReportView.
    /// </summary>
    public partial class GatewayOutboundReportView : Telerik.Reporting.Report
    {
        public GatewayOutboundReportView()
        {
            InitializeComponent();

            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtDate.Value = ReportGlobalModel.Date;
            txtGateway.Value = ReportGlobalModel.Gateway;
            //txtBCO.Value = ReportGlobalModel.Branch;
            //txtBatch.Value = ReportGlobalModel.Batch;

            txtRemarks.Value = ReportGlobalModel.Remarks;
            txtScannedBy.Value = ReportGlobalModel.User;
            txtNotes.Value = ReportGlobalModel.Notes;

            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;

        }
    }
}