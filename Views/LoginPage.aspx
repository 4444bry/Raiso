<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectLABPSD.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/LoginCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
      <div class="container">
        <p class="log">Login</p>
          <div class="login">
            <div class="container2">
                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="TextBoxPassword" runat="server" Type="password"></asp:TextBox>
                </div>

                <div class="rowRemember">
                    <asp:CheckBox ID="CBRemember" runat="server" />
                    <asp:Label ID="LabelRemember" runat="server" Text="Remember Me"></asp:Label>
                </div>

                 <asp:Label CssClass="errorMessage" ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
       
                <asp:Button CssClass="button" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"/>
    
             </div>
          </div>
      </div>
    </div>
</asp:Content>
