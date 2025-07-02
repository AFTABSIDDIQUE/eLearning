<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="eLearning.Admin.Master_Course_List.CourseList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="container mt-5">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID" CssClass="table table-bordered"
    OnRowEditing="GridView1_RowEditing"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowCancelingEdit="GridView1_RowCancelingEdit">
    
    <Columns>
        <asp:TemplateField HeaderText="CourseID">
            <ItemTemplate>
                <%# Eval("CourseID") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Course Name">
            <ItemTemplate>
                <%# Eval("CourseName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

            <asp:TemplateField HeaderText="Course Pic">
        <ItemTemplate>
            <img src='<%# Eval("CoursePic") %>' alt="Course Image" width="100" height="60" />
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCoursePic" runat="server" Text='<%# Bind("CoursePic") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>


        <asp:TemplateField HeaderText="Course Status">
            <ItemTemplate>
                <%# Eval("CourseStatus") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCourseStatus" runat="server" Text='<%# Bind("CourseStatus") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" />

       
    </Columns>
</asp:GridView>

        </div>
</asp:Content>
