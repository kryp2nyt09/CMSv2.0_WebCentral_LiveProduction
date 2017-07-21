<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRoles.aspx.cs" Inherits="CMSVersion2.UserAccess.Roles.RolesModal.AddRoles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../../../../Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        #footer {
        position: fixed;
        right:0;
        bottom: 0;
   
        }

        .page{
        margin-top: 10px;
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
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
       <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        <div class="">
           
               
                 <div class="page">
                    <div class="col-xs-12">
                        <div>
                           <telerik:RadLabel ID="lbl_RoleName" runat="server" Text="Role Name" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="220px" RenderMode="Mobile" ID="txtRoleName" Enabled ="True" runat="server"></telerik:RadTextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoleName"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           
                           <telerik:RadLabel ID="lbl_Desc" runat="server" Text="Description" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="220" RenderMode="Mobile" ID="txtDescription" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>  
                           <br />
                           <br />
                           
                        </div>
                    </div>
                </div>

                
                       
                <div id="footer">
                 <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                 <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>
                </div>
          


        </div>
        <br />
    </form>
</body>
</html>
