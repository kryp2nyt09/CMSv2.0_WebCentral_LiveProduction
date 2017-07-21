<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CMSVersion2.Maintenance.AWBSeries.InssuanceModal.Edit" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap.css" rel="stylesheet" />
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
        <div class="center">
            <div class="form-horizontal">
               <asp:Label ID="lblAwbIssuanceID" runat="server" Text="" Visible="false"></asp:Label>
                 <div class="page">
                    <div class="col-xs-12">
                        <div>
                           <telerik:RadLabel ID="lblDateAssigned" runat="server" Text="Date Assigned" Width="30%"></telerik:RadLabel>
                           <telerik:RadDatePicker ID="rdDateAssigned" Width="230px" MinDate="1950/1/1" ZIndex="11000"  runat="server"></telerik:RadDatePicker>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdDateAssigned"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           <br />
                          
                           <telerik:RadLabel ID="lblBCO" runat="server" Text="BCO" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rdcBCO" runat="server"  Width="230px" AutoPostBack="true" OnSelectedIndexChanged="rdcBCO_SelectedIndexChanged"></telerik:RadComboBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdcBCO"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           <br />
                             
                           
                           <telerik:RadLabel ID="lblRUType" runat="server" Text="Revenue Type" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbRevenueType" runat="server" Width="230px" AutoPostBack="true" OnTextChanged="rcbRevenueType_TextChanged" OnSelectedIndexChanged="rcbRevenueType_SelectedIndexChanged"></telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rcbRevenueType"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           <br />
                           <telerik:RadLabel ID="lblAreaBranch" runat="server" Text="Area/Branch" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rdcArea" runat="server" Width="230px"  AutoPostBack="true" OnSelectedIndexChanged="rdcArea_SelectedIndexChanged"></telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdcArea"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblName" runat="server" Text="Name" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbName" runat="server" Width="230px"></telerik:RadComboBox>
                           <br />
                           <br />
                           
                           <telerik:RadLabel ID="lblStart" runat="server" Text="Series Start" Width="30%"></telerik:RadLabel>
                          <telerik:RadTextBox ID="txtStartSeries" runat="server" Width="230px"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStartSeries"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           <br />

                           <telerik:RadLabel ID="lblEnd" runat="server" Text="Series End" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox ID="txtEndSeries" runat="server" Width="230px"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndSeries"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    </div>
        
                <div id="footer">
                 <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClicked=""></telerik:RadButton>
                 <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>
                 </div>
            </div>


        </div>
        
        <br />
    </form>
</body>
</html>
