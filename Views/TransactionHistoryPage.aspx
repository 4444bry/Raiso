<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="ProjectLABPSD.Views.TransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/TransactionHistoryCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content">
            <div class="container">
                <p class="transactionlist">Transaction History</p>
                <div class="transaction">
                    <div class="container2">
                        <asp:GridView CssClass="gridview" ID="GridView" runat="server" AutoGenerateSelectButton="false"  AutoGenerateColumns="false" DataKeyNames="transactionID">
                            <Columns>
                                <asp:BoundField DataField="transactionID" HeaderText="Transaction ID" SortExpression="transactionID" />
                                <asp:BoundField DataField="userName" HeaderText="User" SortExpression="userName" />
                                <asp:BoundField DataField="transactionDate" HeaderText="Transaction Date" SortExpression="transactionDate" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <div class="action-buttons">
                                            <asp:Button runat="server" ID="btnDet" CommandName="Detail" Text="Info Detail" CssClass="action-buttondet" OnClick="BtnDet_Click"/>
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
