namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    using Models;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class AWBTrackingReport : Telerik.Reporting.Report
    {
        public AWBTrackingReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtAwb.Value = ReportGlobalModel.AirwayBillNo;
            txtShipperName.Value = ReportGlobalModel.ShipperName;
            txtConsignee.Value = ReportGlobalModel.Consignee;
            txtPayMode.Value = ReportGlobalModel.PayMode;
            txtCommodityName.Value = ReportGlobalModel.CommodityType;

            txtOrigin.Value = ReportGlobalModel.Origin;
            txtdestination.Value = ReportGlobalModel.Destination;
            txtQuantity.Value = ReportGlobalModel.Quantity;


            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;
           
        }
    }
}