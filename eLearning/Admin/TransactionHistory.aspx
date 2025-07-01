<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="eLearning.Admin.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <h2>Subscription Transactions</h2>
<asp:GridView ID="GridViewSubscription" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Transaction ID">
            <ItemTemplate><%# Eval("TransactionID") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User ID">
            <ItemTemplate><%# Eval("UserID") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Subscription Name">
            <ItemTemplate><%# Eval("SubscriptionName") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount">
            <ItemTemplate><%# Eval("Amount") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Date">
            <ItemTemplate><%# Eval("PaymentDate") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
            <ItemTemplate><%# Eval("TransactionStatus") %></ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<br />

<h2>SubCourse Transactions</h2>
<asp:GridView ID="GridViewSubCourse" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Transaction ID">
            <ItemTemplate><%# Eval("TransactionID") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User ID">
            <ItemTemplate><%# Eval("UserID") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SubCourse Name">
            <ItemTemplate><%# Eval("SubCourseName") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount">
            <ItemTemplate><%# Eval("Amount", "{0:C}") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Date">
            <ItemTemplate><%# Eval("PaymentDate", "{0:yyyy-MM-dd}") %></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
            <ItemTemplate><%# Eval("TransactionStatus") %></ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
</asp:Content>
