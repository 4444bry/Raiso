using ProjectLABPSD.Factories;
using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Views.Repository
{
    public class CartRepository
    {
        private static DatabaseEntities db = DBSingleton.Getinstances();
        public static List<object> GetCartList(int userID)
        {
            var cartItems = (from cart in db.Carts
                             join MsStationery in db.MsStationeries on cart.stationeryID equals MsStationery.StationeryID
                             where cart.userID == userID
                             select new
                             {
                                 StationeryID = MsStationery.StationeryID,
                                 StationeryName = MsStationery.StationeryName,
                                 StationeryPrice = MsStationery.StationeryPrice,
                                 Quantity = cart.quantity
                             }).ToList<object>();

            return cartItems;
        }

        public static Cart CheckItem(string userID, string StationeryID, int quantity)
        {
            Cart existingItem = db.Carts.FirstOrDefault(x => x.userID.ToString() == userID && x.stationeryID.ToString() == StationeryID);
            return existingItem;
        }

        public static void AddCart(string userID, string stationeryID, int quantity)
        {
            Cart existingCartEntry = CheckItem(userID, stationeryID, quantity);

            if (existingCartEntry != null)
            {
                existingCartEntry.quantity += quantity;
            }
            else
            {
                Cart cart = CartFactories.CreateCart(int.Parse(userID), int.Parse(stationeryID), quantity);
                db.Carts.Add(cart);
            }
            db.SaveChanges();
        }

        public static void UpdateCart(string userID, string stationeryID, int quantity)
        {
            Cart itemToUpdate = CheckItem(userID, stationeryID, quantity);
            
            if(itemToUpdate != null)
            {
                itemToUpdate.quantity= quantity;
                db.SaveChanges();
            }
        }

        public static void RemoveCarts(List<Cart> carts)
        {
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }

        public static Cart GetCartItemByID(int userID, int StationeryID)
        {
            Cart cartItem = db.Carts.FirstOrDefault(c => c.userID == userID && c.stationeryID == StationeryID);

            return cartItem;
        }

        public static void RemoveCartByID(int userID, string stationeryID) 
        {
            Cart cartItemToDelete = db.Carts.FirstOrDefault(c => c.userID == userID && c.stationeryID.ToString() == stationeryID);
            db.Carts.Remove(cartItemToDelete);
            db.SaveChanges();
        }

        public static void DeleteAllItem(int userID)
        {
            var cartItems = db.Carts.Where(c => c.userID == userID).ToList();

            if (cartItems.Any())
            {
                db.Carts.RemoveRange(cartItems);
                db.SaveChanges();
            }
        }
    }
}