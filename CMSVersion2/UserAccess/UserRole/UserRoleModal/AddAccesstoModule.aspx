<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccesstoModule.aspx.cs" Inherits="CMSVersion2.UserAccess.UserRole.UserRoleModal.AddAccesstoModule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #footer {
        position: fixed;
        right:10px;
        bottom: 10px;
   
        }

        .page{
        margin-top: 30px;
        }

        .errorMessage
        {
        position: fixed;
        top:auto;
        right:50px;
        bottom: 50px;
        left:130px;
        }

        .fieldset-auto-width {
        display: inline-block;
        }

        .left-div {
        float: left;
           
        }

        .right-div1,.right-div2,.right-div3 {
        margin-left:10px;
        }   

       
        #container>div, #container1>div {
        vertical-align: top;
        display: inline-block;
        }

        .disabledTreeview {
        pointer-events: none;
        cursor: default;
        }

        .treeviewWebColor
        {
            color:black !important;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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

$(function () {
        $("[id*=treeViewWeb] input[type=checkbox]").bind("click", function () {
            var table = $(this).closest("table");
            if (table.next().length > 0 && table.next()[0].tagName == "DIV") {
                //Is Parent CheckBox
                var childDiv = table.next();
                var isChecked = $(this).is(":checked");
                $("input[type=checkbox]", childDiv).each(function () {
                    if (isChecked) {
                        $(this).attr("checked", "checked");
                    } else {
                        $(this).removeAttr("checked");
                    }
                });
            } else {
                //Is Child CheckBox
                var parentDIV = $(this).closest("DIV");
                if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {
                    $("input[type=checkbox]", parentDIV.prev()).attr("checked", "checked");
                } else {
                    $("input[type=checkbox]", parentDIV.prev()).removeAttr("checked");
                }
            }
        });
    })


    </script>
</head>
<body>
  <form id="form1" runat="server" >
        <div>
            <script type="text/javascript">
                function CloseAndRebind(args) {
                    GetRadWindow().BrowserWindow.refreshGrid(args);
                    GetRadWindow().close();
                }

                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                    return oWindow;
                }

                function CancelEdit() {
                    GetRadWindow().close();
                }
            </script>
            <asp:ScriptManager ID="ScriptManager2" runat="server" />
            <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" Skin="Default" DecoratedControls="All" />
            <div class="">
            <%--<form method="post" action="#">--%>
                 <asp:HiddenField ID="lblUserID" runat="server" Visible="true"></asp:HiddenField>
                
                <div id="container1">
                        <telerik:RadLabel ID="RadLabel2" runat="server" Text="Employee Name:"></telerik:RadLabel>
                        <telerik:RadTextBox Skin="Glow" Width="230px" RenderMode="Mobile" ID="txtFullName" runat="server" Enabled="false"></telerik:RadTextBox>
                  
                    <telerik:RadLabel ID="lblCanLogin" runat="server" Text="Can Login Through:"></telerik:RadLabel>
                        <telerik:RadTextBox Skin="Glow"  Width="230px" Height="100" TextMode="Multiline" RenderMode="Mobile" ID="txtLoginLabel" runat="server" Enabled="false"></telerik:RadTextBox>
                     <%-- <div>
                        <telerik:RadLabel ID="lblCanLogin" runat="server" Text="Can Login Through:"></telerik:RadLabel>
                        <telerik:RadTextBox  Width="230px" Height="100" TextMode="Multiline" RenderMode="Mobile" ID="txtLoginLabel" runat="server"></telerik:RadTextBox>
                    </div>--%>
                   <%-- <div>
                        <telerik:RadLabel ID="RadLabel1" runat="server" Text="Roles:"></telerik:RadLabel>
                        <telerik:RadTextBox  Width="230px" Height="100" TextMode="Multiline" RenderMode="Mobile" ID="RadTextBox1" runat="server"></telerik:RadTextBox>
                    </div>--%>
                     
                </div>
                    <div class="page" id="container">
                        <div>
                           <fieldset class="fieldset-auto-width left-div" id="fsWeb" runat="server">
                               <legend>Web</legend>
                               <asp:TreeView ID="treeViewWeb" runat="server" ShowCheckBoxes="All" OnTreeNodeCheckChanged="treeViewWeb_TreeNodeCheckChanged" CssClass="treeviewWebColor" NodeStyle-ForeColor="Black" NodeStyle-Font-Names="Arial"></asp:TreeView>
                                <%--<telerik:RadCheckBoxList runat="server" ID="chklistWeb" AutoPostBack="false"></telerik:RadCheckBoxList>--%>
                           </fieldset>
                        </div>

                         <div>
                             <fieldset class="fieldset-auto-width" id="fsClient" runat="server">
                               <legend>Client</legend>
                                <telerik:RadCheckBoxList runat="server" ID="chklistClient" AutoPostBack="false"></telerik:RadCheckBoxList>
                           </fieldset>
                          
                        </div>
                        <div>
                             <fieldset class="fieldset-auto-width" id="fsTnT" runat="server">
                               <legend>Track and Trace</legend>
                                <telerik:RadCheckBoxList runat="server" ID="chklistTnt" AutoPostBack="false"></telerik:RadCheckBoxList>
                           </fieldset>
                          
                        </div>
                        <div>
                             <fieldset class="fieldset-auto-width" id="fsMobile" runat="server">
                               <legend>Mobile</legend>
                                <telerik:RadCheckBoxList runat="server" ID="chklistMobile" AutoPostBack="false"></telerik:RadCheckBoxList>
                           </fieldset>
                          
                        </div>

                      
                    </div>


                    
                  <div id="footer">
                 <%--<telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></telerik:RadButton>--%>
                      <telerik:RadButton ID="RadButton1" runat="server" Text="Save" OnClick="RadButton1_Click"></telerik:RadButton>
                 <telerik:RadButton ID="btnCancel" runat="server" AutoPostBack="true" Text="Cancel" OnClick="btnCancel_Click"></telerik:RadButton>
                </div>
               
               
          <%--  </form>--%>


        </div>



           
            <br />
        </div>
    </form>
</body>
</html>
