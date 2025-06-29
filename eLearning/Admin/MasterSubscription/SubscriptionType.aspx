<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SubscriptionType.aspx.cs" Inherits="eLearning.Admin.MasterSubscription.SubscriptionType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card shadow p-4">
                <h4 class="text-center mb-4">Add Subscription Type</h4>

                <div class="form-group">
                    <label>Subscription Type</label>
                    <asp:TextBox ID="txtsubtype" runat="server" CssClass="form-control" placeholder="Enter subscription type"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Status</label>
                    <asp:DropDownList ID="substat" runat="server" CssClass="form-control">
                        <asp:ListItem>Active</asp:ListItem>
                        <asp:ListItem>Inactive</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="text-center">
                    <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary px-4" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
