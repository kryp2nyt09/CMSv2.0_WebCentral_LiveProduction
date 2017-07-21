<%@ Page Title="Sales per Shipmode" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesPerShipmode.aspx.cs" Inherits="CMSVersion2.Report.Finance.Sales.SalesPerShipmode" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>SALES PER SHIPMODE</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Sales</li>
                    <li>Sales Per Shipmode Report</li>
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
                 <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" AppendDataBoundItems="true" 
                     AllowCustomText="true" AutoPostBack="true" MarkFirstMatch="true">
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
                 <telerik:RadGrid ID="grid_SalesPerShipmode" runat="server"  Skin="Glow"
                    AllowPaging="True" 
                    PageSize="10"
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="false" OnPreRender="grid_SalesPerShipmode_PreRender"
                    AllowSorting="true" OnNeedDataSource="grid_SalesPerShipmode_NeedDataSource">
                    
                    <ExportSettings  HideStructureColumns="true" FileName="Sales Per Shipmode" ExportOnlyData="true" 
                        Pdf-DefaultFontFamily="Calibri"
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                        <Pdf ForceTextWrap="false"  PageWidth="397mm" PageHeight="210mm" BorderColor="Black" 
                            DefaultFontFamily="Calibri" 
                             BorderType="AllBorders" PageTitle="Sales Per Shipmode" 
                             BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="150px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>          
                    <MasterTableView  ShowGroupFooter="true"  CommandItemDisplay="Top" Font-Size="Smaller" >
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true"
                             ExportToPdfText="PDF" ShowExportToWordButton="false" 
                             ShowExportToCsvButton="false" ShowAddNewRecordButton="false" 
                             ShowRefreshButton="false" />    
                        <Columns>
                            <telerik:GridBoundColumn DataField="ORIGIN" HeaderText="ORIGIN" FooterText="Total: " Aggregate="Custom"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DESTINATION" HeaderText="DESTINATION"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ShipModeName" HeaderText="Ship Mode Name"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="PP" HeaderText="PP"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FC" HeaderText="FC"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CAS" HeaderText="CAS"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CAC" HeaderText="CAC"></telerik:GridBoundColumn>
                            
                            <telerik:GridCalculatedColumn HeaderText="SubTotal" DataType="System.Double"
                                DataFields="PP, FC,CAS,CAC" Expression="{0}+{1}+{2}+{3}" FooterText=" "
                                Aggregate="Sum">
                            </telerik:GridCalculatedColumn>

                            <telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="SCANNED BY"></telerik:GridBoundColumn>


                        </Columns>                   
                           
                         <GroupByExpressions>
                             <telerik:GridGroupByExpression>
                                 <GroupByFields>
                                     <telerik:GridGroupByField FieldName="ShipModeName" HeaderText="SHIP MODE" />
                                 </GroupByFields>
                                 <SelectFields>
                                     <telerik:GridGroupByField FieldName="ShipModeName" HeaderText="SHIP MODE" />
                                 </SelectFields>
                             </telerik:GridGroupByExpression>
                            
                         </GroupByExpressions>
                        
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
        </telerik:RadAjaxPanel>
        </div>
    </div>
</div> 
</asp:Content>
