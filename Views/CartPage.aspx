<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectLABPSD.Views.CartPage" Async ="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/CartCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container">
            <p class="itemlist">Cart</p>
            <div class="stationery">
                <div class="container2">
                    <asp:Label  ID="LabelEmpty" CssClass="empty" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:GridView CssClass="gridview" ID="GridView" runat="server" AutoGenerateSelectButton="false" DataKeyNames="StationeryID" OnRowDeleting="GridView_RowDeleting" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:BoundField DataField="StationeryName" HeaderText="Item Name" SortExpression="Name" />
                            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="Price" />
                            <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <div class="action-buttons">
                                        <asp:Button runat="server" ID="btnUp" CommandName="Update" Text="Update" CssClass="action-buttonup" OnClick="BtnUp_Click" />
                                        <asp:Button runat="server" ID="btnDel" CommandName="Delete" Text="Remove" CssClass="action-buttondel"/>
                                    </div>
                                </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button runat="server" ID="btnCek" CommandName="Check" Text="Checkout" CssClass="action-buttoncek" OnClick="BtnCek_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
