using ProjectLABPSD.Handlers;
using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ProjectLABPSD.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStationeriesCart();
            }
        }

        private void LoadStationeriesCart()
        {
            int userID = Convert.ToInt32(Session["user"]);
                
            if(CartHandler.GetCartList(userID).Count() == 0)
            {
                LabelEmpty.Text = "Cart is empty";
                LabelEmpty.Visible = true;
                btnCek.Visible = false;
                GridView.Visible = false;
                return;
            }
            GridView.DataSource = CartHandler.GetCartList(userID);
            GridView.DataBind();
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string stationeryID = GridView.DataKeys[rowIndex]["StationeryID"].ToString();
            int userID = Convert.ToInt32(Session["user"]);

            CartHandler.DeleteFromCart(userID, stationeryID);
            LoadStationeriesCart();
        }

        protected void BtnUp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            string stationeryID = GridView.DataKeys[row.RowIndex]["StationeryID"].ToString();
            Response.Redirect($"UpdateCart.aspx?id={stationeryID}");
        }

        protected void BtnCek_Click(object sender, EventArgs e)
        {
            string userID = Session["user"].ToString();
            DateTime transactionDate = DateTime.Now;
            int transactionID = TransactionHandler.AddNewTransaction(int.Parse(userID), transactionDate);
            
            foreach (GridViewRow row in GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string stationeryID = GridView.DataKeys[row.RowIndex]["StationeryID"].ToString();
                    int quantity = Convert.ToInt32(row.Cells[2].Text);
                    TransactionHandler.AddTransactionDetail(transactionID, int.Parse(stationeryID),quantity);
                }
            }
            CartHandler.DeleteAllItem(int.Parse(userID));
            Response.Write("<script>window.alert('Checkout Success'); window.location='HomePage.aspx'</script>");
        }
    }
}