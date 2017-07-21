<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMSVersion2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
</telerik:RadAjaxLoadingPanel>
<div id="wrapper">
    <div id="page-wrapper">
        <div class="container">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h3><i class="glyphicon glyphicon-dashboard"></i> Dashboard</h3>
                    <hr />
                </div>
            </div><!--row-->
           <div class="row">
                    <div class="col-lg-12">
                        <div class="col-sm-2">
                            <div class="panel">
                                <div class="panel-body" style="background-color: #27a9e3; color: #fff; border-radius: 10px;">
                                    <h2>
                                        <i class="glyphicon glyphicon-book"></i>
                                        <asp:Label Text="" runat="server" ID="txtAwbPending"></asp:Label></h2>
                                    <p>Booking Pending</p>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="panel">
                                <div class="panel-body" style="background-color: #27a9e3; color: #fff; border-radius: 10px;">
                                    <h2>
                                        <i class="glyphicon glyphicon-ok-sign"></i>
                                        <asp:Label Text="100" runat="server" ID="txtPickup"></asp:Label></h2>
                                    <p>Booking Picked-up</p>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="panel">
                                <div class="panel-body" style="background-color: #28b779; color: #fff; border-radius: 10px;">
                                    <h2>
                                        <i class="glyphicon glyphicon-flag"></i>
                                        <asp:Label Text="" runat="server" ID="txtDistributed"></asp:Label></h2>
                                    <p>Distrubuted</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="panel">
                                <div class="panel-body" style="background-color: #28b779; color: #fff; border-radius: 10px;">
                                    <h2>
                                        <i class="glyphicon glyphicon-shopping-cart"></i>
                                        <asp:Label Text="" runat="server" ID="txtDelivered"></asp:Label></h2>
                                    <p>Delivered</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="panel">
                                <div class="panel-body" style="background-color: #ffb849; color: #fff; border-radius: 10px;">
                                    <h2>
                                        <i class="glyphicon glyphicon-saved"></i>
                                        <asp:Label Text="" runat="server" ID="txtPaid"></asp:Label></h2>
                                    <p>Paid</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="panel">
                                <div class="panel-body" style="background-color: #ffb849; color: #fff; border-radius: 10px;">
                                    <h2>
                                        <i class="glyphicon glyphicon-remove-circle"></i>
                                        <asp:Label Text="100" runat="server" ID="txtUnpaid"></asp:Label></h2>
                                    <p>Unpaid</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                     <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                    <div class="panel-heading" style="background-color: #620055; color: #fff;">
                                        <div style="text-align: left;">
                                            Quantity by Commodity Type 
                                        </div>
                                        <div style="text-align: right; margin-top: -20px;">
                                            <telerik:RadLabel runat="server" Text="Date:" ForeColor="White"></telerik:RadLabel>

                                            <telerik:RadDatePicker ID="Date" runat="server" Skin="Silk" AutoPostBack="true">
                                            </telerik:RadDatePicker>

                                            <telerik:RadDatePicker ID="DateTo" runat="server" Skin="Silk" AutoPostBack="true">
                                            </telerik:RadDatePicker>

                                            <telerik:RadLabel runat="server" Text="BCO:" ForeColor="White"></telerik:RadLabel>

                                            <telerik:RadComboBox ID="BCO" runat="server" Skin="Silk" AllowCustomText="true" MarkFirstMatch="true"
                                                AppendDataBoundItems="true" Width="260px" AutoPostBack="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                                                </Items>
                                            </telerik:RadComboBox>

                                        </div>
                                    </div>
                                    <div class="panel-body" style="height: 500px; overflow: auto;">
                                        <telerik:RadHtmlChart runat="server" OnLoad="QtybyCommodityTypeChart_Load" OnPreRender="QtybyCommodityTypeChart_PreRender" ID="QtybyCommodityTypeChart" Width="100%" Height="100%" Transitions="true" Skin="Silk">
                                            <PlotArea>
                                                <Series>
                                                  <%--  <telerik:BarSeries Name="[]" DataFieldY="[a gargfg ]" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#5c6bc0" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="C. Valuable Cargo" DataFieldY="Col_1" Stacked="true">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#26c6da" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="D. Dangerous Cargo" DataFieldY="Col_2" Stacked="true">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#9ccc65" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="E. Perishable Cargo" DataFieldY="Col_3" Stacked="true" Gap="1.5" Spacing="0.4">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#ffa726" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="F. Courier - SAP" DataFieldY="Col_4" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#8d6e63" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="G. Courier - MAP" DataFieldY="Col_5" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ff7043" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="H. Courier - LAP" DataFieldY="Col_6" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#78909c" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="I. Courier - NSAP" DataFieldY="Col_7" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ef5350" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="J. Courier - NMAP" DataFieldY="Col_8" Stacked="true">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#ec407" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="K. Courier - NLAP" DataFieldY="Col_9" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ab47bc" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>--%>
                                                </Series>
                                                <Appearance>
                                                    <FillStyle BackgroundColor="White" />
                                                </Appearance>
                                                <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside" Reversed="false">
                                                    <LabelsAppearance DataFormatString="{0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                                    <TitleAppearance Position="Center" RotationAngle="0" Text="City">
                                                    </TitleAppearance>
                                                </XAxis>
                                                <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                                                    MinorTickType="None" Reversed="false">
                                                    <LabelsAppearance DataFormatString="{0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                                    <TitleAppearance Position="Center" RotationAngle="0" Text="Quantity">
                                                    </TitleAppearance>
                                                </YAxis>
                                            </PlotArea>
                                            <Appearance>
                                                <FillStyle BackgroundColor="White"></FillStyle>
                                            </Appearance>
                                            <Legend>
                                                <Appearance BackgroundColor="White" Position="Right" Visible="true">
                                                </Appearance>
                                            </Legend>
                                        </telerik:RadHtmlChart>
                                    </div>
                                         </telerik:RadAjaxPanel>
                                </div>
                            </div>
                        </div>
                    </div>
                

                
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel2">
                                    <div class="panel-heading" style="background-color: #36aa47; color: #fff;">
                                        <div style="text-align: left;">
                                            Weight by Commodity Type 
                                        </div>
                                        <div style="text-align: right; margin-top: -20px;">
                                            <telerik:RadLabel runat="server" Text="Date:" ForeColor="White"></telerik:RadLabel>
                                            <telerik:RadDatePicker ID="WtDateFrom" runat="server" Skin="Silk" AutoPostBack="true">
                                            </telerik:RadDatePicker>
                                            <telerik:RadDatePicker ID="WtDateTo" runat="server" Skin="Silk" AutoPostBack="true">
                                            </telerik:RadDatePicker>
                                            <telerik:RadLabel runat="server" Text="BCO:" ForeColor="White"></telerik:RadLabel>
                                            <telerik:RadComboBox ID="WtBCO" runat="server" Skin="Silk" AllowCustomText="true" MarkFirstMatch="true"
                                                AppendDataBoundItems="true" Width="260px" AutoPostBack="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="All" Value="All" Selected="true" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="height: 500px;">
                                        <telerik:RadHtmlChart OnLoad="WtbyCommodityTypeChart_Load" runat="server" ID="WtbyCommodityTypeChart" Width="100%" Height="100%" Transitions="true" Skin="Silk">
                                            <PlotArea>
                                                <Series>
                                                   <%-- <telerik:BarSeries Name="A. General Cargo" DataFieldY="Col_0" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#5c6bc0" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="C. Valuable Cargo" DataFieldY="Col_1" Stacked="true">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#26c6da" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="D. Dangerous Cargo" DataFieldY="Col_2" Stacked="true">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#9ccc65" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="E. Perishable Cargo" DataFieldY="Col_3" Stacked="true" Gap="1.5" Spacing="0.4">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#ffa726" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="F. Courier - SAP" DataFieldY="Col_4" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#8d6e63" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="G. Courier - MAP" DataFieldY="Col_5" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ff7043" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="H. Courier - LAP" DataFieldY="Col_6" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#78909c" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="I. Courier - NSAP" DataFieldY="Col_7" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ef5350" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="J. Courier - NMAP" DataFieldY="Col_8" Stacked="true">
                                                         <Appearance>
                                                            <FillStyle BackgroundColor="#ec407" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>
                                                    <telerik:BarSeries Name="K. Courier - NLAP" DataFieldY="Col_9" Stacked="true">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ab47bc" />
                                                        </Appearance>
                                                        <LabelsAppearance DataFormatString="{0}" Position="OutsideEnd" Visible="false"></LabelsAppearance>
                                                        <TooltipsAppearance DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:BarSeries>--%>
                                                </Series>
                                                <Appearance>
                                                    <FillStyle BackgroundColor="White" />
                                                </Appearance>
                                                <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside" Reversed="false">
                                                    <LabelsAppearance DataFormatString="{0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                                    <TitleAppearance Position="Center" RotationAngle="0" Text="City">
                                                    </TitleAppearance>
                                                </XAxis>
                                                <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                                                    MinorTickType="None" Reversed="false">
                                                    <LabelsAppearance DataFormatString="{0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                                    <TitleAppearance Position="Center" RotationAngle="0" Text="Weight (Kilos)">
                                                    </TitleAppearance>
                                                </YAxis>
                                            </PlotArea>
                                            <Appearance>
                                                <FillStyle BackgroundColor="White"></FillStyle>
                                            </Appearance>
                                            <Legend>
                                                <Appearance BackgroundColor="White" Position="Right" Visible="true">
                                                </Appearance>
                                            </Legend>
                                        </telerik:RadHtmlChart>
                                    </div>
                                    </telerik:RadAjaxPanel>
                                </div>
                            </div>
                        </div>
                    </div>
                
                </div>     
        </div><!--container-->
    </div><!--page-wrapper-->
</div><!--wrapper-->


</asp:Content>
