﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class TERRITORIOsController : Controller
    {
        private graficosEntities db = new graficosEntities();

        // GET: TERRITORIOs
        public ActionResult Index()
        {
            return View(db.TERRITORIO.ToList());
        }

        // GET: TERRITORIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIO = db.TERRITORIO.Find(id);
            if (tERRITORIO == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIO);
        }

        // GET: TERRITORIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TERRITORIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,auxiliar,iso_pais,nivel_administrativo")] TERRITORIO tERRITORIO)
        {
            if (ModelState.IsValid)
            {
                tERRITORIO.id = db.TEMPORALIDAD.Max(x => x.id) + 1;
                db.TERRITORIO.Add(tERRITORIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tERRITORIO);
        }

        // GET: TERRITORIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIO = db.TERRITORIO.Find(id);
            if (tERRITORIO == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIO);
        }

        // POST: TERRITORIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,auxiliar,iso_pais,nivel_administrativo")] TERRITORIO tERRITORIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tERRITORIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tERRITORIO);
        }

        // GET: TERRITORIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIO = db.TERRITORIO.Find(id);
            if (tERRITORIO == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIO);
        }

        // POST: TERRITORIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TERRITORIO tERRITORIO = db.TERRITORIO.Find(id);
            db.TERRITORIO.Remove(tERRITORIO);
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
