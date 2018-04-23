using GoolgleZonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoolgleZonas.Controllers
{
    public class HomeController : Controller
    {
        ZonasDBEntities db = new ZonasDBEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "CodZona,NombreZona,Descripcion,Latitud,Longitud,Radio,FechaHoraCreado,CodUsuario")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                zona.FechaHoraCreado = DateTime.Now;
                db.Zona.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zona);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}