<%@ Page Title="Flight Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlightInformation.aspx.cs" Inherits="CMSVersion2.Maintenance.FlightInformation.FlightInformation" %>

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

        .center
        {
            text-align:center;
        }

         .alignright
        {
            text-align:right;
        }
  </style>

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

    <div id="wrapper">
        <div id="page-wrapper">

            <div class="container">

                <!--- PAGE HEADER--->
            <div class="row">
                <h3><i class="glyphicon glyphicon-plane"></i> FLIGHT INFORMATION</h3>
                <ol class="breadcrumb">
                    <li>Maintenance</li>
                    <li>Flight Information</li>
                </ol>
            </div>
                <!-- /.row -->
                <div class="row">
                        <telerik:RadAsyncUpload Skin="Glow" runat="server" ID="FileUploadFlightInfo" 
                                            HideFileInput="true" 
                                            AllowedFileExtensions=".xls,.xlsx,.csv"
                                            OnFileUploaded="FileUploadFlightInfo_FileUploaded"
                                            OnClientFilesUploaded="UploadFile"
                                            Localization-Select="Import File"/>
                        
                        <telerik:RadButton ID="btnUpload" runat="server" Text="Upload" 
                            style="display: none" OnClick="btnUpload_Click"></telerik:RadButton>
                         <%--<a href="#" onclick="return ShowInsertForm();" class="alink">
                                             <img src="../../Images/emblem.png" alt="Add Company" width="20">
                                             Add FlightInfo
                                         </a>--%>
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
                            AllowFilteringByColumn="true"
                            AutoGenerateColumns="false"
                            AllowSorting="true"
                            OnItemCreated="RadGrid2_ItemCreated"
                            ExportSettings-Excel-DefaultCellAlignment="Right"
                            PageSize="10" OnItemCommand="RadGrid2_ItemCommand1"
                            CommandItemDisplay="Top">
                           <ExportSettings HideStructureColumns="true" ExportOnlyData="true" 
                               IgnorePaging="true" UseItemStyles="true"></ExportSettings>     
                            <GroupingSettings CaseSensitive="false"></GroupingSettings>

                            <MasterTableView AutoGenerateColumns="False" ClientDataKeyNames="FlightInfoId"
                                AllowFilteringByColumn="true"
                                DataKeyNames="FlightInfoId" CommandItemDisplay="Top" Font-Size="Smaller"
                                InsertItemPageIndexAction="ShowItemOnFirstPage">
                                
                                <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true"
                                    ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                <Columns>

                                    <telerik:GridBoundColumn DataField="FlightNo" HeaderText="Flight No" SortExpression="FlightNo"
                                        UniqueName="FlightNo" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                      
                                    </telerik:GridBoundColumn>

                                    
                                    <telerik:GridDateTimeColumn DataField="ETD" HeaderText="ETD" SortExpression="ETD"
                                        UniqueName="ETD" AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DateTimePicker" DataType="System.DateTime" >
                                       
                                    </telerik:GridDateTimeColumn>

                                    <telerik:GridDateTimeColumn DataField="ETA" HeaderText="ETA" SortExpression="ETA"
                                        UniqueName="ETA"  AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DateTimePicker" DataType="System.DateTime" >
                                       
                                    </telerik:GridDateTimeColumn>

                                  <%--  <telerik:GridBoundColumn DataField="BCOName" HeaderText="BCOName" SortExpression="BCOName"
                                        UniqueName="BCOName" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                        
                                    </telerik:GridBoundColumn>--%>

                                    
                                    <telerik:GridBoundColumn DataField="GateWayName" HeaderText="GateWay Name" SortExpression="GateWayName"
                                        UniqueName="GateWayName" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true" >
                                       
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="OriginCityName" HeaderText="Origin" SortExpression="OriginCityName"
                                        UniqueName="OriginCityName" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true">
                                       
                                    </telerik:GridBoundColumn>

                                    
                                    <telerik:GridBoundColumn DataField="DestinationCityName" HeaderText="Destination" SortExpression="DestinationCityName"
                                        UniqueName="DestinationCityName" FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" HeaderStyle-Font-Bold="true" >
                                        <HeaderStyle />

                                    </telerik:GridBoundColumn>



                                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditLink" runat="server" Text="Edit"></asp:HyperLink> 
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    

                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this?" ButtonType="LinkButton"
                                        ConfirmDialogType="RadWindow" ConfirmDialogHeight="150px" ConfirmTitle="Deactivate User"
                                        CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="">
                                        <HeaderStyle />
                                    </telerik:GridButtonColumn>
                                </Columns>

                                <CommandItemTemplate>
                                    
                                    <div class="center">
                                    |
                                         <a href="#" onclick="return ShowInsertForm();" class="alink">
                                             <img src="../../Images/emblem.png" alt="Add Company" width="20">
                                             Add FlightInfo
                                         </a>
                                    |    
                                        
                                       <%-- <a href="#" onclick="return ShowExportForm();" class="alink">
                                            <img src="../../Images/emblem.png" alt="Print Preview" width="20">
                                            Print Preview
                                        </a>
                                    |
                   
                                 --%>
                                        <a href="#" onclick="location.reload();" class="alink">
                                            <img src="../../Images/emblem.png" alt="Export to Excel" width="20">
                                            Refresh Data
                                        </a>

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
                                <telerik:RadWindow RenderMode="Mobile" ID="UserListDialog" runat="server" Title="Editing record" Height="400px"
                                    Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="AddUser" runat="server" Title="Adding record" Height="400px"
                                    Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
                                    Modal="true" Behaviors="Close,Move">
                                </telerik:RadWindow>

                                <telerik:RadWindow RenderMode="Mobile" ID="ViewRepresentative" runat="server" Title="Representatives" Height="590px"
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

                           <%-- function UploadFile(fileUpload) {
                                if (fileUpload.value != '') {
                                    document.getElementById("<%=btnUpload.ClientID %>").click();
                                }
                            }--%>

                             function UploadFile(sender, args) {
                                document.getElementById("<%= btnUpload.ClientID %>").click();
                            }

                            function ShowEditForm(id, rowIndex) {
                                var grid = $find("<%= RadGrid2.ClientID %>");

                                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                grid.get_masterTableView().selectItem(rowControl, true);

                                window.radopen("Flight/Edit.aspx?Id=" + id, "UserListDialog");
                                return false;
                            }

                            function ViewRep(id, rowIndex) {
                                var grid = $find("<%= RadGrid2.ClientID %>");

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);

                                    window.radopen("UserModal/ViewRepresentative.aspx?CompanyId=" + id, "ViewRepresentative");
                                    return false;
                                }

                                function ViewApprovingAuthority(id, rowIndex) {
                                    var grid = $find("<%= RadGrid2.ClientID %>");

                                   var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                   grid.get_masterTableView().selectItem(rowControl, true);

                                   window.radopen("UserModal/ViewApprovingAuthority.aspx?CompanyId=" + id, "ViewRepresentative");
                                   return false;
                               }

                               function ShowInsertForm() {
                                   window.radopen("Flight/Add.aspx", "AddUser");
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

                                    //ShowEditForm();
                                      window.radopen("UserModal/Flight/EditFlight.aspx?Id=" + eventArgs.getDataKeyValue("FlightInfoId"), "UserListDialog");


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
