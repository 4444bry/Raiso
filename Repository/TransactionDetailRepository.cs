using ProjectLABPSD.Factories;
using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Repository
{
    public class TransactionDetailRepository
    {

        private static DatabaseEntities db = DBSingleton.Getinstances();
        public static void AddNewTransactionDetail(int transactionID, int stationeryID, int quantity)
        {
            TransactionDetail transaction = TransactionDetailFactories.AddNewTransactionDetail(transactionID, stationeryID, quantity);
            db.TransactionDetails.Add(transaction);
            db.SaveChanges();
        }

        public static List<object> GetTransactionDetails(int transactionID)
        {
            var detail = (from x in db.TransactionDetails
                          join MsStationery in db.MsStationeries on x.stationeryID equals MsStationery.StationeryID
                          where x.transactionID == transactionID
                          select new
                          {
                              StationeryName = MsStationery.StationeryName,
                              StationeryPrice = MsStationery.StationeryPrice,
                              quantity = x.quantity,
                          }
                          ).ToList<object>();

            return detail;
        }
    }
}