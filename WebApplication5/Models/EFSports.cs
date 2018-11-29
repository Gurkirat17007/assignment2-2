using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class EFSports : ISportsMock
    {
        //Connect TO Database
        private Model1 db = new Model1();
        public IQueryable<Sport> Sports { get { return db.Sports; } }


        public void Delete(Sport sport)
        {
            db.Sports.Remove(sport);
            db.SaveChanges();
        }

        public Sport Save(Sport sport)
        {
            if (sport.Boys == 0)
            {
                // insert
                db.Sports.Add(sport);
            }
            else
            {
                // update
                db.Entry(sport).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return sport;
        }
    }
}