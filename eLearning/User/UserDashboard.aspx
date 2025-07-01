<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="eLearning.User.UserDashboard" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .dashboard-card {
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
            background-color: #f8f9fa;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            min-height: 120px;
        }

        .progress {
            height: 30px;
            border-radius: 15px;
        }

        .progress-bar {
            font-weight: bold;
            line-height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row text-center">
            <div class="col-md-4">
                <div class="dashboard-card">
                    <h4>My Courses</h4>
                    <asp:Label ID="lblMyCourses" runat="server" CssClass="text-primary h5 d-block"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="dashboard-card">
                    <h4>Completed Courses</h4>
                    <asp:Label ID="Label1" runat="server" CssClass="text-success h5 d-block"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="dashboard-card">
                    <h4>InCompleted Courses</h4>
                    <asp:Label ID="Label2" runat="server" CssClass="text-danger h5 d-block"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="container mt-4">
        <div class="row">
          
            <div class="col-md-6 text-center">
                <asp:Chart ID="PieChart" runat="server" Width="400px" Height="400px">
                    <ChartAreas>
                        <asp:ChartArea Name="MainArea" />
                    </ChartAreas>
                </asp:Chart>
            </div>

         
            <div class="col-md-6">
              <asp:Repeater ID="rptCompletion" runat="server">
    <ItemTemplate>
        <div class="mb-3">
            <strong><%# Eval("SubCourseName") %></strong>
            <div class="progress" style="height: 30px; border-radius: 20px;">
                <div class="progress-bar text-white" role="progressbar"
                     style='width: <%# Eval("CompletionPercentage") %>%; <%# Eval("BarColor") %>'
                     aria-valuenow='<%# Eval("CompletionPercentage") %>' aria-valuemin="0" aria-valuemax="100">
                    <%# string.Format("{0:0.0}%", Eval("CompletionPercentage")) %>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

            </div>
        </div>
    </div>

</asp:Content>
