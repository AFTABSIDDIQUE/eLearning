<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SubscriptionList.aspx.cs" Inherits="eLearning.User.SubscriptionList.SubscriptionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
<style>
      .subscription-card {
          min-height: 100%; 
      }

      .card-img-top {
          height: 200px;
          object-fit: cover;
      }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div class="container mt-5">
    <h3 class="text-center mb-4">Subscription List</h3>

    <div class="row">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card subscription-card shadow-sm">
                        <div class="card-body pb-0">
                            <h5 class="card-title text-center font-weight-bold"><%# Eval("SubscriptionTypeName") %></h5>
                        </div>

                        <img src='<%# ResolveUrl("~/Images/") + Eval("SubscriptionPic") %>' class="card-img-top" alt="Subscription Image" />

                        <div class="card-body pt-2 d-flex flex-column">
                            <p class="card-text"><strong><%# Eval("SubCourses") %></strong></p>
                            <p class="card-text">60 days validity</p>
                            <p class="card-text font-weight-bold">₹<%# Eval("SubscriptionPrice") %></p>

                            <asp:Button ID="btnSubscribe" runat="server" Text="Buy Now"
                                CssClass="btn btn-primary mt-auto w-100"
                                CommandName="BuyNow"
                                CommandArgument='<%# Eval("SubscriptionTypeName") + "|" + Eval("SubscriptionPrice") + "|" + Eval("SubCourses") %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>
