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
    /// Summary description for GatewatInboundReportView.
    /// </summary>
    public partial class GatewayInboundReportView : Telerik.Reporting.Report
    {
        public GatewayInboundReportView()
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
            txtGateway.Value = ReportGlobalModel.Gateway;
            txtCommodityType.Value = ReportGlobalModel.CommodityType;

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