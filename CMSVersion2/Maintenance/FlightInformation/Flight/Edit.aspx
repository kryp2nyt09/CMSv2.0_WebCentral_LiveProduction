<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CMSVersion2.Maintenance.FlightInformation.Flight.Edit" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../../Content/bootstrap.css" rel="stylesheet"/>
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
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
        <%--<asp:ScriptManager ID="ScriptManager2" runat="server" />--%>
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        <%--<asp:Button runat="server" Text="Close" ID="CloseButton"     OnClick="CloseButton_Click1"/>--%>
      <div class="">
            <div class="form-horizontal">
               <asp:Label ID="lblGroupID" runat="server" Text="" Visible="false"></asp:Label>
                 <div class="page">
                    <div class="col-xs-6">
                        <div class="col-xs-3">
                             <asp:Label ID="Label4" runat="server" Text="Origin"></asp:Label>
                            <br />
                            <br />
                             <br />
                             <asp:Label ID="Label5" runat="server" Text="Gateway"></asp:Label>
                            <br />
                             <br />
                            <br />
                             <asp:Label ID="Label8" runat="server" Text="Destination"></asp:Label>
                        </div>

                        <div class="col-xs-3">
                            <telerik:RadComboBox ID="rcbOrigin" runat="server" Width="230px"></telerik:RadComboBox>
                            <br />
                            <br />
                           <telerik:RadComboBox ID="rcbGateway" runat="server" Width="230px"></telerik:RadComboBox>
                            <br />
                            <br />
                            <telerik:RadComboBox ID="rcbDestination" runat="server" Width="230px"></telerik:RadComboBox>
                         </div>
                    </div>

                    <div class="col-xs-6">
                        <div class="col-xs-3">
                            <asp:Label ID="Label7" runat="server" Text="ETD"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Flight No"></asp:Label>
                            <br />
                            <br />
                              <asp:Label ID="Label9" runat="server" Text="ETA"></asp:Label>
                        </div>

                        <div class="col-xs-3">
                             <telerik:RadDateTimePicker RenderMode="Lightweight" runat="server" ID="rdtETD"  Width="230px"></telerik:RadDateTimePicker>
                            <br />
                            <br />
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtFlightNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />
                             <telerik:RadDateTimePicker RenderMode="Lightweight" runat="server" ID="rdtETA"  Width="230px"></telerik:RadDateTimePicker>
                          
                         </div>

                </div>
                    </div>

                
                       
                <div id="footer">
                 <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                 <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>
                </div>
            </div>


        </div>
       
        <br />
    </form>
</body>
</html>
