<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertStationery.aspx.cs" Inherits="ProjectLABPSD.Views.InsertStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/InsertStationeryCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
      <div class="container">
        <p class="insert">Insert Stationery</p>
          <div class="inserts">
            <div class="container2">
                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelName" runat="server" Text="Item Name"></asp:Label>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <asp:Label CssClass="Label" ID="LabelPrice" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                </div>

                 <asp:Label CssClass="errorMessage" ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
   
                <asp:Button CssClass="button" ID="ButtonInsert" runat="server" Text="Insert Item" OnClick="ButtonInsert_Click"/>

             </div>
          </div>
      </div>
    </div>
</asp:Content>
