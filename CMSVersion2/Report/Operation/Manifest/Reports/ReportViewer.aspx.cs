using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.ReportViewer.Html5.WebForms;

namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var clientReportSource = new Telerik.ReportViewer.Html5.WebForms.ReportSource();
            //clientReportSource.IdentifierType = IdentifierType.TypeReportSource;
            //clientReportSource.Identifier = typeof(PickupReport).AssemblyQualifiedName;//or <namespace>.<class>, <assembly> e.g. "MyReports.Report1, MyReportsLibrary"
            //reportViewer1.ReportSource = clientReportSource;
        }
    }
}