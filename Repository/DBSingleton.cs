using ProjectLABPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLABPSD.Views.Repository
{
    public class DBSingleton
    {
        private static DatabaseEntities db = null;
        private DBSingleton() {
        }

        public static DatabaseEntities Getinstances()
        {
            if(db == null)
            {
                db = new DatabaseEntities();
            }
            return db;
        }
    }
}