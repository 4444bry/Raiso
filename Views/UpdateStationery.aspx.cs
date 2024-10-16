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
    public partial class UpdateStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            MsStationery existingStationery = StationeryHandler.GetStationeryByID(int.Parse(stationeryID));
            if (existingStationery != null)
            {
                TextBoxName.Text = existingStationery.StationeryName;
                TextBoxPrice.Text = existingStationery.StationeryPrice.ToString();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string itemName = TextBoxName.Text;
            string Price = TextBoxPrice.Text;

           if(StationeryController.CheckUpdate(itemName,Price) != "")
            {
                ErrorMessageLabel.Text = StationeryController.CheckUpdate(itemName,Price);
                ErrorMessageLabel.Visible = true;
                return;
            }
            string stationeryID = Request.QueryString["id"];
            StationeryHandler.UpdateStationery(int.Parse(stationeryID), itemName, int.Parse(Price));

            Response.Write("<script>window.alert('Successfully Update Item'); window.location='HomePage.aspx'</script>");
        }
    }

}