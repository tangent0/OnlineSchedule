<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebStation.Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script type="text/javascript">
    function logout() {
    /*
        if (confirm("您确定退出后台管理吗？"))
            top.location = "LogOut.aspx";
            */

        if (confirm("您确定退出后台管理吗？"))
            top.location = "Login.aspx";

        return false;
    }
</script>
<script type="text/javascript" language="JavaScript1.2">
    function showsubmenu(sid) {
        var whichEl = eval("submenu" + sid);
        var menuTitle = eval("menuTitle" + sid);
        if (whichEl.style.display == "none") {
            eval("submenu" + sid + ".style.display=\"\";");
        } else {
            eval("submenu" + sid + ".style.display=\"none\";");
        }
    }
</script>
<meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
<meta http-equiv="refresh" content="60" />
<script language="JavaScript1.2" typ="text/javascript" >
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
</script>
<base target="main" />
<link href="images/skin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 600px;
        }
        .userName{ font-size:14px; font-weight:bold; color:#fff;}
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
<table width="100%" height="64" border="0" cellpadding="0" cellspacing="0" class="admin_topbg">
  <tr>
    <td valign="top" class="style1">
        <table>
            <tr>
                <td height="38">
                   <span class="userName">课程表管理系统&nbsp;&nbsp; --用户名： <asp:Literal ID="litUserName" runat="server"></asp:Literal></span>
                </td>
            </tr>
        </table>
    </td>
    <td height="64" align="right">
    <table width="100" border="0" align="right" cellpadding="0" cellspacing="0">
      <tr>
        <td width="18%" height="38" align="center"><a href="#" target="_self" onclick="logout();"><img src="images/out.gif" alt="" width="46" height="20" border="0" /></a></td>
      </tr>
      <tr>
        <td height="19">&nbsp;</td>
      </tr>
    </table>
   </td>
  </tr>
</table>
    </form>
</body>
</html>