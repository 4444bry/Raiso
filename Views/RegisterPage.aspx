<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ProjectLABPSD.Views.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/RegisterCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
      <div class="container">
        <p class="regis">Register</p>
          <div class="register">
            <div class="container2">
                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelDOB" runat="server" Text="DOB"></asp:Label>
                    <asp:TextBox ID="TextBoxDOB" Type="date" runat="server"></asp:TextBox>
                </div>

                <div class="rowGender">
                    <asp:Label CssClass="Label" ID="LabelGender" runat="server" Text="Gender"></asp:Label>
                    <div class="GenderList">
                        <asp:RadioButtonList ID="RadioButtonGender" runat="server">
                            <asp:ListItem Text="Male"></asp:ListItem>
                            <asp:ListItem Text ="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelAddress" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="TextBoxPassword" runat="server" Type="password"></asp:TextBox>
                </div>

                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
                    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                </div>
                <div class="errorMessage">
                    <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </div>
        
                <asp:Button CssClass="button" ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click"/>
        
             </div>
          </div>
      </div>
    </div>
</asp:Content>
