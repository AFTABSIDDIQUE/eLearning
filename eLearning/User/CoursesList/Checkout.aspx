<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="eLearning.User.CoursesList.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div class="container mt-5">
    <h2 class="mb-4 text-center">CheckOut Page</h2>
     <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False"
        ShowFooter="true" CssClass="table table-bordered table-striped table-hover">

    <Columns>
        <asp:TemplateField HeaderText="UserID">
            <ItemTemplate>
                <%# Eval("UserID") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SubCourseID">
            <ItemTemplate>
                <%# Eval("SubCourseID") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SubCourseName">
            <ItemTemplate>
                <%# Eval("SubCourseName") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <asp:Image ID="imgPic" runat="server" ImageUrl='<%# Eval("SubCoursePic") %>' Height="50" Width="50" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Price">
            <ItemTemplate>
                <%# Eval("SubCoursePrice") %>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblTotal" runat="server" />
                <asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="btn btn-success btn-sm" OnClick="btnCheckout_Click" />
            </FooterTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
</div>
</asp:Content>
