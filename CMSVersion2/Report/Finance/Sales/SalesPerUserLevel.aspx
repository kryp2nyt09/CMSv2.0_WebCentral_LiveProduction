<%@ Page Title="Sales Per User Level" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesPerUserLevel.aspx.cs" Inherits="CMSVersion2.Report.Finance.Sales.SalesPerUserLevel" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"><div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>SALES PER USER LEVEL</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Sales</li>
                    <li>Sales Per User Level Report</li>
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
                 <telerik:RadLabel ID="bcolabel" runat="server" Text="BCO CODE:"></telerik:RadLabel>
                 <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" AppendDataBoundItems="true" MarkFirstMatch="true" AllowCustomText="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
                <telerik:RadButton ID="Search" Text="Search" runat="server" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"></telerik:RadButton>
                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>   
            </div>
            <br />
               
            <div class="row">
                 <telerik:RadGrid ID="grid_SalesPerUserLevel" runat="server"  Skin="Glow"
                    AllowPaging="True" OnPreRender="grid_SalesPerUserLevel_PreRender"
                    PageSize="10"  
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="true"
                    AllowSorting="true" OnNeedDataSource="grid_SalesPerUserLevel_NeedDataSource">
                    
                    <ExportSettings HideStructureColumns="true" ExportOnlyData="true" FileName="Sales Per User Level"
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                         <Pdf ForceTextWrap="true"  PageWidth="397mm" PageHeight="210mm" BorderColor="Black"
                              DefaultFontFamily="Calibri" PageLeftMargin="20px" PageRightMargin="20px" 
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="120px" PageTitle="Sales Per User Level Report">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>          
                    <MasterTableView Font-Size="Smaller" ShowGroupFooter="true"  CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ExportToPdfText="PDF" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />                       
                        
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
</telerik:RadAjaxPanel>
        </div>
    </div>
</div> 

</asp:Content>
