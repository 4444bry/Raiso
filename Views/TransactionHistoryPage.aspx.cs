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
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userID = Session["user"].ToString();
                ShowTransactionHistory(int.Parse(userID));
            }
        }

        protected void ShowTransactionHistory(int userID)
        {
            List<object> t = TransactionHandler.GetTransactionHistoryByUserID(userID);


            GridView.DataSource = t;
            GridView.DataBind();
        }

        protected void BtnDet_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            GridViewRow row = (GridViewRow)btn.NamingContainer;

            string transactionID = GridView.DataKeys[row.RowIndex]["transactionID"].ToString();

            Response.Redirect("TransactionDetailPage.aspx?id=" + transactionID);
        }
    }
}