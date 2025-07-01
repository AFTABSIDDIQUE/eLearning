<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreatedAssignmentList.aspx.cs" Inherits="eLearning.Admin.Master_Course_List.CreatedAssignmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:GridView ID="GridViewAssignment" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewAssignment_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
        <asp:BoundField DataField="AssignmentFile" HeaderText="File Name" />
        <asp:BoundField DataField="SubCourseName" HeaderText="SubCourse Name" />
        <asp:BoundField DataField="TopicName" HeaderText="Topic Name" />
        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:dd-MM-yyyy}" />
        <asp:TemplateField HeaderText="Download">
    <ItemTemplate>
        <asp:Button ID="lnkDownload" runat="server" Text="Download"
            CommandName="Download" CommandArgument='<%# Eval("AssignmentFile") %>'>
        </asp:Button>
    </ItemTemplate>
</asp:TemplateField>

    </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>
</asp:Content>
