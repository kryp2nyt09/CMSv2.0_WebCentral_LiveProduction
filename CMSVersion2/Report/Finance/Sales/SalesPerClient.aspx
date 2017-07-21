<%@ Page Title="Sales per Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesPerClient.aspx.cs" Inherits="CMSVersion2.Report.Finance.Sales.SalesPerClient" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>SALES PER CLIENT</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Sales</li>
                    <li>Sales Per Client Report</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

            <div class="row">
                <telerik:RadLabel ID="RadLabel1" runat="server" Text="Date:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date1" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                <telerik:RadLabel runat="server" Text="-"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date2" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                &nbsp;&nbsp;&nbsp;
                 <telerik:RadLabel ID="bcolabel" runat="server" Text="Client:"></telerik:RadLabel>
                 <%--<telerik:RadComboBox ID="Client" runat="server" Skin="Glow" Width="220px"
                     AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                </telerik:RadComboBox>--%>
                 <telerik:RadComboBox ID="rcbClient" runat="server" Skin="Glow" Width="220px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                   
                </telerik:RadComboBox>

                 &nbsp;&nbsp;
                <telerik:RadButton ID="Search" Text="Search" runat="server" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"></telerik:RadButton>   
                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
            </div>
            <br />
            <div class="row">
                 <telerik:RadGrid ID="grid_SalesPerClient" runat="server"  Skin="Glow"
                    AllowPaging="True" ShowFooter="true"
                    PageSize="10"   
                    AllowFilteringByColumn="false" OnPreRender="grid_SalesPerClient_PreRender"
                    AutoGenerateColumns="false"
                    AllowSorting="true" OnNeedDataSource="grid_SalesPerClient_NeedDataSource">
                    
                    <ExportSettings HideStructureColumns="true" FileName="Sales Per Client" ExportOnlyData="true" Pdf-DefaultFontFamily="Segoe UI 10"
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                        <Pdf ForceTextWrap="false"  PageWidth="397mm" PageHeight="210mm" BorderColor="Black" 
                            DefaultFontFamily="Calibri" 
                             BorderType="AllBorders" PageTitle="Sales Per Client" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="150px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                              
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>          
                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ExportToPdfText="PDF" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />                       
                        <Columns>

                            <telerik:GridBoundColumn DataField="DATE" HeaderText="DATE" FooterText="Total: " Aggregate="Custom"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AWB #" HeaderText="AWB #"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ORIGIN" HeaderText="ORIGIN"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DESTINATION" HeaderText="DESTINATION"></telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="ACTUAL WT." HeaderText="ACTUAL WT."></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PAYMODE" HeaderText="PAY MODE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SERVICE MODE" HeaderText="SERVICE MODE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TOTAL AMOUNT" HeaderText="TOTAL AMOUNT" Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="SCANNEDBY"></telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
             </telerik:RadAjaxPanel>
        </div>
    </div>
</div>
</asp:Content>
