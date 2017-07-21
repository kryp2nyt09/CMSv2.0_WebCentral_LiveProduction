<%@ Page Title="AWB Issuance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Issuance.aspx.cs" Inherits="CMSVersion2.Maintenance.AWBSeries.AWBIssuance" %>

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

                <!--- PAGE HEADER--->
            <div class="row">
                <h3><i class="glyphicon glyphicon-credit-card"></i> AWB SERIES ISSUANCE</h3>
                <ol class="breadcrumb">
                    <li>Maintenance</li>
                    <li>AWB Series</li>
                    <li>Inssuance</li>
                </ol>
            </div>
                <!-- /.row -->
               <%-- <div class="size-wide">
                    <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="radSearchawbIssuance" 
                        CssClass="searchBox"
                        DropDownSettings-Height="300"
                        DataSourceID="SqlDataSource1"
                        EmptyMessage="Search"
                        Width="400"
                        DataKeyNames="AwbIssuanceId, BCOid"
                        DataTextField="Name"
                        DataValueField="AwbIssuanceId"
                        ShowSearchButton="false" Skin="Glow"
                        OnDataSourceSelect="radSearchawbIssuance_DataSourceSelect"
                        OnSearch="radSearchawbIssuance_Search">
                        <SearchContext DataSourceID="SqlDataSourceBCO" DataTextField="BranchCorpOfficeName" DataKeyField="BranchCorpOfficeId" DropDownCssClass="contextDropDown"></SearchContext>
                    </telerik:RadSearchBox>
                    
                 </div>
                <br />
                <br />--%>
                  <telerik:LayoutColumn HiddenMd="true" HiddenSm="true" HiddenXs="true">

                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="gridwrapper">
                <div class="row">
                     <div class="col-md-12">
                                <telerik:RadLabel ID="lblBco" runat="server" Text="BCO:"></telerik:RadLabel>
                                <telerik:RadComboBox ID="rcbBranchCorpOffice" Skin="Glow" Width="230px" Height="200px" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="rcbBranchCorpOffice_SelectedIndexChanged"></telerik:RadComboBox>
                                
                                <telerik:RadLabel ID="lblType" runat="server" Text="Type:"></telerik:RadLabel>
                                <telerik:RadComboBox ID="rcbRevenueUnitType" Skin="Glow" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnTextChanged="rcbRevenueUnitType_TextChanged" OnSelectedIndexChanged="rcbRevenueUnitType_SelectedIndexChanged"></telerik:RadComboBox>
                                
                         <telerik:RadLabel ID="RadLabel1" runat="server" Text="Area:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbRevenueUnitName" Skin="Glow" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                                 <telerik:RadButton ID="btnSearch" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearch_Click"></telerik:RadButton>
                 </div>
                </div>
                <br />
                 <br />
              


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

                        <telerik:RadGrid ID="RadGrid2"  Skin="Glow"
                             runat="server" 
                             ShowSearchPanel="True"
                             OnNeedDataSource="RadGrid2_NeedDataSource"
                             AllowPaging="True" 
                             AutoGenerateColumns="false"
                             AllowSorting="true"
                             OnItemCreated="RadGrid2_ItemCreated"
                             ExportSettings-Excel-DefaultCellAlignment="Right"
                             PageSize="10"
                             OnItemCommand="RadGrid2_ItemCommand"
                            DataKeyNames="AwbIssuanceId" CommandItemDisplay="Top">
                            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                            
                            <MasterTableView AutoGenerateColumns="False" 
                                ClientDataKeyNames="AwbIssuanceId"
                                AllowFilteringByColumn="false"
                                DataKeyNames="AwbIssuanceId" 
                                CommandItemDisplay="Top"
                                InsertItemPageIndexAction="ShowItemOnFirstPage">
                                <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true"
                                    ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                <Columns>

                                 <telerik:GridDateTimeColumn
                                 HeaderText="Date Assigned" AllowFiltering="true" DataField="IssueDate" SortExpression="IssueDate" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DatePicker"  DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" UniqueName="IssueDate" FilterControlWidth="100px" ></telerik:GridDateTimeColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" Exportable="false" 
                                  DataField="BranchCorpOfficeName" HeaderText="BCO"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" Exportable="false" 
                                  DataField="RevenueUnitName" HeaderText="Area"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" Exportable="false" 
                                  DataField="Name" HeaderText="Name"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" Exportable="false" 
                                  DataField="SeriesStart" HeaderText="Start Series"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" Exportable="false" 
                                  DataField="SeriesEnd" HeaderText="End Series"></telerik:GridBoundColumn>



                                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditLink" runat="server" Text="Edit"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>


                                    <%--    <telerik:GridButtonColumn  CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                            <HeaderStyle />
                                        </telerik:GridButtonColumn>--%>
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete?" ButtonType="LinkButton"
                                        ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Delete"
                                        CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                        <HeaderStyle />
                                    </telerik:GridButtonColumn>
                                </Columns>

                                <CommandItemTemplate>    
                                    <div class="center">

                                         <a href="#" onclick="return ShowInsertForm();" class="alink">
                                             <img src="../../Images/emblem.png" alt="Add Company" width="20">
                                             Add Series
                                         </a>
                                    |    
                                        
                                        <a href="#" onclick="return ShowExportForm();" class="alink">
                                            <img src="../../Images/emblem.png" alt="Print Preview" width="20">
                                            Print Preview
                                        </a>
                                    |
                   
                                 
                                        <a href="" onclick="LoadRadGrid()" class="alink">
                                            <img src="../../Images/emblem.png" alt="Export to Excel" width="20">
                                            Refresh Data
                                        </a>
                                        <asp:button id="btnSubmit" runat="server" text="Submit" xmlns:asp="#unknown"
                                            onclick="btnSubmit_Click" style="display:none" /> 
                                    </div>
                                        

                                    
                                       
                                </CommandItemTemplate>

                            </MasterTableView>
                            <ClientSettings>
                                <Selecting AllowRowSelect="true"></Selecting>
                                <%--<ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>--%>
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                        <br />
                        <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
                            <Windows>
                                <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="520px"
                                    Width="380px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="500px"
                                    Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="ViewRepresentative" runat="server" Title="Representatives" Height="500px"
                                    Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
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

                                    window.radopen("IssuanceModal/Edit.aspx?AwbIssuanceId=" + id, "ViewRepresentative");
                                    return false;
                                }

                               function ShowInsertForm() {
                                   window.radopen("IssuanceModal/Add.aspx", "AddUser");
                                   return false;
                               }

                               function ShowExportForm() {
                                   window.radopen("Reports/AwbIssuanceExport.aspx", "ShowExport");
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
                                    window.radopen("UserModal/EditForm_csharp.aspx?UserID=" + eventArgs.getDataKeyValue("UserId"), "UserListDialog");
                                }

                                function LoadRadGrid(){ 
                                            document.getElementById("btnSubmit").click(); 
                                        } 
                        </script>


                    </telerik:RadCodeBlock>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:Cms %>"
                        SelectCommand="SELECT awb.*, bco.BranchCorpOfficeName, ru.RevenueUnitName, emp.FirstName + ' ' + emp.MiddleName + ' ' + emp.LastName AS Name from AwbIssuance awb LEFT join BranchCorpOffice bco on awb.BCOid = bco.BranchCorpOfficeId LEFT join RevenueUnit ru on awb.RevenueUnitId = ru.RevenueUnitId LEFT join Employee emp on awb.IssuedToId = emp.EmployeeId where awb.RecordStatus = 1 and bco.BranchCorpOfficeName is not null"></asp:SqlDataSource>
                     <asp:SqlDataSource ID="SqlDataSourceBCO" runat="server"
                        ConnectionString="<%$ ConnectionStrings:Cms %>"
                        SelectCommand="SELECT [BranchCorpOfficeId], [BranchCorpOfficeName] FROM BranchCorpOffice WHERE RecordStatus = 1 ORDER BY [BranchCorpOfficeName]">
                    </asp:SqlDataSource>
    

                </telerik:LayoutColumn> 
            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->


    </div>

</asp:Content>
