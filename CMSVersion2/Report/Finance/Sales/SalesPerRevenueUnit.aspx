<%@ Page Title="Sales Per RevenueUnit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesPerRevenueUnit.aspx.cs" Inherits="CMSVersion2.Report.Finance.Sales.SalesPerRevenueUnit" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>SALES PER REVENUE UNIT</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Sales</li>
                    <li>Sales Per Revenue Unit Report</li>
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
                     AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
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
                 <telerik:RadGrid ID="grid_SalesPerRevenueUnit" runat="server"  Skin="Glow"
                    AllowPaging="True" EnableLinqExpressions="false"
                    PageSize="10"
                    AllowFilteringByColumn="false" OnPreRender="grid_SalesPerRevenueUnit_PreRender"
                    AutoGenerateColumns="false"
                    AllowSorting="true" OnNeedDataSource="grid_SalesPerRevenueUnit_NeedDataSource">
                    
                    <ExportSettings HideStructureColumns="true" ExportOnlyData="true" FileName="Sales Per Revenue Unit"
                        IgnorePaging="true" UseItemStyles="true" Pdf-BorderColor="Black" Pdf-FontType="Subset">
                        <Pdf ForceTextWrap="false" BorderColor="Black" DefaultFontFamily="Calibri" 
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="100px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>          
                    <MasterTableView ShowGroupFooter="true"  CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true"
                             ExportToPdfText="PDF" ShowExportToWordButton="false"
                             ShowExportToCsvButton="false" ShowAddNewRecordButton="false"
                             ShowRefreshButton="false" />                       
                        <Columns>
                            
                            <telerik:GridBoundColumn DataField="REVENUE UNIT" HeaderText="NAME" Aggregate="Custom" FooterText="TOTAL: "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RevenueUnitTypeName" HeaderText="TYPE" Visible="false"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="PP" HeaderText="PP"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FC" HeaderText="FC"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CAS" HeaderText="CAS"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CAC" HeaderText="CAC"></telerik:GridBoundColumn>
                            <%--<telerik:GridCalculatedColumn HeaderText="SUBTOTAL" DataType="System.Double" DataFields="PP,FC,CAS,CAC" Expression="{0}+{1}+{2}+{3}" FooterText=" " Aggregate="Sum">
                            </telerik:GridCalculatedColumn>--%>

                            <telerik:GridCalculatedColumn HeaderText="SUBTOTAL" DataType="System.Double"
                                DataFields="PP,FC,CAS,CAC" Expression="{0}+{1}+{2}+{3}" FooterText=" "
                                Aggregate="Sum">
                            </telerik:GridCalculatedColumn>
                             
                             <telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="SCANNED BY"></telerik:GridBoundColumn>

                        </Columns>

                        <GroupByExpressions>
                             <telerik:GridGroupByExpression>
                                 <GroupByFields>
                                     <telerik:GridGroupByField FieldName="RevenueUnitTypeName" HeaderText="TYPE" />
                                 </GroupByFields>
                                 <SelectFields>
                                     <telerik:GridGroupByField FieldName="RevenueUnitTypeName" HeaderText="REVENUE UNIT TYPE:" />
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
