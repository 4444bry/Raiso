<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="StationeryDetailPage.aspx.cs" Inherits="ProjectLABPSD.Views.StationeryDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StationeryDetailsCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container">
            <div class="statDetail">
                <div class="rowlabel">
                    <asp:Label ID="LabelName" CssClass="Head" runat="server" Text="Item"></asp:Label>
                    <asp:Label ID="LblStatName" runat="server" Text=""></asp:Label>
                </div>
                
                <div class="rowlabel">
                     <asp:Label ID="LabelPrice" CssClass="Head" runat="server" Text="Price"></asp:Label>
                     <asp:Label ID="LblStatPrice" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="cartCustomers" id="cartCustomer" runat="server" visible="false">
                <div class="inputQuantitys">
                    <div class="inputPlusMin">
                        <button type="button" class="btn" id="minus-btn" onclick="changeQuantity(-1);">-</button>
                    </div>
                    <asp:TextBox ID="txtQuantity" runat="server" value="1" min="1" ClientIDMode="Static" onkeypress="return isNumberKey(event);"></asp:TextBox>
                    <div class="inputPlusMin">
                        <button type="button" class="btn" onclick="changeQuantity(1);" id="plus-btn">+</button>
                    </div>
                </div>
                <asp:Label CssClass="errorMessage" ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <asp:Button CssClass="buttonAdd" ID="ButtonAdd" runat="server" Text="Add To Cart" OnClick="ButtonAdd_Click"/>
            </div>
        </div>
    </div>

    <script>
        function changeQuantity(change) {
            var currentQty = document.getElementById("txtQuantity");
            var quantity = parseInt(currentQty.value, 10);

            quantity += change;

            if (isNaN(quantity)) {
                quantity = 0;
            }

            if (quantity <= 0) {
                quantity = 0;
            }

            currentQty.value = quantity;
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
