<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="CMSVersion2.Administration.EmployeeModal.Add" %>
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
</head>
<body>
<form id="form1" runat="server">



        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        
         <div class="">
            <div class="form-horizontal">
               
                 <div class="page">
                    <div class="col-xs-6">
                        <div class="">
                           <telerik:RadLabel ID="lbl_Fname" runat="server" Text="First Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtFirstname" Enabled="True" runat="server"></telerik:RadTextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstname"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <br /> 
                            <br /> 

                            <telerik:RadLabel ID="lbl_Mname" runat="server" Text="Middle Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtMiddlename" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Lname" runat="server" Text="Last Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtLastname" Enabled="True" runat="server"></telerik:RadTextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastname"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Birthday" runat="server" Text="Birthday" Width="30%"></telerik:RadLabel>
                             <telerik:RadDatePicker ID="dpBirthDate" MinDate="1950/1/1" ZIndex="11000"  runat="server" Width="230px"></telerik:RadDatePicker>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_TelNo" runat="server" Text="Tel. No." Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtTel" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br /> 

                             <telerik:RadLabel ID="lbl_MobNo" runat="server" Text="Mobile No." Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtMobile" Enabled="True" runat="server"></telerik:RadTextBox>
                             <br />
                             <br /> 

                             <telerik:RadLabel ID="lbl_Email" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                             
                        </div>
                    </div>

                    <div class="col-xs-6">
                         <div class="">
                           <telerik:RadLabel ID="lbl_Bco" runat="server" Text="BCO" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbBranchCorpOffice" runat="server" Width="230px" Height="200px" AutoPostBack="true" OnSelectedIndexChanged="rcbBranchCorpOffice_SelectedIndexChanged"></telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rcbBranchCorpOffice"
                                    ErrorMessage="*" ForeColor="Red" InitialValue="--Select Assignment--"></asp:RequiredFieldValidator>
                            <br /> 
                            <br /> 

                            <telerik:RadLabel ID="lbl_AssignedTo" runat="server" Text="Assigned To" Width="30%"></telerik:RadLabel>
                             <telerik:RadComboBox ID="rcbRevenueUnitType" runat="server" Width="230px" Height="200px" AutoPostBack="true" OnTextChanged="rcbRevenueUnitType_TextChanged" OnSelectedIndexChanged="rcbRevenueUnitType_SelectedIndexChanged"></telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rcbRevenueUnitType"
                                    ErrorMessage="*" ForeColor="Red" InitialValue="--Select Assignment--"></asp:RequiredFieldValidator>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Location" runat="server" Text="Location" Width="30%"></telerik:RadLabel>
                             <telerik:RadComboBox ID="rcbRevenueUnitName" runat="server" Width="230px" Height="200px"></telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rcbRevenueUnitName"
                                    ErrorMessage="*" ForeColor="Red" InitialValue="--Select Assignment--"></asp:RequiredFieldValidator>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Department" runat="server" Text="Department" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbDepartment" runat="server" Width="230px" Height="200px"></telerik:RadComboBox>
                            <br />
                            <br /> 

                            <telerik:RadLabel ID="lbl_Position" runat="server" Text="Position" Width="30%"></telerik:RadLabel>
                             <telerik:RadComboBox ID="rcbPosition" runat="server" Width="230px" Height="200px"></telerik:RadComboBox>
                            <br />
                            <br /> 

                             <telerik:RadLabel ID="lbl_DLNum" runat="server" Text="Driver License Number" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtLicense" Enabled="True" runat="server"></telerik:RadTextBox>
                             <br />
                             <br /> 

                             <telerik:RadLabel ID="lbl_DLNumExp" runat="server" Text="Driver License Expiration" Width="30%"></telerik:RadLabel>
                             <telerik:RadDatePicker ID="dpLicense" Width="230px" MinDate="1950/1/1"  ZIndex="1100000" AutoPostBack ="false" runat="server"></telerik:RadDatePicker>
                             
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
