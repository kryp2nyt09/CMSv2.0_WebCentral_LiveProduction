<%@ Page Title="Bundle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bundle.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.Bundle" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>BUNDLE</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>   
                    <li>Bundle</li>
                </ol>
            </div>
             <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow2" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <!--- PAGE BODY--->
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

            

            <div class="row">
                <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true" OnSelectedDateChanged="Date_SelectedDateChanged"></telerik:RadDatePicker>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Glow" AutoPostBack="true" OnSelectedDateChanged="Date_SelectedDateChanged"></telerik:RadDatePicker>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" Width="200px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" 
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;


                 <telerik:RadLabel runat="server" Text="Dest BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDestBco" runat="server" Skin="Glow" Width="200px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" 
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                 



<%--                <telerik:RadLabel runat="server" Text="Destination(City):"></telerik:RadLabel>
                 <telerik:RadComboBox ID="Destination" runat="server" MarkFirstMatch="true" AllowCustomText="true"  AutoPostBack="true"
                     Skin="Glow" AppendDataBoundItems="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;--%>

               
            </div>
            <br />

            <div class="row">
               <%--   <telerik:RadLabel runat="server" Text="Sack #:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BundleNumber" runat="server" MarkFirstMatch="true" AllowCustomText="true"
                    Skin="Glow" AppendDataBoundItems="true">
                </telerik:RadComboBox>
                &nbsp;&nbsp;--%>

                 <telerik:RadLabel ID="lblAwb" runat="server" Text="Sack Number:"></telerik:RadLabel>
                <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtSackNumber" Enabled="True" runat="server"></telerik:RadTextBox>

                 <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"> </telerik:RadButton>
                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click" 
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>

            </div>
            <br />

            <div class="row">
                <telerik:RadGrid ID="grid_Bundle" runat="server" Skin="Glow"
                    OnNeedDataSource="grid_Bundle_NeedDataSource"
                    AllowPaging="True" 
                    PageSize="10"  
                    AllowFilteringByColumn="false" ShowFooter="true"
                    AutoGenerateColumns="false" OnPreRender="grid_Bundle_PreRender"
                    AllowSorting="true" ClientSettings-Scrolling-AllowScroll="true" Height="400">

                    <ExportSettings FileName="Bundle" HideStructureColumns="true" ExportOnlyData="true" 
                        IgnorePaging="true" UseItemStyles="true">
                        <Pdf ForceTextWrap="false" PageWidth="397mm" PageHeight="210mm" BorderColor="Black" 
                            DefaultFontFamily="Calibri"
                             BorderType="AllBorders" BorderStyle="Thin" PageHeaderMargin="10px" 
                             PageTopMargin="130px" PageTitle="Bundle Report">
                            <PageHeader>
                              <MiddleCell  Text="<img src='../../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>" TextAlign="Center"/>
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>
                    <MasterTableView CommandItemDisplay="Top" Width="100%" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ShowExportToWordButton="false" ShowExportToCsvButton="false" ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="No" HeaderText="#" ></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AWBNO" HeaderText="AWB #" FooterText="TOTAL: "></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="SACKNO" HeaderText="SACK #"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SHIPPER" HeaderText="SHIPPER"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONSIGNEE" HeaderText="CONSIGNEE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONSIGNEEADDRESS" HeaderText="CONSIGNEE ADDRESS"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COMMODITY" HeaderText="COMMODITY"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COMMODITYTYPE" HeaderText="COMMODITY TYPE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QTY" HeaderText="QTY" Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AGW" HeaderText="AGW" Aggregate="Sum" FooterText=" "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SERVICEMODE" HeaderText="SERVICE MODE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PAYMODE" HeaderText="PAY MODE"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SCANNEDBY" HeaderText="SCANNED BY"></telerik:GridBoundColumn>
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
