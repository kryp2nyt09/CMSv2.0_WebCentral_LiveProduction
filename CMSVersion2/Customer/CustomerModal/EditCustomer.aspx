<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="CMSVersion2.Customer.CustomerModal.EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function CloseOnReload() {
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;
        }
        function RefreshParentPage() {
            var oWnd = GetRadWindow();
            oWnd.close();
            top.location.href = top.location.href;
        }
        function Close() {
            var oWindow = GetRadWindow();
            oWindow.argument = null;
            oWindow.close();
            oWindow.BrowserWindow.location = "newPage.aspx";
            top.location.reload();
            alert('triggered');
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager2" runat="server" />
            <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />

            <div class="">
                <form class="form-horizontal" method="post" action="#">
                    <div class="page">
                        <div class="col-xs-8">
                            <div class="col-xs-4">
                                <asp:Label ID="Label3" runat="server" Text="Employee Name"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="Old Password"></asp:Label>

                                <br />
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="Password"></asp:Label>

                                <br />
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Confirm Password"></asp:Label>
                            </div>

                            <div class="col-xs-4">
                                <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtEmployeeName" Enabled="false" runat="server"></telerik:RadTextBox>
                                <br />
                                <br />
                                <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtUsername" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtUsername"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <br />
                                <telerik:RadTextBox Width="190px" RenderMode="Mobile" TextMode="Password" ID="txtOldPassword" runat="server"></telerik:RadTextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtOldPassword"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtDbPassword" runat="server" Skin="Default"></telerik:RadTextBox>
                                <br />
                                <telerik:RadTextBox Width="190px" TextMode="Password" RenderMode="Mobile" ID="txtNewPassword" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtNewPassword"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <br />
                                <br />
                                <telerik:RadTextBox Width="190px" RenderMode="Mobile" TextMode="Password" ID="txtConfirmPassword" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtConfirmPassword"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>

                            </div>


                        </div>
                    </div>
                    <div id="footer">
                        <div class="errorMessage">
                            <asp:CompareValidator ID="CompareValidator" runat="server"
                                ControlToValidate="txtNewPassword"
                                ControlToCompare="txtConfirmPassword"
                                ErrorMessage="Password does not match!"
                                ForeColor="Red">                                    
                            </asp:CompareValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ControlToValidate="txtDbPassword"
                                Operator="Equal"
                                Type="String"
                                ControlToCompare="txtOldPassword"
                                ErrorMessage="Old password not match to username!"
                                ForeColor="Red">                                    
                            </asp:CompareValidator>

                        </div>

                        <telerik:RadButton ID="RadButton1" runat="server" Text="Save" OnClick="Save_Click"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton2" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click" OnClientClicked="redirect"></telerik:RadButton>
                    </div>

                </form>


            </div>

            <%--<script src="../js/bootstrap.js"></script>--%>
            <%--<script type="text/javascript" src="../../js/bootstrap.js"></script>--%>
            <br />
        </div>
    </form>
</body>
</html>
