<%@ Page Title="Payment Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentSummaryReport.aspx.cs" Inherits="CMSVersion2.Report.Operation.Manifest.PaymentSummaryReport" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper">
        <div class="page-wrapper">
            <div class="container">
                <div class="row">
                    <h3>PAYMENT SUMMARY REPORT</h3>
                    <ol class="breadcrumb">
                        <li>Operation</li>
                        <li>Manifest</li>
                        <li>Payment Summary Report</li>
                    </ol>
                </div><!--row-->
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    
                    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>
                    <div class="row">
                        <telerik:RadLabel runat="server" Text="Collection Date:"></telerik:RadLabel>
                        <telerik:RadDatePicker ID="rdpCollectionDate" runat="server" AutoPostBack="true" Skin="Glow" DateInput-DateFormat="MM/dd/yyyy">
                        </telerik:RadDatePicker>

                        <telerik:RadLabel runat="server" Text="BCO:"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbBco" runat="server" Skin="Glow" Width="220px" 
                            AppendDataBoundItems="true" EnableTextSelection="true" 
                            AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadLabel ID="lblType" runat="server" Text="Rev. Unit Type:"></telerik:RadLabel>
                         <telerik:RadComboBox ID="rcbRevenueUnitType" runat="server" Skin="Glow" EnableTextSelection="true"
                            AppendDataBoundItems="true" AutoPostBack="true" MarkFirstMatch="true"    
                            AutoCompleteSeparator="" AllowCustomText="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadLabel runat="server" Text="Revenue Unit:"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbArea" runat="server" Skin="Glow" EnableTextSelection="true"
                            AppendDataBoundItems="true" AutoPostBack="true" MarkFirstMatch="true"    
                            AutoCompleteSeparator="" AllowCustomText="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadButton ID="Search" runat="server" Text="Search" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"> </telerik:RadButton>
                    </div><!--row-->
                    <br />
                    <div class="row">
                        <telerik:RadGrid ID="radGridPaymentSummary" runat="server" Skin="Glow"
                            AllowPaging="True" ClientSettings-EnablePostBackOnRowClick="true"
                            PageSize="20"
                            AllowFilteringByColumn="false" 
                            AutoGenerateColumns="false" OnNeedDataSource="radGridPaymentSummary_NeedDataSource" OnPreRender="radGridPaymentSummary_PreRender" 
                            OnItemCommand="radGridPaymentSummary_ItemCommand">

                             <MasterTableView CommandItemDisplay="Top" FilterItemStyle-VerticalAlign="Top" Font-Size="Smaller">
                                  
                                 <CommandItemSettings ShowExportToExcelButton="false" 
                                    ShowExportToPdfButton="false" ExportToPdfText="PDF" 
                                    ShowExportToWordButton="false" ShowExportToCsvButton="false" 
                                    ShowAddNewRecordButton="false"  ShowRefreshButton="false" />

                                    <FilterItemStyle VerticalAlign="Top" />

                                 <Columns>
                                      <%--<telerik:GridBoundColumn UniqueName="RowNumber" Visible="false"></telerik:GridBoundColumn> --%>
                                      <telerik:GridBoundColumn HeaderText="Collection Date" DataField="CollectionDate" DataFormatString="{0:MM/dd/yyyy}" ></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn HeaderText="BCO" DataField="BranchCorpOfficeName"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn HeaderText="Revenue Type" DataField="RevenueUnitTypeName" ></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn HeaderText="Revenue Unit" DataField="RevenueUnitName" ></telerik:GridBoundColumn>
                                      <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" AllowFiltering="false" Exportable="false">
                                            <ItemTemplate>
                                               <%-- <asp:HyperLink  ID="PrintLink" runat="server" Text="Print"></asp:HyperLink>--%>
                                                 <telerik:RadButton ID="btnPrint" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" CommandName="PsPrint"> </telerik:RadButton>
                                            </ItemTemplate>
                                      </telerik:GridTemplateColumn>

                                 </Columns>
                                 
                             </MasterTableView>

                        </telerik:RadGrid>
                    </div>
                </telerik:RadAjaxPanel>
                <telerik:RadCodeBlock runat="server">
                    <script type="text/javascript">
                         function Clicking(sender, args)
                        {
                            args.set_cancel(!window.confirm("Are you sure you want to submit the page?"));
                        }
                    </script>
                </telerik:RadCodeBlock>
            </div><!--container-->
        </div><!--page-wrapper-->
    </div><!--wrapper-->
</asp:Content>
