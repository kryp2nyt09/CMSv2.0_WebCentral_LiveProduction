<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStatementOfAccountAdjustment.aspx.cs" Inherits="CMSVersion2.Corporate.StatementOfAccountAdjustment.AddStatementOfAccountAdjustment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form class="form-horizontal" method="post" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator2" runat="server" Skin="Default" DecoratedControls="All" />


        <div class="row">
            <div class="page" style="text-align: center">
                <div class="col-md-12">
                    <br />
                    <div class="col-md-6">
                        <telerik:RadLabel ID="lbl_AccNo" CssClass="col-md-3" runat="server" Text="Account #" Width="20%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" CssClass="col-md-3" RenderMode="Mobile" ID="txtAccountNo" Enabled="True" runat="server"></telerik:RadTextBox>

                        <telerik:RadLabel ID="lbl_SoaNo" CssClass="col-md-3" runat="server" Text="SOA #" Width="20%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" CssClass="col-md-3" RenderMode="Mobile" ID="txtSoaNo" Enabled="True" runat="server"></telerik:RadTextBox>

                    </div>
                    <br />
                    <div class="col-md-6">
                        <telerik:RadLabel ID="lbl_Company" CssClass="col-md-3" runat="server" Text="Company" Width="20%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" CssClass="col-md-3" RenderMode="Mobile" ID="txtCompany" Enabled="True" runat="server"></telerik:RadTextBox>

                        <telerik:RadLabel ID="lbl_BillingPeriod" CssClass="col-md-3" runat="server" Text="Billing Period Covered" Width="20%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" CssClass="col-md-3" RenderMode="Mobile" ID="txtBillingPeriod" Enabled="True" runat="server"></telerik:RadTextBox>
                    </div>
                </div>
            </div>
        </div>

        <%--SHIPMENT--%>
        <br />
        <telerik:RadAjaxPanel ID="RadAjaxPanel2" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="gridwrapper">

            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="ShipmentGrid" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                            <telerik:AjaxUpdatedControl ControlID="AdjustmentGrid" LoadingPanelID="gridLoadingPanel" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>

            <h5>Shipments</h5>
            <telerik:RadGrid
                ID="ShipmentGrid"
                runat="server"
                AllowPaging="True"
                AllowFilteringByColumn="true"
                PageSize="10" Skin="Glow" AllowSorting="true"
                GroupingEnabled="true"
                MasterTableView-CommandItemDisplay="Top"
                MasterTableView-CommandItemSettings-ShowAddNewRecordButton="false"
                OnItemCommand="ShipmentGrid_ItemCommand"
                OnNeedDataSource="ShipmentGrid_NeedDataSource"
                OnItemCreated="ShipmentGrid_ItemCreated"
                OnItemUpdated="ShipmentGrid_ItemUpdated"
                DataSourceID="AdjustmentDataSource">

                <MasterTableView NoMasterRecordsText="No Shipment Records" ShowFooter="true"
                    CommandItemDisplay="Top" DataSourceID="AdjustmentDataSource"
                    CommandItemSettings-ShowAddNewRecordButton="false" EditMode="InPlace"
                    AutoGenerateColumns="False" AllowFilteringByColumn="false">

                    <Columns>

                        <telerik:GridDateTimeColumn DataField="DateAccepted" HeaderText="Date Accepted" SortExpression="DateAccepted"
                            UniqueName="DateAccepted" FilterControlWidth="120px"
                            PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                            HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                            <HeaderStyle Font-Bold="True"></HeaderStyle>
                        </telerik:GridDateTimeColumn>

                        <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AirwayBill" SortExpression="AirwayBillNo"
                            UniqueName="AirwayBillNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="Origin" HeaderText="Origin" SortExpression="Origin"
                            UniqueName="Origin" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Destination" HeaderText="Destination" SortExpression="Destination"
                            UniqueName="Destination" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <%-- <telerik:GridBoundColumn DataField="FreightCharge" HeaderText="Freight Charge" SortExpression="FreightCharge"
                                UniqueName="FreightCharge" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                <HeaderStyle />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="VatAmount" HeaderText="Vat Amount" SortExpression="VatAmount"
                                UniqueName="VatAmount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                <HeaderStyle />
                            </telerik:GridBoundColumn>--%>

                        <telerik:GridBoundColumn DataField="TotalAmount" HeaderText="Total" SortExpression="TotalAmount"
                            UniqueName="TotalAmount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="AmountPaid" HeaderText="AmountPaid" SortExpression="AmountPaid"
                            UniqueName="AmountPaid" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Adjustment" HeaderText="Adjustment" SortExpression="Adjustment"
                            UniqueName="Adjustment" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridEditCommandColumn HeaderText="Edit"></telerik:GridEditCommandColumn>

                    </Columns>

                </MasterTableView>


            </telerik:RadGrid>
            <%--PAYMENT--%>
            <br />
            <h5>PAYMENT</h5>
            <telerik:RadGrid ID="AdjustmentGrid"
                runat="server" Skin="Glow" AllowSorting="True"
                MasterTableView-CommandItemDisplay="Top"
                OnItemCommand="AdjustmentGrid_ItemCommand"
                OnNeedDataSource="AdjustmentGrid_NeedDataSource" AllowPaging="True" AutoGenerateEditColumn="True">

                <MasterTableView NoMasterRecordsText="No Records Found" CommandItemSettings-ShowAddNewRecordButton="false"
                    AutoGenerateColumns="False">

                    <Columns>

                        <telerik:GridDateTimeColumn DataField="PaymentDate" HeaderText="Date" SortExpression="PaymentDate"
                            UniqueName="PaymentDate" FilterControlWidth="120px"
                            PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                            HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                            <HeaderStyle Font-Bold="True"></HeaderStyle>
                        </telerik:GridDateTimeColumn>

                        <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AirwayBill" SortExpression="AirwayBillNo"
                            UniqueName="AirwayBillNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" SortExpression="Amount"
                            UniqueName="Amount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="OrNoPrNo" HeaderText="Or#/Pr#" SortExpression="OrNoPrNo"
                            UniqueName="OrNoPrNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PaymentTypeName" HeaderText="Payment Type" SortExpression="PaymentTypeName"
                            UniqueName="PaymentTypeName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="RecievedBy" HeaderText="Recieved By" SortExpression="RecievedBy"
                            UniqueName="RecievedBy" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                            <HeaderStyle />
                        </telerik:GridBoundColumn>

                    </Columns>

                </MasterTableView>
                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <ClientSettings AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="true"></Selecting>
                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                </ClientSettings>
            </telerik:RadGrid>
        </telerik:RadAjaxPanel>
        <asp:SqlDataSource ID="AdjustmentDataSource" runat="server"
            SelectCommand="sp_view_ShipmentBySoaId"
            SelectCommandType="StoredProcedure"
            ConnectionString="<%$ ConnectionStrings:Cms %>"
            ProviderName="System.Data.SqlClient">

            <SelectParameters>
                <asp:QueryStringParameter Name="soaid" DbType="Guid"  QueryStringField="StatementOfAccountId"  />
            </SelectParameters>

        </asp:SqlDataSource>
        <div>
            <div class="footer-bottom">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                <telerik:RadButton ID="btmCancel" runat="server" Text="Cancel"></telerik:RadButton>
            </div>
        </div>
    </form>
</body>
</html>
