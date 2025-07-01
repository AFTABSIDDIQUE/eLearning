<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddTopic.aspx.cs" Inherits="eLearning.Admin.Master_Course.AddTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    Add Topic
    <br />
    <br />
    Course Name
    <br />
    <asp:DropDownList ID="Course" runat="server">
    </asp:DropDownList>
    <br />
    SubCourse Name<br />
    <asp:DropDownList ID="SubCourse" runat="server">
    </asp:DropDownList>
    <br />
    Topic Name<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    Video Url<br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    Status<br />
    <asp:DropDownList ID="DropDownList3" runat="server">
        <asp:ListItem>Active</asp:ListItem>
        <asp:ListItem>Inactive</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Add Topic" OnClick="Button1_Click" />
</div>
</asp:Content>
