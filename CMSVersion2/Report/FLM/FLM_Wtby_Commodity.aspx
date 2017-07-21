<%@ Page Title="Wt by Commodity" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FLM_Wtby_Commodity.aspx.cs" Inherits="CMSVersion2.Report.FLM.FLM_Wtby_Commodity" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>Weight by Commodity Type</h3>
                <ol class="breadcrumb">
                    <li>FLM</li>
                    <li>Weight by Commodity Type</li>
                </ol>
            </div>
            <!--- PAGE BODY--->

             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

            <div class="row">
                <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true">
                </telerik:RadDatePicker>

                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Glow" AutoPostBack="true">
                </telerik:RadDatePicker>

                &nbsp;&nbsp;


                <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true" 
                    AppendDataBoundItems="true" Width="260px" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadButton ID="Search" runat="server" Text="Search" OnClick="Search_Click" 
                    Skin="Glow" AutoPostBack="true"> </telerik:RadButton>

                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click"
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
                
            </div>            
            <br />

            <div class="row">
                
                <telerik:RadGrid ID="grid_QtyByCommodity" runat="server" Skin="Glow" 
                    AllowPaging="True" ShowFooter="true" 
                    PageSize="10" OnNeedDataSource="grid_QtyByCommodity_NeedDataSource"
                    AllowFilteringByColumn="false" OnPreRender="grid_QtyByCommodity_PreRender"
                    AutoGenerateColumns="false" FooterStyle-HorizontalAlign="Right"                    
                    AllowSorting="true">

                    <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller" HeaderStyle-HorizontalAlign="Right"  FooterStyle-HorizontalAlign="Right">
                        <CommandItemSettings ShowExportToExcelButton="true" 
                            ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                       
                        <Columns>
                           <telerik:GridBoundColumn DataField="CityName" HeaderText="Destination" FooterText="Total: "></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="General1Cargo" HeaderText="General Cargo" Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Valuable1Cargo" HeaderText="Valuable Cargo" Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Dangerous1Cargo" HeaderText="Dangerous Cargo"  Aggregate="Sum" FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Perishable1Cargo" HeaderText="Perishable Cargo" Aggregate="Sum"   FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Courier1_1SAP" HeaderText="Courier - SAP" Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Courier1_1MAP" HeaderText="Courier - MAP"  Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Courier1_1LAP" HeaderText="Courier - LAP" Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Courier1_1NSAP" HeaderText="Courier - NSAP" Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Courier1_1NMAP" HeaderText="Courier - NMAP" Aggregate="Sum"  FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Courier1_1NLAP" HeaderText="Courier - NLAP" Aggregate="Sum"   FooterText=" " ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                            <telerik:GridCalculatedColumn HeaderText="TOTAL" DataType="System.Double" DataFields="General1Cargo,Valuable1Cargo,Dangerous1Cargo,Perishable1Cargo,Courier1_1SAP,Courier1_1MAP,Courier1_1LAP,Courier1_1NSAP,Courier1_1NMAP,Courier1_1NLAP" Expression="{0}+{1}+{2}+{3}+{4}+{5}+{6}+{7}+{8}+{9}" FooterText=" " Aggregate="Sum" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridCalculatedColumn>
                            
                        </Columns>
                        <HeaderStyle Font-Size="Smaller" Font-Bold="true"/>
                        <FooterStyle Font-Bold="true"/>
                        
                     
                    </MasterTableView>
                </telerik:RadGrid> 
                <br />
            </div>
        </telerik:RadAjaxPanel>
        </div>
    </div>
</div>
</asp:Content>
