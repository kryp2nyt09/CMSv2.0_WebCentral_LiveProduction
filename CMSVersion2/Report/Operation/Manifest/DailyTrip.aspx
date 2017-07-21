<%@ Page Title="Daily Trip" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyTrip.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.DailyTrip" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>DAILY TRIP</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>
                    <li>Daily Trip</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
             <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow2" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
           
            

            <div class="row">

                <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                &nbsp;&nbsp;

                
                <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" MarkFirstMatch="true" 
                    AllowCustomText="true" Width="250px"
                    Skin="Glow" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Area:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Area" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true"
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;

               
            </div>
            <br />
            <div class="row">
                  <telerik:RadLabel runat="server" Text="Batch:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbBatch" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true"
                    AppendDataBoundItems="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;

                  <telerik:RadLabel runat="server" Text="Payment Mode:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbPaymentMode" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true"
                    AppendDataBoundItems="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;


                <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"> </telerik:RadButton>
                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
            </div>
             <br />
            <div class="row">
                <telerik:RadGrid ID="grid_DailyTripReport" runat="server" Skin="Glow" 
                    OnNeedDataSource="grid_DailyTripReport_NeedDataSource"
                    AllowPaging="True" ShowFooter="false" OnPreRender="grid_DailyTripReport_PreRender"
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="false"
                    AllowSorting="true" 
                    Width="100%" 
                    PageSize="10">
                <ExportSettings HideStructureColumns="true" FileName="Daily Trip" 
                    ExportOnlyData="true" IgnorePaging="true">
                    <Pdf ForceTextWrap="true" PageTitle="Daily Trip Report"
                         PageWidth="397mm" PageHeight="210mm" BorderColor="Black" 
                         DefaultFontFamily="Calibri"
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px"  
                             PageTopMargin="150px">
                            <PageHeader>
                              <MiddleCell  TextAlign="Center" Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>"/>
                          </PageHeader>
                        </Pdf>
                </ExportSettings>          
                    <MasterTableView CommandItemDisplay="Top" ShowGroupFooter="true" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" 
                            ShowExportToPdfButton="true" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                        <Columns>
                            <%--<telerik:GridBoundColumn DataField="No" HeaderText="#"></telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AWB #" FooterText="Total: " Aggregate="Custom"></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Consignee" HeaderText="CONSIGNEE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Address" HeaderText="ADDRESS"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Qty" HeaderText="QTY" Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AGW" HeaderText="AGW" Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ServiceModeName" HeaderText="SERVICE MODE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PaymentModeName" HeaderText="PAY MODE" Exportable="false"></telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="Driver" HeaderText="DRIVER"></telerik:GridBoundColumn>--%>
                            <%--<telerik:GridBoundColumn DataField="Checker" HeaderText="CHECKER"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PlateNo" HeaderText="PLATE #"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BatchName" HeaderText="BATCH"></telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="Amount" HeaderText="AMOUNT" Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="SCANNED BY"></telerik:GridBoundColumn>--%>
                        </Columns>
                        <GroupByExpressions>
                            <telerik:GridGroupByExpression>
                                
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="PaymentModeName"/>
                                </GroupByFields>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="PaymentModeName" HeaderText="PAY MODE"/>
                                </SelectFields>
                                
                            </telerik:GridGroupByExpression>
                        </GroupByExpressions>
                        <HeaderStyle Font-Size="Smaller" Font-Bold="true" />
                        <FooterStyle Font-Bold="true" Font-Italic="true" />
                        
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
        </telerik:RadAjaxPanel>
        </div>
    </div>
</div>    
</asp:Content>
