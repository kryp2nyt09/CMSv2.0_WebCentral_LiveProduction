<%@ Page Title="AWB Tracking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AWBTracking.aspx.cs" Inherits="CMSVersion2.Shipment.AWBTracking" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="wrapper">
       <div id="page-wrapper">
           <div class="container">
               <!-- Page Heading -->
               <div class="row">
                   <div class="col-lg-12">
                       <h3>Dashboard</h3>
                      <%-- <ol class="breadcrumb">
                           <li>Dashboard</li>
                            <li class="active">Dashboard</li>
                       </ol><!--breadcrumb-->--%>
                       <hr />
                   </div>
               </div><!--row-->
               
               <div class="row">
                   <div class="col-md-12">
                       <telerik:RadLabel ID="lblAwbNo" runat="server" Text="Airway Bill:"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtAwbNo" runat="server" Width="230px" RenderMode="Mobile" Enabled="true"></telerik:RadTextBox>
                        <telerik:RadButton ID="btnSearchAwbNo" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearch_Click"></telerik:RadButton>
                    </div>
               </div>
               <br />

               <div class="row">
                   <div class="col-md-12">
                   <div class="col-md-4">
                        <telerik:RadLabel ID="lblAwb" runat="server" Text="Airway Bill:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtAwb" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="lblDate" runat="server" Text="Date:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtDate" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="lblOrigin" runat="server" Text="Origin:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtOrigin" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblDestination" runat="server" Text="Destination:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtDestination" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblShipper" runat="server" Text="Shipper:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtShipper" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblConsignee" runat="server" Text="Consignee:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtConsignee" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                       
                    </div>
                   <div class="col-md-4">
                      <telerik:RadLabel ID="lblCommodity" runat="server" Text="Commodity:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtCommodity" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblDesc" runat="server" Text="Description:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtDesc" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblServiceType" runat="server" Text="Service Type:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtServiceType" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblShipMode" runat="server" Text="ShipMode:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtShipMode" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblAddress1" runat="server" Text="Address:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtAddress1" runat="server" Width="230px" TextMode="MultiLine" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblAddress2" runat="server" Text="Address:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtAddress2" runat="server" Width="230px" TextMode="MultiLine" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                       
                    </div>

                   <div class="col-md-4">
                      <telerik:RadLabel ID="lblQuantity" runat="server" Text="Quantity:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtQuantity" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblWeight" runat="server" Text="Weight:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtWeight" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                        <br /><br />

                        <telerik:RadLabel ID="lblDimension" runat="server" Text="Dimension:" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox ID="txtDimension" runat="server" Width="230px" Enabled="false" Skin="Glow"></telerik:RadTextBox>
                    </div>
                 </div>
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

               <%--<div class="row">--%>



                   <telerik:RadGrid runat="server" Skin="Glow" 
                    ID="radGridAwbNo"
                    AllowPaging="True" 
                    PageSize="10"  
                    AllowFilteringByColumn="True" 
                    AutoGenerateColumns="false"
                    AllowSorting="true"
                   OnItemCreated="radGridAwbNo_ItemCreated">
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

                        <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller"
                            DataKeyNames="Id"
                            ClientDataKeyNames="Id">
                            <CommandItemSettings ShowExportToExcelButton="false" ShowExportToPdfButton="false" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>
                            
                            <Columns>
                                
                               <%-- <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="Id" HeaderText="Id" ReadOnly="True"
                                SortExpression="Id" UniqueName="Id"></telerik:GridBoundColumn>--%>

                                <telerik:GridDateTimeColumn
                                 DataField="dateandtime" HeaderText="Date and Time" SortExpression="dateandtime" AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DatePicker"  DataFormatString="{0:MM/dd/yyyy HH:mm:ss}" DataType="System.DateTime" UniqueName="dateandtime" FilterControlWidth="100px">
                             </telerik:GridDateTimeColumn>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="statusofAwb" HeaderText="Status" UniqueName="statusofAwb" SortExpression="statusofAwb"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="location" HeaderText="Location" UniqueName="location" SortExpression="location"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="arrivedPcs" HeaderText="Arrived Pcs" UniqueName="arrivedPcs" SortExpression="arrivedPcs"></telerik:GridBoundColumn>

                               <%-- <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="cargo" HeaderText="Cargo"></telerik:GridBoundColumn>--%>

                                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" HeaderText="Cargo" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="viewCargoLink" runat="server" Text="View Cargo"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                               <%-- <telerik:GridHyperLinkColumn UniqueName="HyperLinkCargo"
                                     HeaderText="Cargo" Text="View Cargo">
                                    </telerik:GridHyperLinkColumn>--%>

                                <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="receivedBy" HeaderText="Received By" UniqueName="receivedBy" SortExpression="receivedBy"></telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                  DataField="remarks" HeaderText="Remarks" UniqueName="remarks" SortExpression="remarks"></telerik:GridBoundColumn>

                            </Columns>
                           
                        </MasterTableView>
                       <ClientSettings EnablePostBackOnRowClick="true">
                                <Selecting AllowRowSelect="true"></Selecting>
                                <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                            </ClientSettings>
                    </telerik:RadGrid><!--RadGrid --->
                   <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
                            <Windows>
                               <telerik:RadWindow RenderMode="Mobile" ID="ViewCargoList" runat="server" Title="Cargo" Height="400px"
                                    Width="400px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar="false" AutoSize="false"
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

                            function ShowCargo(id, rowIndex) {
                                var grid = $find("<%= radGridAwbNo.ClientID %>");
                                //var awbNo = document.getElementById("txtAwbNo").value;

                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                    grid.get_masterTableView().selectItem(rowControl, true);

                                    window.radopen("AWBTrackingModal/ViewCargo.aspx?Id=" + id, "ViewCargoList");
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
                            window.radopen("AWBTrackingModal/ViewCargo.aspx?Id=" + eventArgs.getDataKeyValue("Id"), "ViewCargoList");
                                    }
                        </script>


                    </telerik:RadCodeBlock>
                     </telerik:LayoutColumn>
                   <br />
              <%-- </div><!--row-->--%>
           </div><!--container-->
       </div><!--page-wrapper-->
   </div><!--wrapper-->        
</asp:Content>
