<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="CMSVersion2.Corporate.CompanyModal.Add" %>
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
   <form id="form1" runat="server">

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        
        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
        <%--<asp:Button runat="server" Text="Close" ID="CloseButton"     OnClick="CloseButton_Click1"/>--%>
        <div>
        <div>
        <asp:HiddenField ID="lblClientId" runat="server" Visible="true"></asp:HiddenField>
      
        <div class="demo-container no-bg">
            <div>
                <telerik:RadTabStrip CausesValidation="false" RenderMode="Lightweight" runat="server" ID="RadTabStrip1"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk" AutoPostBack="true">
            <Tabs>
                <telerik:RadTab Text="Company Information" ></telerik:RadTab>
                <telerik:RadTab Text="Contact Information"></telerik:RadTab>
                <telerik:RadTab Text="Account Information 1"></telerik:RadTab>
                <telerik:RadTab Text="Account Information 2"></telerik:RadTab>
                <telerik:RadTab Text="Billing Information"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1"  SelectedIndex="0" CssClass="outerMultiPage">
            <%--CompanyInformation--%>
            <telerik:RadPageView runat="server" ID="RadPageView1" >
                <div>
           

                <div>
                    <div class="col-xs-6">
                        
                            <br />
                            <br />
                            <telerik:RadLabel ID="lbl_Fname" runat="server" Text="Account No" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoAccountNo" Enabled="false" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            
                            <telerik:RadLabel ID="RadLabel1" runat="server" Text="Company Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoCompanyName" TextMode="MultiLine" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtCompInfoCompanyName" Display="Dynamic" 
                                    ErrorMessage="*"
                                    ForeColor="Red">
                            </asp:RequiredFieldValidator>   
                            <br />
                            <br />    

                            <telerik:RadLabel ID="RadLabel2" runat="server" Text="Address 1" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoAddress1" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtCompInfoAddress1" Display="Dynamic" 
                                    ErrorMessage="*"
                                    ForeColor="Red">
                            </asp:RequiredFieldValidator>    
                            <br />
                            <br />

                            <telerik:RadLabel ID="RadLabel3" runat="server" Text="Address 2" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoAdress2" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            
                            <telerik:RadLabel ID="RadLabel4" runat="server" Text="City" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbCompInfoCity" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />    

                            <telerik:RadLabel ID="RadLabel5" runat="server" Text="Zip Code" Width="30%"></telerik:RadLabel>
                             <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfozipCode" TextMode="MultiLine" Enabled ="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                       
                    </div>

                    <div class="col-xs-6">
                            <br />
                            <br />
                            <telerik:RadLabel ID="RadLabel6" runat="server" Text="Industry Type" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbCompInfoIndustry" Width="230px" Height="200px" AutoPostBack="true" runat="server"></telerik:RadComboBox>
                            <br />
                            <br />    

                            <telerik:RadLabel ID="RadLabel7" runat="server" Text="Contact Info" Width="30%"></telerik:RadLabel>
                             <telerik:RadMaskedTextBox Width="230px" RenderMode="Mobile" ID="txtContactNo" Enabled="True" Mask="(###)-######" runat="server"></telerik:RadMaskedTextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtContactNo"
                                    ErrorMessage="*"
                                    ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="MaskedTextBoxRegularExpressionValidator"
                                runat="server" ControlToValidate="txtContactNo"
                                ValidationExpression="\(\d{3}\)-\d{6}"></asp:RegularExpressionValidator>
                            <br />
                            <br />


                            <telerik:RadLabel ID="RadLabel8" runat="server" Text="TIN" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox RenderMode="Mobile" ID="txtCompInfoTin" Enabled="True" Width="230px" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />


                            <telerik:RadLabel ID="RadLabel9" runat="server" Text="Website" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoWebsite" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            

                            <telerik:RadLabel ID="RadLabel10" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                            <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic" ControlToValidate="txtCompInfoEmail"
                                ErrorMessage="*" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"></asp:RegularExpressionValidator>

                            <br />
                            <br />

                            <telerik:RadLabel ID="RadLabel11" runat="server" Text="President" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtCompInfoPresident" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />    
                    </div>
                    </div>
                    </div>
              
            </telerik:RadPageView>

            <%--Contact Information--%>
            <telerik:RadPageView runat="server" ID="RadPageView2">
                 <div>
           

                <div>
                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadLabel ID="RadLabel12" runat="server" Text="Contact Person" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInContacPerson" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel13" runat="server" Text="Position" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoPostion" Enabled ="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel14" runat="server" Text="Department" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoDept" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />
                        
                    </div>

                    <div class="col-xs-6">
                        <br />
                        <br />
                         <telerik:RadLabel ID="RadLabel15" runat="server" Text="Mobile No" Width="30%"></telerik:RadLabel>
                         <telerik:RadMaskedTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoMobile" Mask="(##) ###-###-####" RequireCompleteText="true" Enabled="True" runat="server"></telerik:RadMaskedTextBox>
                            <%-- <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator3"
                                runat="server" ControlToValidate="txtContactInfoMobile" ErrorMessage="*"
                                ValidationExpression="^(\\+)?(\\d+)$"></asp:RegularExpressionValidator>--%>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel16" runat="server" Text="Tel No" Width="30%"></telerik:RadLabel>
                        <telerik:RadMaskedTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoTelNo"  Mask="(###)-######" Enabled="True" runat="server"></telerik:RadMaskedTextBox>
                             <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
                                runat="server" ControlToValidate="txtContactInfoTelNo" ErrorMessage="*"
                                ValidationExpression="\(\d{3}\)-\d{6}"></asp:RegularExpressionValidator>
                        <br />
                        <br />


                        <telerik:RadLabel ID="RadLabel17" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoEmail" Enabled ="True" runat="server"></telerik:RadTextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ControlToValidate="txtContactInfoEmail"
                                ErrorMessage="*" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"></asp:RegularExpressionValidator>
                        <br />
                        <br />


                        <telerik:RadLabel ID="RadLabel18" runat="server" Text="Fax" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactInfoFax" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />
                        </div>
                    </div>
                </div>

            </telerik:RadPageView>

            <%--Account Information 1--%>
            <telerik:RadPageView runat="server" ID="RadPageView3">
                  <div>
                <div class="col-xs-12">
                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadLabel ID="RadLabel19" runat="server" Text="Account Type" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbAccountType" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rcbAccountType"
                             ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel20" runat="server" Text="Account Status" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbAccountStatus" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel21" runat="server" Text="Organization Type" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbAcctInfoOrganizationType" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbOrganizationType_OnSelectedIndexChanged"></telerik:RadComboBox>                            
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel22" runat="server" Text="Mother Company" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbAcctInfoMotherCompany" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>                            
                        <br />
                        <br />
                        
                        <telerik:RadLabel ID="RadLabel23" runat="server" Text="Business Type" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbBusinessType" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>     
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel24" runat="server" Text="Billing Period" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbBillingPeriod" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel25" runat="server" Text="Payment Term" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbPaymentTerm" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel26" runat="server" Text="Payment Mode" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbPaymentMode" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                </div>

                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadLabel ID="RadLabel27" runat="server" Text="Date Approve" Width="30%"></telerik:RadLabel>
                        <telerik:RadDatePicker ID="dateApproved" Width="230px" MinDate="1950/1/1" ZIndex="11000"  runat="server"></telerik:RadDatePicker>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator_DateApproved" runat="server" ControlToValidate="dateApproved"
                             ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel28" runat="server" Text="Approved By" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbApprovedBy" Width="230px" Height="200px" runat="server"></telerik:RadComboBox><br />
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel29" runat="server" Text="BCO" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbBCO" Width="230px" Height="200px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbBCO_OnSelectedIndexChanged"></telerik:RadComboBox><br />
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel30" runat="server" Text="Area" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbArea" Width="230px" Height="200px" runat="server"></telerik:RadComboBox><br />
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel31" runat="server" Text="Discount" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAcctDiscount" Enabled="True" runat="server"></telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAcctDiscount"
                             ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <br />


                        <telerik:RadLabel ID="RadLabel32" runat="server" Text="Tax" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAcctTax" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel33" runat="server" Text="Credit Limit" Width="30%"></telerik:RadLabel>
                         <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAcctCreditLimit" Enabled="True" runat="server"></telerik:RadTextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAcctCreditLimit"
                             ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>


            </telerik:RadPageView>
             
            <%--Account Information 2--%>
            <telerik:RadPageView runat="server" ID="RadPageView4">
             <div>
                <div class="col-xs-12">
                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkEVM" Text="Applied EVM"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkAWBFee" Text="Has AirwayBill Fee"></telerik:RadCheckBox>
                        <br />
                        <br />
                        <asp:Label ID="Label33" runat="server" Text="Has Freight Collect Fee"></asp:Label>
                        <br />
                        <div style="float: left; position: relative; left: 20%">
                        <telerik:RadCheckBox runat="server" ID="chkFC" Text="FC"></telerik:RadCheckBox>
                        <telerik:RadCheckBox runat="server" ID="chkCC" Text="CC"></telerik:RadCheckBox>
                        </div>
                        <br />
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasInsurance" Text="Has Insurance"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasFuelCharge" Text="Has Fuel Charge"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkhasVat" Text="Has Vatable"></telerik:RadCheckBox>
                        </div>

                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasValuationCharge" Text="Has Valuation Charge"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasDevFee" Text="Has Delivery Fee"></telerik:RadCheckBox>
                            
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasPerishableFee" Text="Has Perishable Fee"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasDangerousFee" Text="Has Dangerous Fee"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasweightCharge" Text="Has Weight Charge"></telerik:RadCheckBox>
                        <br />
                        <telerik:RadCheckBox runat="server" ID="chkHasChargeInvoice" Text="Has Charge Invoice"></telerik:RadCheckBox>
                    </div>
                </div>
        </div>

            </telerik:RadPageView>

            <%--Billing Information --%>
            <telerik:RadPageView runat="server" ID="RadPageView5">
           <div>
            <div class="form-horizontal">

                <div>
                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadLabel ID="RadLabel34" runat="server" Text="Address 1" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoAdd1" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />
                        
                        <telerik:RadLabel ID="RadLabel35" runat="server" Text="Address 2" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoAdd2" TextMode="MultiLine" Enabled ="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel36" runat="server" Text="City" Width="30%"></telerik:RadLabel>
                        <telerik:RadComboBox ID="rcbBillingInfoCity" Width="230px" Height="200px" runat="server"></telerik:RadComboBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rcbBillingInfoCity"
                            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel37" runat="server" Text="Zip Code" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoZipCode" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel38" runat="server" Text="Contact Person" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoContactPerson" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel39" runat="server" Text="Position" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoPosition" Enabled="True" runat="server"></telerik:RadTextBox>
                    </div>

                    <div class="col-xs-6">
                        <br />
                        <br />
                        <telerik:RadLabel ID="RadLabel40" runat="server" Text="Department" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoDept" Enabled="True" runat="server"></telerik:RadTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel41" runat="server" Text="Contact No" Width="30%"></telerik:RadLabel>
                        <telerik:RadMaskedTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoContactNo" Mask="(###)-######" Enabled ="True" runat="server"></telerik:RadMaskedTextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator5"
                            runat="server" ControlToValidate="txtBillingInfoContactNo" ErrorMessage="*"
                            ValidationExpression="\(\d{3}\)-\d{6}"></asp:RegularExpressionValidator>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel42" runat="server" Text="Mobile No" Width="30%"></telerik:RadLabel>
                        <telerik:RadMaskedTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoMobileNo" Mask="(##)-###-###-####" Enabled="True" runat="server"></telerik:RadMaskedTextBox>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel43" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                        <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic" ControlToValidate="txtBillingInfoEmail"
                            ErrorMessage="*" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"></asp:RegularExpressionValidator>
                        <br />
                        <br />

                        <telerik:RadLabel ID="RadLabel44" runat="server" Text="Fax" Width="30%"></telerik:RadLabel>
                       <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBillingInfoFax" Enabled="True" runat="server"></telerik:RadTextBox>
                       
                </div>
             </div>
        </div>
</div>

            </telerik:RadPageView>
        </telerik:RadMultiPage>

            </div>
        </div>
        </div>
       <div id="footer">
            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>
                <telerik:RadButton ID="btmCancel" runat="server" Text="Cancel"></telerik:RadButton>
       </div>


        </div>
        
        <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>

        <br />
    </form>
</body>
</html>
