<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="CMSVersion2.Maintenance.CMSMaintenance.UserModal.Batch.Add" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../Content/bootstrap.css" rel="stylesheet" />

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

       <%-- <asp:ScriptManager ID="ScriptManager2" runat="server" />--%>
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
       <%-- <asp:Button runat="server" Text="Close" ID="CloseButton"     OnClick="CloseButton_Click1"/>--%>
        <div style="margin-left:80px;margin-top:40px;">
            <div class="form-horizontal">


                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Batch Name</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <asp:Label ID="lblBatchID" runat="server" Text="" Visible="false"></asp:Label>
                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtBatchName" Enabled="True" runat="server"></telerik:RadTextBox>

                        </div>
                        <br />
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>

                    </div>
                </div>

            </div>


        </div>
        
        <script type="text/javascript" src="../../../../Scripts/jquery.js"></script>

        <br />
    </form>
</body>
</html>
