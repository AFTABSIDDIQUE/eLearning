<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="eLearning.Admin.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId" OnRowEditing="gvUsers_RowEditing" 
     OnRowCancelingEdit="gvUsers_RowCancelingEdit" OnRowUpdating="gvUsers_RowUpdating" OnRowDeleting="gvUsers_RowDeleting">
     
     <Columns>
         <asp:TemplateField HeaderText="User ID">
             <ItemTemplate>
                 <%# Eval("UserId") %>
             </ItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="User Name">
             <ItemTemplate>
                 <%# Eval("UserName") %>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>' />
             </EditItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Email">
             <ItemTemplate>
                 <%# Eval("UserEmail") %>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtUserEmail" runat="server" Text='<%# Bind("UserEmail") %>' />
             </EditItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Contact">
             <ItemTemplate>
                 <%# Eval("UserContact") %>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtUserContact" runat="server" Text='<%# Bind("UserContact") %>' />
             </EditItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Role">
             <ItemTemplate>
                 <%# Eval("role") %>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtRole" runat="server" Text='<%# Bind("role") %>' />
             </EditItemTemplate>
         </asp:TemplateField>
          <asp:TemplateField HeaderText="Status">
             <ItemTemplate>
                 <%# Eval("stat") %>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtstat" runat="server" Text='<%# Bind("stat") %>' />
             </EditItemTemplate>
         </asp:TemplateField>
         <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
     </Columns>
 </asp:GridView>
    </div>
</asp:Content>
