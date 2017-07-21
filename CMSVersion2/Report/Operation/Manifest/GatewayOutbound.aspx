<%@ Page Title="Gateway Outbound" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GatewayOutbound.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.GatewayOutbound" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("Are you sure you want to submit the page?"));
        }

        function RefreshParentPage()//function in parent page
        {
            document.location.reload();
        }
    </script>

    <style>
        div.RadUpload .ruBrowse {
            background-position: 0 -23px;
            width: 180px;
            height: 30px;
        }

        div.RadUpload_Default .ruFileWrap .ruButtonHover {
            background-position: 100% -23px !important;
        }
    </style>


<div class="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!--- PAGE HEADER--->
            <div class="row">
                <h3>GATEWAY OUTBOUND</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>
                    <li>Gateway Outbound</li>
                </ol>
            </div>
            <!--- PAGE BODY--->
             <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
             <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow2" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
           
            

            <div class="row">

                <telerik:RadLabel runat="server" Text="Date From:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date" runat="server" OnSelectedDateChanged="Date_SelectedDateChanged"
                    AutoPostBack="true" Width="115px" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                </telerik:RadDatePicker>                
                &nbsp;&nbsp;

                  <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server"
                    AutoPostBack="true" Width="130px" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                </telerik:RadDatePicker>                
                &nbsp;&nbsp;

                   <telerik:RadLabel runat="server" Text="Origin BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" Width="250px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                 <telerik:RadLabel runat="server" Text="Destination BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDestBco" runat="server" Skin="Glow" Width="250px" 
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
                 <telerik:RadLabel runat="server" Text="Driver:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDriver" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" Width="200px" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Gateway"></telerik:RadLabel>
                <telerik:RadComboBox ID="Gateway" runat="server" Skin="Glow" AutoPostBack="true"
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true"
                    AppendDataBoundItems="true">
                     <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>

                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Batch:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Batch" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" Width="115px" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                
                 <telerik:RadLabel runat="server" Text="Commodity Type:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbCommodityType" runat="server" Skin="Glow" EnableTextSelection="true"
                    AppendDataBoundItems="true" Width="200px" AutoPostBack="true" MarkFirstMatch="true"    
                    AutoCompleteSeparator="" AllowCustomText="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;
               
            </div>
             <br />
            <div class="row">
                <telerik:RadLabel ID="lblAwb" runat="server" Text="MAWB:"></telerik:RadLabel>
                <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtMawb" Enabled="True" runat="server"></telerik:RadTextBox>

                <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" OnClick="Search_Click" AutoPostBack="true"> </telerik:RadButton>
                <telerik:RadButton ID="Print" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="Print_Click1"> </telerik:RadButton>

            </div>
            <br />
            <div class="row">
                <telerik:RadGrid ID="gridGatewayOutbound" runat="server"  Skin="Glow"
                    AllowPaging="True" OnPreRender="gridGatewayOutbound_PreRender"
                    PageSize="10" OnNeedDataSource="gridGatewayOutbound_NeedDataSource1"   
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="true"
                    AllowSorting="true" 
                    ExportSettings-Pdf-ForceTextWrap="false"                     
                    ClientSettings-Scrolling-AllowScroll="true"                   
                    ItemStyle-Wrap="false" 
                    Height="400px">

                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="false" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false"/>


                    </MasterTableView>
                </telerik:RadGrid>
                <br />              
            </div>
        </telerik:RadAjaxPanel>
        </div>
    </div>
</div>
</asp:Content>

