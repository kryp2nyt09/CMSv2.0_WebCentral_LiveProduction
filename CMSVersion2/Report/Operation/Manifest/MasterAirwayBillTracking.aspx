<%@ Page Title="Master Airway Bill Tracking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MasterAirwayBillTracking.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.MasterAirwayBillTracking" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
        <div class="page-wrapper">
            <div class="container">
                <!--- PAGE HEADER--->
                <div class="row">
                    <h3>MASTER AIRWAY BILL TRACKING</h3>
                    <ol class="breadcrumb">
                        <li>Operation</li>
                        <li>Manifest</li>
                        <li>Master Airway Bill Tracking</li>
                    </ol>
                </div><!--row-->
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div class="row">
                        <div class="col-md-12">
                            <telerik:RadLabel ID="lblMawb" runat="server" Text="Master Airway Bill:" Font-Bold="true"></telerik:RadLabel>
                            <telerik:RadTextBox ID="txtMawb" runat="server" Width="230px"></telerik:RadTextBox>
                            <telerik:RadButton ID="btnSearchMawb" runat="server" Skin="Glow" Text="SEARCH" OnClick="btnSearchMawb_Click"></telerik:RadButton>
                        </div>
                    </div><!--row-->
                    <br />
                    <div class="row">
                        <telerik:RadGrid ID="radGridMawb" runat="server" Skin="Glow"
                            AllowPaging="True"
                            PageSize="20"
                            AllowFilteringByColumn="false" 
                            AutoGenerateColumns="false" OnNeedDataSource="radGridMawb_NeedDataSource" OnPreRender="radGridMawb_PreRender">
                            
                            <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller">
                                
                                <CommandItemSettings ShowExportToExcelButton="false" 
                                    ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                                    ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                                    ShowAddNewRecordButton="false"  ShowRefreshButton="false" />

                                <FilterItemStyle VerticalAlign="Top" />

                                <Columns>

                                   <telerik:GridBoundColumn HeaderText="MAWB" DataField="MasterAirwayBillNo" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="GW Transmittal Date" DataField="TransmittalDate" DataFormatString="{0:MMM dd,yyyy}"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Airlines" DataField="AirlinesTransmittal" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Flight Number" DataField="FlightNumberTransmittal" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Scanned By" DataField="ScannedByTransmittal" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Destination BCO" DataField="DestinationBCO" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Commodity Type" DataField="CommodityTypeName" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="GW Inbound Date" DataField="InboundDate" DataFormatString="{0:MMM dd,yyyy}"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="BCO" DataField="BranchCorpOfficeName" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Airlines" DataField="AirlinesInbound" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Flight Number" DataField="FlightNumberInbound" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Scanned By" DataField="ScannedByInbound" ></telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div><!--row-->
                </telerik:RadAjaxPanel>
            </div><!--container-->
        </div><!--page-wrapper-->
    </div><!--wrapper-->
</asp:Content>
