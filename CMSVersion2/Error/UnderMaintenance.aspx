<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnderMaintenance.aspx.cs" Inherits="CMSVersion2.Error.UnderMaintenance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Under Maintenance</title>
     <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
</head>
<body>
    <form runat="server">
        <telerik:RadScriptManager runat="server"></telerik:RadScriptManager>
       
         <div class="container">
 <div runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <img runat="server" src="~/Images/logo1.png" class="imageLogo"/>
                </div>
                
            </div>
            </div><!--wrapper-->
        </div><!--container-->

        <div class="container body-content">
           
           <div class="wrapper">
    <div id="page-wrapper">
        <div class="container"><br/><br/><br/><br/><br/>
            <div class="text-center">
            <img src="../images/APCARGO-Logo.jpg" alt="AP Cargo Logo" height="100" width="300"/>
            <br/>
            <br/>
            <h3 style="font-style:italic" class="subtitle">We're working hard to launch our website and we'll be ready very soon.</h3>
            <h4 >This page is under maintenance.</h4>
            </div>
            <br/><br/><br/><br/><br/>
            <br/><br/><br/><br/><br/>
            <div class="text-center">
                <h5>Copyright © 2017 - ApCargo - CMS Web 2.0</h5>
            </div>
        </div>
    </div>
</div>
        </div>
       
    </form>
</body>
</html>
