using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    [Authorize]
    public class oneController : Controller
    {
        //db connection moved to models/EFOneControllerRepository.cs
        //private Model1 db = new Model1();
        private IOneControllerRepository db;

        // if no mock specified, use db
            public oneController()
        {
            this.db = new EFOneControllerRepository();
        }

        // if we tell the controller we are testing, use the mock interface
        public oneController(IOneControllerRepository db)
        {
            this.db = db;
        }

        // GET: one
        public ViewResult Index()
        {
            return View(db.phones.ToList());
        }

        // GET: one/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            phone phone = db.phones.FirstOrDefault(a => a.price == id);
            if (phone == null)
            {
                return View("Error");
            }
            return View(phone);
        }
        //        [AllowAnonymous]
        //        // GET: one/Create
        //        public ActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: one/Create
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "phones,models,launch_year,price,ratings")] phone phone)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.phones.Add(phone);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }

        //            return View(phone);
        //        }

        //        // GET: one/Edit/5
        //        public ActionResult Edit(string id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            phone phone = db.phones.Find(id);
        //            if (phone == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(phone);
        //        }

        //        // POST: one/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "phones,models,launch_year,price,ratings")] phone phone)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(phone).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            return View(phone);
        //        }

        //        // GET: one/Delete/5
        //        public ActionResult Delete(string id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            phone phone = db.phones.Find(id);
        //            if (phone == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(phone);
        //        }

        // POST: one/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ViewResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            phone phone = db.phones.FirstOrDefault(a => a.price == id);

            if (phone == null)
            {
                return View("Error");
            }

            db.Delete(phone);
            return View("Index");
        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}
