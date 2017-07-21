<%@ Page Title="Representative" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Representative.aspx.cs" Inherits="CMSVersion2.Corporate.Representative" %>

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
                <h3><i class="glyphicon glyphicon-user"></i> REPRESENTATIVE</h3>
                <ol class="breadcrumb">
                    <li>Corporate</li>
                    <li>Representative</li>                    
                </ol>
            </div>
                <!-- /.row -->
                <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchRepresentatives" EmptyMessage="Search Representatives"
                          OnSearch="radSearchRepresentatives_Search" Width="300"
                        DataKeyNames="ClientId"
                        DataTextField="Name"
                        DataValueField="ClientId"
                        ShowSearchButton="false"  Skin="Glow">
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
                                PageSize="10" OnItemCommand="RadGrid2_ItemCommand1"
                                DataKeyNames="ClientId" CommandItemDisplay="Top"
                                > 
                                
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <GroupingSettings CaseSensitive="false"></GroupingSettings>


                                <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="ClientId"
                                    AllowFilteringByColumn="false"
                                    DataKeyNames="ClientId" CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">

                                   <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true" 
                                        ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Client Name" SortExpression="Name"
                                            UniqueName="Name" FilterDelay="2000" ShowFilterIcon="false"
                                             CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"  >
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        
                                        <telerik:GridBoundColumn DataField="AccountNo" HeaderText="AccountNo" SortExpression="AccountNo"
                                            UniqueName="AccountNo" FilterDelay="2000" ShowFilterIcon="false"
                                             CurrentFilterFunction="Contains" AutoPostBackOnFilter="false">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"
                                            UniqueName="CompanyName" FilterDelay="2000" ShowFilterIcon="false"
                                             CurrentFilterFunction="Contains" AutoPostBackOnFilter="false">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="CityName" HeaderText="City Name" SortExpression="CityName"
                                            UniqueName="CityName" FilterDelay="2000" ShowFilterIcon="false"
                                             CurrentFilterFunction="Contains" AutoPostBackOnFilter="false">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>
                                        
                                        <telerik:GridBoundColumn DataField="BranchCorpOfficeName" HeaderText="BranchCorpOffice" SortExpression="BranchCorpOfficeName"
                                            UniqueName="BranchCorpOfficeName" FilterDelay="2000" ShowFilterIcon="false"
                                             CurrentFilterFunction="Contains" AutoPostBackOnFilter="false">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

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
                                        <div class="center">
                            |
                                        <a href="#" onclick="return ShowInsertForm();" class="alink">
                                             <img src="../images/emblem.png" alt="Add Company" width="20">
                                             Add Representatives
                                         </a>
                                        
                                        |
                                        
                           <%--             <a href="#"  onclick="return ShowExportForm();" class="alink">
                                            <img src="../images/emblem.png" alt="Print Preview" width="20">
                                           Print Preview
                                            </a>
       |--%>
                   
                                 
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
                                    <telerik:RadWindow RenderMode="Mobile" ID="RepresentativeListDialog" runat="server" Title="Editing record" Height="630px"
                                        Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                        Modal="true" Behaviors="Close,Move">
                                    </telerik:RadWindow>

                                     <telerik:RadWindow RenderMode="Mobile" ID="AddRepresentatives" runat="server" Title="Adding record" Height="630px"
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

                                    window.radopen("RepresentativeModal/Edit.aspx?ClientId=" + id, "RepresentativeListDialog");
                                    return false;
                                }
                                function ShowInsertForm() {
                                    window.radopen("RepresentativeModal/Add.aspx", "AddRepresentatives");
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
                                    window.radopen("RepresentativeModal/Edit.aspx?ClientId=" + eventArgs.getDataKeyValue("ClientId"), "RepresentativeListDialog");
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
