<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="eLearning.User.VideoPanel.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        </div>
    </form>
</body>
</html>
