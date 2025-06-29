<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddSubscription.aspx.cs" Inherits="eLearning.Admin.MasterSubscription.AddSubscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           
        <div class="container mt-5">
     <div class="row justify-content-center">
         <div class="col-md-6">
             <div class="card shadow p-4">
                 <h4 class="text-center mb-4">Add New Subscription</h4>

                 <div class="form-group">
                     <label>Subscription Type</label>
                     <asp:DropDownList ID="subtype" runat="server" CssClass="form-control"></asp:DropDownList>
                 </div>

                 <div class="form-group">
                     <label>Course Name</label>
                     <asp:DropDownList ID="course" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="course_SelectedIndexChanged"></asp:DropDownList>
                 </div>

                 <div class="form-group">
                     <label>Sub Courses</label>
                     <asp:CheckBoxList ID="chkSubCourses" runat="server" CssClass="form-check">
                     </asp:CheckBoxList>
                 </div>

                 <div class="form-group">
                     <label>Price</label>
                     <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter price"></asp:TextBox>
                 </div>

                 <div class="form-group">
                     <label>Upload Picture</label>
                     <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                 </div>

                 <div class="form-group">
                     <label>Subscription Status</label>
                     <asp:DropDownList ID="Substat" runat="server" CssClass="form-control">
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
