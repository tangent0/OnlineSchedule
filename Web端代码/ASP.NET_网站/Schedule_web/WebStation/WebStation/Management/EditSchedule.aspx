<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterContent.master" AutoEventWireup="true" CodeBehind="EditSchedule.aspx.cs" Inherits="WebStation.Management.EditSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    课程表信息编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="summary" runat="server">
    课程表信息编辑
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="conCon" runat="server">
<table class="add_table" width="100%">
    <tr>
        <td>班级编号</td>
        <td>
            <asp:Label ID="labelClassNo" runat="server" Text=""></asp:Label>   
        </td>
        <td colspan="4" style="text-align:left">
            
        </td>
    </tr>
    <tr>
       
        <td colspan="6" style="text-align:center">            
            <asp:DropDownList ID="cbWeek" Width="120" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cbWeek_SelectedIndexChanged">
            </asp:DropDownList>            
        </td>
    </tr>
    <tr>
        <td >
            课时
        </td>
        <td>
            课程代码
        </td>
        <td>
            课程名称
        </td>
        <td>
            上课地点
        </td>
        <td>
            授课老师
        </td>
        <td>
            教学周
        </td>

    </tr>
    <tr>
        <td >            
            <asp:Label ID="Label1" runat="server" Text="第一二节(8:00-09:40)"></asp:Label>  
                      
            <input id="hid1" type="hidden" runat="server" />
                      
        </td>
        <td>
            <asp:TextBox ID="tbCourseCode1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbCourse1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbAddr1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeacher1" runat="server"></asp:TextBox>
        </td>
        <!-- <td style="width:300px"> -->         <!--Height="50px"-->
        <td style="width:100px">
            <asp:TextBox ID="tbTeachingWeek1" runat="server" Height="20px" TextMode="MultiLine" Width="90%" />
        </td>
    </tr>
    <tr>
        <td >            
            <asp:Label ID="Label2" runat="server" Text="第三四节(10:10-11:50)"></asp:Label> 
            <input id="hid2" type="hidden" runat="server" />           
        </td>
        <td>
            <asp:TextBox ID="tbCourseCode2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbCourse2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbAddr2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeacher2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeachingWeek2" runat="server" Height="20px" TextMode="MultiLine" Width="90%" />
        </td>
    </tr>
    <tr>
        <td >            
            <asp:Label ID="Label3" runat="server" Text="第五六节(14:00-15:40)"></asp:Label> 
            <input id="hid3" type="hidden" runat="server" />           
        </td>
        <td>
            <asp:TextBox ID="tbCourseCode3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbCourse3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbAddr3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeacher3" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeachingWeek3" runat="server" Height="20px" TextMode="MultiLine" Width="90%" />
        </td>
    </tr>
    <tr>
        <td >            
            <asp:Label ID="Label4" runat="server" Text="第七八节(16:10-17:50)"></asp:Label> 
            <input id="hid4" type="hidden" runat="server" />           
        </td>
        <td>
            <asp:TextBox ID="tbCourseCode4" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbCourse4" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbAddr4" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeacher4" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="tbTeachingWeek4" runat="server" Height="20px" TextMode="MultiLine" Width="90%" />
        </td>
    </tr>
    
    <tr>
       
        <td colspan="5" style="text-align:left">
            <asp:Button ID="btnDo" runat="server" Text="执行操作" OnClick="btnDo_Click" />
            <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"  />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
</table>

</asp:Content>
