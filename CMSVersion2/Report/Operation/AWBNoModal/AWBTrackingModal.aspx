<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AWBTrackingModal.aspx.cs" Inherits="CMSVersion2.Report.Operation.AWBNoModal.AWBTrackingModal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .center {
        /*margin: auto;
        width: 80%;
        padding: 10px;*/
        text-align: center;
        }

        #lblName, #RadLabel1
        {
        vertical-align: middle;
        }

        .box-border {
        /*border-style: double;
        border-width: thin;*/
        border-top:2px solid; 
        border-bottom: 2px solid;
        }

        .div-border {
        border-style: solid;
        border-width: thick;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" />
    <div>
        <asp:HiddenField ID="lblAwbNumber" runat="server" Visible="true"></asp:HiddenField>
       <%-- <telerik:RadTextBox ID="txtAwbNo" runat="server" Width="230px"></telerik:RadTextBox>--%>

      <%--  <telerik:RadGrid ID="radGridSignature" 
                                runat="server" AllowPaging="True" 
                                ExportSettings-Excel-DefaultCellAlignment="Right"
                                PageSize="10" 
                                AllowSorting="true"
                                RenderMode="Mobile"
                                CommandItemDisplay="Top"
                                OnNeedDataSource="radGridSignature_NeedDataSource"> 
                                <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
                                
                                <MasterTableView CommandItemDisplay="Top">
                                   
                                    <CommandItemSettings ShowExportToWordButton="false" ShowExportToExcelButton="false" 
                                    ShowExportToCsvButton="false" ShowExportToPdfButton="false">

                                    </CommandItemSettings>
                                    <Columns>
                                        
                                        <telerik:GridBinaryImageColumn DataField="Signature" HeaderText="Signature" UniqueName="Signature" 
                                        ImageAlign="Middle" ImageHeight="100px" ImageWidth="150px" ResizeMode="Fit"
                                        DataAlternateTextFormatString="Image of {0}"> 
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </telerik:GridBinaryImageColumn>
                                    </Columns>
                                </MasterTableView>
                               
        </telerik:RadGrid>--%>
        <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="RadWindow1" AutoSize="true" AutoSizeBehaviors="HeightProportional" Width="1300px" Skin="Glow" VisibleStatusbar="false"></telerik:RadWindow>

        <div class="div-border">

            <div>
                <telerik:RadLabel ID="lblDateDelivered" runat="server" Text="Date Received:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                <telerik:RadLabel ID="txtDatedelivered" runat="server" Width="50%"></telerik:RadLabel>

                <telerik:RadLabel ID="lblPOD" runat="server" Text="POD for AWB Number:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                <telerik:RadLabel ID="txtAwb" runat="server" Width="50%" Font-Bold="true"></telerik:RadLabel>

                <div class="box-border">
                    <telerik:RadLabel ID="RadLabel2" runat="server" Text="Delivery Details:" Font-Bold="true"></telerik:RadLabel>
                </div>
                
                 <div class="row">
                        <div class="col-md-12">
                    <div class="col-md-6">
                        <telerik:RadLabel ID="RadLabel1" runat="server" Font-Bold="true" Text="Received By:" Width="30%"></telerik:RadLabel>
                        <telerik:RadLabel ID="lblName" runat="server" Width="50%"></telerik:RadLabel>

                        <telerik:RadLabel ID="lblSignature" runat="server" Text="Signature:" Width="30%" Font-Bold="true"></telerik:RadLabel>
                        <asp:Panel runat="server" ID="Panel2" HorizontalAlign="Center" Width="50%">
                            <asp:Image ID="Image1" runat="server" Height="80" Width="100"/>
                        </asp:Panel>
                    </div>

                    <div class="col-md-6">
                        <telerik:RadLabel ID="lblDeliveryStatus" runat="server" Font-Bold="true" Text="Delivery Status:" Width="30%"></telerik:RadLabel>
                        <telerik:RadLabel ID="txtDeliveryStatus" runat="server" Width="50%"></telerik:RadLabel>

                        <telerik:RadLabel ID="lblDestination" runat="server" Font-Bold="true" Text="Destination:" Width="30%"></telerik:RadLabel>
                        <telerik:RadLabel ID="txtDestination" runat="server" Width="50%"></telerik:RadLabel>
                    </div>
                </div>
                 </div>
             

                 <div class="box-border">
                    <telerik:RadLabel ID="RadLabel3" runat="server" Text="Shipment Details:" Font-Bold="true"></telerik:RadLabel>
                </div>

                <div class="row">
                    <div class="col-md-8">
                        <div class="col-md-4">
                            <telerik:RadLabel ID="lblShipper" runat="server" Font-Bold="true" Text="Shipper:" Width="30%"></telerik:RadLabel>
                            <telerik:RadLabel ID="txtShipper" runat="server" Width="50%"></telerik:RadLabel>

                            <telerik:RadLabel ID="lblOrigin" runat="server" Font-Bold="true" Text="Origin:" Width="30%"></telerik:RadLabel>
                            <telerik:RadLabel ID="txtOrigin" runat="server" Width="50%"></telerik:RadLabel>
                     

                        </div>

                        <div class="col-md-4">

                             <telerik:RadLabel ID="lblCommodity" runat="server" Font-Bold="true" Text="Commodity:" Width="30%"></telerik:RadLabel>
                            <telerik:RadLabel ID="txtCommodity" runat="server" Width="50%"></telerik:RadLabel>
                        
                            <telerik:RadLabel ID="lblQuantity" runat="server" Font-Bold="true" Text="Quantity:" Width="30%"></telerik:RadLabel>
                            <telerik:RadLabel ID="txtQuantity" runat="server" Width="50%"></telerik:RadLabel>

                           
                        </div>
                    </div>
                </div>
  
            </div>
        </div>

       <%-- <telerik:RadButton ID="Print" runat="server" Text="Print" Skin="Glow" AutoPostBack="true" OnClick="Print_Click"> </telerik:RadButton>--%>
    </div>
    </form>
</body>
</html>
