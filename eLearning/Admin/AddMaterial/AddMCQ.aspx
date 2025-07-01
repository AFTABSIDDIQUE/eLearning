<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddMCQ.aspx.cs" Inherits="eLearning.Admin.AddMaterial.AddMCQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
       Course Name&nbsp;&nbsp;
      <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
      <br />
      <br /> 
       SubCourse Name
      <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ></asp:DropDownList>
      <br />
      <br />
       Topic&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true"></asp:DropDownList><br /><br />
      <asp:Button ID="btnAddMore" runat="server" Text="Add MCQ" OnClick="btnmcq_Click" /><br /><br />
      <asp:Repeater ID="Repeater1" runat="server" Visible="false">
          <ItemTemplate>
              <div  style="border:1px solid gray; padding:10px; margin-bottom:15px; background-color:#f9f9f9;"">
                  Question: <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox><br />
                  Option A: <asp:TextBox ID="txtOptionA" runat="server"></asp:TextBox><br />
                  Option B: <asp:TextBox ID="txtOptionB" runat="server"></asp:TextBox><br />
                  Option C: <asp:TextBox ID="txtOptionC" runat="server"></asp:TextBox><br />
                  Option D: <asp:TextBox ID="txtOptionD" runat="server"></asp:TextBox><br />
                  Answer: <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox><br />
              </div>
          </ItemTemplate>
      </asp:Repeater>

      <asp:HiddenField ID="Hfcount" runat="server" Value="0" />

      
      <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnsave_Click" />

  </div>                                
</asp:Content>
