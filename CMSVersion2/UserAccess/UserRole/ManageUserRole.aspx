<%@ Page Title="User Role" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUserRole.aspx.cs" Inherits="CMSVersion2.UserAccess.UserRole.ManageUserRole" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style type="text/css">
        .alink{
            text-decoration:none !important;
            color:#c1c7ca !important;
        }

        .alink:hover{
            text-decoration:none !important;
            color:#c1c7ca !important;
        }

        .center {
            text-align: center;
        }
    </style>

    <div id="wrapper">
   <div id="page-wrapper"  >

            <div class="container">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                     
                            <h3>USER MAINTENANCE</h3>   
                        
                        <ol class="breadcrumb">
                            <li>
                                Administration
                            </li>
                            <li >
                                 User Roles
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- /.row -->

                 <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchUserEmployee" 
                        EmptyMessage="Search Employee Name "
                         OnSearch="radSearchUserEmployee_Search" Width="300"
                        DataKeyNames="UserId"
                        DataTextField="FullName"
                        DataValueField="UserId"
                        ShowSearchButton="false" Skin="Glow">
                        <DropDownSettings Width="300" />
                    </telerik:RadSearchBox>
                    
                 </div>
                <br />

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
                           
                            <telerik:RadGrid ID="RadGrid2" OnItemCreated="RadGrid2_ItemCreated"
                                runat="server" AllowPaging="True" ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="10" Skin="Glow" AllowSorting="true" OnItemCommand="RadGrid2_ItemCommand1"
                                 AllowFilteringByColumn="true"
                                DataKeyNames="UserId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                
                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="UserId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="UserId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   
                                    <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true" 
                                        ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                        <telerik:GridBoundColumn DataField="UserName" HeaderText="UserName" SortExpression="UserName"
                                            UniqueName="UserName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="FullName" HeaderText="FullName" SortExpression="FirstName"
                                            UniqueName="FullName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>
                                         <telerik:GridTemplateColumn UniqueName="RolesLink" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HyperLink  ID="RolesLink" runat="server" Text="Roles"  ></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                         <telerik:GridTemplateColumn UniqueName="ManageLink" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HyperLink  ID="ManageLink" runat="server" Text="Manage"  ></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HyperLink  ID="EditLink" runat="server" Text="Edit"  ></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                         <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this user role?" ButtonType="LinkButton"
                                            ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Deactivate User Role" 
                                             CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>
                                    </Columns>

                                    <GroupByExpressions>
                                 <telerik:GridGroupByExpression>
                                     <GroupByFields>
                                         <telerik:GridGroupByField FieldName="BranchCorpOfficeName" />
                                     </GroupByFields>
                                   
                                     <SelectFields>
                                         <telerik:GridGroupByField FieldName="BranchCorpOfficeName" HeaderText="BCO"/>
                                     </SelectFields>
                                 </telerik:GridGroupByExpression>
                                </GroupByExpressions>



                                    <CommandItemTemplate>
                                        <div class="center">
                                        |

                                         <a href="#"  onclick="return ShowInsertForm();" class="alink">
                                            <img src="../../Images/emblem.png" alt="Add User Role" width="20">
                                            Add User Role
                                            </a>
                                        |    
                                        
                                    <%--    <a href="#"  onclick="return ShowExportForm();" class="alink">
                                            <img src="../../Images/emblem.png" alt="Print Preview" width="20">
                                           Print Preview
                                            </a>
       |--%>
                   
                                 
                                        <a href="" onclick="LoadRadGrid()" class="alink">
                                            <img src="../../Images/emblem.png" alt="Export to Excel" width="20">
                                            Refresh Data
                                        </a>
                                        <asp:button id="btnSubmit" runat="server" text="Submit" xmlns:asp="#unknown"
                                            onclick="btnSubmit_Click" style="display:none" /> 
                        
                            |
                                       </div>
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
                                    <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="450px"
                                        Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="400px"
                                        Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
                                        Modal="true" Behaviors="Close,Move"  >
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="ViewRole" runat="server" Title="Roles" Height="400px"
                                    Width="400px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="ManageModule" runat="server" Title="Roles" Height="500px"
                                    Width="950px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
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

                                    window.radopen("UserRoleModal/EditUserRole.aspx?UserId=" + id, "UserListDialog");
                                    return false;
                                }

                        function ViewRoles(id, rowIndex) {
                                var grid = $find("<%= RadGrid2.ClientID %>");

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);

                                    window.radopen("../Roles/RolesModal/ViewRoles.aspx?UserId=" + id, "ViewRole");
                                    return false;
                                }

                    function ManageMenuAccess(id, rowIndex) {
                                var grid = $find("<%= RadGrid2.ClientID %>");

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);

                                    window.radopen("UserRoleModal/AddAccesstoModule.aspx?UserId=" + id, "ManageModule");
                                    return false;
                                }
                                function ShowInsertForm() {
                                    window.radopen("UserRoleModal/AddUserRole.aspx", "AddUser");
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
                                //ShowEditForm();
                                    window.radopen("UserModal/EditForm_csharp.aspx?UserID=" + eventArgs.getDataKeyValue("UserId"), "UserListDialog");
                                }

                                function LoadRadGrid(){ 
                                            document.getElementById("btnSubmit").click(); 
                                        } 
                            </script>


                        </telerik:RadCodeBlock>

                    </telerik:LayoutColumn>
            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

                 
           </div>
</asp:Content>
