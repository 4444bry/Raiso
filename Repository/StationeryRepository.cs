using ProjectLABPSD.Factories;
using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Views.Repository
{
    public class StationeryRepository
    {
        private static DatabaseEntities db = DBSingleton.Getinstances();

        public static List<MsStationery> GetStationery()
        {
            return (from x in db.MsStationeries select x).ToList();
        }

        public static MsStationery GetStationeryByID(int id)
        {
            return (from x in db.MsStationeries where x.StationeryID == id select x).FirstOrDefault();
        }

        public static void UpdateStationery(int stationeryID, string itemName, int itemPrice)
        {
            MsStationery existStat = GetStationeryByID(stationeryID);
            if (existStat != null)
            {
                existStat.StationeryID = stationeryID;
                existStat.StationeryName = itemName;
                existStat.StationeryPrice = itemPrice;
                db.SaveChanges();
            }
        }

        public static void InsertStationery(string itemName, int itemPrice)
        {
            MsStationery newStationery = StationeryFactories.CreateStationery(itemName, itemPrice);
            db.MsStationeries.Add(newStationery);
            db.SaveChanges();
        }

        public static void DeleteStationery(string stationeryID)
        {
            MsStationery stationeryItem = GetStationeryByID(int.Parse(stationeryID));
            db.MsStationeries.Remove(stationeryItem);
            db.SaveChanges();
        }

        public static int GetStationeryPrice(int stationeryID)
        {
            var price = (from x in db.MsStationeries where x.StationeryID == stationeryID select x).FirstOrDefault();
            return price.StationeryPrice;
        }
    }
}