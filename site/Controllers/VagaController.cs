using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dados;

namespace site.Controllers
{
    public class VagaController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Vaga/

        public ActionResult Index()
        {
            var vaga = db.Vaga.Include(v => v.Bloco).Include(v => v.Carro);
            return View(vaga.ToList());
        }

        //
        // GET: /Vaga/Details/5

        public ActionResult Details(int id = 0)
        {
            Vaga vaga = db.Vaga.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        //
        // GET: /Vaga/Create

        public ActionResult Create()
        {
            ViewBag.Id_Bloco = new SelectList(db.Bloco, "Id", "Nome");
            ViewBag.Id_Carro = new SelectList(db.Carro, "Id", "Marca");
            return View();
        }

        //
        // POST: /Vaga/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                db.Vaga.Add(vaga);
                db.SaveChanges();
                return RedirectToAction("Details", new { vaga.Id });
            }

            ViewBag.Id_Bloco = new SelectList(db.Bloco, "Id", "Nome", vaga.Id_Bloco);
            return View(vaga);
        }

        //
        // GET: /Vaga/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vaga vaga = db.Vaga.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Bloco = new SelectList(db.Bloco, "Id", "Nome", vaga.Id_Bloco);
            ViewBag.Id_Carro = new SelectList(db.Carro, "Id", "Marca", vaga.Id_Carro);
            return View(vaga);
        }

        //
        // POST: /Vaga/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { vaga.Id });
            }
            ViewBag.Id_Bloco = new SelectList(db.Bloco, "Id", "Nome", vaga.Id_Bloco);
            ViewBag.Id_Carro = new SelectList(db.Carro, "Id", "Marca", vaga.Id_Carro);
            return View(vaga);
        }

        //
        // GET: /Vaga/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vaga vaga = db.Vaga.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        //
        // POST: /Vaga/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaga vaga = db.Vaga.Find(id);
            db.Vaga.Remove(vaga);
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