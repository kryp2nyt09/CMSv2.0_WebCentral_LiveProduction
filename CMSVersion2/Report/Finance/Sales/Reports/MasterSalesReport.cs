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
    /// Summary description for MasterSalesReport.
    /// </summary>
    public partial class MasterSalesReport : Telerik.Reporting.Report
    {
        public MasterSalesReport()
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
            textBox6.Value = ReportGlobalModel.Origin;
            textBox8.Value= ReportGlobalModel.Destination;
            textBox12.Value= ReportGlobalModel.ShipMode;
            textBox10.Value= ReportGlobalModel.CommodityType;
            textBox16.Value= ReportGlobalModel.PayMode;
            textBox14.Value = ReportGlobalModel.User;
        }
    }
}