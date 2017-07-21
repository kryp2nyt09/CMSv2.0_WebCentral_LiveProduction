<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBooking.aspx.cs" Inherits="CMSVersion2.Corporate.Booking.ViewBooking" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container-fluid">
                 <asp:ScriptManager ID="ScriptManager2" runat="server" />
                <telerik:LayoutColumn HiddenMd="true" HiddenSm="true" HiddenXs="true">
                     <telerik:RadAjaxPanel ID="RadAjaxPanel2" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="gridwrapper">
                         <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                                <AjaxSettings>
                                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                    <telerik:AjaxSetting AjaxControlID="radgrid2">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                </AjaxSettings>
                            </telerik:RadAjaxManager>
                            <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>

                         <asp:HiddenField ID="lblCompanyID" runat="server" Visible="true"></asp:HiddenField>
                        <telerik:RadGrid ID="RadGrid2" 
                            runat="server" AllowPaging="True" RenderMode="Mobile"
                            ExportSettings-Excel-DefaultCellAlignment="Right"
                            PageSize="5" Skin="Glow" AllowSorting="true" 
                            OnItemCommand="RadGrid2_ItemCommand1"
                            OnItemCreated="RadGrid2_ItemCreated"
                            DataKeyNames="BookingId" CommandItemDisplay="Top"
                            OnNeedDataSource="RadGrid2_NeedDataSource">
                            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                             <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="BookingId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="BookingId" CommandItemDisplay="Top"
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                            <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true"
                                ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                 <Columns>
                                    <telerik:GridBoundColumn DataField="BookingNo" HeaderText="Booking No"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DateBooked" HeaderText="Booking Date"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TypeOfBooking" HeaderText="Type Of Booking"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BookingStatus" HeaderText="Booking Status"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DatePickedUp" HeaderText="Date Pickup"></telerik:GridBoundColumn>
                                     <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="CancelLink" runat="server" Text="Cancel"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to deactivate?" ButtonType="LinkButton"
                                        ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Deactivate Booking"
                                        CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                        <HeaderStyle />
                                    </telerik:GridButtonColumn>
                                 </Columns>

                                 <CommandItemTemplate>
                                      <a href="#" onclick="return ShowInsertForm(<%= lblCompanyID.ClientID %>);" >
                                             <img src="../../images/emblem.png" alt="Add Approver" width="20">
                                             Add Booking
                                        </a>
                                 </CommandItemTemplate>
                            </MasterTableView>

                        </telerik:RadGrid>

                         
                     </telerik:RadAjaxPanel>
                     <telerik:RadCodeBlock runat="server">
                         <script type="text/javascript">
                            function refreshGrid(arg) {
                                if (!arg) {
                                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                                }
                                else {
                                    find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                                }
                            }
                         </script>
                    </telerik:RadCodeBlock>
                   
                </telerik:LayoutColumn>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
