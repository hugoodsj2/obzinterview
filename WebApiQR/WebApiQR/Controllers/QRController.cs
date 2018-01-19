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
    public class QRController : Controller
    {
        private WebApiQRContext db = new WebApiQRContext();

        //
        // GET: /QR/

        public ActionResult Index()
        {
            return View(db.QR_CODE.ToList());
        }

        //
        // GET: /QR/Details/5

        public ActionResult Details(int id = 0)
        {
            QR_CODE qr_code = db.QR_CODE.Find(id);
            if (qr_code == null)
            {
                return HttpNotFound();
            }
            return View(qr_code);
        }

        //
        // GET: /QR/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QR/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QR_CODE qr_code)
        {
            if (ModelState.IsValid)
            {
                db.QR_CODE.Add(qr_code);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qr_code);
        }

        //
        // GET: /QR/Edit/5

        public ActionResult Edit(int id = 0)
        {
            QR_CODE qr_code = db.QR_CODE.Find(id);
            if (qr_code == null)
            {
                return HttpNotFound();
            }
            return View(qr_code);
        }

        //
        // POST: /QR/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QR_CODE qr_code)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qr_code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qr_code);
        }

        //
        // GET: /QR/Delete/5

        public ActionResult Delete(int id = 0)
        {
            QR_CODE qr_code = db.QR_CODE.Find(id);
            if (qr_code == null)
            {
                return HttpNotFound();
            }
            return View(qr_code);
        }

        //
        // POST: /QR/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QR_CODE qr_code = db.QR_CODE.Find(id);
            db.QR_CODE.Remove(qr_code);
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