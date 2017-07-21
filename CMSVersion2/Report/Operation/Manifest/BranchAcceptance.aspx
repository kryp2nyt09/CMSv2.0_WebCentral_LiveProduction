<%@ Page Title="Branch Acceptance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BranchAcceptance.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.BranchAcceptance" %>
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
                <h3>BRANCH ACCEPTANCE</h3>
                <ol class="breadcrumb">
                    <li>Operation</li>
                    <li>Manifest</li>
                    <li>Branch Acceptance</li>
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
                <telerik:RadDatePicker ID="Date" runat="server" Skin="Glow" AutoPostBack="true">
                </telerik:RadDatePicker>

                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Date To:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Glow" AutoPostBack="true">
                </telerik:RadDatePicker>

                &nbsp;&nbsp;


                <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true" 
                    AppendDataBoundItems="true" Width="260px" AutoPostBack="true" OnSelectedIndexChanged="BCO_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadLabel runat="server" Text="Area:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Area" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true"
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                
            </div>
            <br />
            <div class="row">
                 <telerik:RadLabel runat="server" Text="Driver:"></telerik:RadLabel>
                <telerik:RadComboBox ID="rcbDriver" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true" 
                    AppendDataBoundItems="true" AutoPostBack="true">
                     <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;


                <telerik:RadLabel runat="server" Text="Batch:"></telerik:RadLabel>
                <telerik:RadComboBox ID="Batch" runat="server" Skin="Glow" AllowCustomText="true" MarkFirstMatch="true" 
                    AppendDataBoundItems="true" AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                &nbsp;&nbsp;

                <telerik:RadButton ID="Search" runat="server" Text="Search" 
                    Skin="Glow" AutoPostBack="true" OnClick="Search_Click"> </telerik:RadButton>

                <telerik:RadButton ID="btnPrint" Skin="Glow" OnClick="btnPrint_Click" 
                    runat="server" Text="PRINT" AutoPostBack="true"></telerik:RadButton>
            </div>
              <br />

            <div class="row">
                
                <telerik:RadGrid ID="grid_BranchAcceptance" runat="server" Skin="Glow"
                    AllowPaging="True" ShowFooter="true"
                    PageSize="10" OnPreRender="grid_BranchAcceptance_PreRender"
                    AllowFilteringByColumn="false" 
                    AutoGenerateColumns="false"                    
                    AllowSorting="true" 
                    OnNeedDataSource="grid_BranchAcceptance_NeedDataSource">

                    <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller">
                        <CommandItemSettings ShowExportToExcelButton="true" 
                            ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                            ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                            ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                        <FilterItemStyle VerticalAlign="Top" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="No" HeaderText="#" HeaderStyle-Width="20px"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AWBNO" HeaderText="AWB #" FooterText="TOTAL: "></telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="SCANNED QTY" HeaderText="SCANNED QTY"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DISCREPENCY QTY" HeaderText="DISCREPANCY QTY"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TOTAL QTY" HeaderText="TOTAL QTY" FooterText=" " Aggregate="Sum"></telerik:GridBoundColumn>

                             <telerik:GridBoundColumn DataField="DRIVER" HeaderText="DRIVER"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="CHECKER" HeaderText="CHECKER"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="BATCH" HeaderText="BATCH"></telerik:GridBoundColumn>
                            <%-- <telerik:GridBoundColumn DataField="CHECKER" HeaderText="CHECKER"></telerik:GridBoundColumn>--%>
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
