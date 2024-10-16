using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Factories
{
    public class TransactionDetailFactories
    {
        public static TransactionDetail AddNewTransactionDetail(int transactionID, int stationeryID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.transactionID = transactionID;
            transactionDetail.stationeryID = stationeryID;
            transactionDetail.quantity = quantity; 

            return transactionDetail;
        }
    }
}