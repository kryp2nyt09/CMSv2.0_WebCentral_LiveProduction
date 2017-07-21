<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMSVersion2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="overflow-x:hidden;overflow-y:hidden;">
<head runat="server">
     <title>AP Cargo - Web v2.0</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <link rel="shortcut icon" type="image/x-icon" href="Images/emblem.png" />

    <!-- Bootstrap Core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>

    <!-- Custom CSS -->
    <link href="Content/full-slider.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .LoginControl
        {
        background-color:#F7F7DE;
        border-color:#CCCC99;
        border-style:solid;
        border-width:1px;
        font-family:Verdana;
        font-size:10px;    
        }

        .fontColor
        {
            color:white;
        }

        /*table, th, td {
        border: 1px solid black;
        }*/

        .cellValue{
        vertical-align:middle;
        margin-top:-20px;
        }
</style>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.js"></script>
     <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="container">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>

                     <a class="navbar-brand" href="#"> 
                         <img src="Images/logo1.png" runat="server" height="50" width="157" />
                     </a>

                </div><!--navbar-header-->

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" style="text-align: right">
                    <%--<form name="sentMessage" id="login-form" novalidate="novalidate" runat="server">--%>
                        <form id="form1" runat="server">
                        <br />
                        <ul class="nav navbar-nav navbar-right">
                           <li>
            <asp:Login ID="Login1" runat="server" DisplayRememberMe="false" OnAuthenticate="btnSubmit_Click">
            <LayoutTemplate>
                <table style="border-collapse:collapse;  padding: 100px;">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="fontColor">UserName</asp:Label>

                                    </th>
                                    <th>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="fontColor">Password</asp:Label>
                                    </th>
                                    <th><asp:Label ID="Label1" runat="server" CssClass="fontColor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Width="160px" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                     <td>
                                         
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="160px" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                     <td>
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Login" ValidationGroup="Login1" class="btn btn-xl cellValue"/>
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
                            
                            </li>
                        </ul><!--ul-->
                    </form>
                   
                </div><!--collapse-->
                <br />

            </div><!--container-->
        </nav><!--nav-->

         <!-- Full Page Image Background Carousel Header -->
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol><!--ol-->

            <!-- Wrapper for Slides -->
            <div class="carousel-inner">
                <div class="item active">
                     <!-- Set the first background image using inline CSS below. -->
                    <div class="fill" style="background-image: url('http://apcargo.com.ph/images/banners/01-b-keyvisual-home-big-v2.jpg');"></div>
                    <%--<img src="Images/item1.jpg" alt="Item 1"/>--%> 
                    <div class="carousel-caption">
                        <%--<h2>Caption 1</h2>--%>
                    </div>
                </div><!--item 1-->

                <div class="item">
                    <!-- Set the second background image using inline CSS below. -->
                    <div class="fill" style="background-image: url('http://apcargo.com.ph/images/banners/01-d-keyvisual-home-big-1.jpg');"></div>
                    <%--<img src="Images/item2.jpg" alt="Item 1"/>--%> 
                    <div class="carousel-caption">
                        <%--<h2>Caption 2</h2>--%>
                    </div>
                </div><!--item 2-->

                <div class="item">
                    <!-- Set the third background image using inline CSS below. -->
                    <div class="fill" style="background-image: url('http://apcargo.com.ph/images/banners/partnership-home-banner.jpg');"></div>
                    <%--<img src="Images/item3.jpg" alt="Item 1"/>--%> 
                    <div class="carousel-caption">
                        <%--<h2>Caption 3</h2>--%>
                    </div>
                </div><!--item 3-->
            </div><!--carousel-inner-->
            
            <!-- Controls -->
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="icon-prev"></span>
            </a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="icon-next"></span>
            </a>
        </div><!--header-->

        <!-- Page Content -->
        <hr/>
        <footer>
            <div class="row" style="text-align: center">
                <div class="col-lg-12">
                    <p>Copyright &copy; APCargo 2016</p>
                </div>
            </div><!-- /.row -->
        </footer>

        <!-- Script to Activate the Carousel -->
       <!-- jQuery -->
     <%--   <script src="Scripts/jquery.js"></script>
        
        <!-- Bootstrap Core JavaScript -->
        <script src="Scripts/bootstrap.min.js"></script>--%>
        

        <!-- Script to Activate the Carousel -->
        <script>
            $('.carousel').carousel({
                interval: 3000 //changes the speed
            })
    </script>

    <%--</form>--%>
</body>
</html>
