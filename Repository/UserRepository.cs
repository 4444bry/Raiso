using ProjectLABPSD.Factories;
using ProjectLABPSD.Model;
using System;
using System.Linq;

namespace ProjectLABPSD.Views.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = DBSingleton.Getinstances();

        public static MsUser GetUser(string userName, string userPassword)
        {
            return (from x in db.MsUsers where x.userName == userName && x.userPassword == userPassword select x).FirstOrDefault();
        }

        public static MsUser GetUserbyID(int id)
        {
            return (from x in db.MsUsers where x.userID == id select x).FirstOrDefault();
        }

        public static MsUser GetUserName(string userName)
        {
            return (from x in db.MsUsers where x.userName == userName select x).FirstOrDefault();
        }

        public static void AddNewUser(string userName, string userPassword, string userGender, string userPhone, string userAddress, string userRole, DateTime DOB)
        {
            MsUser newUser = UserFactories.CreateUser(userName, userPassword, userGender, userPhone, userAddress, userRole, DOB);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
        }

        public static void UpdateExistingUser(int userID, string userName, string userPassword, string userGender, string userPhone, string userAddress, DateTime DOB)
        {
            MsUser user = (from x in db.MsUsers where x.userID == userID select x).FirstOrDefault();

            user.userName = userName;
            user.userPassword = userPassword;
            user.userGender = userGender;
            user.userPhone = userPhone;
            user.userAddress = userAddress;
            user.userDOB = DOB;

            db.SaveChanges();
        }
    }
}