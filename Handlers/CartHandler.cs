using ProjectLABPSD.Model;
using ProjectLABPSD.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Handlers
{
    public class CartHandler
    {
        public static List<object> GetCartList(int userID)
        {
            return CartRepository.GetCartList(userID);
        }

        public static void AddToCart(string userID, string stationeryID, int quantity)
        {
            CartRepository.AddCart(userID, stationeryID, quantity);
        }

        public static void DeleteFromCart(int userID, string stationeryID)
        {
            CartRepository.RemoveCartByID(userID, stationeryID);
        }

        public static void UpdateCart(string userID, string stationeryID, int quantity)
        {
            CartRepository.UpdateCart(userID, stationeryID, quantity);
        }

        public static void DeleteAllItem(int userID)
        {
            CartRepository.DeleteAllItem(userID);
        }

        public static Cart GetCartItemByID(int userID, int StationeryID)
        {
            return CartRepository.GetCartItemByID(userID, StationeryID);
        }
    }
}