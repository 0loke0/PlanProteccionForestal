using System;
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
    public class ReservasAguasController : Controller
    {
        private ProteccionForestalEntities db = new ProteccionForestalEntities();

        // GET: ReservasAguas
        public ActionResult Index()
        {
            return View(db.ReservasAgua.ToList());
        }

        // GET: ReservasAguas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservasAgua reservasAgua = db.ReservasAgua.Find(id);
            if (reservasAgua == null)
            {
                return HttpNotFound();
            }
            return View(reservasAgua);
        }

        // GET: ReservasAguas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasAguas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Area,TipoReserva,Ubicacion")] ReservasAgua reservasAgua)
        {
            if (ModelState.IsValid)
            {
                db.ReservasAgua.Add(reservasAgua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservasAgua);
        }

        // GET: ReservasAguas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservasAgua reservasAgua = db.ReservasAgua.Find(id);
            if (reservasAgua == null)
            {
                return HttpNotFound();
            }
            return View(reservasAgua);
        }

        // POST: ReservasAguas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Area,TipoReserva,Ubicacion")] ReservasAgua reservasAgua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservasAgua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservasAgua);
        }

        // GET: ReservasAguas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservasAgua reservasAgua = db.ReservasAgua.Find(id);
            if (reservasAgua == null)
            {
                return HttpNotFound();
            }
            return View(reservasAgua);
        }

        // POST: ReservasAguas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservasAgua reservasAgua = db.ReservasAgua.Find(id);
            db.ReservasAgua.Remove(reservasAgua);
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
