using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Handlers
{
    public class UserHandler
    {
        public static MsUser Login(string userName, string userPassword)
        {
            MsUser user = UserRepository.GetUser(userName, userPassword);
            return user;
        }

        public static MsUser CheckUser (string userName)
        {
            MsUser user = UserRepository.GetUserName(userName);
            return user;
        }

        public static void DoRegisterUser(string userName, string userPassword, string userGender, string userPhone, string userAddress, string userRole, DateTime DOB)
        {
            UserRepository.AddNewUser(userName,userPassword, userGender, userPhone, userAddress, userRole, DOB);
        }

        public static void DoUpdateUser(int userID, string userName, string userPassword, string userGender, string userPhone, string userAddress, DateTime DOB)
        {
            UserRepository.UpdateExistingUser(userID,userName,userPassword,userGender, userPhone, userAddress, DOB);
        }
    }
}