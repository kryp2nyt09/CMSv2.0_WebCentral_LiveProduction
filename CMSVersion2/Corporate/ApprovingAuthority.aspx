<%@ Page Title="Approving Authority" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovingAuthority.aspx.cs" Inherits="CMSVersion2.Corporate.ApprovingAuthority" %>

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

                <div class="row">
                <h3><i class="glyphicon glyphicon-thumbs-up"></i> APPROVING AUTHORITY</h3>
                <ol class="breadcrumb">
                    <li>Corporate</li>
                    <li>Approving Authority</li>                    
                </ol>
            </div>
                <!-- /.row -->
                 <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchApprovingAuthority" EmptyMessage="Search Approving Authority"
                          OnSearch="radSearchApprovingAuthority_Search" Width="300"
                        DataKeyNames="ApprovingAuthorityId"
                        DataTextField="Name"
                        DataValueField="ApprovingAuthorityId"
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
                                DataKeyNames="ApprovingAuthorityId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource"> 
                                
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <GroupingSettings CaseSensitive="false"></GroupingSettings>

                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="ApprovingAuthorityId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="ApprovingAuthorityId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true" 
                                        ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                      <telerik:GridBoundColumn DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"
                                            UniqueName="CompanyName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Full Name" SortExpression="Name"
                                            UniqueName="Name" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>


                                     <%--   <telerik:GridNumericColumn DataField="LastName" HeaderText="Last Name" SortExpression="LastName"
                                            UniqueName="LastName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>--%>

                                        <telerik:GridBoundColumn DataField="Title" HeaderText="Title" SortExpression="Title"
                                            UniqueName="Title" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Position" HeaderText="Position" SortExpression="Position"
                                            UniqueName="Position" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Department" HeaderText="Department" SortExpression="Department"
                                            UniqueName="Department" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Email" HeaderText="Email" SortExpression="Email"
                                            UniqueName="Email" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>


                                        <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HyperLink  ID="EditLink" runat="server" Text="Edit"  ></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    <%--    <telerik:GridButtonColumn  CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>--%>
                                         <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this record?" ButtonType="LinkButton"
                                            ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Deactivate User" 
                                             CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>
                                    </Columns>

                                    <CommandItemTemplate>
                                      <div class="center">
                                        
                                        |

                                         <a href="#"  onclick="return ShowInsertForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Add Approver" width="20"/>
                                            Add Approver
                                            </a>
                                    

<%--                            |
                                        
                                        <a href="#"  onclick="return ShowExportForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Print Preview" width="20"/>
                                           Print Preview
                                            </a>--%>
       |
                   
                                 
                                        <a href="" onclick="LoadRadGrid()" class="alink">
                                            <img src="../images/emblem.png" alt="Export to Excel" width="20">
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
                                    <telerik:RadWindow RenderMode="Mobile" ID="ApprovingAuthorityListDialog" runat="server" Title="Editing record" Height="450px"
                                        Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="450px"
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

                                    window.radopen("ApprovingAuthorityModal/Edit.aspx?ID=" + id, "ApprovingAuthorityListDialog");
                                    return false;
                                }
                                function ShowInsertForm() {
                                    window.radopen("ApprovingAuthorityModal/Add.aspx", "AddUser");
                                    
                                    return false;
                                }

                                function ShowExportForm() {
                                    window.radopen("Reports/ApprovingAuthorityExportReport.aspx", "ShowExport");
                                    return false;
                                }


                                function refreshGrid(arg) {
                                    s
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
                                    window.radopen("ApprovingAuthorityModal/Edit.aspx?ID=" + eventArgs.getDataKeyValue("ApprovingAuthorityId"), "ApprovingAuthorityListDialog");
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
