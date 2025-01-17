﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BosquesController : Controller
    {
        private ProteccionForestalEntities db = new ProteccionForestalEntities();

        // GET: Bosques
        public ActionResult Index()
        {
            return View(db.Bosques.ToList());
        }

        // GET: Bosques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bosques bosques = db.Bosques.Find(id);
            if (bosques == null)
            {
                return HttpNotFound();
            }
            return View(bosques);
        }

        // GET: Bosques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bosques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Area,Ubicacion")] Bosques bosques)
        {
            if (ModelState.IsValid)
            {
                db.Bosques.Add(bosques);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bosques);
        }

        // GET: Bosques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bosques bosques = db.Bosques.Find(id);
            if (bosques == null)
            {
                return HttpNotFound();
            }
            return View(bosques);
        }

        // POST: Bosques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Area,Ubicacion")] Bosques bosques)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bosques).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bosques);
        }

        // GET: Bosques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bosques bosques = db.Bosques.Find(id);
            if (bosques == null)
            {
                return HttpNotFound();
            }
            return View(bosques);
        }

        // POST: Bosques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bosques bosques = db.Bosques.Find(id);
            db.Bosques.Remove(bosques);
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
