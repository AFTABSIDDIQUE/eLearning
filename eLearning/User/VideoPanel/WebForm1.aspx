<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="eLearning.User.VideoPanel.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="MCQ" CssClass="btn btn-primary" OnClick="Button5_Click"/>
                <asp:Repeater ID="rptMCQ" runat="server">
                    <ItemTemplate>
                        <div class="mb-3 border p-2">
                            <h5><%# Eval("Question") %></h5>
                            <div>
                                <label><input type="radio" name="q<%# Eval("MCQID") %>" value="A" /> A. <%# Eval("OptionA") %></label><br />
                                <label><input type="radio" name="q<%# Eval("MCQID") %>" value="B" /> B. <%# Eval("OptionB") %></label><br />
                                <label><input type="radio" name="q<%# Eval("MCQID") %>" value="C" /> C. <%# Eval("OptionC") %></label><br />
                                <label><input type="radio" name="q<%# Eval("MCQID") %>" value="D" /> D. <%# Eval("OptionD") %></label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
<!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModalCenter">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModalCenter" tabindex="-1" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalCenterTitle">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>

        </div>
    </form>
</body>
</html>
