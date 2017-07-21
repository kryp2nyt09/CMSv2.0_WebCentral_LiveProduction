namespace CMSVersion2.Report.FLM.Report
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
    /// Summary description for FLM_Qtyby_Commodity.
    /// </summary>
    public partial class FLM_Qtyby_Commodity : Telerik.Reporting.Report
    {
        public FLM_Qtyby_Commodity()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            DataTable dataTable = ReportGlobalModel.table1;
            objectDataSource.DataSource = dataTable;
            table1.DataSource = objectDataSource;

            txtPrintedDate.Value = DateTime.Now.ToString();
            txtDate.Value = ReportGlobalModel.Date;
            txtBco.Value = ReportGlobalModel.Branch;
            txtPrintedBy.Value = ReportGlobalModel.User;

            //objectDataSource1.DataSource = objectDataSource;
           
           
            //graph1.CategoryGroups = table1.ColumnGroups

        }
    }
}