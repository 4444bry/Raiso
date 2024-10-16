using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Factories
{
    public class CartFactories
    {
        public static Cart CreateCart(int userID, int stationeryID, int quantity)
        {
            Cart newItem = new Cart();
            newItem.userID = userID;
            newItem.stationeryID = stationeryID;
            newItem.quantity = quantity;   

            return newItem;
        }
    }
}