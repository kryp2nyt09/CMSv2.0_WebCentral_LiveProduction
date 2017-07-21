<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGroupIsland.aspx.cs" Inherits="CMSVersion2.Maintenance.CMSMaintenance.UserModal.GroupIslandMaintenance.AddGroupIsland" %>
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
<body>
    <form id="form1" runat="server">

        
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

        <%--<asp:ScriptManager ID="ScriptManager2" runat="server" />--%>
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        <%--<asp:Button runat="server" Text="Close" ID="CloseButton"     OnClick="CloseButton_Click1"/>--%>
        <div class="main-login main-center" style="margin-left:80px;margin-top:40px;">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Group Island</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">
                            <asp:Label ID="lblGroupID" runat="server" Text="" Visible="false"></asp:Label>
                            <telerik:RadTextBox  Width="190px" RenderMode="Mobile" ID="txtIslandGroup" Enabled="True" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Group" runat="server"
                                    ControlToValidate="txtIslandGroup"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <telerik:RadButton ID="btnSave" runat="server" Skin="Glow" Text="Save" OnClick="btnSave_Click" OnClientClicked=""></telerik:RadButton>
                        <telerik:RadButton ID="btnCancel" runat="server" Skin="Glow" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click" OnClientClicked="redirect"></telerik:RadButton>

                    </div>
                </div>

            </div>


        </div>
        <%--<script src="../js/bootstrap.js"></script>--%>
        <script type="text/javascript" src="../../../../Scripts/bootstrap.js"></script>

        <br />
    </form>
</body>
</html>
