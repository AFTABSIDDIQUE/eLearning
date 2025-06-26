<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginDB.aspx.cs" Inherits="eLearning.LoginDB" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center align-items-center">
                <!-- Left Side Image -->
                <div class="col-md-6 d-none d-md-block">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                         class="img-fluid rounded" alt="Login image" />
                </div>

                <!-- Right Side Form -->
                <div class="col-md-6">
                    <div class="shadow p-4 rounded bg-light">
                        <!-- Pills navs -->
                        <ul class="nav nav-pills nav-justified mb-3" id="ex1" role="tablist">
                            <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="tab-login" data-bs-toggle="pill" href="#pills-login" role="tab"
                                   aria-controls="pills-login" aria-selected="true">Login</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="tab-register" data-bs-toggle="pill" href="#pills-register" role="tab"
                                   aria-controls="pills-register" aria-selected="false">Register</a>
                            </li>
                        </ul>
                        <!-- Pills navs -->

                        <!-- Pills content -->
                        <div class="tab-content">
                            <!-- Login Tab -->
                            <div class="tab-pane fade show active" id="pills-login" role="tabpanel" aria-labelledby="tab-login">
                                <p class="text-center"></p>

                                <div class="form-outline mb-4">
                                    <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email or username" />
                                    <label class="form-label" for="txtLoginEmail">Email or username</label>
                                </div>

                                <div class="form-outline mb-4">
                                    <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
                                    <label class="form-label" for="txtLoginPassword">Password</label>
                                </div>

                               <div class="text-end mb-4">
                                        <asp:Button ID="btnLogin" runat="server" Text="Sign in" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                                    </div>

                            </div>

                            <!-- Register Tab -->
                            <div class="tab-pane fade" id="pills-register" role="tabpanel" aria-labelledby="tab-register">

                                <p class="text-center"></p>

                                <div class="form-outline mb-4">
                                    <asp:TextBox ID="txtRegName" runat="server" CssClass="form-control" placeholder="Your name" />
                                    <label class="form-label" for="txtRegName">Name</label>
                                </div>

                                <div class="form-outline mb-4">
                                    <asp:TextBox ID="txtRegEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email" />
                                    <label class="form-label" for="txtRegEmail">Email</label>
                                </div>

                                <div class="form-outline mb-4">
                                    <asp:TextBox ID="txtRegContact" runat="server" CssClass="form-control" placeholder="PhoneNumber" />
                                    <label class="form-label" for="txtRegContact">Phone Number</label>
                                </div>

                                <div class="form-outline mb-4">
                                    <asp:TextBox ID="txtRegPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
                                    <label class="form-label" for="txtRegPassword">Password</label>
                                </div>

                                <div class="text-end mb-4">
                                     <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-block mb-3" OnClick="btnRegister_Click" />
                                 </div>

                            </div>
                        </div>
                        <!-- Pills content -->
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
