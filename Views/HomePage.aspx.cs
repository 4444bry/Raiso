using ProjectLABPSD.Controllers;
using ProjectLABPSD.Handlers;
using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectLABPSD.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonInsert.Visible = AuthController.UserIsAdmin();
                LoadStationeries();
            }
        }

        private void LoadStationeries()
        {
                GridView.DataSource = StationeryHandler.GetStationery();
                GridView.DataBind();
                foreach(GridViewRow row in GridView.Rows)
                {
                    Button btnUpdate = (Button)row.FindControl("btnUp");
                    Button btnDetail = (Button)row.FindControl("btnDet");
                    Button btnDelete = (Button)row.FindControl("btnDel");
                    if (AuthController.UserIsAdmin())
                    {
                        btnUpdate.Visible = true;
                        btnDetail.Visible = true;  
                        btnDelete.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnDetail.Visible = true; ;
                    }
                }
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string stationeryID = GridView.DataKeys[rowIndex]["StationeryID"].ToString();
            StationeryHandler.DeleteStationery(stationeryID);
            LoadStationeries();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertStationery.aspx");
        }

        protected void BtnUp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            string stationeryID = GridView.DataKeys[row.RowIndex]["StationeryID"].ToString();
            Response.Redirect($"UpdateStationery.aspx?id={stationeryID}");
        }

        protected void BtnDet_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            GridViewRow row = (GridViewRow)btn.NamingContainer;

            string stationeryID = GridView.DataKeys[row.RowIndex]["StationeryID"].ToString();

            Response.Redirect("StationeryDetailPage.aspx?id=" + stationeryID);
        }
    }
}