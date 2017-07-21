<%@ Page Title="Segregation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Segregation.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Segregation" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>SEGREGATION</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>  
                    <li>Manifest</li>
                    <li>Segregation</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow2" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

             
            

            <div class="row">
                <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Glow" AutoPostBack="true"></telerik:RadDatePicker>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Destination BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDestinationBCO" runat="server" MarkFirstMatch="true" 
                    AllowCustomText="true" Width="200px"
                    Skin="Glow" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Origin BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbOriginBco" runat="server" MarkFirstMatch="true" 
                    AllowCustomText="true" Width="200px"
                    Skin="Glow" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;
             </div>
                <br />
                <div class="row">
                <telerik:RadLabel runat="server" Text="Driver:" AutoPostBack="true"></telerik:RadLabel>
                <telerik:RadComboBox ID="Driver" runat="server" MarkFirstMatch="true" AllowCustomText="true" Width="150px"
                    Skin="Glow" AppendDataBoundItems="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Plate #:"></telerik:RadLabel>
                <telerik:RadComboBox ID="PlateNo" runat="server" MarkFirstMatch="true" AllowCustomText="true"
                Skin="Glow" AppendDataBoundItems="true">
                    <Items>
                    <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;

             
                <telerik:RadLabel runat="server" Text="Batch:" AutoPostBack="true"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbBatch" runat="server" MarkFirstMatch="true" AllowCustomText="true" Width="150px"
                    Skin="Glow" AppendDataBoundItems="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"> </telerik:RadButton>
                <telerik:RadButton ID="Print" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="Print_Click"> </telerik:RadButton>

            </div>
            <br />
            <div class="row">
                <telerik:RadGrid ID="grid_Segregation" runat="server" Skin="Glow" 
                    AllowPaging="True" ShowFooter="true" 
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="false"
                    AllowSorting="true"
                    PageSize="10"  OnPreRender="grid_Segregation_PreRender"
                    OnNeedDataSource="grid_Segregation_NeedDataSource">
                <ExportSettings HideStructureColumns="true" FileName="Segregation" 
                    ExportOnlyData="true" IgnorePaging="true" UseItemStyles="true">
                    <Pdf Title="Segregation" PageTitle="Segregation Report" 
                        PageHeaderMargin="10px" PageTopMargin="140px" BorderType="AllBorders" 
                        BorderStyle="Thin" DefaultFontFamily="Calibri">
                            <PageHeader>
                              <MiddleCell TextAlign="Center"  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>"/>
                          </PageHeader>
                        </Pdf>
                </ExportSettings>          
                    <MasterTableView CommandItemDisplay="Top" Width="100%" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                        <Columns>
                             <telerik:GridBoundColumn DataField="No" HeaderText="#" HeaderStyle-Width="20px"></telerik:GridBoundColumn>                            
                             <telerik:GridBoundColumn DataField="AirwayBillNo" HeaderText="Airway Bill No" FooterText="TOTAL: " ></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Driver" HeaderText="Driver" Exportable="false"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Checker" HeaderText="Checker" Exportable="false"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="PlateNo" HeaderText="Plate #" Exportable="false"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="BatchName" HeaderText="Batch" Exportable="false"></telerik:GridBoundColumn> 
                             <telerik:GridBoundColumn DataField="Qty" HeaderText="Qty" FooterText=" " Aggregate="Sum"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Area" HeaderText="Area(City)"></telerik:GridBoundColumn>
                             <%--<telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="Scanned By"></telerik:GridBoundColumn>--%>

                        </Columns>
                        <HeaderStyle Font-Size="Smaller" Font-Bold="true" />
                        <FooterStyle Font-Bold="true" />
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
</telerik:RadAjaxPanel>
        </div>
    </div>
</div>   
</asp:Content>
