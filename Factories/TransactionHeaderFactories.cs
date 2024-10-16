using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Factories
{
    public class TransactionHeaderFactories
    {
        public static TransactionHeader NewTransaction(int userID, DateTime transactionDate)
        {
            TransactionHeader t = new TransactionHeader();
            t.userID = userID;
            t.transactionDate = transactionDate;
            return t;
        }
    }
}