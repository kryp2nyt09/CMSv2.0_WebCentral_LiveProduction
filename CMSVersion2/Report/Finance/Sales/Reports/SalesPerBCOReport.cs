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
    /// Summary description for SalesPerBCOReport.
    /// </summary>
    public partial class SalesPerBCOReport : Telerik.Reporting.Report
    {
        public SalesPerBCOReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtFrom.Value = ReportGlobalModel.Date;
            txtTo.Value = ReportGlobalModel.Remarks;
            txtBCO.Value = ReportGlobalModel.Branch;

        }
    }
}