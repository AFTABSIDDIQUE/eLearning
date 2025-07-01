<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="VideoPanel.aspx.cs" Inherits="eLearning.User.VideoPanel.VideoPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container">
        <div class="row">
            <!-- Left side: iframe -->
            <div class="col-md-8">
                <iframe
                    id="videoFrame"
                    src="https://www.youtube.com/embed/ZbZfaD-RUuA"
                    width="100%"
                    height="400"
                    style="border: 1px solid #ccc;"></iframe>

                <!-- Buttons under iframe -->
                <div class="mt-3">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="d-flex gap-2">
                                <asp:Button ID="Button5" runat="server" Text="MCQ" CssClass="btn btn-primary" OnClientClick="showSection('mcqDiv')" OnClick="Button5_Click" />

                                <button type="button" class="btn btn-success" onclick="showSection('assignmentDiv')">Assignment</button>
                                <button type="button" class="btn btn-info" onclick="showSection('reviewDiv')">Review</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <!-- MCQ section -->
                        <div id="mcqDiv" class="mt-3" style="border: 1px solid #ccc; padding: 10px;">
                            <h5>MCQ Section</h5>

                            <asp:Repeater ID="rptMCQ" runat="server">
                                <ItemTemplate>
                                    <div class="mb-3 border p-2">
                                        <h5><%# Eval("Question") %></h5>
                                        <div>
                                            <label>
                                                <input type="radio" name="q<%# Eval("MCQID") %>" value="<%# Eval("OptionA") %>" />
                                                A. <%# Eval("OptionA") %>
                                            </label>
                                            <br />
                                            <label>
                                                <input type="radio" name="q<%# Eval("MCQID") %>" value="<%# Eval("OptionB") %>" />
                                                B. <%# Eval("OptionB") %>
                                            </label>
                                            <br />
                                            <label>
                                                <input type="radio" name="q<%# Eval("MCQID") %>" value="<%# Eval("OptionC") %>" />
                                                C. <%# Eval("OptionC") %>
                                            </label>
                                            <br />
                                            <label>
                                                <input type="radio" name="q<%# Eval("MCQID") %>" value="<%# Eval("OptionD") %>" />
                                                D. <%# Eval("OptionD") %>
                                            </label>
                                        </div>
                                        <asp:HiddenField ID="hfMCQID" runat="server" Value='<%# Eval("MCQID") %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>


                            <asp:Button
                                ID="btnSubmitMCQ"
                                runat="server"
                                Text="Submit MCQ"
                                OnClick="btnSubmitMCQ_Click"
                                CssClass="btn btn-primary" />

                            <asp:Label ID="lblMCQResult" runat="server" CssClass="text-success mt-2"></asp:Label>
                        </div>



                        <!-- Review section -->
                        <div id="reviewDiv" class="mt-3" style="display: none; border: 1px solid #ccc; padding: 10px;">
                            <h5>Review Section</h5>

                            <p>
                                Give the Review
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                                / 5.
                            </p>
                            <br>
                            <p>
                                Feedback
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </p>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="Button3"  OnClientClick="showSection('reviewDiv')" class="btn btn-danger me-2" runat="server" Text="Submit"  OnClick="Button3_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                       <!-- Assignment section -->
                        <div id="assignmentDiv" class="mt-3" style="display: none; border: 1px solid #ccc; padding: 10px;">
                            <h5>Assignment Section</h5>
                            <p>Download Assignment.</p>
                            <asp:Button ID="Button1" class="btn btn-danger me-2 mb-2" runat="server" Text="Download" OnClick="Button1_Click" />
                            <p>Upload Assignment.</p>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="Button2" OnClientClick="showSection('reviewDiv')" class="btn btn-danger me-2" runat="server" Text="Submit" />
                        </div>

            </div>

            <!-- Right side: playlist -->
            <div class="col-md-4">
                <h4>Playlist</h4>
                <div class="list-group">

                    <asp:HiddenField ID="hdnSelectedTopicID" runat="server" />
                    <asp:Repeater ID="rptPlaylist" runat="server">
                        <ItemTemplate>
                            <a href="#"
                                class='list-group-item list-group-item-action <%# Container.ItemIndex != 0 ? "my-disabled" : "active" %>'
                                style='<%# Container.ItemIndex != 0 ? "pointer-events: none; opacity: 0.6;": "" %>'
                                data-index="<%# Container.ItemIndex %>"
                                data-topicid="<%# Eval("TopicID") %>"
                                onclick="changeVideo('<%# Eval("TopicUrl") %>', this, <%# Container.ItemIndex %>, '<%# Eval("TopicID") %>', '<%# ((Button)Container.FindControl("btnHidden")).ClientID %>'); return false;">
                                <%# Eval("TopicName") %>
                            </a>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button
                                        ID="btnHidden"
                                        runat="server"
                                        Text="hidden"
                                        Style="display: none"
                                        OnClick="btnHidden_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">


        function changeVideo(videoUrl, linkElement, index, topicId, hiddenButtonId) {
            console.log("Clicked TopicID: " + topicId);

            // store topic id for backend later
            document.getElementById("<%= hdnSelectedTopicID.ClientID %>").value = topicId;

            // change iframe video
            const iframe = document.getElementById("videoFrame");
            iframe.src = videoUrl;

            // highlight current
            document.querySelectorAll(".list-group-item").forEach(item => item.classList.remove("active"));
            linkElement.classList.add("active");

            // unlock next
            const nextItem = document.querySelector(`.list-group-item[data-index="${index + 1}"]`);
            if (nextItem && nextItem.classList.contains("my-disabled")) {
                nextItem.classList.remove("my-disabled");
                nextItem.style.pointerEvents = "auto";
                nextItem.style.opacity = "1";
            }

            // trigger hidden button click to fire server event
            document.getElementById(hiddenButtonId).click();
        }



        function showSection(sectionId) {
            // hide all sections first
            document.getElementById("mcqDiv").style.display = "none";
            document.getElementById("assignmentDiv").style.display = "none";
            document.getElementById("reviewDiv").style.display = "none";

            // show requested
            document.getElementById(sectionId).style.display = "block";
        }

        function showPartialSection() {
            // hide all sections first
            document.getElementById("mcqDiv").style.display = "none";
        }
    </script>
</asp:Content>






