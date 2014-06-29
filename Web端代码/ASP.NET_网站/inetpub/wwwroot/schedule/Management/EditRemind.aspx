<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.Master" AutoEventWireup="true" CodeBehind="EditRemind.aspx.cs" Inherits="WebStation.Management.EditRemind" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    重要提醒信息编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    重要提醒信息编辑
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
<table class="add_table" width="100%">
    <tr>
        <td width="90">序号</td>
        <td>
            <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
           
        </td>
    </tr>

    <tr>
        <td width="90">月份</td>
        <td>
            <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="90">日期</td>
        <td>
            <asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="90">提醒内容</td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server" Width="80%" ></asp:TextBox>
            
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
