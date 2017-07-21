<%@ Page Title="Grand Manifest" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GrandManifest.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.GrandManifest" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
    .rgExpXLS
    {
        float: left !important;
        margin-right: 1900px !important;
    } 
    .RadGrid_SkinName .rgCommandRow
    {
        color: Transparent !important;
    }
</style>

    <div class="wrapper">
        <div class="page-wrapper">
            <div class="container">
                <!--- PAGE HEADER--->
                <div class="row">
                    <h3>GRAND MANIFEST</h3>
                    <ol class="breadcrumb">
                        <li>Operation</li>
                        <li>Manifest</li>
                        <li>Grand Manifest</li>
                    </ol>
                </div><!--row-->

                 <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

                    <div class="row">
                        <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                        <telerik:RadDatePicker ID="DateFrom" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy"></telerik:RadDatePicker>                
              
                        <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                        <telerik:RadDatePicker ID="DateTo" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy"></telerik:RadDatePicker>                
               
                         <telerik:RadLabel runat="server" Text="Origin BCO:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbOriginBco" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadLabel runat="server" Text="Dest BCO:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbDestinationBco" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                    </div><!--row-->
                    <br />
                    <div class="row">

                        <telerik:RadLabel runat="server" Text="Service Mode:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbServiceMode" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>


                        <telerik:RadLabel runat="server" Text="Payment Mode:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbPaymentMode" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadLabel runat="server" Text="Service Type:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbServiceType" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>
                    </div>

                    <br />
                    <div class="row">
                         <telerik:RadLabel runat="server" Text="Ship Mode:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbShipMode" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadButton ID="btnSearch" runat="server" Text="Search" Skin="Glow" AutoPostBack="true" OnClick="btnSearch_Click"> </telerik:RadButton>
                        <telerik:RadButton ID="btnPrint" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="btnPrint_Click"> </telerik:RadButton>
                        <%--<telerik:RadButton ID="btnExport" runat="server" Text="Export" Skin="Glow" AutoPostBack="true" OnClick="btnExport_Click"> </telerik:RadButton>--%>
                    </div>

                    <br />
                    <div class="row">
                        <telerik:RadGrid ID="radGridGrandManifest" runat="server" Skin="Glow"
                            AllowPaging="True" ShowFooter="true"
                            PageSize="20"
                            AllowFilteringByColumn="false" 
                            ClientSettings-Scrolling-AllowScroll="true"
                            AutoGenerateColumns="false" 
                            OnNeedDataSource="radGridGrandManifest_NeedDataSource" 
                            OnPreRender="radGridGrandManifest_PreRender" 
                            OnItemCommand="radGridGrandManifest_ItemCommand" 
                           >
                        
                            <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller">
                            <CommandItemSettings ShowExportToExcelButton="true" 
                                    ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                                    ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                                    ShowAddNewRecordButton="false"  ShowRefreshButton="false" />

                            <FilterItemStyle VerticalAlign="Top" />
                             <Columns>

                                   <telerik:GridBoundColumn HeaderText="AirwayBillNo" DataField="AirwayBillNo" DataFormatString="&nbsp;{0}" FooterText="TOTAL: " ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Date Accepted" DataField="DateAccepted" DataFormatString="{0:MMM dd,yyyy}"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Shipper Name" DataField="ShipperName" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Origin BCO" DataField="OriginBCO" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Shipper Address" DataField="ShipperAddress" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Origin City" DataField="OriginCity" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Consignee Name" DataField="ConsigneeName" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Consignee Address" DataField="ConsigneeAddress"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Destination BCO" DataField="DestinationBCO" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Destination City" DataField="DestinationCity" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity" FooterText=" " Aggregate="Sum"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Total Amount" DataField="TotalAmount" FooterText=" " Aggregate="Sum"></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Service Mode" DataField="ServiceModeName" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Payment Mode" DataField="PaymentModeName" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Accepted By" DataField="AcceptedBy" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Assignment" DataField="Assignment" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Booking Area" DataField="BookingArea" ></telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="BookedBy" DataField="BookedBy" ></telerik:GridBoundColumn>
                             </Columns>


                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </telerik:RadAjaxPanel>
            </div><!--container-->
        </div><!--page wrapper-->
    </div><!--wrapper-->
</asp:Content>
