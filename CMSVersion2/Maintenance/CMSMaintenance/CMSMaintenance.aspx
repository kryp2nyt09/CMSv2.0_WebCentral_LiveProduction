<%@ Page Title="CMS Maintenance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMSMaintenance.aspx.cs" Inherits="CMSVersion2.Maintenance.CMSMaintenance.CMSMaintenance" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("Are you sure you want to delete this?"));
        }

        function RefreshParentPage()//function in parent page
        {
            document.location.reload();
        }
    </script>

    <style>
        div.RadUpload .ruBrowse {
            background-position: 0 -23px;
            width: 180px;
            height: 30px;
        }

        div.RadUpload_Default .ruFileWrap .ruButtonHover {
            background-position: 100% -23px !important;
        }
    </style>


    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="RadWindow1" VisibleStatusbar="false" Title="Update Group Island" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="RadWindowRegion" Title="Update Region" VisibleStatusbar="false" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwAddGroupIsland" VisibleStatusbar="false" Title="New Group Island"  Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwAddregion" Title="New Region" VisibleStatusbar="false" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwProvinceEdit" Title="Update Province" VisibleStatusbar="false" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwProvinceAdd" VisibleStatusbar="false" Title="New Province" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwBranchCodeEdit" VisibleStatusbar="false" Title="Update Branch Corp Office" Height="380px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwBranchCodeAdd" VisibleStatusbar="false" Title="New Branch Corp Office" Height="380px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwClusterAdd" VisibleStatusbar="false" Title="New Cluster" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwClusterEdit" VisibleStatusbar="false" Title="Update Cluster" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwCityAdd" Title="New City" Height="550px" Width="380px" VisibleStatusbar="false">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwCityEdit" Title="Update City" Height="550px" Width="380px" VisibleStatusbar="false">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwAreaAdd" Title="New Area" Height="450px" Width="380px" VisibleStatusbar="false">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwAreaEdit" Title="Update Area" Height="450px" Width="380px" VisibleStatusbar="false">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwBranchSatOfficeAdd" Title="New BSO" VisibleStatusbar="false" Height="380px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwBranchSatOfficeEdit" Title="Update BSO" VisibleStatusbar="false" Height="380px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwGatewaySayOfficeAdd" VisibleStatusbar="false" Title="New GSO" Height="380px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwGatewaySayOfficeEdit" VisibleStatusbar="false"  Title="Update GSO" Height="380px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwRUTAdd" Title="New Revenue Unit Type" VisibleStatusbar="false" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwRUTEdit" Title="Update Revenue Unit Type" VisibleStatusbar="false"  Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwApplicablerateAdd" Title="New Applicable Rate" VisibleStatusbar="false" Height="430px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwApplicablerateEdit" Title="Udpate Applicable Rate" VisibleStatusbar="false" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwCommodityTypeEdit" Title="Update Commodity Type" VisibleStatusbar="false" Height="430px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwCommodityTypeAdd" Title="New Commodity Type" VisibleStatusbar="false" Height="430px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwCommodityAdd" Title="New Commidity" VisibleStatusbar="false" Height="350px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" Behaviors="Close" runat="server" ID="rwCommodityEdit" Title="Update Commodity" VisibleStatusbar="false"  Height="350px" Width="380px">
    </telerik:RadWindow>

    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwGoodsDescAdd" Title="New Description" Height="300px" Width="380px">
    </telerik:RadWindow>

    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwGoodsDescEdit" Title="Update Description" Height="300px" Width="380px">
    </telerik:RadWindow>

    
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwSBFAdd" Title="New SBF" Height="550px" Width="380px">
    </telerik:RadWindow>

    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwSBFEdit" Title="Update SBF" Height="550px" Width="380px">
    </telerik:RadWindow>

    
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwCratingAdd" Title="New Crating" Height="550px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwCratingEdit" Title="Update Crating" Height="550px" Width="380px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwPackagingAdd" Title="New Packaging" Height="550px" Width="380px">
    </telerik:RadWindow>
      <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwPackagingEdit" Title="Update Packaging" Height="550px" Width="380px">
    </telerik:RadWindow>

     <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwServiceTypeAdd" Title="New Service Type" Height="350px" Width="380px">
    </telerik:RadWindow>
     <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwServiceTypeEdit" Title="Update Service Type" Height="350px" Width="380px">
    </telerik:RadWindow>

      <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwServiceModeAdd" Title="New Service Mode" Height="550px" Width="380px">
    </telerik:RadWindow>

    
      <telerik:RadWindow RenderMode="Lightweight" Skin="Glow" VisibleStatusbar="false" Behaviors="Close" runat="server" ID="rwServiceModeEdit" Title="Update Service Mode" Height="550px" Width="380px">
    </telerik:RadWindow>
    <%--<asp:Button ID="Button4" Text="open the RadWindow from the server" runat="server" OnClick="Button4_Click" />--%>
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container">

                <div class="container">

               <div class="row">
                <h3><i class="glyphicon glyphicon-cog"></i> CMS MAINTENANCE</h3>
                <ol class="breadcrumb">
                    <li>Maintenance</li>
                    <li>CMS</li>                    
                </ol>
            </div>

                <div class="container-fluid">
                    <br />
                    <div class="col-md-2" style="text-align: right">Island Group</div>

                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbIslandGroup" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnIslandAdd" Skin="Glow" OnClick="btnIslandAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnIslandEdit" OnClick="btnIslandEdit_Click" Skin="Glow" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnIslandDelete" Skin="Glow" runat="server" Text="DELETE"
                            OnClientClicking="StandardConfirm" OnClick="btnIslandDelete_Click">
                        </telerik:RadButton>

                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Region</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbRegion" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnRegionAdd" runat="server" OnClick="btnRegionAdd_Click" Skin="Glow" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnRegionEdit" runat="server" OnClick="btnRegionEdit_Click" Skin="Glow" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnRegionDelete" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="btnRegionDelete_Click" Text="DELETE"></telerik:RadButton>
                    </div>

                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Province</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbProvince" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnProvinceAdd" runat="server" OnClick="btnProvinceAdd_Click" Skin="Glow" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnProvinceEdit" runat="server" OnClick="btnProvinceEdit_Click" Skin="Glow" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnProvinceDelete" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="btnProvinceDelete_Click" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right">Branch Corp Office</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBranchCorpOffice" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnBranchCorpAdd" runat="server" Skin="Glow" Text="ADD" OnClick="btnBranchCorpAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnBranchCorpEdit" runat="server" Skin="Glow" Text="EDIT" OnClick="btnBranchCorpEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnBranchCorpDelete" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="btnBranchCorpDelete_Click" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right">Cluster</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCluster" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnClusterAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnClusterAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnClusterEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnClusterEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnClusterDelete" Skin="Glow" runat="server" OnClientClicking="StandardConfirm" Text="DELETE" OnClick="btnClusterDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right">City</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCity" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCityAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnCityAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCityEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnCityEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCityDelete" Skin="Glow" runat="server" OnClientClicking="StandardConfirm" OnClick="btnCityDelete_Click" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />


                    <div class="col-md-2" style="text-align: right">Area</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbArea" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnAreaAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnAreaAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnAreaEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnAreaEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnAreaDelete" Skin="Glow" runat="server" OnClientClicking="StandardConfirm" Text="DELETE" OnClick="btnAreaDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />


                    <div class="col-md-2" style="text-align: right">Branch Sat Office</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBranchSatOffice" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnBranchSatOfficeADD" Skin="Glow" runat="server" Text="ADD" OnClick="btnBranchSatOfficeADD_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnBranchSatOfficeEDIT" Skin="Glow" runat="server" Text="EDIT" OnClick="btnBranchSatOfficeEDIT_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnBranchSatOfficeDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnBranchSatOfficeDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right">Gateway Sat Office</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGatewayOffice" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGatewayOfficeADD" Skin="Glow" runat="server" Text="ADD" OnClick="btnGatewayOfficeADD_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnGatewayOfficeEDIT" Skin="Glow" runat="server" Text="EDIT" OnClick="btnGatewayOfficeEDIT_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnGatewayOfficeDELETE" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnGatewayOfficeDELETE_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right">Revenue Unit Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbRevenue" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnRevenueAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnRevenueAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnRevenueEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnRevenueEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnRevenueDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnRevenueDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Applicable Rate</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbApplicableRate" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnApplicableRateADD" Skin="Glow" runat="server" Text="ADD" OnClick="btnApplicableRateADD_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnApplicableRateEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnApplicableRateEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnApplicableRateDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnApplicableRateDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Commodity Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCommodityType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCommodityTypeAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnCommodityTypeAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCommodityTypeEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnCommodityTypeEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCommodityTypeDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnCommodityTypeDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Commodity</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCommodity" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCommodityAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnCommodityAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCommodityEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnCommodityEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCommodityDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnCommodityDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Goods Description</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGoodsDescription" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGoodsDescAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnGoodsDescAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnGoodsDescEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnGoodsDescEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnGoodsDescDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnGoodsDescDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Shipment Basic Fee</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbShipmentBasicFee" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnSBFAdd" Skin="Glow" runat="server" Text="ADD" onclick="btnSBFAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnSBFEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnSBFEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnSBFDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" Onclick="btnSBFDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Crating</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCrating" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCratingAdd" Skin="Glow" runat="server" Text="ADD" onclick="btnCratingAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCratingEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnCratingEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCratingDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnCratingDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Packaging</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbPackaging" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnPackagingAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnPackagingAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnPackagingEdit" Skin="Glow" runat="server" Text="EDIT" Onclick="btnPackagingEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnPackagingDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnPackagingDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">TransShipment Routes</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbTransShipmentRoutes" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton16" Skin="Glow" runat="server" Text="ADD" Enabled ="false" ></telerik:RadButton>
                        <telerik:RadButton ID="RadButton17" Skin="Glow" runat="server" Text="EDIT" Enabled ="false" ></telerik:RadButton>
                        <telerik:RadButton ID="RadButton18" Skin="Glow" runat="server" Text="DELETE" Enabled ="false"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Service Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbServiceType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnServiceTypeAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnServiceTypeAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnServiceTypeEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnServiceTypeEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnServiceTypeDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnServiceTypeDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Service Mode</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbServiceMode" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnServiceModeAdd" Skin="Glow" runat="server" Text="ADD" OnClick="btnServiceModeAdd_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnServiceModeEdit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnServiceModeEdit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnServiceModeDelete" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="btnServiceModeDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Payment Mode</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbPaymentMode" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton25" Skin="Glow" OnClick="PaymentModeAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton26" Skin="Glow" OnClick="PaymentModeEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton27" Skin="Glow" runat="server" OnClientClicking="StandardConfirm" Text="DELETE" OnClick="PaymentModeDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Payment Term</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbPaymentTerm" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton28" Skin="Glow" OnClick="PaymentTermAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton29" Skin="Glow" OnClick="PaymentTermEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton30" Skin="Glow" runat="server" Text="DELETE" OnClientClicking="StandardConfirm" OnClick="PaymentTermDelete_Click"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Ship Mode</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbShipMode" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton31" Skin="Glow" OnClick="ShipModeAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton32" Skin="Glow" OnClick="ShipModeEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton33" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="ShipModeDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Booking Status</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBookingStatus" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton34" Skin="Glow"  OnClick="bookingStatusAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton35" Skin="Glow"  OnClick="bookingStatusEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton36" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="bookingStatusDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Booking Remark</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBookingRemarks" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton37" Skin="Glow"  OnClick="bookingRemarkAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton38" Skin="Glow" OnClick="bookingRemarkEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton39" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="bookingRemarkDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Delivery Status</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbDeliveryStatus" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton40" Skin="Glow" OnClick="DeliveryStatusAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton41" Skin="Glow" OnClick="DeliveryStatusEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton42" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="DeliveryStatusDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Delivery Remark</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbDeliverRemark" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton43" runat="server" OnClick="DeliveryRemarksAdd_Click" Skin="Glow" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton44" runat="server" OnClick="DeliveryRemarksEdit_Click" Skin="Glow" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton45" runat="server" OnClientClicking="StandardConfirm" OnClick="DeliveryRemarksDelete_Click" Skin="Glow" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Account Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbAccountType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton46" Skin="Glow" OnClick="AccountTypeAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton47" Skin="Glow" OnClick="AccountTypeEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton48" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="AccountTypeDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Acount Status</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbAccountStatus" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton49" Skin="Glow" OnClick="AccountStatusAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton50" Skin="Glow" OnClick="AccountStatusEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton51" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="AccountStatusDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Business Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBusinessType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton52" Skin="Glow" OnClick="BusinessTypeAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton53" Skin="Glow" OnClick="BusinessTypeEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton54" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="BusinessTypeDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Organization Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbOrganizationType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton55" Skin="Glow" OnClick="OrganizationTypeAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton56" Skin="Glow" OnClick="OrganizationTypeEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton57" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="OrganizationTypeDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Industry</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbIndustry" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton58" Skin="Glow" OnClick="IndustryAdd_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton59" Skin="Glow" OnClick="IndustryEdit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton60" Skin="Glow" OnClientClicking="StandardConfirm" OnClick="IndustryDelete_Click" runat="server" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Billing Period</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBillingPeriod" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton61" Skin="Glow" runat="server" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton62" Skin="Glow" runat="server" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton63" Skin="Glow" runat="server" Text="DELETE" Enabled="false"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                </div>
            </div>

        </div>
    </div>

    </div>
</asp:Content>
