<%@ Page Title="Booking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Booking" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
        <div id="page-wrapper">
            <div class="container">
                <!--- PAGE HEADER--->
                <div class="row">
                    <h3>BOOKING</h3>
                    <ol class="breadcrumb">
                        <li>Operation</li>
                        <li>Manifest</li>
                        <li>Booking</li>
                    </ol>
                </div>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                <!--- PAGE BODY--->
                <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

              


                <div class="row">
                    <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                    <telerik:RadDatePicker ID="Date" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                    </telerik:RadDatePicker>                
                    &nbsp;&nbsp;

                    <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                    <telerik:RadDatePicker ID="DateTo" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                    </telerik:RadDatePicker>                
                    &nbsp;&nbsp;

                    <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                    <telerik:RadComboBox ID="rcbBco" runat="server" Skin="Glow" Width="220px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                        </Items>
                    </telerik:RadComboBox>
                    &nbsp;&nbsp;

                     <telerik:RadLabel runat="server" Text="Status:"></telerik:RadLabel>
                    <telerik:RadComboBox ID="rcbStatus" runat="server" Skin="Glow" Width="150px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                        </Items>
                    </telerik:RadComboBox>
                    &nbsp;&nbsp;
                
                <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" OnClick="Search_Click" AutoPostBack="true"> </telerik:RadButton>
                <telerik:RadButton ID="Print" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="Print_Click"> </telerik:RadButton>


                </div>
                <br />
                <div class="row">
                    <telerik:RadGrid ID="gridBooking" runat="server" Skin="Glow"
                    AllowPaging="True"
                    PageSize="10"  
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="false"
                    AllowSorting="true" 
                    ExportSettings-Pdf-ForceTextWrap="false"                     
                    ClientSettings-Scrolling-AllowScroll="true"                    
                    ItemStyle-Wrap="false" 
                    Height="400px"
                    OnNeedDataSource="gridBooking_NeedDataSource" 
                    OnPreRender="gridBooking_PreRender">

                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="false" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>
                        <Columns>
                            <telerik:GridBoundColumn DataField="DateBooked" HeaderText="Booking Date"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BookingNo" HeaderText="Booking No"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Shipper" HeaderText="Shipper Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OriginCity" HeaderText="Origin City"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Consignee" HeaderText="Consignee Name"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DestinationCity" HeaderText="Destination City"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="BookedBy" HeaderText="Booked By"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AssignedToArea" HeaderText="Assigned To"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BookingStatus" HeaderText="Booking Status"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
</asp:Content>
