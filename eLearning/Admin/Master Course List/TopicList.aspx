<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="eLearning.Admin.Master_Course_List.TopicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container mt-5">
            <h2>Topic List</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
    DataKeyNames="TopicID"
    OnRowEditing="GridView1_RowEditing"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowCancelingEdit="GridView1_RowCancelingEdit">

    <Columns>
        <asp:TemplateField HeaderText="Topic ID">
            <ItemTemplate>
                <%# Eval("TopicID") %>
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

        <asp:TemplateField HeaderText="Topic Name">
            <ItemTemplate>
                <%# Eval("TopicName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTopicName" runat="server" Text='<%# Bind("TopicName") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Video URL">
            <ItemTemplate>
                <a href='<%# Eval("TopicURL") %>' target="_blank">Watch</a>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTopicURL" runat="server" Text='<%# Bind("TopicURL") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" />
                &nbsp;|&nbsp;
                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" />
                &nbsp;|&nbsp;
                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </div>
</asp:Content>
