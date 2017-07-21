<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="CMSVersion2.Maintenance.RateMatrix.RateMatrix.Add" %>

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

  
        <div class="main-login main-center">

                  <div class="row">
    
            <div class="form-horizontal">


                <div class="form-group">


                    <label for="email" class="cols-sm-2 control-label">Applicable Rate</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <%--<span class="input-group-addon"><i class="glyphicon glyphicon-tasks" aria-hidden="true"></i></span>
                            --%>
                            <telerik:RadComboBox ID="rdcApplicableRate" runat="server" Width="230"></telerik:RadComboBox>
                        </div>
                        <br />

                    </div>



<%--                    <label for="email" class="cols-sm-2 control-label">Commodity Type</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <telerik:RadComboBox ID="rdcCommodityType" runat="server"></telerik:RadComboBox>
                        </div>
                        <br />

                    </div>--%>


                   <%-- <label for="email" class="cols-sm-2 control-label">Service Type</label>
                    <div class="cols-sm-10">
                        <div class="input-group" style="font-size: 12px">

                            <telerik:RadComboBox ID="rdcServicteType" runat="server"></telerik:RadComboBox>
                        </div>
                        <br />

                    </div>--%>

                   <%-- <label for="email" class="cols-sm-2 control-label">Service Type</label>--%>
                    <div class="cols-sm-10">
                       <%-- <div class="input-group" style="font-size: 12px">

                            <telerik:RadComboBox ID="rdcServiceMode" runat="server"></telerik:RadComboBox>
                        </div>
                        <br />--%>

                      

                        <label for="email" class="cols-sm-2 control-label">Applicable Fees</label>
                        <div class="cols-sm-10">
                            <div class="input-group" style="font-size: 12px">

                                <asp:CheckBox ID="chkApplyEVM" runat="server" Checked="false" Text="Apply EVM" /> <br />
                                <asp:CheckBox ID="chkApplyWeight" runat="server" Checked="false" Text="Apply Weight" /> <br />
                                <asp:CheckBox ID="chkhasAWBFee" runat="server" Checked="false" Text="Has AWB Fee" /> <br />
                                <asp:CheckBox ID="chkhasInsurance" runat="server" Checked="false" Text="Has Insurance"/> <br />
                                <asp:CheckBox ID="chkFuelSurcharge" runat="server" Checked="false" Text ="Has Surcharge"/> <br />
                                <asp:CheckBox ID="chkIsVatable" runat="server" Checked="false" Text="Is Vatable" /> <br />
                                <asp:CheckBox ID="chkHasValuationCharge" runat="server" Checked="false"  Text="Has Valuation Charge" /> <br />
                                <asp:CheckBox ID="chkHasDeliveryFee" runat="server" Checked="false" Text="Has Delivery Charge" /> <br />
                                <asp:CheckBox ID="chkHasPerishableFee" runat="server" Checked="false" Text="Has PerishableFee" /><br />
                                <asp:CheckBox ID="chkHasDangerousFee" runat="server" Checked="false" Text="Has Dangerous Fee" /><br />

                            </div>
                            <br />
                        </div>
                          <label for="email" class="cols-sm-2 control-label">Amount</label>
                         <div class="cols-sm-10">
                            <div class="input-group" style="font-size: 12px">

                                <telerik:RadTextBox ID="txtAmount" runat="server" Width="230"></telerik:RadTextBox>
                            </div>
                            <br />
                        </div>
                        <%--<label for="email" class="cols-sm-2 control-label">Group Island</label>--%>
                        <div class="cols-sm-10">
                            <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClicked=""></telerik:RadButton>
                            <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click" OnClientClicked="redirect"></telerik:RadButton>

                        </div>
                    </div>
            </div>


        </div>
        <%--<script src="../js/bootstrap.js"></script>--%>
        <script type="text/javascript" src="../../../js/bootstrap.js"></script>

        <br />
    </form>
</body>
</html>
