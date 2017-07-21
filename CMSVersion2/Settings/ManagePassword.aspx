<%@ Page Title="Manage Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="CMSVersion2.Settings.ManagePassword" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
       <%-- <header>
            <img align="left" runat="server" src="~/images/logo1.png" />
            
        </header>--%>
        
        <br />
        <div class="text-center">
           <div class="row">
                <div class="col-sm-12">
                    <h1>Manage Password</h1>
                </div>
           </div>

           <div class="row">
                <div class="col-sm-6 col-sm-offset-3">
                
                <p class="text-center">Change Password</p>
               
                
                    <%--<telerik:RadTextBox Width="220px" Enabled ="True" runat="server" class="input-lg form-control"></telerik:RadTextBox>--%>
                <telerik:RadLabel ID="lblCurrentPassword" runat="server" Text="Current Password" Width="30%"></telerik:RadLabel>
                <telerik:RadTextBox Width="230px" ID="txtOldPassword" runat="server" TextMode="Password"  ValidationGroup="vg1"></telerik:RadTextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtOldPassword"
                                    ValidationGroup="vg1"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                <telerik:RadTextBox Width="230px" ID="txtDbPassword" runat ="server" Skin="Default"></telerik:RadTextBox>
               
                <br />
                <telerik:RadLabel ID="lblNewPassword" runat="server" Text="New Password" Width="30%"></telerik:RadLabel>
                <telerik:RadTextBox Width="230px" TextMode="Password" ID="txtNewPassword" runat="server"  ValidationGroup="vg1"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtNewPassword"
                     ValidationGroup="vg1"
                    ErrorMessage="*"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>                
                 <br/>
                <br />
                <telerik:RadLabel ID="lblConfirmPassword" runat="server" Text="Confirm Password" Width="30%"></telerik:RadLabel>
                <telerik:RadTextBox Width="230px" TextMode="Password" ID="txtConfirmPassword" runat="server"  ValidationGroup="vg1"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtConfirmPassword"
                     ValidationGroup="vg1"
                    ErrorMessage="*"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                 <br/>
                <br />
                     <div id="footer">
                         <div class="errorMessage"> 
                         <asp:CompareValidator ID="CompareValidator" runat="server"
                                    ControlToValidate="txtNewPassword"
                              ValidationGroup="vg1"
                                    ControlToCompare="txtConfirmPassword"
                                    ErrorMessage="Password does not match!"
                                    ForeColor="Red">                                    
                                </asp:CompareValidator>
                    <br />
                     <asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="txtDbPassword"
                          ValidationGroup="vg1"
                                    Operator="Equal"
                                    type="String"
                                    ControlToCompare="txtOldPassword"
                                    ErrorMessage="Old password not match to username!"
                                    ForeColor="Red">                                    
                                </asp:CompareValidator>

                     </div>
                          
               <%-- <telerik:RadButton ID="btnChangePassword" Skin="Glow" runat="server" Text="Change Password"  OnClick="btnChangePassword_Click" CausesValidation="false"></telerik:RadButton>--%>
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CausesValidation="False" UseSubmitBehavior="false"  ValidationGroup="vg1" OnClick="btnChangePassword_Click" />
                     </div>
               

               
                </div><!--/col-sm-6-->
            </div><!--/row--> 
        </div>
       
    </div>
</asp:Content>
