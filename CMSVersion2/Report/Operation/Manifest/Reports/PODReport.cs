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
    public partial class PODReport : Telerik.Reporting.Report
    {
        public PODReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            //DataTable dataTable = ReportGlobalModel.table1;
            //objectDataSource.DataSource = dataTable;
           
            txtDate.Value = ReportGlobalModel.Date;
            txtAwb.Value = ReportGlobalModel.AirwayBillNo;
            txtPrintedDate.Value = DateTime.Now.ToString();
            txtPrintedBy.Value = ReportGlobalModel.User;
            // pictureBx_Signature.Value = ByteToImage(ReportGlobalModel.Signature);
           // pictureBx_Signature.Value = ReportGlobalModel.Signature;
        }

        public static Bitmap ByteToImage(byte[] sign)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] data = sign;
            mStream.Write(data, 0, Convert.ToInt32(data.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}