using ProjectLABPSD.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLABPSD.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string transactionID = Request.QueryString["id"];

            if(!string.IsNullOrEmpty(transactionID) )
            {
                LoadTransactionDetails(int.Parse(transactionID));
            }
        }

        protected void LoadTransactionDetails(int id)
        {
            GridView.DataSource = TransactionHandler.GetTransactionDetails(id);
            GridView.DataBind();
        }
    }
}