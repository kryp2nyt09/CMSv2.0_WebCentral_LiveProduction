<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCrating.aspx.cs" Inherits="CMSVersion2.Maintenance.CMSMaintenance.UserModal.Crating.AddCrating" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../css/bootstrap.css" rel="stylesheet" />
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
                    <label for="email" class="cols-sm-2 control-label">Crating Name</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>
                            <%--<input type="text" class="form-control" name="name" id="name" placeholder="Enter your Name" style="width: 175px" required />--%>
                            <asp:Label ID="lblSBFid" runat="server" Text="" Visible="false"></asp:Label>
                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtCratingName" Enabled="True" runat="server"></telerik:RadTextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtCratingName" runat="server"
                                    ControlToValidate="txtCratingName"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                        </div>
                        <br />

                    </div>

                    <label for="email" class="cols-sm-2 control-label">Min Weight</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>

                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtMin" Enabled="True" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtMin" runat="server"
                                    ControlToValidate="txtMin"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                        </div>
                        <br />

                    </div>

                    <label for="email" class="cols-sm-2 control-label">Max weight</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>

                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtMax" Enabled="True" runat="server"></telerik:RadTextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtMax" runat="server"
                                    ControlToValidate="txtMax"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                        </div>
                        <br />

                    </div>

                    <label for="email" class="cols-sm-2 control-label">Minimum Cost</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>

                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtMinimumCost" Enabled="True" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtMinimumCost" runat="server"
                                    ControlToValidate="txtMinimumCost"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                        </div>
                        <br />

                    </div>
                    
                    <label for="email" class="cols-sm-2 control-label">Excess Cost</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>

                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtExcessCost" Enabled="True" runat="server"></telerik:RadTextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtExcessCost" runat="server"
                                    ControlToValidate="txtExcessCost"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                        </div>
                        <br />

                    </div>




                    <label for="email" class="cols-sm-2 control-label">Factor</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>
                            
                            <telerik:RadTextBox Width="190px" RenderMode="Mobile" ID="txtFactor" Enabled="True" runat="server"></telerik:RadTextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtFactor" runat="server"
                                    ControlToValidate="txtFactor"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>

                        </div>

                        <br />
                        <telerik:RadButton Skin="Glow" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClicked=""></telerik:RadButton>
                        <telerik:RadButton Skin="Glow" ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click" OnClientClicked="redirect"></telerik:RadButton>

                    </div>
                </div>

            </div>


        </div>
       <script type="text/javascript" src="../../../../Scripts/bootstrap.js"></script>

        <br />
    </form>
</body>
</html>
