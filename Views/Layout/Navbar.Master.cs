using ProjectLABPSD.Controllers;
using System;
using System.Web;
namespace ProjectLABPSD.Views.Layout
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            liLogout.Visible = AuthController.UserIsLoggedIn();
        }

        public void DisplayAdminNavigationLinks()
        {
            Response.Write("<li><a href=\"../Views/HomePage.aspx\">Home</a></li>");
            Response.Write("<li><a href=\"../Views/TransactionReportPage.aspx\">Transaction</a></li>");
            Response.Write("<li><a href=\"../Views/UpdateProfilePage.aspx\">Update Profile</a></li>");
        }

        public void DisplayCustomerNavigationLinks()
        {
            Response.Write("<li><a href=\"../Views/HomePage.aspx\">Home</a></li>");
            Response.Write("<li><a href=\"../Views/CartPage.aspx\">Cart</a></li>");
            Response.Write("<li><a href=\"../Views/TransactionHistoryPage.aspx\">Transaction</a></li>");
            Response.Write("<li><a href=\"../Views/UpdateProfilePage.aspx\">Update Profile</a></li>");
        }

        public void DisplayGuestNavigationLinks()
        {
            Response.Write("<li><a href=\"../Views/HomePage.aspx\">Home</a></li>");
            Response.Write("<li><a href=\"../Views/LoginPage.aspx\">Login</a></li>");
            Response.Write("<li><a href=\"../Views/RegisterPage.aspx\">Register</a></li>");
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            Session.Remove("user");
            Session.Remove("userName");
            Session.Remove("userRole");
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}