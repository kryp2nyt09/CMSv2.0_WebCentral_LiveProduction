<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="CMSVersion2.Corporate.ApprovingAuthorityModal.Add" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
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

function getRadWindow1() 
{
  var oWindow = null;
  if (window.radWindow) oWindow = window.radWindow;
  else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
  return oWindow;
}

function closeWindow() 
{
  getRadWindow1().close();
}
    </script>
</head>
<body>
<form id="form2" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
    <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator2" runat="server" Skin="Default" DecoratedControls="All" />
        
         <div class="">
            <div class="form-horizontal">
               
                 <div class="page">
                    <div class="col-xs-6">
                        <div class="">
                           <telerik:RadLabel ID="lbl_Fname" runat="server" Text="First Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtFname" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtFname"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br /> 
                            <br /> 

                            <telerik:RadLabel ID="lbl_Lname" runat="server" Text="Last Name" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtLname" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtLname"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Title" runat="server" Text="Title" Width="30%"></telerik:RadLabel>
                              <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtTitle" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtTitle"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Position" runat="server" Text="Position" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtPosition" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtPosition"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <br /> 

                             <telerik:RadLabel ID="lbl_Department" runat="server" Text="Department" Width="30%"></telerik:RadLabel>
                              <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtDepartment" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtDepartment"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-xs-6">
                         <div class="">
                           <telerik:RadLabel ID="lbl_ContactNo" runat="server" Text="Contact No" Width="30%"></telerik:RadLabel>
                          <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactNumber" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtContactNumber"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br /> 
                            <br /> 

                            <telerik:RadLabel ID="lbl_Mobile" runat="server" Text="Mobile" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtMobile" Enabled="true" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtMobile"
                                ErrorMessage="*"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Fax" runat="server" Text="Fax" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtFax" Enabled="true" runat="server"></telerik:RadTextBox>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Email" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtEmail" Enabled="true" runat="server"></telerik:RadTextBox>
                             <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>  
                            <br />
                            
                            <telerik:RadLabel ID="lbl_Company" runat="server" Text="Company" Width="30%"></telerik:RadLabel>
                              <telerik:RadComboBox ID="rcbComapny" runat="server" Width="230px"></telerik:RadComboBox>
                           
                             
                        </div>
                        </div>
                    </div>
                 <div id="footer">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClicked=""></telerik:RadButton>
                        <%--<telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click" OnClientClicked="redirect"></telerik:RadButton>--%>
                
                 <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="false" Text="Cancel" OnClientClicked="closeWindow" CausesValidation="false"></telerik:RadButton>
                 </div>
            </div>


        </div>
        
       <%-- <script type="text/javascript" src="../../../js/bootstrap.js"></script>--%>

        <br />
    </form>
</body>
</html>
