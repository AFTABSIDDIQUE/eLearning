<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreatedMCQList.aspx.cs" Inherits="eLearning.Admin.Master_Course_List.CreatedMCQList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewMCQ" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="MCQID" HeaderText="ID" />
        <asp:BoundField DataField="Question" HeaderText="Question" />
        <asp:BoundField DataField="OptionA" HeaderText="A" />
        <asp:BoundField DataField="OptionB" HeaderText="B" />
        <asp:BoundField DataField="OptionC" HeaderText="C" />
        <asp:BoundField DataField="OptionD" HeaderText="D" />
        <asp:BoundField DataField="Answer" HeaderText="Answer" />
        <asp:BoundField DataField="SubCourseName" HeaderText="SubCourse Name" />
        <asp:BoundField DataField="TopicName" HeaderText="Topic Name" />
        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:dd-MM-yyyy}" />
      
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
