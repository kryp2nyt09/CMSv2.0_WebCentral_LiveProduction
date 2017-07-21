<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="CMSVersion2.Report.Finance.Collection" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="wrapper">
    <div id="page-wrapper"> 
         <div class="container">
             <!--- PAGE HEADER --->
             <div class="row">
                <h3>COLLECTION</h3>
                <ol class="breadcrumb">
                    <li>Finance</li>
                    <li>Collection</li>
                </ol>
             </div>
            <!--- PAGE BODY --->
             <div class="row">
                <telerik:RadLabel ID="RadLabel1" runat="server" Text="Date:"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date1" runat="server" Skin="Glow"></telerik:RadDatePicker>
                <telerik:RadLabel runat="server" Text="-"></telerik:RadLabel>
                <telerik:RadDatePicker ID="Date2" runat="server" Skin="Glow"></telerik:RadDatePicker>
                &nbsp;&nbsp;&nbsp;
                 <telerik:RadLabel ID="bcolabel" runat="server" Text="BCO Code:"></telerik:RadLabel>
                 <telerik:RadComboBox ID="BCO" runat="server" Skin="Glow" AppendDataBoundItems="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
                 <telerik:RadLabel ID="RadLabel2" runat="server" Text="Revenue Type:"></telerik:RadLabel>
                 <telerik:RadComboBox ID="REVENUETYPE" runat="server" Skin="Glow" AppendDataBoundItems="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="All" Value="0" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
                 &nbsp;&nbsp;
                <telerik:RadButton ID="Search" Text="Search" runat="server" Skin="Glow" AutoPostBack="true" OnClick="Search_Click"></telerik:RadButton>
                   
            </div>
            <br />

             <div class="row" >
                <telerik:RadGrid ID="grid_Collection" runat="server"  Skin="Glow" EnableLinqExpressions="false"
                    AllowPaging="True" 
                    PageSize="10" ShowFooter="true"
                    AllowFilteringByColumn="false"
                    AutoGenerateColumns="false "
                    AllowSorting="true" OnNeedDataSource="grid_Collection_NeedDataSource">
                    
                    <ExportSettings HideStructureColumns="true" ExportOnlyData="true" 
                        IgnorePaging="true" FileName="Collection"
                         UseItemStyles="true">
                        <Pdf Title="Branch Acceptance" PageHeaderMargin="10px" PageRightMargin="30px" PageLeftMargin="30px"
                             PageTopMargin="150px" BorderType="AllBorders" PageTitle="Collection Report" 
                             BorderStyle="Thin" DefaultFontFamily="Calibri">
                            <PageHeader>
                              <MiddleCell  Text="<img src='../../images/APCARGO-Logo.jpg' width='100%' height='100%'/>"/>
                          </PageHeader>
                        </Pdf>
                    </ExportSettings>          
                    <MasterTableView CommandItemDisplay="Top" Font-Size="Smaller" ShowGroupFooter="true">
                        <CommandItemSettings ShowExportToExcelButton="true" 
                             ShowExportToPdfButton="true" ShowExportToWordButton="false"
                             ShowExportToCsvButton="false" ShowAddNewRecordButton="false"  
                             ShowRefreshButton="false" />
                        <Columns>
                             <telerik:GridBoundColumn DataField="BCO" HeaderText="BCO" FooterText="TOTAL : " Aggregate="Custom"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Revenue Unit" HeaderText="REVENUE UNIT"></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="Revenue Type" HeaderText="REVENUE TYPE"></telerik:GridBoundColumn>
                            
                             <telerik:GridCalculatedColumn HeaderText="TOTAL AMOUNT" DataType="System.Double"
                                DataFields="CASHAMOUNT, CHECKAMOUNT" Expression="{0}+{1}" FooterText=" "
                                Aggregate="Sum" >
                            </telerik:GridCalculatedColumn>

                             <telerik:GridBoundColumn DataField="CASHAMOUNT" HeaderText="CASH "></telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="CHECKAMOUNT" HeaderText="CHECK"></telerik:GridBoundColumn>

                             <telerik:GridBoundColumn DataField="TaxWithHeld" HeaderText="TAX WITH HELD"></telerik:GridBoundColumn>

                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
            </div>
         </div>
    </div>
</div>
</asp:Content>
