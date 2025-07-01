<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserReview.aspx.cs" Inherits="eLearning.Admin.Review.UserReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
         <Columns>

             <asp:TemplateField HeaderText="Review ID">
                 <ItemTemplate>
                     <%# Eval("ReviewID") %>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="User Name">
                 <ItemTemplate>
                     <%# Eval("UserName") %>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="Course Name">
                 <ItemTemplate>
                     <%# Eval("CourseName") %>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="SubCourse Name">
                 <ItemTemplate>
                     <%# Eval("SubCourseName") %>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="Rating">
                 <ItemTemplate>
                     <span class="stars"><%# GetStars(Eval("Rating")) %></span>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="Feedback">
                 <ItemTemplate>
                     <%# Eval("FeedbackText") %>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="Created At">
                 <ItemTemplate>
                     <%# Eval("CreatedAt", "{0:yyyy-MM-dd HH:mm:ss}") %>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="Status">
                 <ItemTemplate>
                     <%# Eval("Status") %>
                     <asp:Button ID="Button2" runat="server" Text="Approve" CommandName="EditRow" CommandArgument=' <%# Eval("ReviewID") %>' />
                     
                 </ItemTemplate>
             </asp:TemplateField>

         </Columns>
     </asp:GridView>

     <br />
     <asp:Button ID="Button1" runat="server" Style="height: 29px" OnClick="Button1_Click" Text="ApproveAll" />

 </div>
</asp:Content>
