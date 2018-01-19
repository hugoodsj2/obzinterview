using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiQR.Models;

namespace WebApiQR.Controllers
{
    public class QRCodeController : ApiController
    {
        private WebApiQRContext db = new WebApiQRContext();

        public string GetInformation(int id = 0)
        {
            var informations = db.INFORMATIONS.Where(inf => inf.id_qr == id).First().informations1;
            return informations;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}