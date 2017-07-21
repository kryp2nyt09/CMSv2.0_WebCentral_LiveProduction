<%@ Page Title="AWB Series Monitoring" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Monitoring.aspx.cs" Inherits="CMSVersion2.Maintenance.AWBSeries.Monitoring" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="wrapper">
       <div id="page-wrapper">
           <div class="container">
               <!-- Page Heading -->
               <div class="row">
                   <div class="col-lg-12">
                       <h3>AWB Series Monitoring</h3>
                       <ol class="breadcrumb">
                           <li>AWB Series</li>
                            <li class="active">AWB Series Monitoring</li>
                       </ol><!--breadcrumb-->
                       <hr />
                   </div>
               </div><!--row-->

               <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
       
                       

               <div class="row">
                   <div class="col-md-12">
                       <telerik:RadLabel ID="lblBco" runat="server" Text="BCO:"></telerik:RadLabel>
                       <telerik:RadComboBox ID="rdcBCO" runat="server" Skin="Glow" Width="220px" 
                        AppendDataBoundItems="true" EnableTextSelection="true" 
                        AutoCompleteSeparator="None" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rdcBCO_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>
                        
                      <%-- <telerik:RadComboBox ID="rdcBCO" runat="server"  Width="230px" AutoPostBack="true" Skin="Glow" OnSelectedIndexChanged="rdcBCO_SelectedIndexChanged"></telerik:RadComboBox>--%>
                      
                       <telerik:RadLabel ID="lblArea" runat="server" Text="Area:"></telerik:RadLabel>
                       <telerik:RadComboBox ID="rcbRevenueType" runat="server" Skin="Glow" Width="150px" 
                        AppendDataBoundItems="true" EnableTextSelection="true" 
                        AutoCompleteSeparator="None" MarkFirstMatch="true" AutoPostBack="true" OnTextChanged="rcbRevenueType_TextChanged" OnSelectedIndexChanged="rcbRevenueType_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>
                       <%--<telerik:RadComboBox ID="rcbRevenueType" runat="server" Skin="Glow" AutoPostBack="true" OnTextChanged="rcbRevenueType_TextChanged" OnSelectedIndexChanged="rcbRevenueType_SelectedIndexChanged"></telerik:RadComboBox>--%>

                       <%--<telerik:RadComboBox ID="rdcArea" runat="server" Width="200px" Skin="Glow" AutoPostBack="true" OnSelectedIndexChanged="rdcArea_SelectedIndexChanged"></telerik:RadComboBox>--%>
                       <telerik:RadComboBox ID="rdcArea" runat="server" Skin="Glow" Width="180px" 
                        AppendDataBoundItems="true" EnableTextSelection="true" 
                        AutoCompleteSeparator="None" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rdcArea_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>
                       <%--<telerik:RadComboBox ID="rcbName" Skin="Glow" Height="200px" runat="server" AutoPostBack="true"></telerik:RadComboBox>--%>
                       <telerik:RadComboBox ID="rcbName" runat="server" Skin="Glow" Width="180px" 
                        AppendDataBoundItems="true" EnableTextSelection="true" 
                        AutoCompleteSeparator="None" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>


                       <%--<telerik:RadComboBox ID="rcbAwbSeries" Skin="Glow" Width="150px" Height="200px" runat="server" AutoPostBack="true"></telerik:RadComboBox>--%>
                        <telerik:RadComboBox ID="rcbAwbSeries" runat="server" Skin="Glow" Width="180px" 
                        AppendDataBoundItems="true" EnableTextSelection="true" 
                        AutoCompleteSeparator="None" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>
                      <telerik:RadButton ID="btnSearchEmployee" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearch_Click"></telerik:RadButton>
                </div>
               </div>
               <br />
               
               <div class="row">

                   <telerik:RadGrid runat="server" Skin="Glow" 
                    ID="radGridAwbSeriesMonitoring"
                    AllowPaging="True" 
                    PageSize="10"  
                    AllowFilteringByColumn="True" 
                    AutoGenerateColumns="false"
                    AllowSorting="true"
                    OnNeedDataSource="radGridAwbSeriesMonitoring_NeedDataSource">
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                       <ExportSettings HideStructureColumns="true" ExportOnlyData="true" IgnorePaging="true" UseItemStyles="false" FileName="AWBSeriesMonitoring" Pdf-PageLeftMargin="20px" Pdf-PageRightMargin="20px"> 
                        <Pdf ForceTextWrap="true" PageWidth="397mm" PageHeight="210mm" BorderColor="Black" 
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="100px">
                          <PageHeader>
                              <MiddleCell  Text="<img src='../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center" />
                          </PageHeader>
                        </Pdf>
                        <Excel  Format="Xlsx"/>
                    </ExportSettings>      

                        <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                            <CommandItemSettings ShowExportToExcelButton="false" ShowExportToPdfButton="true" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>
                            
                            <Columns>
                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="AirwayBillNo" HeaderText="AWB"></telerik:GridBoundColumn>

                                <telerik:GridDateTimeColumn
                                 DataField="CreatedDate" HeaderText="Date" SortExpression="CreatedDate" AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DatePicker"  DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" UniqueName="CreatedDate" FilterControlWidth="100px">
                             </telerik:GridDateTimeColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="BranchCorpOfficeName" HeaderText="BCO"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="Area" HeaderText="Area"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="Shipper" HeaderText="Shipper"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="DestinationCity" HeaderText="Destination"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="PaymentModeName" HeaderText="Payment Mode"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="TotalAmount" HeaderText="Amount"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="EncodedBy" HeaderText="Encoded By"></telerik:GridBoundColumn>


                            </Columns>
                           
                        </MasterTableView>
                    </telerik:RadGrid><!--RadGrid - radGridAwbIssuance-->
                   <br />
               </div><!--row-->
        </telerik:RadAjaxPanel>
               <telerik:RadCodeBlock runat="server">
                   <script type="text/javascript">
                            function onRequestStart(sender, args) {
                                if (args.get_eventTarget().indexOf("Button") >= 0) {
                                    args.set_enableAjax(false);
                                }
                            }

                        
                    </script>

                </telerik:RadCodeBlock>
           </div><!--container-->
       </div><!--page-wrapper-->
   </div><!--wrapper-->        

</asp:Content>
