<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="CMSVersion2.Administration.UserModal.Add" %>
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
    </script>
    <style>
        #footer
        {
            position: absolute;
            right:    0;
            bottom:   10px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server" >
        
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
            <%--<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server"  DecoratedControls="All" />--%>
            
            <div id="wrapper">
                <div id="page-wrapper">
                    <div class="container">
                        <br />
                        <%--<div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Employee Name:</label>
						            <div class="col-sm-8">
                                        <telerik:RadDropDownList runat="server" Skin="Glow" ID="ddLEmployee1" Width="300px"></telerik:RadDropDownList>
						            </div>                                   
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Username:</label>
						            <div class="col-sm-8">
                                        <telerik:RadTextBox ID="a" runat="server" Skin="Glow" Width="300px"></telerik:RadTextBox>
						            </div>                                   
                                </div> 
                                
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Password:</label>
						            <div class="col-sm-8">
                                        <telerik:RadTextBox ID="RadTextBox1" runat="server" Skin="Glow" Width="300px"></telerik:RadTextBox>
						            </div>                                   
                                </div>   
                                
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Confirm Password:</label>
						            <div class="col-sm-8">
                                        <telerik:RadTextBox ID="RadTextBox2" runat="server" Skin="Glow" Width="300px"></telerik:RadTextBox>
						            </div>                                   
                                </div>   
                                
                                <div class="form-group">
                                    <div class="panel-footer">
                                    <telerik:RadButton ID="RadButton3" runat="server" Skin="Glow" Text="Save"> </telerik:RadButton>                                
                                    <telerik:RadButton ID="as" runat="server" Skin="Glow" Text="Cancel"> </telerik:RadButton>                                
                                    </div>
                                </div>                        
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>

            <div class="">
            <div class="form-horizontal">
               <div class="page">
                    <div class="col-xs-12">
                        
                        <div class="col-xs-4">
                            <asp:Label ID="Label3" runat="server" Text="Employee Name"></asp:Label>
                             <asp:DropDownList Width="230px" Height="30px"  ID="ddLEmployee" runat="server" Style="font-size: 12px;">
                                    <asp:ListItem>--Select Employee--</asp:ListItem>

                                </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
                            <telerik:RadTextBox  Width="230px" RenderMode="Mobile" ID="txtUsername" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtUsername"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator><br />
                            <br />
                             <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                           <telerik:RadTextBox  Width="230px" TextMode="Password" RenderMode="Mobile" ID="txtPassword" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtPassword"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>  <br />
                            <br />
                            <asp:Label ID="Label8" runat="server" Text="Confirm Password"></asp:Label>
                              <telerik:RadTextBox  Width="230px" RenderMode="Mobile" TextMode="Password" ID="txtConfirmPassword" runat="server"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtConfirmPassword"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator> <br />
                            <br />
                         
                         </div>
                       

                    </div>
                    </div>
                <div id="footer">
                     <div class="errorMessage"> 
                         <asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="txtPassword"
                                    ControlToCompare="txtConfirmPassword"
                                    ErrorMessage="Password does not match!"
                                    ForeColor="Red">                                    
                                </asp:CompareValidator>

                     </div>
                    
                  <telerik:RadButton ID="RadButton1" runat="server" Text="Save" OnClick="Save_Click"></telerik:RadButton>
                  <telerik:RadButton ID="RadButton2" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click" OnClientClicked="redirect"></telerik:RadButton>
                </div>
               
            </div>


        </div>



           <%-- <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>--%>
            <br />
     
    </form>
</body>
</html>
