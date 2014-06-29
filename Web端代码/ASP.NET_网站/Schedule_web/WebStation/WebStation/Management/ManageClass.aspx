<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.master" AutoEventWireup="true" CodeBehind="ManageClass.aspx.cs" Inherits="WebStation.Management.ManageClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    班级管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    班级管理
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
        <asp:GridView ID="grid" runat="server" CssClass="add_table" 
        Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Classno" HeaderText="班级编号">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField  DataField="ClassName" HeaderText="班级名称">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
           
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="false" 
                         OnCommand="lbtnEdit_Command"   CommandArgument='<%# Eval("Classno") %>' Text="编辑"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation="false" 
                    OnCommand="lbtnDel_Command"     CommandArgument='<%# Eval("Classno") %>' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程表" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnCourse" runat="server" CausesValidation="false" 
                         OnCommand="lbtnCourse_Command"  CommandArgument='<%# Eval("Classno") %>' Text="课程表"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
    <asp:Button ID="btnAdd" runat="server" CssClass="submit"  OnClick="btnAdd_Click" 
        Text="添加班级" />
    </p>
</asp:Content>
