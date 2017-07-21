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
    /// Summary description for GrandManifestReportView.
    /// </summary>
    public partial class GrandManifestReportView : Telerik.Reporting.Report
    {
        public GrandManifestReportView()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtOriginBco.Value = ReportGlobalModel.Origin;
            txtDestinationBCO.Value = ReportGlobalModel.Destination;
            txtServiceMode.Value = ReportGlobalModel.ServiceMode;
            txtServiceType.Value = ReportGlobalModel.ServiceType;
            txtPaymode.Value = ReportGlobalModel.PayMode;
            txtShipmode.Value = ReportGlobalModel.ShipMode;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}