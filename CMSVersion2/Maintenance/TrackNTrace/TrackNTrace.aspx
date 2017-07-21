<%@ Page Title="Track N Trace" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackNTrace.aspx.cs" Inherits="CMSVersion2.Maintenance.TrackNTrace.TrackNTrace" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("Are you sure you want to submit the page?"));
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
       <!--- PAGE HEADER--->
    <div class="row">
        <h3><i class="glyphicon glyphicon-eye-open"></i> TRACK N TRACE</h3>
        <ol class="breadcrumb">
            <li>Maintenance</li>
            <li>Track N Trace</li>
        </ol>
    </div>

    <%-- BranchAcceptance - BATCH--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_BA_Batch" Height="300px" Width="400px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_BA_Batch" Height="350px" Width="380px">
    </telerik:RadWindow>

     <%-- BranchAcceptance - REMARKS--%>
     <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_BA_Remarks" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_BA_Remarks" Height="350px" Width="380px">
    </telerik:RadWindow>
   
     <%-- Gateway Transmittal - BATCH--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_GT_Batch" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_GT_Batch" Height="350px" Width="380px">
    </telerik:RadWindow>

     <%-- Gateway Outbound - BATCH--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_GO_Batch" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_GO_Batch" Height="350px" Width="380px">
    </telerik:RadWindow>

      <%-- Gateway Outbound - REMARKS--%>
     <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_GO_Remarks" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_GO_Remarks" Height="350px" Width="380px">
    </telerik:RadWindow>

       <%-- Gateway Inbound - REMARKS--%>
     <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_GI_Remarks" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_GI_Remarks" Height="350px" Width="380px">
    </telerik:RadWindow>

      <%-- Gateway Transmittal - Airlines--%>
     <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_GT_Airlines" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_GT_Airlines" Height="350px" Width="380px">
    </telerik:RadWindow>

     <%-- Gateway Outbound - Airlines--%>
     <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_GO_Airlines" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_GO_Airlines" Height="350px" Width="380px">
    </telerik:RadWindow>

       <%-- Cargo Transfer - BATCH--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_CT_Batch" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_CT_Batch" Height="350px" Width="380px">
    </telerik:RadWindow>

      <%-- Segregation - BATCH--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_SG_Batch" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_SG_Batch" Height="350px" Width="380px">
    </telerik:RadWindow>

     <%-- Segregation - REMARKS--%>
     <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_SG_Remarks" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_SG_Remarks" Height="350px" Width="380px">
    </telerik:RadWindow>


       <%-- Distribution - BATCH--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_DIS_Batch" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_DIS_Batch" Height="350px" Width="380px">
    </telerik:RadWindow>

         <%-- Cargo Transfer - Airlines--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_CT_Airlines" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_CT_Airlines" Height="350px" Width="380px">
    </telerik:RadWindow>

          <%-- Cargo Transfer - Status--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_CT_Status" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_CT_Status" Height="350px" Width="380px">
    </telerik:RadWindow>

      <%-- Hold Cargo - Status--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_HC_Status" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_HC_Status" Height="350px" Width="380px">
    </telerik:RadWindow>
 
         <%-- Cargo transfer - Reason--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_CT_Reason" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_CT_Reason" Height="350px" Width="380px">
    </telerik:RadWindow>

          <%--Hold Cargo - Reason--%>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwAdd_HC_Reason" Height="300px" Width="350px">
    </telerik:RadWindow>
    <telerik:RadWindow RenderMode="Lightweight" Behaviors="Close" runat="server" ID="rwEdit_HC_Reason" Height="350px" Width="380px">
    </telerik:RadWindow>
 

    <%--<asp:Button ID="Button4" Text="open the RadWindow from the server" runat="server" OnClick="Button4_Click" />--%>
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container">

                <div class="container-fluid">
                    <br />

                    <div class="col-md-2" style="text-align: right">Branch Acceptance</div>

                    <div class="col-md-2" style="text-align: right">Batch</div>

                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBA_Batch" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnBA_Batch_Add" Skin="Glow" OnClick="btnBA_Batch_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnBA_Batch_Edit" Skin="Glow"  OnClick="btnBA_Batch_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnBA_Batch_Delete" Skin="Glow" OnClick="btnBA_Batch_Delete_Click" runat="server" Text="DELETE"
                            OnClientClicking="StandardConfirm">
                        </telerik:RadButton>

                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>

                    <div class="col-md-2" style="text-align: right">Remarks</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBA_Remarks" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnBA_Remarks_Add" runat="server" Skin="Glow" OnClick="btnBA_Remarks_Add_Click" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnBA_Remarks_Edit" runat="server" Skin="Glow" OnClick="btnBA_Remarks_Edit_Click" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnBA_Remarks_Delete" runat="server" Skin="Glow" OnClick="btnBA_Remarks_Delete_Click" OnClientClicking="StandardConfirm" Text="DELETE"></telerik:RadButton>
                    </div>

                    <br />
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Gateway Transmittal</div>
                    <div class="col-md-2" style="text-align: right">Batch</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGT_Batch" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnGT_Batch_Add" runat="server" Skin="Glow" OnClick="btnGT_Batch_Add_Click" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnGT_Batch_Edit" runat="server" Skin="Glow" OnClick="btnGT_Batch_Edit_Click" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnGT_Batch_Delete" runat="server" Skin="Glow" OnClick="btnGT_Batch_Delete_Click" OnClientClicking="StandardConfirm" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Destination</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGT_Destination" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGT_Destination_Add" runat="server" Skin="Glow" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="btnGT_Destination_Edit" runat="server" Skin="Glow" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="btnGT_Destination_Delete" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" Text="DELETE" Enabled="false"></telerik:RadButton>
                    </div>
                    <br />
                    <br />


                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Airlines</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGT_Airlines" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">
                        <telerik:RadButton ID="btnGT_Airlines_Add" Skin="Glow"  OnClick="btnGT_Airlines_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnGT_Airlines_Edit" Skin="Glow" OnClick="btnGT_Airlines_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnGT_Airlines_Delete" Skin="Glow" OnClick="btnGT_Airlines_Delete_Click" runat="server" OnClientClicking="StandardConfirm" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Commodity Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCommodityType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton1" runat="server" Skin="Glow" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton2" runat="server" Skin="Glow" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton3" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" Enabled="false" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Gateway Outbound:</div>
                    <div class="col-md-2" style="text-align: right">Batch</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGO_Batch" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGO_Batch_Add" Skin="Glow" OnClick="btnGO_Batch_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnGO_Batch_Edit" Skin="Glow"  OnClick="btnGO_Batch_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnGO_Batch_Delete" Skin="Glow" OnClick="btnGO_Batch_Delete_Click" runat="server" OnClientClicking="StandardConfirm" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Remarks</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGO_Remarks" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGO_Remarks_Add" Skin="Glow" OnClick="btnGO_Remarks_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnGO_Remarks_Edit" Skin="Glow" OnClick="btnGO_Remarks_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnGO_Remarks_Delete" Skin="Glow"  OnClick="btnGO_Remarks_Delete_Click" runat="server" OnClientClicking="StandardConfirm" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right"></div>

                    <div class="col-md-2" style="text-align: right">Airlines</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGO_Airlines" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGO_Airlines_Add" Skin="Glow"  OnClick="btnGO_Airlines_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnGO_Airlines_Edit" Skin="Glow" OnClick="btnGO_Airlines_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnGO_Airlines_Delete" Skin="Glow" OnClick="btnGO_Airlines_Delete_Click" runat="server" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                                        <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Commodity Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGO_CommodityType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton4" runat="server" Skin="Glow" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton5" runat="server" Skin="Glow" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton6" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" Enabled="false" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                      <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Ship Mode</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbShipMode" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                         <telerik:RadButton ID="RadButton7" runat="server" Skin="Glow" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton8" runat="server" Skin="Glow" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton9" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" Enabled="false" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <br />

                    <div class="col-md-2" style="text-align: right">Gateway Inbound:</div>
                
                    <div class="col-md-2" style="text-align: right">Remarks</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGI_Remarks" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGI_Remarks_Add" Skin="Glow" OnClick="btnGI_Remarks_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnGI_Remarks_Edit" Skin="Glow" OnClick="btnGI_Remarks_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnGI_Remarks_Delete" Skin="Glow" OnClick="btnGI_Remarks_Delete_Click" runat="server" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Origin</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGI_Origin" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnGI_Origin_Add" Skin="Glow" runat="server" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="btnGI_Origin_Edit" Skin="Glow" runat="server" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="btnGI_Origin_Delete" Skin="Glow" runat="server" Text="DELETE" Enabled="false"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                                            <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Commodity Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGI_CommodityType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton10" runat="server" Skin="Glow" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton11" runat="server" Skin="Glow" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton12" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" Enabled="false" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                      <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Ship Mode</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbGI_ShipMode" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                         <telerik:RadButton ID="RadButton13" runat="server" Skin="Glow" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton14" runat="server" Skin="Glow" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton15" runat="server" Skin="Glow" OnClientClicking="StandardConfirm" Enabled="false" Text="DELETE"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    
                    <br />
                    <div class="col-md-2" style="text-align: right">Segregation</div>
                    <div class="col-md-2" style="text-align: right">Commodity Type</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbSG_CommodityType" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnSG_CommodityType_Add" Skin="Glow" runat="server" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="btnSG_CommodityType_Edit" Skin="Glow" runat="server" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="btnSG_CommodityType_Delete" Skin="Glow" runat="server" Text="DELETE" Enabled="false"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Batch</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbSG_Batch" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnSG_Batch_Add" Skin="Glow" OnClick="btnSG_Batch_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnSG_Batch_Edit" Skin="Glow" OnClick="btnSG_Batch_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnSG_Batch_Delete" Skin="Glow" OnClick="btnSG_Batch_Delete_Click" runat="server" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Remarks</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbSG_Remarks" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnSG_Remarks_Add" Skin="Glow" OnClick="btnSG_Remarks_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnSG_Remarks_Edit" Skin="Glow" OnClick="btnSG_Remarks_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnSG_Remarks_Delete" Skin="Glow" OnClick="btnSG_Remarks_Delete_Click" runat="server" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Distribution:</div>
                    <div class="col-md-2" style="text-align: right">Batch</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbDIS_Batch" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnDIS_Batch_Add" Skin="Glow" OnClick="btnDIS_Batch_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnDIS_Batch_Edit" Skin="Glow" OnClick="btnDIS_Batch_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnDIS_Batch_Delete" Skin="Glow" OnClick="btnDIS_Batch_Delete_Click" runat="server" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Cargo Transfer:</div>
                    <div class="col-md-2" style="text-align: right">Batch</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCT_Batch" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCT_Batch_Add" Skin="Glow" OnClick="btnCT_Batch_Add_Click" runat="server" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Batch_Edit" Skin="Glow" OnClick="btnCT_Batch_Edit_Click" runat="server" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Batch_Delete" Skin="Glow" OnClick="btnCT_Batch_Delete_Click" runat="server" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                     <div class="col-md-2" style="text-align: right"></div>
                     <div class="col-md-2" style="text-align: right">Status</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCT_Status" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCT_Status_Add" Skin="Glow" runat="server" OnClick="btnCT_Status_Add_Click" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Status_Edit" Skin="Glow" runat="server" OnClick="btnCT_Status_Edit_Click" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Status_Delete" Skin="Glow" runat="server" OnClick="btnCT_Status_Delete_Click" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />


                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Reason</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCT_Reason" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCT_Reason_Add" Skin="Glow" runat="server" Text="ADD" OnClick="btnCT_Reason_Add_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Reason_Edit" Skin="Glow" runat="server" Text="EDIT" OnClick="btnCT_Reason_Edit_Click"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Reason_Delete" Skin="Glow" runat="server" Text="DELETE" OnClick="btnCT_Reason_Delete_Click" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Airlines</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbCT_Airlines" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnCT_Airlines_Add" Skin="Glow" runat="server" OnClick="btnCT_Airlines_Add_Click" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Airlines_Edit" Skin="Glow" runat="server" OnClick="btnCT_Airlines_Edit_Click" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnCT_Airlines_Delete" Skin="Glow" runat="server" OnClick="btnCT_Airlines_Delete_Click" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Hold Cargo</div>
                    <div class="col-md-2" style="text-align: right">Status</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbHC_Status" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnHC_Status_Add" Skin="Glow" runat="server" OnClick="btnHC_Status_Add_Click" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnHC_Status_Edit" Skin="Glow" runat="server" OnClick="btnHC_Status_Edit_Click" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnHC_Status_Delete" Skin="Glow" runat="server" OnClick="btnHC_Status_Delete_Click" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right"></div>
                    <div class="col-md-2" style="text-align: right">Reason</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbHC_Reason" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="btnHC_Reason_Add" Skin="Glow" runat="server" OnClick="btnHC_Reason_Add_Click" Text="ADD"></telerik:RadButton>
                        <telerik:RadButton ID="btnHC_Reason_Edit" Skin="Glow" runat="server" OnClick="btnHC_Reason_Edit_Click" Text="EDIT"></telerik:RadButton>
                        <telerik:RadButton ID="btnHC_Reason_Delete" Skin="Glow" runat="server" OnClick="btnHC_Reason_Delete_Click" Text="DELETE" OnClientClicking="StandardConfirm"></telerik:RadButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-md-2" style="text-align: right">Bundling</div>
                    <div class="col-md-2" style="text-align: right">Destination</div>
                    <div class="col-md-2">
                        <telerik:RadComboBox ID="rcbBund_Destination" Skin="Glow" runat="server"></telerik:RadComboBox>
                    </div>
                    <div class="col-md-4">

                        <telerik:RadButton ID="RadButton25" Skin="Glow" runat="server" Text="ADD" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton26" Skin="Glow" runat="server" Text="EDIT" Enabled="false"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton27" Skin="Glow" runat="server" Text="DELETE" Enabled="false"></telerik:RadButton>
                    </div>
                    <br />
                    <br />

                    <br />
                    <br />

                </div>
            </div>

        </div>


    </div>

</asp:Content>
