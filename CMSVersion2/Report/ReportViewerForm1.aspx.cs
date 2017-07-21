namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    using System;
    using Telerik.ReportViewer.Html5.WebForms;
    using CMSVersion2.Models;
    using Finance.Sales.Reports;
    using Finance.Collect;
    using CargoMonitoring.Reports;
    using FLM.Report;

    public partial class ReportViewerForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var clientReportSource = new Telerik.ReportViewer.Html5.WebForms.ReportSource();
            clientReportSource.IdentifierType = IdentifierType.TypeReportSource;

            switch (ReportGlobalModel.Report)
            {
                //OPERATION -> MANIFEST
                case "Booking":
                    clientReportSource.Identifier = typeof(BookingReport).AssemblyQualifiedName;
                    break;
                case "PickUpCargo":
                    clientReportSource.Identifier = typeof(PickupReport).AssemblyQualifiedName;
                    break;
                case "BranchAcceptance":
                    clientReportSource.Identifier = typeof(BranchAcceptance).AssemblyQualifiedName;
                    break;
                case "Bundle":
                    clientReportSource.Identifier = typeof(BundleReport).AssemblyQualifiedName;
                    break;
                case "Unbundle":
                    clientReportSource.Identifier = typeof(UnbundleReport).AssemblyQualifiedName;
                    break;
                case "Segregation":
                    clientReportSource.Identifier = typeof(SegregationReport).AssemblyQualifiedName;
                    break;
                case "DailyTrip":
                    clientReportSource.Identifier = typeof(DailyTripReport).AssemblyQualifiedName;
                    break;
                case "GWTransmittal":
                    clientReportSource.Identifier = typeof(GatewayTransmitalReportView).AssemblyQualifiedName;
                    break;
                case "GWOutbound":
                    clientReportSource.Identifier = typeof(GatewayOutboundReportView).AssemblyQualifiedName;
                    break;
                case "GWInbound":
                    clientReportSource.Identifier = typeof(GatewayInboundReportView).AssemblyQualifiedName;
                    break;
                case "CargoTransfer":
                    clientReportSource.Identifier = typeof(CargoTransferReportView).AssemblyQualifiedName;
                    break;
                case "HoldCargo":
                    clientReportSource.Identifier = typeof(HoldCargoReport).AssemblyQualifiedName;
                    break;

                //OPERATION -> CARGO MONITORING
                case "Delivered":
                    clientReportSource.Identifier = typeof(DeliveredReport).AssemblyQualifiedName;
                    break;
                case "HoldReport":
                    clientReportSource.Identifier = typeof(HoldReport).AssemblyQualifiedName;
                    break;
                case "Misrouted":
                    clientReportSource.Identifier = typeof(MisroutedReport).AssemblyQualifiedName;
                    break;
                case "Offloaded":
                    clientReportSource.Identifier = typeof(OffloadedReport).AssemblyQualifiedName;
                    break;
                case "Pending":
                    clientReportSource.Identifier = typeof(PendingReport).AssemblyQualifiedName;
                    break;
                case "RUD":
                    clientReportSource.Identifier = typeof(RUDReport).AssemblyQualifiedName;
                    break;

                //FINANCE -> SALES
                case "MasterSaless":
                    clientReportSource.Identifier = typeof(MasterSalesReport).AssemblyQualifiedName;
                    break;
                case "SalesPerBCO":
                    clientReportSource.Identifier = typeof(SalesPerBCOReport).AssemblyQualifiedName;
                    break;
                case "SalesPerClient":
                    clientReportSource.Identifier = typeof(SalesPerClientReport).AssemblyQualifiedName;
                    break;
                case "SalesPerRevenueunit":
                    clientReportSource.Identifier = typeof(SalesPerRevenueUnitReport).AssemblyQualifiedName;
                    break;
                case "SalesPerShipmode":
                    clientReportSource.Identifier = typeof(SalesPerShipmodeReport).AssemblyQualifiedName;
                    break;
                case "SalesPerUserLevel":
                    clientReportSource.Identifier = typeof(SalesPerUserLevelReport).AssemblyQualifiedName;
                    break;

                    //FINANCE->COLLECTION
                case "Collection":
                    clientReportSource.Identifier = typeof(ReportCollection).AssemblyQualifiedName;
                    break;

                //AWB Tracking
                case "POD":
                    clientReportSource.Identifier = typeof(PODReport).AssemblyQualifiedName;
                    break;

               
                case "AWBDetailedTracking":
                    clientReportSource.Identifier = typeof(rpt_AWBDetailedTracking).AssemblyQualifiedName;
                    break;

               
                case "AWBTracking":
                    clientReportSource.Identifier = typeof(AWBTrackingReport).AssemblyQualifiedName;
                    break;

                //FLM
                case "QtybyCommodity":
                    clientReportSource.Identifier = typeof(FLM_Qtyby_Commodity).AssemblyQualifiedName;
                    break;
                case "WtbyCommodity":
                    clientReportSource.Identifier = typeof(FLM_Wtby_Commodity).AssemblyQualifiedName;
                    break;

                //Payment Summary
                case "PaymentSummaryReport":
                    clientReportSource.Identifier = typeof(PaymentSummaryReportView).AssemblyQualifiedName;
                    break;
                //GrandManifest
                case "GrandManifest":
                    clientReportSource.Identifier = typeof(GrandManifestReportView).AssemblyQualifiedName;
                    break;

                default:
                    clientReportSource.Identifier = typeof(Report1).AssemblyQualifiedName;
                    break;
            }

            reportViewer1.ReportSource = clientReportSource;
        }
    }
}