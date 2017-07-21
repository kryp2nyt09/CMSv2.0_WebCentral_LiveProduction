<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="CMSVersion2.Customer.CustomerModal.AddCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">



function CloseOnReload() {
    GetRadWindow().Close();
    //var oWnd = GetRadWindow();
    //oWnd.close();
    //top.location.href = top.location.href;
}

function RefreshParentPage() {
    var oWnd = GetRadWindow();
    oWnd.close();
    window.radopen("../../Corporate/Company.aspx", "AddCorporateAccount");
    //top.location.href = top.location.href;
        
}

function GetRadWindow()
{
    if (window.radWindow) return window.radWindow; 
    else if (window.frameElement.radWindow) return window.frameElement.radWindow;
    return null;
}

function OpenWindow(obj)
        {
         setTimeout(function(){
								GetRadWindow().BrowserWindow.OpenWindow(obj,'AddRepresentative');
							},0
					);
        }

function OpenWindowCompany(obj)
        {
         setTimeout(function(){
								GetRadWindow().BrowserWindow.OpenWindowCompany(obj,'AddCorporateAccount');
							},0
					);
        }

function ShowCompanyForm(obj) {
   window.radopen("../../Corporate/CompanyModal/Add.aspx?ClientId=" + obj.value, "AddCorporateAccount");
   return false;
}

 function ShowInsertForm(obj) {
        window.radopen("../../Corporate/RepresentativeModal/Edit.aspx?ClientId=" + obj.value, "AddRepresentative");
        return false;
    }
</script>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
         <asp:HiddenField ID="lblClientId" runat="server" Visible="true"></asp:HiddenField>
    <div>
        <a href="javascript:void(0)" onclick="return OpenWindow(<%= lblClientId.ClientID %>);" class="alink">Add as Representative</a>
        <br />
        <a href="javascript:void(0)" onclick="return OpenWindowCompany(<%= lblClientId.ClientID %>);" class="alink">Add as Corporate Account</a>
    </div>

    <telerik:RadWindowManager RenderMode="Mobile" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Mobile" ID="AddCorporateAccount" runat="server" Title="Adding record" Height="600px"
            Width="880px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
            Modal="true" Behaviors="Close,Move"  >
            </telerik:RadWindow>
            
            <telerik:RadWindow RenderMode="Mobile" ID="AddRepresentative" runat="server" Title="Adding record" Height="650px"
                Width="1000px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" VisibleStatusbar ="false" AutoSize="false"
                Modal="true" Behaviors="Close,Move"  >
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    </form>

   
</body>
</html>
