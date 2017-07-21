<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyExportPreview.aspx.cs" Inherits="CMSVersion2.Corporate.Reports.CompanyExportPreview" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div>
            <script type="text/javascript">
                function CloseAndRebind(args) {
                    GetRadWindow().BrowserWindow.refreshGrid(args);
                    GetRadWindow().close();
                }

                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                    return oWindow;
                }

                function CancelEdit() {
                    GetRadWindow().close();
                }
            </script>
            <asp:ScriptManager ID="ScriptManager2" runat="server" />
            <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Vista" DecoratedControls="All" />
         
           <telerik:RadGrid RenderMode="Lightweight" ID="rdPreview" OnNeedDataSource="rdPreview_NeedDataSource" AllowSorting="True" Skin="Simple" MasterTableView-AllowSorting="false"
            AutoGenerateColumns="false" AllowPaging="True" PageSize="10" runat="server" OnItemCommand="rdPreview_ItemCommand">
            <ExportSettings HideStructureColumns="true" ExportOnlyData="true" IgnorePaging="true" UseItemStyles="true">
            </ExportSettings>
            <MasterTableView Width="100%" CommandItemDisplay="Top" >
                <CommandItemSettings ShowExportToExcelButton="true" ShowExportToPdfButton="true" ShowExportToWordButton="true" ShowExportToCsvButton="true" ShowAddNewRecordButton="false"  ShowRefreshButton="false" />
                    <Columns>

                      
                                        <telerik:GridBoundColumn DataField="AccountNo" HeaderText="Account No." SortExpression="AccountNo"
                                            UniqueName="AccountNo">
                                            <HeaderStyle />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridNumericColumn DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"
                                            UniqueName="CompanyName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                          <telerik:GridDateTimeColumn DataField="ApprovedDate" HeaderText="Approved Date" SortExpression="ApprovedDate"
                                            UniqueName="ApprovedDate" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                                            <HeaderStyle />
                                        </telerik:GridDateTimeColumn>

                                        <telerik:GridNumericColumn DataField="Stats" HeaderText="Status" SortExpression="Stats"
                                            UniqueName="Stats">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="MotherCompany" HeaderText="Mother Company" SortExpression="MotherCompany"
                                            UniqueName="MotherCompany">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>
                                        
                      
                    </Columns>
                   <ItemStyle BackColor="#DFDFDF" />
                <HeaderStyle BackColor="#FFFFFF" ForeColor="#767676" />
                <AlternatingItemStyle BackColor="#FFFFFF" />

                </MasterTableView>
             
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>
