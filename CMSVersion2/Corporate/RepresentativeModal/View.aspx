<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="CMSVersion2.Corporate.RepresentativeModal.View" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;//Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;//IE (and Moz az well)
            return oWindow;
        }

        function CloseOnReload() {
            //GetRadWindow().Close();
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;
        }

        function RefreshParentPage() {
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;

        }
    </script>
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
                           

                             <asp:HiddenField ID="lblCompanyID" runat="server" Visible="true"></asp:HiddenField>

                            <telerik:RadGrid ID="RadGrid2" OnItemCreated="RadGrid2_ItemCreated"
                                runat="server" AllowPaging="True" ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="5" Skin="Glow" AllowSorting="true" OnItemCommand="RadGrid2_ItemCommand1"
                                RenderMode="Mobile"
                                DataKeyNames="ClientId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="ClientId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="ClientId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true" 
            ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                        <telerik:GridNumericColumn DataField="Name" HeaderText="Client Name" SortExpression="Name"
                                            UniqueName="Name">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        
                                        <telerik:GridNumericColumn DataField="AccountNo" HeaderText="AccountNo" SortExpression="AccountNo"
                                            UniqueName="AccountNo">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"
                                            UniqueName="CompanyName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="CityName" HeaderText="City Name" SortExpression="CityName"
                                            UniqueName="CityName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>
                                        
                                        <telerik:GridNumericColumn DataField="BranchCorpOfficeName" HeaderText="BranchCorpOffice" SortExpression="BranchCorpOfficeName"
                                            UniqueName="BranchCorpOfficeName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                       <telerik:GridDateTimeColumn DataField="ModifiedDate" HeaderText="Date Modified" SortExpression="ModifiedDate"
                                            UniqueName="ModifiedDate" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                                            <HeaderStyle />

                                        </telerik:GridDateTimeColumn>
                                        <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HyperLink  ID="EditLink" runat="server" Text="Edit"  ></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    <%--    <telerik:GridButtonColumn  CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>--%>
                                         <telerik:GridButtonColumn ConfirmText="Are you sure you want to deactivate this user?" ButtonType="LinkButton"
                                            ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Deactivate User" 
                                             CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>
                                    </Columns>

                                    <CommandItemTemplate>

                                          |

                                         <a href="#"  onclick="return ShowInsertForm(<%= lblCompanyID.ClientID %>);">
                                            <img src="../../images/emblem.png" alt="Add Company" width="20px">
                                            Add Representative
                                            </a>
                                       
                                     <%--   <button class="btn btn-link"><img src="../../images/emblem.png" alt="Add Company" width="20px">
                                             Add Representatives
                                        </button>
                            |--%>
                                        
                                       <%-- <a href="#"  onclick="return ShowExportForm();">
                                            <img src="../../images/emblem.png" alt="Print Preview" width="20px">
                                           Print Preview
                                            </a>
       |--%>
                   
                                 
                                        <a href="#"  onclick="location.reload();">
                                            <img src="../../images/emblem.png" alt="Export to Excel" width="20px">
                                            Refresh Data
                                            </a>
                        
                            |
                                       
                                    </CommandItemTemplate>
                              
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

                                    window.radopen("Edit.aspx?ClientId=" + id, "RepresentativeListDialog");
                                    return false;
                                }

                                function ShowInsertForm(obj) {
                                    window.radopen("Add.aspx?CompanyId=" + obj.value, "AddRepresentatives");
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
   
        <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>
     
    </form>
</body>
</html>
