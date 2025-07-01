<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddSubcourse.aspx.cs" Inherits="eLearning.Admin.Master_Course.AddSubcourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>

     Add SubCourse<br />
     <br />
     Course Name<br />
     <asp:DropDownList ID="Course" runat="server">
     </asp:DropDownList>
     <br />
     SubCourse Name<br />
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <br />
     Thumbnail<br />
     <asp:FileUpload ID="FileUpload1" runat="server" />
     <br />
     Price<br />
     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
     <br />
     Status<br />
     <asp:DropDownList ID="DropDownList1" runat="server">
         <asp:ListItem>Active</asp:ListItem>
         <asp:ListItem>Inactive</asp:ListItem>
     </asp:DropDownList>
     <br />
     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Course" />
     <br />
     <br />
  

 </div>
</asp:Content>
