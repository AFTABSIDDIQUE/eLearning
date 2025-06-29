<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="eLearning.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            background: linear-gradient(to right, #74ebd5, #ACB6E5);
            color: #333;
            padding-top: 100px;
        }
        .container {
            background: #fff;
            border-radius: 10px;
            padding: 50px;
            width: 400px;
            margin: 0 auto;
            box-shadow: 0 10px 25px rgba(0,0,0,0.1);
        }
        .btn {
            background-color: #007bff;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>👋 Welcome to the Course Portal</h1>
            <p>Explore a variety of subscriptions or SubCourses and start learning today.</p>
            <asp:Button ID="btnStart" runat="server" Text="Explore Courses" CssClass="btn" OnClick="btnStart_Click" />
        </div>
    </form>
</body>
</html>

