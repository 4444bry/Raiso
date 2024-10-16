using ProjectLABPSD.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Controllers
{
    public class StationeryController
    {
        public static string CheckInsert(string itemName, string itemPrice)
        {
            string response = "";

            if (string.IsNullOrEmpty(itemName))
            {
                return "Item name must be filled";
            }

            if (string.IsNullOrEmpty(itemPrice))
            {
                return "Price must be filled";
            }

            if(itemName.Length < 3 || itemName.Length > 50)
            {
                return "Item name must be between 3 - 50 characters";
            }

            if (!int.TryParse(itemPrice, out _))
            {
                return "Price must be numeric";
            }

            int price = int.Parse(itemPrice);

            if(price < 2000)
            {
                return "Price must be greather or equal to 2000";
            }

            StationeryHandler.CreateStationery(itemName, price);
            return response;
        }

        public static string CheckUpdate(string itemName, string itemPrice)
        {
            string response = "";

            if (string.IsNullOrEmpty(itemName))
            {
                return "Item name must be filled";
            }

            if (string.IsNullOrEmpty(itemPrice))
            {
                return "Price must be filled";
            }

            if (itemName.Length < 3 || itemName.Length > 50)
            {
                return "Item name must be between 3 - 50 characters";
            }

            if (!int.TryParse(itemPrice, out _))
            {
                return "Price must be numeric";
            }

            int price = int.Parse(itemPrice);

            if (price < 2000)
            {
                return "Price must be greather or equal to 2000";
            }

            return response;
        }

        public static string CheckQuantity(string quantity)
        {
            string response = "";
            if (!int.TryParse(quantity, out _))
            {
                return "Quantity must be more than 0";
            }

            int i = int.Parse(quantity);
            if (i <= 0)
            {
                return "Quantity must be more than 0";
            }

            return response;
        }
    }
}