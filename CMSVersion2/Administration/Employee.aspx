<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="CMSVersion2.Administration.Employee" %>

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

            <div class="container" >

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                     
                            <h3>EMPLOYEE MAINTENANCE</h3>
                        
                        <ol class="breadcrumb">
                            <li>
                                Administration
                            </li>
                            <li class="active">
                                Manage Employee
                            </li>
                        </ol>
                        <hr />

                    </div>
                </div>
                 <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">


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


                <!-- /.row -->
                <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchEmployee" 
                        EmptyMessage="Search Employee Name "
                         OnSearch="radSearchEmployee_Search" Width="300"
                        DataKeyNames="EmployeeId"
                        DataTextField="FullName"
                        DataValueField="EmployeeId"
                        ShowSearchButton="false" Skin="Glow">
                        <DropDownSettings Width="300" />
                    </telerik:RadSearchBox>
                    
                 </div>
                <br />
             <div class="col-md-12">
                     <div class="col-md-12">
                                <telerik:RadLabel ID="lblBco" runat="server" Text="BCO:"></telerik:RadLabel>
                                <telerik:RadComboBox ID="rcbBranchCorpOffice" Skin="Glow" Width="230px" Height="200px" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="rcbBranchCorpOffice_SelectedIndexChanged"></telerik:RadComboBox>
                                
                                <telerik:RadLabel ID="lblType" runat="server" Text="Type:"></telerik:RadLabel>
                                <telerik:RadComboBox ID="rcbRevenueUnitType" Skin="Glow" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnTextChanged="rcbRevenueUnitType_TextChanged" OnSelectedIndexChanged="rcbRevenueUnitType_SelectedIndexChanged"></telerik:RadComboBox>
                                
                         <telerik:RadLabel ID="RadLabel1" runat="server" Text="Area:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbRevenueUnitName" Skin="Glow" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                                 <telerik:RadButton ID="btnSearchEmployee" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearch_Click"></telerik:RadButton>
                 </div>
                </div>
                <br />
                 <br />

                           
                            <telerik:RadGrid ID="RadGrid2" OnItemCreated="RadGrid2_ItemCreated"
                                runat="server" AllowPaging="True" ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="10" AllowSorting="true" OnItemCommand="RadGrid2_ItemCommand1"
                                AllowFilteringByColumn="true"
                                DataKeyNames="EmployeeId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource" Skin="Glow" > 
                                
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <GroupingSettings CaseSensitive="false"></GroupingSettings>
                                
                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="EmployeeId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="EmployeeId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true" 
            ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                        <telerik:GridBoundColumn DataField="FullName" HeaderText="Full name" SortExpression="FullName"
                                            UniqueName="FullName" FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        
                                       <%-- <telerik:GridNumericColumn DataField="MiddleName" HeaderText="Middle name" SortExpression="MiddleName"
                                            UniqueName="MiddleName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="LastName" HeaderText="Last name" SortExpression="LastName"
                                            UniqueName="LastName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>--%>

                                        <telerik:GridDateTimeColumn DataField="BirthDate" HeaderText="Birth Date" SortExpression="BirthDate" FilterControlWidth="120px"
                                            UniqueName="BirthDate"  PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                  HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                            <HeaderStyle />
                                        </telerik:GridDateTimeColumn>
                                        
                                        <telerik:GridNumericColumn DataField="ContactNo" HeaderText="Contact No" SortExpression="ContactNo"
                                            UniqueName="ContactNo"  FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        
                                        <telerik:GridBoundColumn DataField="Email" HeaderText="Email" SortExpression="Email"
                                            UniqueName="Email"  FilterDelay="2000" ShowFilterIcon="false" FilterControlWidth="120px"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                      

                                         <telerik:GridDateTimeColumn DataField="CreatedDate" HeaderText="Date Created" SortExpression="CreatedDate" FilterControlWidth="120px"
                                            UniqueName="CreatedDate"  PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                  HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
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
                                        <div class="center">
                                        |

                                         <a href="#"  onclick="return ShowInsertForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Add New Employee" width="20">
                                            Add New Employee
                                            </a>
                                        &nbsp;|    
                                        
                                       <%-- <a href="#"  onclick="return ShowExportForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Print Preview" width="20">
                                           Print Preview
                                            </a>
       &nbsp;|--%>
                   
                                 
                                        <a href="" onclick="LoadRadGrid()" class="alink">
                                            <img src="../images/emblem.png" alt="Export to Excel" width="20">
                                            Refresh Data
                                            </a>
                                            <asp:button id="btnSubmit" runat="server" text="Submit" xmlns:asp="#unknown"
                                            onclick="btnSubmit_Click" style="display:none" /> 
                        
                            &nbsp;|
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
                                    <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="600px"
                                        Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="600px"
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

                                    window.radopen("EmployeeModal/Edit.aspx?EmployeeId=" + id, "UserListDialog");
                                    return false;
                                }
                                function ShowInsertForm() {
                                    window.radopen("EmployeeModal/Add.aspx", "AddUser");
                                    return false;
                                }

                                function ShowExportForm() {
                                    window.radopen("Reports/EmployeeExportPreview.aspx", "ShowExport");
                                    return false;
                                }

                                 function RefreshData() {
                                    window.radopen("ManageEmployee.aspx", "ShowExport");
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
                                    window.radopen("EditForm_csharp.aspx?UserID=" + eventArgs.getDataKeyValue("UserId"), "UserListDialog");
                                }

                                function LoadRadGrid(){ 
                                            document.getElementById("btnSubmit").click(); 
                                        } 
                            </script>


                        </telerik:RadCodeBlock>

                   
            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

                 
           </div>
</asp:Content>
