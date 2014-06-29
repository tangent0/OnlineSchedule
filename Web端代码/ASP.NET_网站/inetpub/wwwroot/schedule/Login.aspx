<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebStation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台登陆</title>
<style type="text/css">
<!--
body {
	margin: 0px;
	
}
#loginBg{ background:url('images/loginBG.jpg') left top; 
width:1004px; 
height:568px; 
        margin-left: auto;
        margin-right: auto;
        margin-bottom: 0;
    }
    .style1
    {
        width: 160px;
    }
-->
</style>
</head>
<body>
    <form id="form1" runat="server" >
<div id="loginBg">
  <table style="margin-top:208px"width="300" border="0" align="right">
    <tr>
      <td height="35" align="right" class="style1"><asp:TextBox ID="txtUserName" runat="server" Width="155px"></asp:TextBox><td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage="请请输入登录名">*</asp:RequiredFieldValidator></td>
                </td>
    </tr>
    <tr>
      <td height="35" align="right" class="style1"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox><td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="请请输入密码">*</asp:RequiredFieldValidator></td>
                </td>
    </tr>
    <tr>
      <td height="35" class="style1"> <asp:Button ID="btnLogin" runat="server" CssClass="Submit" Text="登陆" OnClick="btnLogin_Click" /></td>
      <td>
         </td>
    </tr>
  </table>
</div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
                
    </form>
</body>
</html>