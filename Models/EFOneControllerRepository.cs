using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// references


namespace Assignment_2.Models
{


    public class EFOneControllerRepository : IOneControllerRepository
    {
        // repositoryfor CRUD with phones in SQL server db

        // db connection moved here from oneController
        Model1 db = new Model1();

        public IQueryable<phone> phones { get { return db.phones; } }

        public void Delete(phone phone)
        {
            db.phones.Remove(phone);
            db.SaveChanges();
        }

        public phone Save(phone phone)
        {
            if (phone.price == 0 )
            {
                db.phones.Add(phone);
            }
            else
            {
                db.Entry(phone).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return phone;

        }
    }
}