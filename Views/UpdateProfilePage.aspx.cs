using ProjectLABPSD.Controllers;
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
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userID = Session["user"].ToString();
                LoadUserProfile(int.Parse(userID));
            }
        }
        
        protected void LoadUserProfile(int userID)
        {
            MsUser user = UserRepository.GetUserbyID(userID);
            if (user != null)
            {
                TextBoxName.Text = user.userName;
                TextBoxAddress.Text = user.userAddress;
                TextBoxPassword.Text = user.userPassword;
                TextBoxPhone.Text = user.userPhone;
                TextBoxDOB.Text = Convert.ToDateTime(user.userDOB).ToString("yyyy-MM-dd");
                RadioButtonGender.Text = user.userGender;
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string userID = Session["user"].ToString();
            string userName = TextBoxName.Text.Trim();
            string userPassword = TextBoxPassword.Text.Trim();
            string userGender = RadioButtonGender.SelectedValue;
            string userAddress = TextBoxAddress.Text.Trim();
            string userPhone = TextBoxPhone.Text.Trim();
                
            if (ProfileController.CheckProfile(int.Parse(userID),userName, TextBoxDOB.Text, userGender, userAddress, userPassword, userPhone) != "")
            {
                ErrorMessageLabel.Text = ProfileController.CheckProfile(int.Parse(userID), userName, TextBoxDOB.Text, userGender, userAddress, userPassword, userPhone);
                ErrorMessageLabel.Visible = true;
                return;
            }
            Response.Write("<script>window.alert('Successfully Updated'); window.location='UpdateProfilePage.aspx'</script>");
        }
    }
}