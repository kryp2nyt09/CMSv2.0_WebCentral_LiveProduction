<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="CMSVersion2.Maintenance.RateMatrix.RateMatrix.Import" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;//Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;//IE (and Moz az well)
            return oWindow;
        }

        function CloseOnReload() {
            //GetRadWindow().Close();
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;
        }

        function RefreshParentPage() {
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;

        }

        
    </script>
</head>
<body runat="server">
   
    <%--<asp:Button ID="Button4" Text="open the RadWindow from the server" runat="server" OnClick="Button4_Click" />--%>
    <form runat="server">
         <telerik:RadScriptManager runat="server" ID="ScriptManager"></telerik:RadScriptManager>
   <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" Height="300px" Width="350px">
    </telerik:RadWindow>
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container">
                <div class="buttons">
                    <br />
                  <%-- <label for="email" class="cols-sm-2 control-label">Commodity Type</label>--%>

                       <telerik:RadAsyncUpload Skin="Glow" runat="server" ID="RadAsyncUpload2" 
                                            HideFileInput="true" 
                                            AllowedFileExtensions=".xls,.xlsx"
                                            OnClientFilesUploaded="fileUploaded"
                                            OnFileUploaded="AsyncUpload1_FileUploaded"
                                            Localization-Select="Import File"
                                           InputSize="150"
                                            />

                  <%--  <telerik:RadAsyncUpload ID="RadAsyncUpload2" Skin="Glow" OnClientFilesUploaded="fileUploaded" OnFileUploaded="AsyncUpload1_FileUploaded"
                        HideFileInput="True" runat="server" Localization-Select="Import From Excel File" AllowedFileExtensions=".xlsx, .xls" Font-Size="14px"></telerik:RadAsyncUpload>--%>
                    <br />
                    <br />
                    <br />
                    

                </div>

            <telerik:RadGrid ID="RadGrid2"
                                runat="server" AllowPaging="false" ExportSettings-Excel-DefaultCellAlignment="Right" 
                                PageSize="10" Skin="Glow" AllowSorting="true" OnItemCreated="RadGrid2_ItemCreated"
                                RenderMode="Mobile" 
                                DataKeyNames="ExpressRateId" CommandItemDisplay="Top"
                                OnNeedDataSource="RadGrid2_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                <MasterTableView AutoGenerateColumns="False" 
                                    AllowFilteringByColumn="false"
                                     CommandItemDisplay="Top" 
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                   <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true" 
            ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                                    <Columns>

                                        <telerik:GridNumericColumn DataField="No" HeaderText="No" SortExpression="No"
                                            UniqueName="No">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="OriginCityName" HeaderText="Origin" SortExpression="OriginCityName"
                                            UniqueName="OriginCityName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        
                                        <telerik:GridNumericColumn DataField="DestinationCityName" HeaderText="Destination" SortExpression="DestinationCityName"
                                            UniqueName="DestinationCityName">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="1to5Cost" HeaderText="1 to 5" SortExpression="1to5Cost"
                                            UniqueName="1to5Cost">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                        <telerik:GridNumericColumn DataField="6to49Cost" HeaderText="6 to 49" SortExpression="6to49Cost"
                                            UniqueName="6to49Cost">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>
                                        
                                        <telerik:GridNumericColumn DataField="50to249Cost" HeaderText="50 to 249" SortExpression="50to249Cost"
                                            UniqueName="50to249Cost">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>
                                         
                                        <telerik:GridNumericColumn DataField="250to999Cost" HeaderText="250 to 999" SortExpression="250to999Cost"
                                            UniqueName="250to999Cost">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>

                                                                                 
                                        <telerik:GridNumericColumn DataField="1000to10000Cost" HeaderText="1000 to 10000" SortExpression="1000-10000Cost"
                                            UniqueName="1000to10000Cost">
                                            <HeaderStyle />
                                        </telerik:GridNumericColumn>
                                        
                                       <telerik:GridDateTimeColumn DataField="EffectiveDate" HeaderText="EffectiveDate" SortExpression="EffectiveDate"
                                            UniqueName="EffectiveDate" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                                            <HeaderStyle />

                                        </telerik:GridDateTimeColumn>
                                
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings>
                                    <Selecting AllowRowSelect="true"></Selecting>
                                    <%--<ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>--%>
                                </ClientSettings>
                            </telerik:RadGrid>
                <br />
               
                 <telerik:RadButton ID="RadButton1" runat="server" Text="Undo Changes" OnClick="RadButton1_Click">
                     </telerik:RadButton>

                   <telerik:RadButton ID="RadButton2" runat="server" Text="Save Changes" OnClick="RadButton2_Click">
                     </telerik:RadButton>
                <br 

                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <telerik:RadButton ID="RadButton4" runat="server" Text="" OnClick="RadButton4_Click" Width="1px" ></telerik:RadButton>

            </div>

        </div>


    </div>
        </form>
     <telerik:RadCodeBlock runat="server">
           <script type="text/javascript">
            function fileUploaded(sender, args) {
                 document.getElementById("<%= RadButton4.ClientID %>").click();
            }
    </script>
     </telerik:RadCodeBlock>

  
</body>
</html>
