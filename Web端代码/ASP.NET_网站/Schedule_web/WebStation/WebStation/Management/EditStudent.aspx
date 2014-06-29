<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="WebStation.Management.EditStudent" %>
<%@ Register Assembly="DevControl" Namespace="DevControl" TagPrefix="Dev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Common/common_js.js" type="text/javascript"></script>
    <script src="../Editor/xheditor-zh-cn.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    学生信息编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    学生信息编辑
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
<table class="add_table" width="100%">
    <tr>
        <td width="90">学号</td>
        <td>
            <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbId" ErrorMessage="请填写学号">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td width="90">姓名</td>
        <td>
            <asp:TextBox ID="tbName" runat="server" ></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td width="90">所在班级</td>
        <td>

            <Dev:DropDownCheckBoxList ID="cbClass" runat="server" DataValueField="Classno" DataTextField="ClassName" ShowSelectAllOption="true"
                DisplayMode="Label" Width="320px">
            </Dev:DropDownCheckBoxList>
            
        </td>
    </tr>
    <tr>
        <td width="90">联系电话</td>
        <td>
            <asp:TextBox ID="tbPhone" runat="server" ></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td width="90">邮箱</td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server" ></asp:TextBox>
            
        </td>
    </tr>
    
    <tr>
        <td width="90">&nbsp;</td>
        <td>
            <asp:Button ID="btnDo" runat="server" Text="执行操作" OnClick="btnDo_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
</table>
</asp:Content>
