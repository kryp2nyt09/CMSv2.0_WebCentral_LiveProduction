<%@ Page Title="Statement Of Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatementOfAccount.aspx.cs" Inherits="CMSVersion2.Corporate.StatementOfAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div id="wrapper">
        <div id="page-wrapper">

            <div class="container">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">

                        <h3>STATEMENT OF ACCOUNT</h3>

                        <ol class="breadcrumb">
                            <li>Statement of Account
                            </li>
                            <li>List
                            </li>
                        </ol>
                    </div>
                </div>

                <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchUser" EmptyMessage="Search SOA Number"
                        OnSearch="radSearchUser_Search" Width="300"
                        DataKeyNames="StatementOfAccountId"
                        DataTextField="StatementOfAccountNo"
                        DataValueField="StatementOfAccountId"
                        EnableAutoComplete="true"
                        ShowSearchButton="false" Skin="Office2010Black"
                        DataSourceID="StatementOfAccountDataSource">

                        <DropDownSettings Width="300" />
                    </telerik:RadSearchBox>

                </div>
                <br />
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                    <Windows>
                        <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="true" Width="600px" Height="600px">
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>
                <br />
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
                    <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="Grid" DecoratedControls="All" EnableRoundedCorners="false" />
                    <div id="Grid">
                        <telerik:RadGrid ID="RadGrid2" ShowFooter ="true" FooterStyle-BackColor="#ffcc00" 
                            FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right"
                            runat="server" AllowPaging="True" Skin="Office2010Black" AllowSorting="True"
                            AllowFilteringByColumn="True"
                            DataKeyNames="CompanyId" CommandItemDisplay="Top"
                            DataSourceID="CompanyDataSource" ShowStatusBar="True"
                            OnInsertCommand="RadGrid2_InsertCommand"
                            OnItemCreated="RadGrid2_ItemCreated"
                            OnItemCommand="RadGrid2_ItemCommand">
                            
                            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>

                            <MasterTableView AutoGenerateColumns="False" AllowFilteringByColumn="false"
                                CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage"
                                DataSourceID="CompanyDataSource" DataKeyNames="CompanyId" AllowPaging="true"
                                PageSize="5" CommandItemSettings-ShowAddNewRecordButton="false" EditMode="InPlace"
                                RetainExpandStateOnRebind="true" Font-Size="Small">
                                <CommandItemTemplate>
                                    <div class="center" style="align-content: center; text-align: left">
                                        <asp:Label runat="server">
                                            <img src="../Images/emblem.png" alt="" width="20" />
                                            Company Accounts
                                        </asp:Label>
                                    </div>
                                </CommandItemTemplate>
                                <DetailTables>
                                    <telerik:GridTableView Name="StatementOfAccounts" AutoGenerateColumns="false"
                                        DataKeyNames="StatementOfAccountId" AllowAutomaticUpdates="true" DataSourceID="StatementOfAccountDataSource"
                                        Width="100%" runat="server" CommandItemDisplay="Top" AllowFilteringByColumn="false"
                                        CommandItemSettings-ShowAddNewRecordButton="false" RetainExpandStateOnRebind="true"
                                        EditMode="InPlace">
                                        <CommandItemTemplate>
                                            <div class="center" style="align-content: center; text-align: left">
                                                <asp:Label runat="server">
                                                            <img src="../Images/emblem.png" alt="" width="20" />
                                                            Statement Of Accounts
                                                </asp:Label>
                                            </div>
                                        </CommandItemTemplate>
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="CompanyId" MasterKeyField="CompanyId" />
                                        </ParentTableRelation>

                                        <DetailTables>
                                            <telerik:GridTableView Name="Shipments" DataKeyNames="ShipmentId,StatementOfAccountId,AirwayBillNo"
                                                DataSourceID="ShipmentDataSource" AllowAutomaticUpdates="true" Width="100%" runat="server"
                                                CommandItemDisplay="Top" AllowPaging="true" PageSize="5"
                                                AllowFilteringByColumn="false" AutoGenerateColumns="false"
                                                CommandItemSettings-ShowAddNewRecordButton="false" EditMode="InPlace"
                                                EditFormSettings-EditColumn-UpdateText="Adjust" EditFormSettings-EditColumn-CancelText="Cancel"
                                                RetainExpandStateOnRebind="true">
                                                <CommandItemTemplate>
                                                    <div class="center" style="align-content: center; text-align: left">
                                                        <asp:Label runat="server">
                                                            <img src="../Images/emblem.png" alt="" width="20" />
                                                            Shipments
                                                        </asp:Label>
                                                    </div>
                                                </CommandItemTemplate>
                                                <ParentTableRelation>
                                                    <telerik:GridRelationFields DetailKeyField="StatementOfAccountId" MasterKeyField="StatementOfAccountId" />
                                                </ParentTableRelation>

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="ShipmentId" UniqueName="ShipmentId" Visible="false"></telerik:GridBoundColumn>
                                                    <telerik:GridDateTimeColumn DataField="DateAccepted"  Aggregate="None" FooterText="Total"  UniqueName="DateAccepted" HeaderText="Date Accepted"></telerik:GridDateTimeColumn>
                                                    <telerik:GridBoundColumn DataField="AirwayBillNo" UniqueName="AirwayBillNo" HeaderText="AirwayBill"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Origin" UniqueName="Origin" HeaderText="Origin"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Destination" UniqueName="Destination" HeaderText="Destination"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FreightCharge" DataFormatString="{0:N2}" Aggregate="Sum" FooterText=" " DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" UniqueName="FreightCharge" HeaderText="Freight Charge"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VatAmount" Aggregate="Sum" FooterText=" " DataFormatString="{0:N2}"  DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" UniqueName="VatAmount" HeaderText="Vat"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn Aggregate="Sum" FooterText=" " DataField="TotalAmount" DataFormatString="{0:N2}" DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" UniqueName="TotalAmount" HeaderText="Amount"></telerik:GridBoundColumn>
                                                     <telerik:GridNumericColumn DataField="Adjustment" Aggregate="Sum" FooterText=" " DataFormatString="{0:N2}" UniqueName="Adjustment" ItemStyle-HorizontalAlign="Right" EmptyDataText="0.00" HeaderText="Adjustment" DataType="System.Decimal"></telerik:GridNumericColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Reason">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Reason")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <telerik:RadDropDownList RenderMode="Lightweight" runat="server" ID="RadDropDownList2" DataTextField="Reason"
                                                                DataValueField="AdjustmentReasonId" DataSourceID="AdjustmentReasonDataSource" SelectedValue='<%#Bind("AdjustmentReasonId") %>'>
                                                            </telerik:RadDropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridEditCommandColumn EditText="Make Adjustment" ></telerik:GridEditCommandColumn>

                                                </Columns>
                                            </telerik:GridTableView>
                                        </DetailTables>

                                        <Columns>
                                            <telerik:GridBoundColumn DataField="StatementOfAccountId" UniqueName="StatementOfAccountId" Visible="false"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn DataField="StatementOfAccountDate" UniqueName="StatementOfAccountDate" HeaderText="SOA Date"></telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn DataField="StatementOfAccountNo" HeaderText="SOA No" UniqueName="SOANo" HeaderStyle-Font-Bold="true"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="BillingPeriodName" HeaderText="Billing Period" SortExpression="BillingPeriodName" UniqueName="BillingPeriod"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn DataField="SOADueDate" UniqueName="SOADueDate" HeaderText="Due Date"></telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn DataField="AmountDue" DataFormatString="{0:N2}" UniqueName="AmountDue" ItemStyle-HorizontalAlign="Right" HeaderText="Amount Due"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Adjustment" DataFormatString="{0:N2}"  DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" EmptyDataText="None" HeaderText="Adjustment"></telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="Reason">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Reason")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadDropDownList RenderMode="Lightweight" runat="server" ID="RadDropDownList1" DataTextField="Reason"
                                                        DataValueField="AdjustmentReasonId" DataSourceID="AdjustmentReasonDataSource" SelectedValue='<%#Bind("AdjustmentReasonId") %>'>
                                                    </telerik:RadDropDownList>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridEditCommandColumn EditText="Make Adjustment"></telerik:GridEditCommandColumn>
                                            <telerik:GridTemplateColumn UniqueName="Details" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="PrintLink" runat="server" NavigateUrl='<%# string.Format("~/Corporate/SOAPrintedPDF/{0}_{1}_{2}.pdf", Eval("AccountNo"), Eval("CompanyName"), Eval("StatementOfAccountNo")) %>' CssClass="btn bg-gray glyphicon glyphicon-print" ForeColor="#666666" ToolTip="Print SOA" Text=""></asp:HyperLink>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                        </Columns>

                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>

                                    <telerik:GridBoundColumn DataField="CompanyId" UniqueName="CompanyId" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AccountNo" UniqueName="AccountNo" HeaderText="Account No"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CompanyName" UniqueName="CompanyName" HeaderText="Company Name"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ContactNo" UniqueName="ContactNo" HeaderText="Telephone No"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Email" UniqueName="Email" HeaderText="Email"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Address" UniqueName="Address" HeaderText="Address"></telerik:GridBoundColumn>
                                </Columns>

                            </MasterTableView>
                            <ClientSettings>
                                <Selecting AllowRowSelect="true"></Selecting>
                            </ClientSettings>
                        </telerik:RadGrid>
                    </div>

                    <asp:SqlDataSource ID="CompanyDataSource" runat="server"
                        SelectCommand="sp_view_company" SelectCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="StatementOfAccountDataSource" runat="server"
                        SelectCommand="sp_view_StatementOfAccountByCompanyId" OnUpdating="StatementOfAccountDataSource_Updating" SelectCommandType="StoredProcedure"
                        UpdateCommand="sp_insert_StatementOfAccountAdjustment" UpdateCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>">
                        <SelectParameters>
                            <asp:Parameter Name="CompanyId" DbType="Guid" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="StatementOfAccountId" DbType="Guid" />
                            <asp:Parameter Name="AdjustmentReasonId" DbType="Guid" />
                            <asp:Parameter Name="AirwayBillNo" DbType="String"/>
                            <asp:Parameter Name="Adjustment" DbType="Decimal" />
                            <asp:Parameter Name="AdjustedBy" DbType="Guid" ConvertEmptyStringToNull="true" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="AdjustmentReasonDataSource" runat="server"
                        SelectCommand="sp_view_AdjustmentReason" SelectCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="ShipmentDataSource" OnUpdating="StatementOfAccountDataSource_Updating" runat="server"
                        SelectCommand="sp_view_ShipmentBySoaId" SelectCommandType="StoredProcedure"
                        UpdateCommand="sp_insert_StatementOfAccountAdjustment" UpdateCommandType="StoredProcedure"
                        ConnectionString="<%$ ConnectionStrings:Cms %>">
                        <SelectParameters>
                            <asp:Parameter Name="StatementOfAccountId" DbType="Guid" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="StatementOfAccountId" DbType="Guid" />
                            <asp:Parameter Name="AdjustmentReasonId" DbType="Guid" />
                            <asp:Parameter Name="AirwayBillNo" DbType="String"/>
                            <asp:Parameter Name="Adjustment" DbType="Decimal" />
                            <asp:Parameter Name="AdjustedBy" DbType="Guid" ConvertEmptyStringToNull="true" />
                        </UpdateParameters>

                    </asp:SqlDataSource>

                </telerik:RadAjaxPanel>

                <telerik:RadCodeBlock runat="server">
                    <script type="text/javascript">

                        function onRequestStart(sender, args) {
                            if (args.get_eventTarget().indexOf("Button") >= 0) {
                                args.set_enableAjax(false);
                            }
                        }



                        function test(sender, args) {


                            var item = args.get_item();
                            var name = item.get_owner().get_name();
                            alert("dfhdj " + name + " is in edit mode = " + item.get_isInEditMode());
                            if (name == "Shipments") {

                                alert("Record " + item.get_itemIndex() + " is in edit mode. and name is " + name);

                            }
                        }
                        function Rebind(sender, args, tableViewId) {
                            var tableView = $find(tableViewId);
                            var columns = tableview.get_colums();

                            for (var i = 0; i < columns.length; i++) {

                                var uniqueName = colums[i].get_uniqueName();
                                if (uniqueName == "Adjustment") {
                                    columns[i].ReadOnly = false;
                                } else {
                                    columns[i].ReadOnly = true;
                                }
                            }
                            tableView.Rebind();
                        };

                        function PrintPDF(fileName, rowindex) {
                            window.radopen("SOAPrintedPDF/" + "00001" + ".pdf", "RadWindow1");
                            return false;
                        };

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

                    </script>
                </telerik:RadCodeBlock>

            </div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
</asp:Content>
