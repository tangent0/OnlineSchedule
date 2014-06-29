<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.Master" AutoEventWireup="true" CodeBehind="ManageRemind.aspx.cs" Inherits="WebStation.Management.ManageRemind" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    重要提醒管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    重要提醒管理
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
    <asp:GridView ID="grid" runat="server" CssClass="add_table" 
        Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="序号">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField  DataField="Month" HeaderText="月份">
                <HeaderStyle HorizontalAlign="Left" Width="96" />
            </asp:BoundField>
            <asp:BoundField  DataField="Day" HeaderText="日期" >
                <HeaderStyle HorizontalAlign="Left" Width="96" />
            </asp:BoundField>
           
            <asp:BoundField  DataField="Note" HeaderText="提醒内容">
                <HeaderStyle HorizontalAlign="Left" Width="60%" />
            </asp:BoundField>
          
           
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="false" 
                         OnCommand="lbtnEdit_Command"   CommandArgument='<%# Eval("Id") %>' Text="编辑"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation="false" 
                    OnCommand="lbtnDel_Command"     CommandArgument='<%# Eval("Id") %>' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
    <asp:Button ID="btnAdd" runat="server" CssClass="submit"  OnClick="btnAdd_Click" 
        Text="添加重要提醒" />
    </p>
</asp:Content>
