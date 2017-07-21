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
    public partial class rpt_AWBDetailedTracking : Telerik.Reporting.Report
    {
        public rpt_AWBDetailedTracking()
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


            //Group group1 = new Group();
            //group1.Name = "group1";
            //group1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.Date"));
            //GroupFooterSection groupFooterSection1 = new GroupFooterSection();
            //GroupHeaderSection groupHeaderSection1 = new GroupHeaderSection();
            //group1.GroupFooter = groupFooterSection1;
            //group1.GroupHeader = groupHeaderSection1;

            //table1.Groups.Add(group1);

            //Telerik.Reporting.TableGroup group1 = new Telerik.Reporting.TableGroup();
            //group1.Name = "Group1";
            //group1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.Date"));

            ////// If you need to filter the members of the group, apply filtering
            ////group1.Filters.Add(new Telerik.Reporting.Filter("=Fields.ProductID", Telerik.Reporting.FilterOperator.Equal, "=10"));

            ////// If you need to order the members of the group, apply sorting
            ////group1.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.ProductID", Telerik.Reporting.SortDirection.Asc));

            //Telerik.Reporting.TextBox textBox1 = new Telerik.Reporting.TextBox();
            //table1.Items.Add(textBox1);
            //group1.ReportItem = textBox1;

            //table1.RowGroups.Add(group1);

        }
    }
}