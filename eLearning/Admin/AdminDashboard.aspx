<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="eLearning.Admin.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Admin Dashboard</h2>
            <div class="row g-4">
                <div class="col-md-4">
                    <div class="card text-white bg-primary">
                        <div class="card-body">
                            <h5 class="card-title">Total Courses</h5>
                            <asp:Label ID="lblCourses" runat="server" CssClass="card-text fs-3"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card text-white bg-success">
                        <div class="card-body">
                            <h5 class="card-title">Total Subcourses</h5>
                            <asp:Label ID="lblSubCourses" runat="server" CssClass="card-text fs-3"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card text-white bg-info">
                        <div class="card-body">
                            <h5 class="card-title">Total Subscriptions</h5>
                            <asp:Label ID="lblSubscriptions" runat="server" CssClass="card-text fs-3"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card text-white bg-warning">
                        <div class="card-body">
                            <h5 class="card-title">Active Users</h5>
                            <asp:Label ID="lblActiveUsers" runat="server" CssClass="card-text fs-3"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card text-white bg-danger">
                        <div class="card-body">
                            <h5 class="card-title">Inactive Users</h5>
                            <asp:Label ID="lblInactiveUsers" runat="server" CssClass="card-text fs-3"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card text-white bg-secondary">
                        <div class="card-body">
                            <h5 class="card-title">Sold Courses</h5>
                            <asp:Label ID="lblSoldCourses" runat="server" CssClass="card-text fs-3"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:GridView ID="GridViewSubCourseData" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
    <Columns>
        <asp:TemplateField HeaderText="SubCourse ID">
            <ItemTemplate>
                <%# Eval("SubCourseID") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SubCourse Name">
            <ItemTemplate>
                <%# Eval("SubCourseName") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="No. of Videos">
            <ItemTemplate>
                <%# Eval("NoOfVideos") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="No. of Assignments">
            <ItemTemplate>
                <%# Eval("NoOfAssignments") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="No. of MCQs">
            <ItemTemplate>
                <%# Eval("NoOfMCQs") %>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </div>
</asp:Content>
