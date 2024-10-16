<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProjectLABPSD.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/HomeCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container">
            <p class="itemlist">Stationery List</p>
            <div class="stationery">
                <div class="container2">
                     <asp:Button ID="ButtonInsert" runat="server" Text="Insert Stationery" CssClass="buttonInsert" Visible="false" OnClick="ButtonInsert_Click"/>
                 
                        <asp:GridView CssClass="gridview" ID="GridView" runat="server" AutoGenerateSelectButton="false" DataKeyNames="StationeryID" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="StationeryName" HeaderText="Item Name" SortExpression="Name" />
                                <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="Price" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <div class="action-buttons">
                                            <asp:Button runat="server" ID="btnDet" CommandName="Detail" Text="Info Detail" CssClass="action-buttondet" OnClick="BtnDet_Click" />
                                            <asp:Button runat="server" ID="btnUp" CommandName="Update" Text="Update" CssClass="action-buttonup" OnClick="BtnUp_Click" />
                                            <asp:Button runat="server" ID="btnDel" CommandName="Delete" Text="Delete" CssClass="action-buttondel"/>
                                        </div>
                                    </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

