<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRoles.aspx.cs" Inherits="CMSVersion2.UserAccess.Roles.RolesModal.ViewRoles" %>

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

                    <script type="text/javascript">
                        function CloseAndRebind(args) {
                            GetRadWindow().BrowserWindow.refreshGrid(args);
                            GetRadWindow().close();
                        }

                        function GetRadWindow() {
                            var oWindow = null;
                            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                            return oWindow;
                        }

                        function CancelEdit() {
                            GetRadWindow().close();
                        }
                    </script>
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
                           

                             <asp:HiddenField ID="lblRoleUserID" runat="server" Visible="true"></asp:HiddenField>

                            <telerik:RadGrid ID="RadGrid2"
                                runat="server" AllowPaging="True" ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="5" Skin="Glow" AllowSorting="true"
                                RenderMode="Mobile"
                                DataKeyNames="User_UserId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="User_UserId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="User_UserId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                 
                                    <Columns>

                                        <telerik:GridBoundColumn DataField="RoleName" HeaderText="Roles" SortExpression="RoleName"
                                            UniqueName="RoleName">
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
                            <br />
                            <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
                                <Windows>
                                    <telerik:RadWindow RenderMode="Mobile" ID="RepresentativeListDialog" runat="server" Title="Editing record" Height="600px"
                                        Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="AddRepresentatives" runat="server" Title="Adding record" Height="600px"
                                        Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move"  >
                                    </telerik:RadWindow>

                                    
                                     <telerik:RadWindow RenderMode="Mobile" ID="ShowExport" runat="server" Title="Export Report Preview" Height="590px"
                                        Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move"  >
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </telerik:RadAjaxPanel>
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
                                    var grid = $find("<%= RadGrid2.ClientID %>");

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);

                                    window.radopen("Representatives/EditRepresentatives.aspx?ClientId=" + id, "RepresentativeListDialog");
                                    return false;
                                }

                                function ShowInsertForm(obj) {
                                    window.radopen("Representatives/AddRepresentatives.aspx?CompanyId=" + obj.value, "AddRepresentatives");
                                    return false;
                                }

                                function ShowExportForm() {
                                    window.radopen("Reports/RepresentativesExportReport.aspx", "ShowExport");
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

                                    <%--<%--    //changed code here 
                                    var grid = $find("<%= RadGrid2.ClientID %>");
                                    var MasterTable = grid.get_masterTableView();
                                    var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                                    var key = MasterTable.getCellByColumnUniqueName(row, "UserId");  // get the value by uniquecolumnname
                                    var ID = key.innerHTML;        
                                    MasterTable.fireCommand("MyClick2",ID);        
                                --%>
                                    //ShowEditForm();
                                     window.radopen("UserModal/Representatives/EditRepresentatives.aspx?ClientId=" + eventArgs.getDataKeyValue("ClientId"), "RepresentativeListDialog");
                                }
                            </script>


                        </telerik:RadCodeBlock>

                    </telerik:LayoutColumn>

                  
                </div>
            </div>
        </div>
   
      <%--  <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
     --%>
    </form>
</body>
</html>
