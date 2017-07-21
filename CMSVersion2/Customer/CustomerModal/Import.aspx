<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="CMSVersion2.Customer.CustomerModal.Import" %>

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

                        <telerik:RadAsyncUpload Skin="Glow" runat="server" ID="RadAsyncUpload2"
                            HideFileInput="true"
                            AllowedFileExtensions=".xls,.xlsx"
                            OnClientFilesUploaded="fileUploaded"
                            OnFileUploaded="AsyncUpload1_FileUploaded"
                            Localization-Select="Import File"
                            InputSize="150" />
                        <br />
                        <br />
                        <br />


                    </div>

                    <telerik:RadGrid ID="RadGrid2"
                        runat="server" AllowPaging="false" ExportSettings-Excel-DefaultCellAlignment="Right"
                        PageSize="10" Skin="Glow" AllowSorting="true" OnItemCreated="RadGrid2_ItemCreated"
                        RenderMode="Mobile" DataKeyNames="ExpressRateId" CommandItemDisplay="Top"
                        OnNeedDataSource="RadGrid2_NeedDataSource">
                        <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                        <MasterTableView AutoGenerateColumns="False" AllowFilteringByColumn="false"
                            CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
                            <CommandItemSettings ShowExportToWordButton="true" ShowExportToExcelButton="true"
                                ShowExportToCsvButton="true" ShowExportToPdfButton="true"></CommandItemSettings>
                            <Columns>
                                <telerik:GridNumericColumn DataField="No" HeaderText="No" SortExpression="No"
                                    UniqueName="No">
                                    <HeaderStyle />
                                </telerik:GridNumericColumn>
                                
                                <telerik:GridBoundColumn DataField="AccountNo" HeaderText="Account #" SortExpression="Account"
                                    UniqueName="Account">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"
                                    UniqueName="FirstName">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="LastName" HeaderText="Last Name" SortExpression="LastName"
                                    UniqueName="LastName">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="6to49Cost" HeaderText="6 to 49" SortExpression="6to49Cost"
                                    UniqueName="6to49Cost">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="50to249Cost" HeaderText="50 to 249" SortExpression="50to249Cost"
                                    UniqueName="50to249Cost">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="250to999Cost" HeaderText="250 to 999" SortExpression="250to999Cost"
                                    UniqueName="250to999Cost">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn DataField="1000to10000Cost" HeaderText="1000 to 10000" SortExpression="1000-10000Cost"
                                    UniqueName="1000to10000Cost">
                                    <HeaderStyle />
                                </telerik:GridBoundColumn>


                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="true"></Selecting>

                        </ClientSettings>
                    </telerik:RadGrid>
                    <br />

                    <telerik:RadButton ID="RadButton1" runat="server" Text="Undo Changes" OnClick="RadButton1_Click">
                    </telerik:RadButton>

                    <telerik:RadButton ID="RadButton2" runat="server" Text="Save Changes" OnClick="RadButton2_Click">
                    </telerik:RadButton>
                    <br />

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <telerik:RadButton ID="RadButton4" runat="server" Text="" OnClick="RadButton4_Click" Width="1px"></telerik:RadButton>

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
