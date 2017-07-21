namespace CMSVersion2.Report.Finance.Sales.Reports
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
    /// Summary description for SalesPerShipmodeReport.
    /// </summary>
    public partial class SalesPerShipmodeReport : Telerik.Reporting.Report
    {
        public SalesPerShipmodeReport()
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

            txtFrom.Value = ReportGlobalModel.Date;
            txtTo.Value = ReportGlobalModel.Remarks;
            txtBCO.Value = ReportGlobalModel.Branch;
        }
    }
}