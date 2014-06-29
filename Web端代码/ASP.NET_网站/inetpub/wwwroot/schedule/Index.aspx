<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebStation.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <frameset rows="64,*"  frameborder="NO" border="0" framespacing="0">
        <frame src="./Top.aspx" noresize="noresize" frameborder="NO" name="topFrame" scrolling="auto" marginwidth="0" marginheight="0" target="main" />
        <frameset cols="185,*"  rows="560,*" id="frame">
	        <frame src="./Left.aspx" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="0" scrolling="no" target="main" />
	        <frame src="./Base/Base.aspx" name="main" marginwidth="0" marginheight="0" frameborder="0" scrolling="auto" target="_self" />
        </frameset>
    </frameset>

</html>