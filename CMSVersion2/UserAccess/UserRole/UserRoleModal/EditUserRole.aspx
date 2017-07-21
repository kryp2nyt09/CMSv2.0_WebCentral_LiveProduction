<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserRole.aspx.cs" Inherits="CMSVersion2.UserAccess.UserRole.UserRoleModal.EditUserRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #footer {
        position: fixed;
        right:0;
        bottom: 0;
   
        }

        .page{
        margin-top: 30px;
        margin-right: 15px;
        margin-left: 15px;
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
        </script>
</head>
<body>
   <form id="form2" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
       <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator2" runat="server" Skin="Default" DecoratedControls="All" />
        <div class="">
            <%--<form class="form-horizontal" method="post" action="#">--%>
               <asp:Label ID="lblUserID" runat="server" Text="" Visible="false"></asp:Label>
                 <div class="page">
                    <div class="col-xs-12">
                        <div>
                           <telerik:RadLabel ID="lblEmployeeName" runat="server" Text="Employee Name:" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="220px" RenderMode="Mobile" ID="txtEmpName" Enabled ="false" runat="server"></telerik:RadTextBox>
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
                     </div>
                
                       
                <div id="footer">
                 <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                 <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>
                </div>
           <%-- </form>--%>


        </div>
     

        <br />
    </form>
</body>
</html>
