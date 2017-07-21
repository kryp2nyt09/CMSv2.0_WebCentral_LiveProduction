<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CMSVersion2.Corporate.RepresentativeModal.Edit" %>
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
            <div class="form-horizontal" >
               <asp:Label ID="lblRepresenatativesID" runat="server" Text="" Visible="false"></asp:Label>
                 <div class="page">
                    <div class="col-xs-6">
                        <div>
                           <telerik:RadLabel ID="lbl_Fname" runat="server" Text="First Name" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="220px" RenderMode="Mobile" ID="txtRepFirstName" Enabled ="True" runat="server"></telerik:RadTextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRepFirstName"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           <br />
                          
                           <telerik:RadLabel ID="lbl_Lname" runat="server" Text="Last Name" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="220px" RenderMode="Mobile" ID="txtRepLastName" Enabled="True" runat="server"></telerik:RadTextBox>  
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRepLastName"
                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           <br />
                           <br />
                           
                           <telerik:RadLabel ID="lblAddress1" runat="server" Text="Address 1" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepAdress1" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                           <br />
                           <br />

                           <telerik:RadLabel ID="lblAddress2" runat="server" Text="Address 2" Width="30%"></telerik:RadLabel>
                           <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepAdress2" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                           <br />
                           <br />

                            <telerik:RadLabel ID="lblCity" runat="server" Text="City" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbRepCity" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />
                            
                            <telerik:RadLabel ID="lblZipCode" runat="server" Text="Zip Code" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepzipCode" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             
                            <telerik:RadLabel ID="lblStreet" runat="server" Text="Street" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepStreet" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                            <telerik:RadLabel ID="lblBarangay" runat="server" Text="Barangay" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepBarangay" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                            <telerik:RadLabel ID="lblRemarks" runat="server" Text="Remarks" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepRemarks" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                             <telerik:RadLabel ID="lblCompany" runat="server" Text="Company" Width="30%"></telerik:RadLabel>
                            <%--<telerik:RadComboBox ID="rcbRepCompany" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>--%>
                            <telerik:RadComboBox ID="rcbRepCompany" runat="server" Width="220px" 
                    AppendDataBoundItems="true" EnableTextSelection="true" 
                    AutoCompleteSeparator="None" AllowCustomText="true" MarkFirstMatch="true" AutoPostBack="true">
                   
                    </telerik:RadComboBox>
                         <%--   <telerik:RadComboBox ID="rcbRepCompany" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>--%>
                        </div>
                    </div>

                    <div class="col-xs-6">
                        <div>
                           <telerik:RadLabel ID="lblBco" runat="server" Text="BCO" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbBco" Width="230px" Height="200px" runat="server" AutoPostBack="true" 
                                  OnSelectedIndexChanged="rcbBco_SelectedIndexChanged"></telerik:RadComboBox>
                           <br />
                           <br />
                           
                           <telerik:RadLabel ID="lblRevenueType" runat="server" Text="Revenue Type" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbRevenueType" Width="230px" Height="200px" runat="server"
                                 AutoPostBack="true" OnTextChanged="rcbRevenueType_TextChanged" OnSelectedIndexChanged="rcbRevenueType_SelectedIndexChanged"></telerik:RadComboBox>
                           <br />
                           <br />

                           <telerik:RadLabel ID="lblArea" runat="server" Text="Area" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbRepArea" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                           <br />
                           <br />
 
                            <telerik:RadLabel ID="lblContactNo" runat="server" Text="Contact No" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox RenderMode="Mobile" ID="txtRepContactNo" Enabled="True" Width="230px" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                             
                            <telerik:RadLabel ID="lblMobileNo" runat="server" Text="Mobile No" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepMobileNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                            <telerik:RadLabel ID="lblFax" runat="server" Text="Fax" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepFax" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                            <telerik:RadLabel ID="lblEmail" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                            <telerik:RadLabel ID="lblTitle" runat="server" Text="Title" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepTitle" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                             <br />

                            <telerik:RadLabel ID="lblDept" runat="server" Text="Department" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtRepDept" Enabled="True" runat="server"></telerik:RadTextBox>
                        </div>

                </div>
                    </div>

                
                       
                <div id="footer">
                 <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                 <%--<telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>--%>
                    <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="false" Text="Cancel" OnClientClicked="closeWindow" CausesValidation="false"></telerik:RadButton>
                </div>
            </div>


        </div>
        
        <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>

        <br />
    </form>
</body>
</html>
