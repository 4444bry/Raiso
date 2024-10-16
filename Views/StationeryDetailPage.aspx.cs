using ProjectLABPSD.Controllers;
using ProjectLABPSD.Factories;
using ProjectLABPSD.Handlers;
using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjectLABPSD.Views
{
    public partial class StationeryDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stationeryID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(stationeryID))
                { 
                    LoadStationery(stationeryID);
                    CheckUser();
                }
            }
        }

        private void LoadStationery(string stationeryID)
        {
            MsStationery stationery = StationeryHandler.GetStationeryByID(int.Parse(stationeryID));
            if (stationery != null)
            {
                LblStatName.Text = stationery.StationeryName;
                LblStatPrice.Text = stationery.StationeryPrice.ToString();
            }
        }

        private void CheckUser()
        {
            if(AuthController.UserIsLoggedIn() && AuthController.UserIsCustomer())
            {
                cartCustomer.Visible = true; 
            } else
            {
                cartCustomer.Visible = false;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(StationeryController.CheckQuantity(txtQuantity.Text) != "")
            {
                ErrorMessageLabel.Text = StationeryController.CheckQuantity(txtQuantity.Text);
                ErrorMessageLabel.Visible = true;
                return;
            }
            string loggedUser = Session["user"].ToString();
            string stationeryID = Request.QueryString["id"];

            CartHandler.AddToCart(loggedUser, stationeryID, int.Parse(txtQuantity.Text));
            Response.Write("<script>window.alert('Added to cart');window.location = 'StationeryDetailPage.aspx?id=" + stationeryID + "'</script>");
        }
    }
}