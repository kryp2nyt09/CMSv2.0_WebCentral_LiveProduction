<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserRole.aspx.cs" Inherits="CMSVersion2.UserAccess.UserRole.UserRoleModal.AddUserRole" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        #footer {
        position: fixed;
        right:10px;
        bottom: 10px;
   
        }

        .page{
        margin-top: 30px;
        margin-right: 15px;
        margin-left: 15px;
        }

        .errorMessage
        {
        position: fixed;
        top:auto;
        right:50px;
        bottom: 50px;
        left:130px;
        }
    </style>

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

        function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }

        function CancelEdit() {
            GetRadWindow().close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager2" runat="server" />
         <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        <div>
            <div class="page">
            <div class="col-xs-12">
                <div>
                    <telerik:RadLabel ID="lblEmployeeName" runat="server" Text="Employee Name:" Width="30%"></telerik:RadLabel>
                    <telerik:RadComboBox ID="rcbEmployee" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rcbEmployee"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <br />
                    <br />

                    <telerik:RadLabel ID="lblRoles" runat="server" Text="Roles:" Width="30%"></telerik:RadLabel>
                    <telerik:RadCheckBoxList runat="server" ID="chkListRoles" AutoPostBack="false"></telerik:RadCheckBoxList>
                    <br />
                    <br />

                    <telerik:RadLabel ID="lblLogin" runat="server" Text="Login through:" Width="30%"></telerik:RadLabel>

                    <div class="col-xs-12">
                        <div class="col-xs-6">
                            <telerik:RadCheckBox runat="server" ID="chkWeb" Text="CMS Web"></telerik:RadCheckBox>
                            <telerik:RadCheckBox runat="server" ID="chkTnt" Text="CMS TnT"></telerik:RadCheckBox>
                        </div>
                        <div class="col-xs-6">
                            <telerik:RadCheckBox runat="server" ID="chkClient" Text="CMS Client"></telerik:RadCheckBox>
                            <telerik:RadCheckBox runat="server" ID="chkMobile" Text="CMS Mobile"></telerik:RadCheckBox>
                        </div>
                    </div>
                </div>
            </div>

        </div><!--PAGE-->
        <div id="footer">
             <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
             <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel"></telerik:RadButton>
        </div>
    </div>
        
    </form>
</body>
</html>
