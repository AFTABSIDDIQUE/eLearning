<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="MyCourses.aspx.cs" Inherits="eLearning.User.CoursesList.MyCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvTransactions_RowCommand">
              <Columns>
                <asp:BoundField DataField="Name" HeaderText="Course Name" />
                 <asp:TemplateField HeaderText="Active">
                    <ItemTemplate>
                        <asp:Button ID="btnPlay" runat="server" Text="Play" CommandName="PlayCourse" CommandArgument='<%# Eval("Name") %>' />
                    </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        </asp:GridView>
</div>
</asp:Content>
