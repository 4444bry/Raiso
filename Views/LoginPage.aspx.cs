using ProjectLABPSD.Controllers;
using ProjectLABPSD.Model;
using System;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie isAdmin = HttpContext.Current.Request.Cookies["user_cookie"];
            if (isAdmin != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            String userName = TextBoxName.Text;
            String userPassword = TextBoxPassword.Text;
            bool isChecked = CBRemember.Checked;

            if(AuthController.CheckNameAndPassword(userName, userPassword) != "")
            {
                ErrorMessageLabel.Text = AuthController.CheckNameAndPassword(userName, userPassword);
                ErrorMessageLabel.Visible = true;
                return;
            }

           MsUser user = AuthController.Login(userName, userPassword, isChecked);
            if (user != null)
            {
                Session.Add("user", user.userID);
                Session.Add("userName", user.userName);
                Session.Add("userRole", user.userRole);
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = "Incorrect name or password. Please try again.";
                ErrorMessageLabel.CssClass = "errorMessage2";
                ErrorMessageLabel.Visible = true;
                return;
            }
        }
    }
}