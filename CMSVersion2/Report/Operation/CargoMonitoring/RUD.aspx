<%@ Page Title="RUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RUD.aspx.cs" Inherits="CMSVersion2.Report.Operation.CargoMonitoring.RUD" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>CARGO MONITORING - RUD</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Cargo Monitoring</li>
                    <li>RUD</li>
                </ol>
            </div>

             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

            <div class="row">
                <telerik:RadLabel ID="RadLabel1" runat="server" Text="Date:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date1" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                <telerik:RadLabel runat="server" Text="-"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date2" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
               
                 &nbsp;&nbsp;
                <telerik:RadButton ID="Search" Text="Search" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadButton>   
                 <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
            </div>
            <br />
            <div class="row">
                <telerik:RadGrid ID="grid_Hold" runat="server"  Skin="Glow"
                    AllowPaging="True" ShowFooter="true"
                    PageSize="10" ClientSettings-Scrolling-AllowScroll="true"  
                    AllowFilteringByColumn="false" OnPreRender="grid_Hold_PreRender"
                    AutoGenerateColumns="true" Height="500px" ItemStyle-Wrap="false"
                    AllowSorting="true" OnNeedDataSource="grid_Hold_NeedDataSource">

                     <ExportSettings HideStructureColumns="true" FileName="Cargo Monitoring - RUD" ExportOnlyData="true"
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                        <Pdf ForceTextWrap="false"  PageWidth="597mm" PageHeight="210mm" BorderColor="Black" 
                            DefaultFontFamily="Calibri" 
                             BorderType="AllBorders" PageTitle="Cargo Monitoring - RUD" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="150px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                              
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>      
                     <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ExportToPdfText="PDF" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                         
                     </MasterTableView>
                </telerik:RadGrid>
            </div>
                 </telerik:RadAjaxPanel>
        </div>
    </div>
</div>
</asp:Content>
