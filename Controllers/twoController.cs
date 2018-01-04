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
    public class twoController : Controller
    {
        private Model1 db = new Model1();

        // GET: two
        public ActionResult Index()
        {
            var phones1 = db.phones1.Include(p => p.phone);
            return View(phones1.ToList());
        }

        // GET: two/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phones1 phones1 = db.phones1.Find(id);
            if (phones1 == null)
            {
                return HttpNotFound();
            }
            return View(phones1);
        }

        // GET: two/Create
        public ActionResult Create()
        {
            ViewBag.phones = new SelectList(db.phones, "phones", "models");
            return View();
        }

        // POST: two/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "models,phones,price,condition")] phones1 phones1)
        {
            if (ModelState.IsValid)
            {
                db.phones1.Add(phones1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.phones = new SelectList(db.phones, "phones", "models", phones1.phones);
            return View(phones1);
        }

        // GET: two/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phones1 phones1 = db.phones1.Find(id);
            if (phones1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.phones = new SelectList(db.phones, "phones", "models", phones1.phones);
            return View(phones1);
        }

        // POST: two/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "models,phones,price,condition")] phones1 phones1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phones1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.phones = new SelectList(db.phones, "phones", "models", phones1.phones);
            return View(phones1);
        }

        // GET: two/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phones1 phones1 = db.phones1.Find(id);
            if (phones1 == null)
            {
                return HttpNotFound();
            }
            return View(phones1);
        }

        // POST: two/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            phones1 phones1 = db.phones1.Find(id);
            db.phones1.Remove(phones1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
