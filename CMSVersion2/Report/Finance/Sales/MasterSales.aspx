<%@ Page Title="Master Sales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MasterSales.aspx.cs" Inherits="CMSVersion2.Report.Finance.Sales.MasterSales" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>MASTER SALES</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Sales</li>
                    <li>Master Sales Report</li>
                </ol>
            </div>
             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

           			<div class="row">
                <telerik:RadLabel runat="server" Text="Date   :"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date1" runat="server" Skin="Glow"></telerik:RadDatePicker>
                <telerik:RadLabel runat="server" Text="-"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date2" runat="server" Skin="Glow"></telerik:RadDatePicker>
                &nbsp;&nbsp;
                <telerik:RadLabel runat="server" Text="BCO Shipper:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCOShipper" runat="server" MarkFirstMatch="true" AllowCustomText="true" AutoPostBack="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="200px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
               &nbsp;&nbsp;
                <telerik:RadLabel runat="server" Text="BCO Consignee:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCOConsignee" runat="server" MarkFirstMatch="true" AllowCustomText="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="300px">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
            </div>
            <br />
            <div class="row">
                <telerik:RadLabel runat="server" Text="Shipmode:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Shipmode" runat="server" MarkFirstMatch="true" AllowCustomText="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="138px">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
                <telerik:RadLabel runat="server" Text="Commodity Type:"></telerik:RadLabel>
                <telerik:RadComboBox ID="CommodityType" runat="server" MarkFirstMatch="true" AllowCustomText="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="365px">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
                <telerik:RadLabel runat="server" Text="Service Mode:"></telerik:RadLabel>&nbsp;&nbsp;&nbsp;&nbsp;
                <telerik:RadComboBox ID="ServiceMode" runat="server" MarkFirstMatch="true" AllowCustomText="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="300px">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
            </div>
            <br />
            <div class="row">
                <telerik:RadLabel runat="server" Text="Paymode:"></telerik:RadLabel>&nbsp;
                <telerik:RadComboBox ID="Paymode" runat="server" MarkFirstMatch="true" AllowCustomText="true" AutoPostBack="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="138px">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
                <telerik:RadLabel runat="server" Text="User:"></telerik:RadLabel>
                <telerik:RadComboBox ID="User" runat="server" MarkFirstMatch="true" AllowCustomText="true" AutoPostBack="true"
                    Skin="Glow" AppendDataBoundItems="true" Width="300px">
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
            <!--- PAGE BODY--->
            <br />
            <div class="row">

                 <telerik:RadGrid ID="grid_MasterSales" runat="server"  Skin="Glow"
                    AllowPaging="True"
                    PageSize="10"  
                    AllowFilteringByColumn="false" 
                    AutoGenerateColumns="true"
                    AllowSorting="true" OnPreRender="grid_MasterSales_PreRender"
                    OnNeedDataSource="grid_MasterSales_NeedDataSource" ClientSettings-Scrolling-AllowScroll="true" Height="400px" ItemStyle-Wrap="false">
                    
                    <ExportSettings HideStructureColumns="true" FileName="Master Sales" ExportOnlyData="true" Pdf-DefaultFontFamily="Calibri Light" 
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                        <Pdf ForceTextWrap="false"  PageTitle="Master Sales Report" PageWidth="397mm" PageHeight="210mm" BorderColor="Black" DefaultFontFamily="Calibri Light" 
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="150px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>          
                    <MasterTableView ShowFooter="true" AllowMultiColumnSorting="true" CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="X-Small">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="false" ExportToPdfText="PDF" ShowExportToWordButton="false" ShowExportToCsvButton="true" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />                       
                        <%--<Columns>
                            <telerik:GridDateTimeColumn
                                 DataField="TRANSACTION DATE" HeaderText="TRANSACTION DATE" SortExpression="TRANSACTION DATE" AllowFiltering="true" FilterListOptions="VaryByDataType"
                                 PickerType="DatePicker" EnableRangeFiltering="true"  DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime"  FilterControlWidth="85px" 
                                 ></telerik:GridDateTimeColumn>

                             <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false"  AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="ISLAND" HeaderText="ISLAND"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="400" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" AllowFiltering="false"
                                  DataField="REGION" HeaderText="REGION"></telerik:GridBoundColumn>
                            
                             <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" AllowFiltering="false" 
                                  DataField="CLUSTER" HeaderText="CLUSTER"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="REVENUE UNIT" HeaderText="REVENUE UNIT"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="AREA" HeaderText="AREA"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="AWB #" HeaderText="AWB #"></telerik:GridBoundColumn>                             

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="SHIPPER NAME" HeaderText="SHIPPER NAME"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="SHIPPER BCO" HeaderText="SHIPPER BCO"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="SHIPPER CITY" HeaderText="SHIPPER CITY"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="SHIPPER ADDRESS" HeaderText="SHIPPER ADDRESS"></telerik:GridBoundColumn>


                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="CONSIGNEE NAME" HeaderText="CONSIGNEE NAME"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="CONSIGNEE BCO" HeaderText="CONSIGNEE BCO"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="CONSIGNEE CITY" HeaderText="CONSIGNEE CITY"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="CONSIGNEE ADDRESS" HeaderText="CONSIGNEE ADDRESS"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="COMMODITY TYPE" HeaderText="COMMODITY TYPE"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="COMMODITY" HeaderText="COMMODITY"></telerik:GridBoundColumn>


                             <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="SHIP MODE" HeaderText="SHIP MODE"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="SERVICE MODE" HeaderText="SERVICE MODE"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="PAYMENT MODE" HeaderText="PAYMENT MODE"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="AGW" HeaderText="AGW"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn Aggregate="Sum" FilterDelay="200" ShowFilterIcon="false" AllowFiltering="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="AMOUNT" HeaderText="AMOUNT" FooterText="TOTAL: "></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn FilterDelay="200" ShowFilterIcon="false" AllowFiltering="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" 
                                  DataField="USER" HeaderText="USER"></telerik:GridBoundColumn>

                        </Columns>--%>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
        </telerik:RadAjaxPanel>
        </div>
    </div>
</div> 
</asp:Content>
