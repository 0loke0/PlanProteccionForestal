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
    public class IncendiosForestalesController : Controller
    {
        private ProteccionForestalEntities1 db = new ProteccionForestalEntities1();

        // GET: IncendiosForestales
        public ActionResult Index()
        {
            return View(db.IncendiosForestales.ToList());
        }

        // GET: IncendiosForestales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncendiosForestales incendiosForestales = db.IncendiosForestales.Find(id);
            if (incendiosForestales == null)
            {
                return HttpNotFound();
            }
            return View(incendiosForestales);
        }

        // GET: IncendiosForestales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncendiosForestales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdBosques,IdPersonal,IdReservasAgua,IdHerramientas,IdCantidadHerramienta")] IncendiosForestales incendiosForestales)
        {
            if (ModelState.IsValid)
            {
                db.IncendiosForestales.Add(incendiosForestales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incendiosForestales);
        }

        // GET: IncendiosForestales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncendiosForestales incendiosForestales = db.IncendiosForestales.Find(id);
            if (incendiosForestales == null)
            {
                return HttpNotFound();
            }
            return View(incendiosForestales);
        }

        // POST: IncendiosForestales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdBosques,IdPersonal,IdReservasAgua,IdHerramientas,IdCantidadHerramienta")] IncendiosForestales incendiosForestales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incendiosForestales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incendiosForestales);
        }

        // GET: IncendiosForestales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncendiosForestales incendiosForestales = db.IncendiosForestales.Find(id);
            if (incendiosForestales == null)
            {
                return HttpNotFound();
            }
            return View(incendiosForestales);
        }

        // POST: IncendiosForestales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncendiosForestales incendiosForestales = db.IncendiosForestales.Find(id);
            db.IncendiosForestales.Remove(incendiosForestales);
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
