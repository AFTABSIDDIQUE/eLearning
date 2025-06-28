<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ViewCoursesList.aspx.cs" Inherits="eLearning.User.CoursesList.ViewCoursesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div>
    <div class="row mb-3">
    <div class="col-md-4">
        <asp:DropDownList ID="ddlCourses" runat="server"
            AutoPostBack="true"
            CssClass="form-select"
            OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged" />
    </div>
<div class="col-md-4">
        <asp:DropDownList ID="ddlSort" runat="server"
            AutoPostBack="true"
            CssClass="form-select"
            OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
            <asp:ListItem Text="Sort by Price" Value="" />
            <asp:ListItem Text="Low to High" Value="ASC" />
            <asp:ListItem Text="High to Low" Value="DESC" />
        </asp:DropDownList>
    </div>

</div>

<div>
            <hr />
            <asp:DataList ID="dlSubCourses" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="row row row-cols-1 row-cols-md-4 g-4" OnItemCommand="dlSubCourses_ItemCommand">
                <ItemTemplate>
                    <div class="card m-2 p-2" style="width: 18rem;">
                        <p class="card-text">ID: <%# Eval("SubCourseID") %></p>
                        <h5 class="card-title text-center"><%# Eval("SubCourseName") %></h5>
                        <img src='<%# Eval("SubCoursePic") %>' class="card-img-top" style="height: 150px; object-fit: cover;" />
                        <div class="card-body">
                            <p class="card-text">Price: ₹<%# Eval("SubCoursePrice") %></p>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart"
                                    CssClass="btn btn-primary w-100"
                                    CommandName="AddToCart"
                                    CommandArgument='<%# Eval("SubCourseID") + "|" + Eval("SubCourseName") + "|" + Eval("SubCoursePic") + "|" + Eval("SubCoursePrice") %>' />                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        </div>
</asp:Content>
