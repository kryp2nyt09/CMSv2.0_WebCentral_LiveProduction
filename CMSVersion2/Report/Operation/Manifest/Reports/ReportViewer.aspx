<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Reports.ReportViewer" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.Html5.WebForms" Namespace="Telerik.ReportViewer.Html5.WebForms" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Viewer</title>
    <style>
        body {
            margin: 5px;
            font-family: Verdana, Arial;
        }

        #reportViewer1 {
            position: absolute;
            left: 5px;
            right: 5px;
            top: 40px;
            bottom: 5px;
            overflow: hidden;
            clear: both;
        }
    </style>

   
</head>
<body>
    <form runat="server">

        <telerik:ReportViewer Width="" Height=""
            ID="reportViewer1"
            runat="server">
            <ReportSource 
                Identifier="CMSVersion2.Report.Operation.Manifest.Reports.PickupReport, CMSVersion2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" 
                IdentifierType="TypeReportSource">                   
            </ReportSource>
        </telerik:ReportViewer>

    </form>
</body>
</html>
