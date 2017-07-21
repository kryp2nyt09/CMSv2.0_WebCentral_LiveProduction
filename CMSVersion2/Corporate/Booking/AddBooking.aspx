<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBooking.aspx.cs" Inherits="CMSVersion2.Corporate.Booking.AddBooking" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../../Content/bootstrap.css" rel="stylesheet" />
     <style>
        #footer
        {
            position: absolute;
            right:    0;
            bottom:   10px;
        }

        .disabledtext
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <asp:HiddenField ID="lblCompanyID" runat="server" Visible="true"></asp:HiddenField>
    <div class="demo-container no-bg">
        <div>
                <telerik:RadTabStrip CausesValidation="false" RenderMode="Lightweight" runat="server" ID="RadTabStrip1"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk" AutoPostBack="true">
                <Tabs>
                    <telerik:RadTab Text="Shipper/Consignee Information" ></telerik:RadTab>
                    <telerik:RadTab Text="Additional Information"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>

            <telerik:RadMultiPage runat="server" ID="RadMultiPage1"  SelectedIndex="0" CssClass="outerMultiPage">
                <telerik:RadPageView runat="server" ID="RadPageView1">
                    <div class="col-lg-12">
                        <div class="col-lg-6 colg-sm-6 col-xs-6">
                            <br />
                            <br />
                            <telerik:RadLabel ID="lblShipperName" runat="server" Text="Shipper Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbShipperName" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"    
                                AutoCompleteSeparator="" AllowCustomText="false">
                            </telerik:RadComboBox>
                            <br />
                            <br />
                            <!--Consignee Info-->
                            <telerik:RadLabel ID="lblLName" runat="server" Text="Consignee Last Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtConsigneeLName" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblFName" runat="server" Text="Consignee First Name" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtConsigneeFName" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblCompanyName" runat="server" Text="Company Name" Width="30%"></telerik:RadLabel>
                            <%--<telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="RadTextBox1" Enabled="True" runat="server"></telerik:RadTextBox>--%>
                             <telerik:RadComboBox ID="rcbCompanyName" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"   
                                AutoCompleteSeparator="" AllowCustomText="true">
                            </telerik:RadComboBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblAddress1" runat="server" Text="Address 1" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAddress1" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblAddress2" runat="server" Text="Address 2" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtAddress2" TextMode="MultiLine" Enabled="True" runat="server"></telerik:RadTextBox>
                        </div>

                        <div class="col-lg-6 colg-sm-6 col-xs-6">
                            <br />
                            <br />
                            <telerik:RadLabel ID="lblStreet" runat="server" Text="Street" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtStreet" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblBarangay" runat="server" Text="Barangay" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBarangay" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblBCO" runat="server" Text="BCO" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbBco" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"    
                                AutoCompleteSeparator="" AllowCustomText="false" OnSelectedIndexChanged="rcbBco_SelectedIndexChanged">
                            </telerik:RadComboBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblCity" runat="server" Text="City" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbCity" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"    
                                AutoCompleteSeparator="" AllowCustomText="false">
                            </telerik:RadComboBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblContactNo" runat="server" Text="Contact No" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtContactNo" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblMobile" runat="server" Text="Mobile No" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtMobileNo" Enabled="True" runat="server"></telerik:RadTextBox>
                            <br />
                            <br />
                            <telerik:RadLabel ID="lblEmail" runat="server" Text="Email" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtEmail" Enabled="True" runat="server"></telerik:RadTextBox>
                        </div>
                    </div>
                </telerik:RadPageView>

                <!--ADDITIONAL INFO-->
                <telerik:RadPageView runat="server" ID="RadPageView2">
                    <div class="col-lg-12">
                        <div class="col-lg-6 colg-sm-6 col-xs-6">
                            <br />
                            <br />
                            <telerik:RadLabel ID="lblBookingNo" runat="server" Text="BookingNo" Width="30%"></telerik:RadLabel>
                            <telerik:RadTextBox Width="230px" RenderMode="Mobile" ID="txtBookingNo" Enabled="True" runat="server"></telerik:RadTextBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblAssignedTo" runat="server" Text="Assigned To" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbAssignedTo" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"    
                                AutoCompleteSeparator="" AllowCustomText="false">
                            </telerik:RadComboBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblStatus" runat="server" Text="Status" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbStatus" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"    
                                AutoCompleteSeparator="" AllowCustomText="false">
                            </telerik:RadComboBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblRemarks" runat="server" Text="Remarks" Width="30%"></telerik:RadLabel>
                           <telerik:RadComboBox ID="rcbRemarks" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"    
                                AutoCompleteSeparator="" AllowCustomText="true">
                            </telerik:RadComboBox>
                        </div>
                        <div class="col-lg-6 colg-sm-6 col-xs-6">
                            <br />
                            <br />
                            <telerik:RadLabel ID="lblSched" runat="server" Text="Sched of Booking" Width="30%"></telerik:RadLabel>
                            <telerik:RadComboBox ID="rcbSchedule" runat="server" EnableTextSelection="true" Width="230"
                                AutoPostBack="true" MarkFirstMatch="true"   
                                AutoCompleteSeparator="" AllowCustomText="false" OnSelectedIndexChanged="rcbSchedule_SelectedIndexChanged">
                            </telerik:RadComboBox>

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblDateBooked" runat="server" Text="Date Booked" Width="30%"></telerik:RadLabel>
                            <telerik:RadDatePicker ID="rdDateBooked" runat="server" AutoPostBack="true" DateInput-DateFormat="MM/dd/yyyy" Width="230">
                            </telerik:RadDatePicker>    

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblStartDate" runat="server" Text="Start Date" Width="30%"></telerik:RadLabel>
                            <telerik:RadDatePicker ID="rdStartDate" runat="server" AutoPostBack="true" DateInput-DateFormat="MM/dd/yyyy" Width="230">
                            </telerik:RadDatePicker>    

                            <br />
                             <br />
                            <telerik:RadLabel ID="lblEndDate" runat="server" Text="End Date" Width="30%"></telerik:RadLabel>
                            <telerik:RadDatePicker ID="rdEndDate" runat="server" AutoPostBack="true" DateInput-DateFormat="MM/dd/yyyy" Width="230">
                            </telerik:RadDatePicker>    

                            <br />
                            <br />
                            <telerik:RadLabel ID="lblByDates" runat="server" Text="By Dates" Width="30%"></telerik:RadLabel>
                            <telerik:RadCalendar ID="radcalDates" runat="server">  
                            </telerik:RadCalendar>

                        </div>
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </div><!--demo-container no-bg-->
    <div id="footer">
        <telerik:RadButton ID="btnSave" runat="server" Text="Save"></telerik:RadButton>
        <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel"></telerik:RadButton>
    </div>
    </telerik:RadAjaxPanel>
    </div>
    <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>
    </form>
</body>
</html>
