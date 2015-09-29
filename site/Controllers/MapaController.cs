using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dados;

namespace site.Controllers
{
    public class MapaController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Mapa/

        public ActionResult Index()
        {
            return View(db.Mapa.ToList());
        }

        //
        // GET: /Mapa/Details/5

        public ActionResult Details(int id = 0)
        {
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        //
        // GET: /Mapa/Create

        public ActionResult Create(int id = 0)
        {
            ViewBag.Id_Caminho = id;

            return View();
        }

        //
        // POST: /Mapa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            int Id_Caminho = int.Parse(form["Id_Caminho"]);

            Mapa mapa = new Mapa();
            mapa.Descricao = form["Descricao"];

            mapa.Caminho_Mapa.Add(
                new Caminho_Mapa
                {
                    Id_Caminho = Id_Caminho
                });

            SetFile(mapa);
            
            if (ModelState.IsValid)
            {
                db.Mapa.Add(mapa);
                db.SaveChanges();
                return RedirectToAction("Details", "Caminho", new { id = Id_Caminho });
            }

            return View();
        }

        private void SetFile(Mapa mapa)
        {

            HttpPostedFileBase upload = Request.Files[0];

            if (HasFile(upload))
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(upload.InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }

                mapa.Imagem = fileData;
            }

        }
        private bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        //
        // GET: /Mapa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        //
        // POST: /Mapa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mapa mapa)
        {
            SetFile(mapa);

            if (ModelState.IsValid)
            {
                db.Entry(mapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = mapa.Id });
            }
            return View(mapa);
        }

        //
        // GET: /Mapa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        //
        // POST: /Mapa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mapa mapa = db.Mapa.Find(id);
            db.Mapa.Remove(mapa);
            db.SaveChanges();
            return RedirectToAction("Index", "Caminho", null);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}