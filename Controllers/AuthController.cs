using ProjectLABPSD.Handlers;
using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Controllers
{
    public class AuthController
    {
        public static string CheckNameAndPassword(string userName, string userPassword)
        {
            string response = "";
            if (string.IsNullOrEmpty(userName)){
                response = "Name must be filled";
                return response;
            }

            if (string.IsNullOrEmpty(userPassword))
            {
                response = "Password must be filled";
                return response;
            }
            return response;
        }

        public static MsUser Login (string userName, string userPassword, bool isChecked)
        {
            MsUser user = UserHandler.Login(userName, userPassword);
            if (user != null)
            {
                if (isChecked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie["userID"] = user.userID.ToString();
                    cookie["userName"] = user.userName;
                    cookie["userRole"] = user.userRole;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }

            return user;
        }

        public static bool UserIsAdmin()
        {
            HttpCookie isAdmin = HttpContext.Current.Request.Cookies["user_cookie"];
            if (isAdmin != null && isAdmin["userRole"] == "Admin")
            {
                return true;
            }
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["userRole"] != null)
            {
                if (HttpContext.Current.Session["userRole"].ToString() == "Admin")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UserIsLoggedIn()
        {
            return HttpContext.Current.Session["user"] != null || HttpContext.Current.Request.Cookies["user_cookie"] != null;
        }
        public static bool UserIsCustomer()
        {
            HttpCookie isCustomer = HttpContext.Current.Request.Cookies["user_cookie"];
            if (isCustomer != null && isCustomer["userRole"] == "Customer")
            {
                return true;
            }

            if (HttpContext.Current.Session != null && HttpContext.Current.Session["userRole"] != null)
            {
                if (HttpContext.Current.Session["userRole"].ToString() == "Customer")
                {
                    return true;
                }
            }
            return false;
        }
    }
}