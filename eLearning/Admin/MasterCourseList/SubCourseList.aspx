<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SubCourseList.aspx.cs" Inherits="eLearning.Admin.Master_Course_List.SubCourseList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div class="container mt-5">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
    DataKeyNames="SubCourseID"
    OnRowEditing="GridView1_RowEditing"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowCancelingEdit="GridView1_RowCancelingEdit">

    <Columns>
        <asp:TemplateField HeaderText="SubCourse ID">
            <ItemTemplate>
                <%# Eval("SubCourseID") %>
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
            <EditItemTemplate>
                <asp:TextBox ID="txtSubCourseName" runat="server" Text='<%# Bind("SubCourseName") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SubCourse Image">
            <ItemTemplate>
                <img src='<%# Eval("SubCoursePic") %>' width="100" height="60" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtSubCoursePic" runat="server" Text='<%# Bind("SubCoursePic") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Price">
            <ItemTemplate>
                ₹ <%# Eval("SubCoursePrice") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("SubCoursePrice") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                &nbsp;|&nbsp;
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                &nbsp;|&nbsp;
                <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


        </div>
</asp:Content>
