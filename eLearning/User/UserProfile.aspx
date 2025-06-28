<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="eLearning.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
     <div class="row justify-content-center">
         <div class="col-md-6">
             <div class="card shadow">
                 <div class="card-header bg-primary text-white">
                     <h4 class="mb-0">User Profile</h4>
                 </div>
                 <div class="card-body">
                     <div class="mb-3">
                         <label class="form-label fw-bold">Name:</label>
                         <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="mb-3">
                         <label class="form-label fw-bold">Email:</label>
                         <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="mb-3">
                         <label class="form-label fw-bold">Contact:</label>
                         <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="text-end">
                         <asp:Button ID="btnUpdate" runat="server" Text="Update Details" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
