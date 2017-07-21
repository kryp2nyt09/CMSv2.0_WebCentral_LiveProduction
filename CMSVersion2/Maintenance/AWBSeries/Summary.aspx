<%@ Page Title="AWB Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="CMSVersion2.Maintenance.AWBSeries.Summary" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
       <div id="page-wrapper">
           <div class="container">
                  <!--- PAGE HEADER--->
            <div class="row">
                <h3><i class="glyphicon glyphicon-tasks"></i> AWB ISSUED SUMMARY</h3>
                <ol class="breadcrumb">
                    <li>Maintenance</li>
                    <li>AWB Series</li>
                    <li>Summary</li>
                </ol>
            </div>


               
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

                <telerik:RadAjaxLoadingPanel ID="gridLoadingPanel" runat="server">
            </telerik:RadAjaxLoadingPanel>
               <div class="row">
                   <div class="col-md-12">
                      <telerik:RadLabel ID="lblDateFrom" runat="server" Text="Date From:"></telerik:RadLabel>
                      <telerik:RadDatePicker ID="startDate" MinDate="1950/1/1" ZIndex="11000"  runat="server" Skin="Glow"></telerik:RadDatePicker>
                      
                       <telerik:RadLabel ID="lblDateTo" runat="server" Text="Date To:"></telerik:RadLabel>
                       <telerik:RadDatePicker ID="endDate" MinDate="1950/1/1" ZIndex="11000"  runat="server" Skin="Glow"></telerik:RadDatePicker>
                      
                       <telerik:RadLabel ID="lblBco" runat="server" Text="BCO:"></telerik:RadLabel>
                       <telerik:RadComboBox ID="rcbBranchCorpOffice" Skin="Glow" Width ="230" Height="200px" runat="server"  AutoPostBack="true"></telerik:RadComboBox>
                      
                       <telerik:RadLabel ID="lblArea" runat="server" Text="Area:"></telerik:RadLabel>
                       <telerik:RadComboBox ID="rcbRevenueUnitType" Skin="Glow" Height="200px" runat="server" AutoPostBack="true"></telerik:RadComboBox>
                      <telerik:RadButton ID="btnSearchEmployee" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearch_Click"></telerik:RadButton>
                </div>
               </div>
               <br />
               




               <div class="row">

                   <telerik:RadGrid runat="server" Skin="Glow" 
                    ID="radGridAwbIssuedSummary"
                    AllowPaging="True" 
                    PageSize="10"  
                    AllowFilteringByColumn="false" 
                    AutoGenerateColumns="false"
                    AllowSorting="true"
                    OnNeedDataSource="radGridAwbIssuedSummary_NeedDataSource">
                       <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>

                        <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top">
                            <CommandItemSettings ShowExportToExcelButton="false" ShowExportToPdfButton="false" ExportToPdfText="PDF" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                            <FilterItemStyle VerticalAlign="Top" />

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


                            </Columns>
                           
                        </MasterTableView>
                    </telerik:RadGrid><!--RadGrid - radGridAwbIssuance-->
                   <br />
               </div><!--row-->
                </telerik:RadAjaxPanel>
                <telerik:RadCodeBlock runat="server">
                    <script type="text/javascript">
                                 function refreshGrid(arg) {
                                    if (!arg) {
                                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                                    }
                                    else {
                                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                                    }
                                }
                    </script>
                </telerik:RadCodeBlock>
           </div><!--container-->
       </div><!--page-wrapper-->
   </div><!--wrapper-->         
                 
</asp:Content>
