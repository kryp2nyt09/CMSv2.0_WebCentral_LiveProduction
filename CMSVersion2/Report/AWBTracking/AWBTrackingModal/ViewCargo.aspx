<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCargo.aspx.cs" Inherits="CMSVersion2.Shipment.AWBTrackingModal.ViewCargo" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <div id="wrapper">
            <div id="page-wrapper">

                <div class="container-fluid">

                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                   <telerik:LayoutColumn HiddenMd="true" HiddenSm="true" HiddenXs="true">
                       <br />
                       
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
                           

                             <asp:HiddenField ID="lblAwbNumber" runat="server" Visible="true"></asp:HiddenField>

                            <telerik:RadGrid ID="rdViewCargo" 
                                runat="server" AllowPaging="True" 
                                ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="10" 
                                Skin="Glow" 
                                AllowSorting="true"
                                RenderMode="Mobile"
                                CommandItemDisplay="Top"
                                OnNeedDataSource="rdViewCargo_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                
                                <MasterTableView AutoGenerateColumns="False"
                                    AllowFilteringByColumn="false"
                                    CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   
                                    <CommandItemSettings ShowExportToWordButton="false" ShowExportToExcelButton="false" 
                                    ShowExportToCsvButton="false" ShowExportToPdfButton="false">

                                    </CommandItemSettings>
                                    <Columns>

                                      <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                             CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                             DataField="cargo" HeaderText="Cargo">

                                      </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                               
                            </telerik:RadGrid>
                            <br />
                            <br />
                        </telerik:RadAjaxPanel>
                    </telerik:LayoutColumn>
                </div>
            </div>
        </div>
   
        <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>
     
    </form>
</body>
</html>
