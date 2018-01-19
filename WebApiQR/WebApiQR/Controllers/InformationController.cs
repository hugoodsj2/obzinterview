using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiQR.Models;

namespace WebApiQR.Controllers
{
    public class InformationController : Controller
    {
        private WebApiQRContext db = new WebApiQRContext();

        //
        // GET: /Information/

        public ActionResult Index()
        {
            var informations = db.INFORMATIONS.Include(i => i.QR_CODE);
            return View(informations.ToList());
        }

        //
        // GET: /Information/Details/5

        public ActionResult Details(int id = 0)
        {
            INFORMATIONS informations = db.INFORMATIONS.Find(id);
            if (informations == null)
            {
                return HttpNotFound();
            }
            return View(informations);
        }

        //
        // GET: /Information/Create

        public ActionResult Create()
        {
            ViewBag.id_qr = new SelectList(db.QR_CODE, "id", "qr_local");
            return View();
        }

        //
        // POST: /Information/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(INFORMATIONS informations)
        {
            if (ModelState.IsValid)
            {
                db.INFORMATIONS.Add(informations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_qr = new SelectList(db.QR_CODE, "id", "qr_local", informations.id_qr);
            return View(informations);
        }

        //
        // GET: /Information/Edit/5

        public ActionResult Edit(int id = 0)
        {
            INFORMATIONS informations = db.INFORMATIONS.Find(id);
            if (informations == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_qr = new SelectList(db.QR_CODE, "id", "qr_local", informations.id_qr);
            return View(informations);
        }

        //
        // POST: /Information/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(INFORMATIONS informations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_qr = new SelectList(db.QR_CODE, "id", "qr_local", informations.id_qr);
            return View(informations);
        }

        //
        // GET: /Information/Delete/5

        public ActionResult Delete(int id = 0)
        {
            INFORMATIONS informations = db.INFORMATIONS.Find(id);
            if (informations == null)
            {
                return HttpNotFound();
            }
            return View(informations);
        }

        //
        // POST: /Information/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INFORMATIONS informations = db.INFORMATIONS.Find(id);
            db.INFORMATIONS.Remove(informations);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}