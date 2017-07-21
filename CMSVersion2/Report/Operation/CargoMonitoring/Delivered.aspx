<%@ Page Title="Delivered" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delivered.aspx.cs" Inherits="CMSVersion2.Report.Operation.CargoMonitoring.Delivered" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>CARGO MONITORING - DELIVERED</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Cargo Monitoring</li>
                    <li>Delivered</li>
                </ol>
            </div>
             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

                 <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow2" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
                
               

               

            <div class="row">


                <telerik:RadLabel ID="RadLabel1" runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date1" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                <telerik:RadLabel runat="server" Text="Date To"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date2" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
               
                 &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbBco" runat="server" Skin="Glow" Width="200px"
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcbBco_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Revenue type:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbRevenueUnitType" runat="server" Skin="Glow" Width="200px"
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true" 
                    OnSelectedIndexChanged="rcbRevenueUnitType_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

               
            </div>
            <br />
            <div class="row">
                 <telerik:RadLabel runat="server" Text="Revenue Unit:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbRevenueUnit" runat="server" Skin="Glow" Width="200px"
                     EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Delivered By:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDeliveredBy" runat="server" Skin="Glow" Width="200px"
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Status:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbStatus" runat="server" Skin="Glow" Width="200px"
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;
                
                <telerik:RadButton ID="Search" Text="Search" runat="server" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"></telerik:RadButton>   
                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
            </div>
             <br />
            <div class="row">
                <telerik:RadGrid ID="grid_Delivered" runat="server"  Skin="Glow"
                    AllowPaging="True" ShowFooter="true"
                    PageSize="10" ClientSettings-Scrolling-AllowScroll="true"  
                    AllowFilteringByColumn="false" OnPreRender="grid_Delivered_PreRender"
                    AutoGenerateColumns="false" Height="500px" ItemStyle-Wrap="false"
                    AllowSorting="true" OnNeedDataSource="grid_Delivered_NeedDataSource">

                     <ExportSettings HideStructureColumns="true" FileName="Cargo Monitoring - Delivered" ExportOnlyData="true"
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                        <Pdf ForceTextWrap="false"  PageWidth="597mm" PageHeight="210mm" BorderColor="Black" 
                            DefaultFontFamily="Calibri" 
                             BorderType="AllBorders" PageTitle="Cargo Monitoring - Delivered" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="150px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                              
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>      
                     <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ExportToPdfText="PDF" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                         <Columns>
                            <telerik:GridBoundColumn DataField="NO" HeaderText="#" HeaderStyle-Width="20px"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRANSACTION DATE" HeaderText="TRANSACTION DATE"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="AWB" HeaderText="AWB"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ORIGIN BCO" HeaderText="ORIGIN BCO"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DESTINATION BCO" HeaderText="DESTINATION BCO"></telerik:GridBoundColumn>

                             <telerik:GridBoundColumn DataField="SHIPPER" HeaderText="SHIPPER"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="SHIPPER #" HeaderText="SHIPPER #"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="SHIPPER ADDRESS" HeaderText="SHIPPER ADDRESS"></telerik:GridBoundColumn>
                            
                              <telerik:GridBoundColumn DataField="CONSIGNEE" HeaderText="CONSIGNEE"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="CONSIGNEE #" HeaderText="CONSIGNEE #"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="CONSIGNEE ADDRESS" HeaderText="CONSIGNEE ADDRESS"></telerik:GridBoundColumn>


                              <telerik:GridBoundColumn DataField="QTY" HeaderText="QTY"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="WEIGHT" HeaderText="WEIGHT"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="PAYMODE" HeaderText="PAYMODE"></telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="AMOUNT" HeaderText="AMOUNT"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="STATUS" HeaderText="STATUS"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="REMARKS" HeaderText="REMARKS"></telerik:GridBoundColumn>

                               <telerik:GridBoundColumn DataField="DELIVEREDBY" HeaderText="DELIVEREDBY"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="INBOUNDDATE" HeaderText="INBOUNDDATE"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="DELIVEREDDATE" HeaderText="DELIVEREDDATE"></telerik:GridBoundColumn>

                          
                        </Columns>
                     </MasterTableView>
                </telerik:RadGrid>
            </div>
            </telerik:RadAjaxPanel>
        </div>
    </div>
</div>
</asp:Content>
