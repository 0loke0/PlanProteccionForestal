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
    public class HerramientasController : Controller
    {
        private ProteccionForestalEntities db = new ProteccionForestalEntities();

        // GET: Herramientas
        public ActionResult Index()
        {
            return View(db.Herramientas.ToList());
        }

        // GET: Herramientas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramientas herramientas = db.Herramientas.Find(id);
            if (herramientas == null)
            {
                return HttpNotFound();
            }
            return View(herramientas);
        }

        // GET: Herramientas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo,Cantidad,Capacitacion")] Herramientas herramientas)
        {
            if (ModelState.IsValid)
            {
                db.Herramientas.Add(herramientas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herramientas);
        }

        // GET: Herramientas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramientas herramientas = db.Herramientas.Find(id);
            if (herramientas == null)
            {
                return HttpNotFound();
            }
            return View(herramientas);
        }

        // POST: Herramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo,Cantidad,Capacitacion")] Herramientas herramientas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herramientas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herramientas);
        }

        // GET: Herramientas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramientas herramientas = db.Herramientas.Find(id);
            if (herramientas == null)
            {
                return HttpNotFound();
            }
            return View(herramientas);
        }

        // POST: Herramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herramientas herramientas = db.Herramientas.Find(id);
            db.Herramientas.Remove(herramientas);
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
