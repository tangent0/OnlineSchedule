<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.master" AutoEventWireup="true" CodeBehind="ManageTeacher.aspx.cs" Inherits="WebStation.Management.ManageTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    教师信息管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    教师信息管理
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
    <asp:GridView ID="grid" runat="server" CssClass="add_table" 
        Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TeacherNo" HeaderText="工号">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField  DataField="Name" HeaderText="姓名">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField  DataField="Phone" HeaderText="电话">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField  DataField="Email" HeaderText="邮箱">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField  DataField="Address" HeaderText="住址">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
          
           
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="false" 
                         OnCommand="lbtnEdit_Command"   CommandArgument='<%# Eval("TeacherNo") %>' Text="编辑"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation="false" 
                    OnCommand="lbtnDel_Command"     CommandArgument='<%# Eval("TeacherNo") %>' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
    <asp:Button ID="btnAdd" runat="server" CssClass="submit"  OnClick="btnAdd_Click" 
        Text="添加教师" />
    </p>
</asp:Content>
