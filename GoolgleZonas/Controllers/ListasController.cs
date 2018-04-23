using GoolgleZonas.ModelosQuerys;
using GoolgleZonas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GoolgleZonas.Controllers
{
    public class ListasController : Controller
    {
        ZonasDBEntities db = new ZonasDBEntities();
        // GET: Listas
        public ActionResult Index()
        {
            List<Lista> lista = new List<Lista>();
            var query = from z in db.Zona
                        select new
                        {
                            z.CodZona,
                            z.NombreZona,
                            z.Descripcion,
                            z.Latitud,
                            z.Longitud,
                            z.Radio,
                            z.FechaHoraCreado,
                            z.CodUsuario
                        };
            foreach (var item in query)
            {
                lista.Add(new Lista
                {
                   CodZona=item.CodZona,
                   NombreZona=item.NombreZona,
                   Descripcion=item.Descripcion,
                   Latitud=item.Latitud,
                   Longitud=item.Longitud,
                   Radio=item.Radio,
                   FechaHoraCreado=item.FechaHoraCreado,
                   CodUsuario=item.CodUsuario
                });
            }
            return View(lista);
        }
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CodZona,NombreZona,Descripcion,Latitud,Longitud,Radio,FechaHoraCreado,CodUsuario")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                zona.FechaHoraCreado = DateTime.Now;
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zona);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zona zona = db.Zona.Find(id);
            db.Zona.Remove(zona);
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