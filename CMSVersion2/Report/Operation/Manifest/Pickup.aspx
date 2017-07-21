<%@ Page Title="Pickup Cargo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pickup.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Pickup" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>PICK UP CARGO</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>
                    <li>Pickup Cargo</li>
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
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" Width="220px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Destination BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDestBco" runat="server" Skin="Glow" Width="220px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;


            </div>
            <br />
            <div class="row">
                 <telerik:RadLabel ID="lblType" runat="server" Text="Rev. Unit Type:"></telerik:RadLabel>
                 <telerik:RadComboBox ID="rcbRevenueUnitType" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true" OnSelectedIndexChanged="rcbRevenueUnitType_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                
                
             <%--   <telerik:RadComboBox ID="rcbRevenueUnitType" Skin="Glow" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbRevenueUnitType_SelectedIndexChanged">
                     <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>--%>

                <telerik:RadLabel runat="server" Text="Revenue Unit:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Area" runat="server" Skin="Glow" EnableTextSelection="true"
                   AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                 <telerik:RadLabel ID="lblAwb" runat="server" Text="AWB #:"></telerik:RadLabel>
                <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAwbNumber" Enabled="True" runat="server"></telerik:RadTextBox>

                 <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" OnClick="Search_Click" AutoPostBack="true"> </telerik:RadButton>
                <telerik:RadButton ID="Print" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="Print_Click"> </telerik:RadButton>

            </div>
             <br />
          
            <br />
            <div class="row">
                <telerik:RadGrid ID="gridPickupCargo" runat="server"  Skin="Glow"
                    AllowPaging="True"
                    PageSize="10"  
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="true"
                    AllowSorting="true" 
                    ExportSettings-Pdf-ForceTextWrap="false"                     
                    ClientSettings-Scrolling-AllowScroll="true"                    
                    ItemStyle-Wrap="false" 
                    Height="400px"
                    OnNeedDataSource="gridPickupCargo_NeedDataSource" 
                    OnPreRender="gridPickupCargo_PreRender">

                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="false" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>
                       <%-- <Columns>                           
                             <telerik:GridDateTimeColumn
                                 DataField="CreatedDate" HeaderText="Date" SortExpression="CreatedDate" AllowFiltering="true" FilterListOptions="VaryByDataType" Exportable="false"
                                 PickerType="DatePicker"  DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" UniqueName="CreatedDate" FilterControlWidth="80px">
                             </telerik:GridDateTimeColumn>

                             <telerik:GridBoundColumn FilterDelay="2000" ShowFilterIcon="false"
                                  CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" FilterControlWidth="60px"
                                  DataField="AirwayBillNo" HeaderText="Airway Bill No"></telerik:GridBoundColumn>--%>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />              
            </div>
        </telerik:RadAjaxPanel>
        </div>
    </div>
</div>
</asp:Content>
