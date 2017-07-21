<%@ Page Title="Company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="CMSVersion2.Corporate.Company" %>

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
        <div id="page-wrapper">

            <div class="container">

               <div class="row">
                <h3><i class="glyphicon glyphicon-home"></i> COMPANY</h3>
                <ol class="breadcrumb">
                    <li>Corporate</li>
                    <li>Company</li>
                </ol>
            </div>
                <!-- /.row -->
                 <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchCompany" EmptyMessage="Search Company Name "
                          OnSearch="radCompany_Search" Width="300"
                        DataKeyNames="CompanyId"
                        DataTextField="CompanyName"
                        DataValueField="CompanyId"
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

                        <telerik:RadGrid ID="RadGrid2" Skin="Glow" 
                             runat="server" 
                            OnNeedDataSource="RadGrid2_NeedDataSource"
                            AllowPaging="True" 
                            AutoGenerateColumns="false"
                            AllowSorting="true"
                             OnItemCreated="RadGrid2_ItemCreated"
                            ExportSettings-Excel-DefaultCellAlignment="Right"
                            PageSize="10" 
                            OnItemCommand="RadGrid2_ItemCommand1"
                            CommandItemDisplay="Top"
                            >
                            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                            <GroupingSettings CaseSensitive="false"></GroupingSettings>
                            
                            <MasterTableView AutoGenerateColumns="false" ClientDataKeyNames="CompanyId"
                                AllowFilteringByColumn="false"
                                DataKeyNames="CompanyId" CommandItemDisplay="Top"
                                InsertItemPageIndexAction="ShowItemOnFirstPage">
                               
                                 <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true"
                                    ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                <Columns>

                                    <telerik:GridBoundColumn DataField="AccountNo" HeaderText="Account No." SortExpression="AccountNo" UniqueName="AccountNo"
                                       FilterDelay="2000" ShowFilterIcon="true" AllowFiltering ="true"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"
                                        UniqueName="CompanyName" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                        
                                    </telerik:GridBoundColumn>

                                    <telerik:GridDateTimeColumn DataField="ApprovedDate" HeaderText="Approved Date" SortExpression="ApprovedDate"
                                        UniqueName="ApprovedDate" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}" FilterDelay="2000" DataType="System.DateTime"
                                  HeaderStyle-Font-Bold="true" AllowFiltering="true" FilterListOptions="VaryByDataType">
                                       
                                    </telerik:GridDateTimeColumn>

                                    <telerik:GridBoundColumn DataField="Stats" HeaderText="Status" SortExpression="Stats"
                                        UniqueName="Stats" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                      
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="MotherCompany" HeaderText="Mother Company" SortExpression="MotherCompany"
                                        UniqueName="MotherCompany" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                       
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" HeaderText="Representatives" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="ViewRepsLink" runat="server" Text="View"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" HeaderText="Approving Authority" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="ViewApprovingLink" runat="server" Text="View"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    
                                  <%--  <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" HeaderText="Booking" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="ViewBookingLink" runat="server" Text="View"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    --%>
                                    
                                    
                                    
                                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditLink" runat="server" Text="Edit"></asp:HyperLink>
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
                                     <a href="#" onclick="return ShowInsertForm();" class="alink">
                                             <img src="../images/emblem.png" alt="Add Company" width="20">
                                             Add Company
                                         </a>
                                    |    
                                        
                                        <a href="#" onclick="return ShowExportForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Print Preview" width="20">
                                            Print Preview
                                        </a>
                                    |
                   
                                 
                                         <a href="" onclick="LoadRadGrid()" class="alink">
                                            <img src="../images/emblem.png" alt="Export to Excel" width="20">
                                            Refresh Data
                                        </a>
                                        <asp:button id="btnSubmit" runat="server" text="Submit" xmlns:asp="#unknown"
                                            onclick="btnSubmit_Click" style="display:none" /> 

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
                                <telerik:RadWindow RenderMode="Mobile" ID="CompanyListDialog" runat="server" Title="Editing record" Height="600px"
                                    Width="880px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="AddCompany" runat="server" Title="Adding record" Height="600px"
                                    Width="880px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="ViewRepresentative" runat="server" Title="Representatives" Height="650px"
                                    Width="1000px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="ViewAppAuthority" runat="server" Title="Approving Authority" Height="650px"
                                    Width="1000px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>
                                 <telerik:RadWindow RenderMode="Mobile" ID="rdwViewBooking" runat="server" Title="Booking" Height="650px"
                                    Width="1000px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>
                                <telerik:RadWindow RenderMode="Mobile" ID="ShowExport" runat="server" Title="Export Report Preview" Height="590px"
                                    Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
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

                                window.radopen("CompanyModal/Edit.aspx?CompanyId=" + id, "CompanyListDialog");
                                return false;
                            }

                            function ViewRep(id, rowIndex) {
                                var grid = $find("<%= RadGrid2.ClientID %>");

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);

                                    window.radopen("RepresentativeModal/View.aspx?CompanyId=" + id, "ViewRepresentative");
                                    return false;
                                }

                                function ViewApprovingAuthority(id, rowIndex) {
                                    var grid = $find("<%= RadGrid2.ClientID %>");

                                   var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                   grid.get_masterTableView().selectItem(rowControl, true);

                                   window.radopen("ApprovingAuthorityModal/View.aspx?CompanyId=" + id, "ViewAppAuthority");
                                   return false;
                               }

                                function ViewBooking(id, rowIndex) {
                                    var grid = $find("<%= RadGrid2.ClientID %>");

                                   var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                   grid.get_masterTableView().selectItem(rowControl, true);

                                   window.radopen("Booking/AddBooking.aspx?CompanyId=" + id, "rdwViewBooking");
                                   return false;
                               }

                               function ShowInsertForm() {
                                   window.radopen("CompanyModal/Add.aspx", "AddCompany");
                                   return false;
                               }

                               function ShowExportForm() {
                                   window.radopen("Reports/CompanyExportPreview.aspx", "ShowExport");
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
                                    window.radopen("CompanyModal/Edit.aspx?CompanyId=" + eventArgs.getDataKeyValue("CompanyId"), "CompanyListDialog");
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
