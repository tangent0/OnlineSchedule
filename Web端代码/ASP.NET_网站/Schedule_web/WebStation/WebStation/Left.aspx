<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="WebStation.Left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>操作列表</title>
    <style type="text/css">
        body
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #000;
            background-color: #EEF2FB;
            margin: 0px;
        }
        #container
        {
            width: 182px;
        }
        #sideBar
        {
            width: 182px;
        }
        #sideBar h3
        {
            margin: 0;
            padding: 0;
            background: #fff url(images/menu_bg.gif) no-repeat;
            width: 182px;
            height: 27px;
            line-height: 27px;
        }
        #sideBar ul, #sideBar li
        {
            list-style: none;
            margin: 0;
            padding: 0;
        }
        #sideBar h3 a
        {
            display: block;
            text-align: center;
            width: 182px;
            height: 27px;
            line-height: 27px;
            color: #000;
            font-size: 12px;
            font-weight: bold;
            text-decoration: none;
        }
        #sideBar h3 a span
        {
            font-weight: normal;
        }
        #sideBar ul
        {
            background: #fff url(images/menu_topline.gif) top no-repeat;
            padding-top: 5px;
        }
        #sideBar ul li
        {
            width: 182px;
            height: 26px;
            line-height: 26px;
            background: #fff url(images/menu_bg2.gif) no-repeat;
        }
        #sideBar ul li a
        {
            display: block;
            width: 182px;
            height: 26px;
            line-height: 26px;
            color: #000;
            font-size: 12px;
            text-decoration: none;
            text-align: center;
        }
    </style>

    <script type="text/javascript" src="Common/common_js.js"></script>

    <script type="text/javascript">
        $(function () {
            var $sideBar = $("#sideBar");
            //var $side_item = $("ul.side_list");
            //$side_item.hide();
            $(":header").click(function () {
                $side_item.hide();
                $(this).parent().children(".side_list").toggle("fast");
            });
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="sideBar">
 
        <div class="side_item">
            <h3>
                <a href="##"><span>>>&nbsp;&nbsp;</span>课程表管理<span>&nbsp;&nbsp;<<</span></a></h3>
            <ul class="side_list">
                
                <li><a href="./Management/ManageStudent.aspx" target="main">学生管理</a></li>                  
                <li><a href="./Management/ManageClass.aspx" target="main">教学班管理</a></li>
                <li><a href="./Management/ManageRemind.aspx" target="main">重要提醒管理</a></li>
            </ul>
        </div>
        <!--
        <div class="side_item">
            <h3>
                <a href="##"><span>>>&nbsp;&nbsp;</span>信息管理<span>&nbsp;&nbsp;<<</span></a></h3>
            <ul class="side_list">
                <li><a href="Staff/User_Edit.aspx" target="main">修改信息</a></li>
                <li><a href="Staff/RePassword.aspx" target="main">修改密码</a></li>
            </ul>
        </div>
        -->
        <% if (string.Equals(UserInfo.LoginName,"admin",StringComparison.CurrentCultureIgnoreCase))
           { %>
        <div class="side_item">
            <h3>
                <a href="##"><span>>>&nbsp;&nbsp;</span>系统管理<span>&nbsp;&nbsp;<<</span></a></h3>
            <ul class="side_list">
                <li><a href="./Management/ManageTeacher.aspx" target="main">教师管理</a></li> 
            </ul>
        </div>
        <%} %>
        
        <%  %>
    </div>
    </form>
</body></html>
