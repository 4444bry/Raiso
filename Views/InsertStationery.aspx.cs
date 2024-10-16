using ProjectLABPSD.Controllers;
using ProjectLABPSD.Factories;
using ProjectLABPSD.Handlers;
using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLABPSD.Views
{
    public partial class InsertStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            string itemName = TextBoxName.Text;
            string Price = TextBoxPrice.Text;


            if(StationeryController.CheckInsert(itemName, Price) != "")
            {
                ErrorMessageLabel.Text = StationeryController.CheckInsert(itemName, Price);
                ErrorMessageLabel.Visible = true;
                return;
            }

            Response.Write("<script>window.alert('Successfully Insert Item'); window.location='InsertStationery.aspx'</script>");
        }
    }
}