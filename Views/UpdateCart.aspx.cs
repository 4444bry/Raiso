using ProjectLABPSD.Controllers;
using ProjectLABPSD.Handlers;
using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLABPSD.Views
{
    public partial class UpdateCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string stationeryID = Request.QueryString["id"];
                    LoadExistingData(stationeryID);
                }
            }
        }

        private void LoadExistingData(string stationeryID)
        {
            string userID = Session["user"].ToString();
            MsStationery existingStationery = StationeryHandler.GetStationeryByID(int.Parse(stationeryID));
            Cart quantity = CartHandler.GetCartItemByID(int.Parse(userID),int.Parse(stationeryID));
            if (existingStationery != null)
            {
                txtQuantity.Text = quantity.quantity.ToString();
                LblStatName.Text = existingStationery.StationeryName;
                LblStatPrice.Text = existingStationery.StationeryPrice.ToString();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (StationeryController.CheckQuantity(txtQuantity.Text) != "")
            {
                ErrorMessageLabel.Text = StationeryController.CheckQuantity(txtQuantity.Text);
                ErrorMessageLabel.Visible = true;
                return;
            }
            string loggedUser = Session["user"].ToString();
            string stationeryID = Request.QueryString["id"];

            CartHandler.UpdateCart(loggedUser, stationeryID, int.Parse(txtQuantity.Text));
            Response.Write("<script>window.alert('Added to cart');window.location = 'CartPage.aspx'</script>");
        }
    }
}