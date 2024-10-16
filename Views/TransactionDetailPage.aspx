<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjectLABPSD.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TransactionDetailCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">
         <div class="container">
             <p class="itemlist">Purchased Items</p>
             <div class="stationery">
                 <div class="container2">
                     <asp:GridView CssClass="gridview" ID="GridView" runat="server" AutoGenerateSelectButton="false" AutoGenerateColumns="false" >
                         <Columns>
                             <asp:BoundField DataField="StationeryName" HeaderText="Item Name" SortExpression="Name" />
                             <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="Price" />
                             <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                         </Columns>
                     </asp:GridView>
                 </div>
             </div>
         </div>
     </div>
</asp:Content>
