<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.master" AutoEventWireup="true" CodeBehind="ManageStudent.aspx.cs" Inherits="WebStation.Management.ManageStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    学生信息管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    学生信息管理

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
    <p>
        <asp:Label Text="请选择班级:" runat="server"></asp:Label>
        <asp:DropDownList ID="cbClass" runat="server" DataTextField="ClassName" DataValueField="Classno" OnSelectedIndexChanged="cbClass_SelectedIndexChanged"
            AutoPostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" CssClass="submit"  OnClick="btnSearch_Click"
        Text="检索" />
    </p>
    <asp:GridView ID="grid" runat="server" CssClass="add_table" 
        Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StudentNo" HeaderText="学号">
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
            <asp:BoundField  DataField="Classno" HeaderText="所在班级">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
          
           
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="false" 
                         OnCommand="lbtnEdit_Command"   CommandArgument='<%# Eval("StudentNo") %>' Text="编辑"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation="false" 
                    OnCommand="lbtnDel_Command"     CommandArgument='<%# Eval("StudentNo") %>' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
    <asp:Button ID="btnAdd" runat="server" CssClass="submit"  OnClick="btnAdd_Click" 
        Text="添加学生" />
    </p>
</asp:Content>
