<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatementOfAccountPrint.aspx.cs" Inherits="CMSVersion2.Corporate.StatementOfAccountDetails.StatementOfAccountDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
        <div id="page-wrapper">

            <div class="container">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12" style="position:relative">

                        <h3>STATEMENT OF ACCOUNT</h3>

                        <ol class="breadcrumb">
                            <li>Statement of Account
                            </li>
                            <li>Details
                            </li>
                        </ol>


                        <div class="page">
                            <div class="col-xs-6">
                                <div class="">
                                    <telerik:RadLabel ID="lbl_AccNo" runat="server" Text="Account #" Width="30%"></telerik:RadLabel>
                                    <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAccountNo" Enabled="True" runat="server"></telerik:RadTextBox>
                                    <br />
                                    <br />

                                    <telerik:RadLabel ID="lbl_Company" runat="server" Text="Company" Width="30%"></telerik:RadLabel>
                                    <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompany" Enabled="True" runat="server"></telerik:RadTextBox>
                                    <br />
                                    <br />

                                </div>
                            </div>

                            <div class="col-xs-6">
                                <div class="">
                                    <telerik:RadLabel ID="lbl_SoaNo" runat="server" Text="SOA #" Width="30%"></telerik:RadLabel>
                                    <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtSoaNo" Enabled="True" runat="server"></telerik:RadTextBox>
                                    <br />
                                    <br />

                                    <telerik:RadLabel ID="lbl_BillingPeriod" runat="server" Text="Billing Period Covered" Width="30%"></telerik:RadLabel>
                                    <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingPeriod" Enabled="True" runat="server"></telerik:RadTextBox>
                                    <br />
                                    <br />
                                </div>
                            </div>

                        </div>
                    </div>                    
                </div>
                
                <div class="row">
                    <div class="col-lg-12">

                        <telerik:RadAjaxPanel ID="RadAjaxPanel2" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="gridwrapper">
                            
                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                                <AjaxSettings>
                                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                </AjaxSettings>
                            </telerik:RadAjaxManager>
                            <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
                      
                            <h5>SHIPMENTS</h5>
                            <telerik:RadGrid ID="ShipmentGrid"
                                runat="server"
                                AllowPaging="True"
                                AllowFilteringByColumn="true"
                                PageSize="10" Skin="Glow" AllowSorting="true"
                                GroupingEnabled="true"
                                MasterTableView-CommandItemDisplay="Top"
                                MasterTableView-CommandItemSettings-ShowAddNewRecordButton ="false"
                                OnItemCommand="ShipmentGrid_ItemCommand"
                                OnNeedDataSource="ShipmentGrid_NeedDataSource">

                                <MasterTableView NoMasterRecordsText="No Shipment Records" ShowFooter="true" AutoGenerateColumns="False" AllowFilteringByColumn="false">

                                    <Columns>

                                        <telerik:GridDateTimeColumn DataField="DateAccepted" HeaderText="Date Accepted" SortExpression="DateAccepted"
                                            UniqueName="DateAccepted" FilterControlWidth="120px"
                                            PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
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

                                        <telerik:GridBoundColumn DataField="FreightCharge" HeaderText="Freight Charge" SortExpression="FreightCharge"
                                            UniqueName="FreightCharge" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true"
                                             Aggregate="Sum">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="VatAmount" HeaderText="Vat Amount" SortExpression="VatAmount"
                                            UniqueName="VatAmount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true"
                                             Aggregate="Sum">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="TotalAmount" HeaderText="Total" SortExpression="TotalAmount"
                                            UniqueName="TotalAmount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true"
                                             Aggregate="Sum">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>


                                    </Columns>

                                </MasterTableView>
                                <ClientSettings>
                                    <Selecting AllowRowSelect="true"></Selecting>
                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                </ClientSettings>
                            </telerik:RadGrid>
                            <br />
                            <h5>PAYMENTS</h5>
                            <telerik:RadGrid ID="PaymentGrid" MasterTableView-CommandItemDisplay="Top"
                                runat="server"
                                AllowFilteringByColumn="true"
                                PageSize="10" Skin="Glow" AllowSorting="true"
                                OnItemCommand="PaymentGrid_ItemCommand"
                                OnNeedDataSource="PaymentGrid_NeedDataSource">

                                <MasterTableView NoMasterRecordsText="No Payment Records" ShowFooter="true" CommandItemSettings-ShowAddNewRecordButton="false" AutoGenerateColumns="False"
                                    AllowFilteringByColumn="false">

                                    <Columns>

                                        <telerik:GridDateTimeColumn DataField="PaymentDate" HeaderText="Date" SortExpression="PaymentDate"
                                            UniqueName="PaymentDate" FilterControlWidth="120px"
                                            PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                        </telerik:GridDateTimeColumn>

                                        <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AirwayBill" SortExpression="AirwayBillNo"
                                            UniqueName="AirwayBillNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" SortExpression="Amount"
                                            UniqueName="Amount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true"
                                             Aggregate="Sum">
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
                                <ClientSettings>
                                    <Selecting AllowRowSelect="true"></Selecting>
                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                </ClientSettings>
                            </telerik:RadGrid>
                            <br />
                            <h5>ADJUSTMENTS</h5>
                            <telerik:RadGrid ID="AdjustmentGrid"
                                runat="server"
                                AllowFilteringByColumn="true"
                                PageSize="10" Skin="Glow" AllowSorting="true"
                                MasterTableView-CommandItemDisplay="Top"
                                OnItemCommand="RadGrid1_ItemCommand"
                                OnNeedDataSource="RadGrid1_NeedDataSource">

                                <MasterTableView NoMasterRecordsText="No Adjustments Records" ShowFooter="true" CommandItemSettings-ShowAddNewRecordButton="false" AutoGenerateColumns="False"
                                    AllowFilteringByColumn="false">

                                    <Columns>

                                        <telerik:GridDateTimeColumn DataField="AdjustedDate" HeaderText="Date" SortExpression="AdjustedDate"
                                            UniqueName="AdjustedDate" FilterControlWidth="120px"
                                            PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                        </telerik:GridDateTimeColumn>

                                        <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="AirwayBill" SortExpression="AirwayBillNo"
                                            UniqueName="AirwayBillNo" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" SortExpression="Amount"
                                            UniqueName="Amount" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true"
                                             Aggregate="Sum">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="AdjustedBy" HeaderText="Adjusted By" SortExpression="AdjustedBy"
                                            UniqueName="AdjustedBy" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Reason" HeaderText="Reason" SortExpression="Reason"
                                            UniqueName="Reason" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                    </Columns>

                                </MasterTableView>
                                <ClientSettings>
                                    <Selecting AllowRowSelect="true"></Selecting>
                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                </ClientSettings>
                            </telerik:RadGrid>
                            <br />
                            <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
                                <Windows>
                                    <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="450px"
                                        Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                    <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="400px"
                                        Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>


                                    <telerik:RadWindow RenderMode="Mobile" ID="ShowExport" runat="server" Title="Export Report Preview" Height="590px"
                                        Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>


                <telerik:RadCodeBlock runat="server">
                    <script type="text/javascript">
                        function onRequestStart(sender, args) {
                            if (args.get_eventTarget().indexOf("Button") >= 0) {
                                args.set_enableAjax(false);
                            }
                        }
                    </script>


                    <script type="text/javascript">
                        function ShowEditForm(id, rowIndex) {
                            var grid = $find("<%= ShipmentGrid.ClientID %>");

                            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                            grid.get_masterTableView().selectItem(rowControl, true);
                            window.Location.href = "~/UserModal/EditForm_csharp.aspx?StatementOfAccountId=" + id;
                            //return false;
                        }
                        function ShowInsertForm() {
                            window.radopen("UserModal/AddNewUser.aspx", "AddUser");
                            return false;
                        }

                        function ShowExportForm() {
                            window.radopen("Reports/UserExportPreview.aspx", "ShowExport");
                            return false;
                        }


                        function refreshGrid(arg) {
                            if (!arg) {
                                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                            }
                            else {
                                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                            }
                        }
                        function RowDblClick(sender, eventArgs) {

                            window.radopen("UserModal/EditForm_csharp.aspx?StatementOfAccountId=" + eventArgs.getDataKeyValue("StatementOfAccountId"), "UserListDialog");
                        }

                        function LoadRadGrid() {
                            document.getElementById("btnSubmit").click();
                        }
                    </script>
                </telerik:RadCodeBlock>
                <br />

            </div>
        </div>
    </div>
</asp:Content>
