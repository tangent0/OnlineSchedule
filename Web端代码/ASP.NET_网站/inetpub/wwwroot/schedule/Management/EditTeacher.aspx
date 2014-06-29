<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.master" AutoEventWireup="true" CodeBehind="EditTeacher.aspx.cs" Inherits="WebStation.Management.EditTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    编辑教师信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    编辑教师信息
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
    <table class="add_table" width="100%">
    <tr>
        <td width="90">工号</td>
        <td>
            <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbId" ErrorMessage="请填写教师工号">*</asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td width="90">姓名</td>
        <td>
            <asp:TextBox ID="tbName" runat="server" ></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td width="90">电话</td>
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
        <td width="90">住址</td>
        <td>
            <asp:TextBox ID="tbAddress" runat="server" ></asp:TextBox>
            
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
