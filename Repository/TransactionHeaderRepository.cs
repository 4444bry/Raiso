using ProjectLABPSD.Factories;
using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Views.Repository
{
    public class TransactionHeaderRepository
    {

        private static DatabaseEntities db = DBSingleton.Getinstances();


        public static List<TransactionHeader> GetTransactions()
        {
            return db.TransactionHeaders.ToList();
        }

        public static List<object> GetTransactionHistoryByUserID(int userID)
        {

            var history = (from TransactionHeader in db.TransactionHeaders
                           join MsUser in db.MsUsers on TransactionHeader.userID equals MsUser.userID
                           where TransactionHeader.userID == userID
                           select new {
                               transactionID = TransactionHeader.transactionID,
                               userName = MsUser.userName,
                               transactionDate = TransactionHeader.transactionDate,
                           }).ToList();

            var formatted = history.Select(item => new
            {
                transactionID = item.transactionID,
                userName = item.userName,
                transactionDate = Convert.ToDateTime(item.transactionDate).ToShortDateString(),
            }).ToList<object>();

            return formatted;
        }

        public static int AddNewTransaction(int userID, DateTime transactionDate)
        {
            TransactionHeader transaction = TransactionHeaderFactories.NewTransaction(userID, transactionDate);
            db.TransactionHeaders.Add(transaction);
            db.SaveChanges();

            return transaction.transactionID;
        }
    }
}