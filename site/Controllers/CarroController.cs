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
    public class CarroController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Carro/Details/5

        public ActionResult Details(int id = 0)
        {
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        //
        // GET: /Carro/Create

        public ActionResult Create(int id = 0)
        {
            ViewBag.Id_Cliente = id;

            return View();
        }

        //
        // POST: /Carro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            int Id_Cliente = int.Parse(form["Id_Cliente"]);

            Carro carro = new Carro();
            carro.Id_Cliente = Id_Cliente;
            carro.Placa = form["Descricao"];
            carro.Marca = form["Descricao"];
            carro.Tag = form["Descricao"];

            if (ModelState.IsValid)
            {
                db.Carro.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = carro.Id });
            }

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nome", carro.Id_Cliente);
            return View(carro);
        }

        //
        // GET: /Carro/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nome", carro.Id_Cliente);
            return View(carro);
        }

        //
        // POST: /Carro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = carro.Id });
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nome", carro.Id_Cliente);
            return View(carro);
        }

        //
        // GET: /Carro/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        //
        // POST: /Carro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carro.Find(id);

            int Id_Cliente = carro.Id_Cliente;

            db.Carro.Remove(carro);
            db.SaveChanges();
            return RedirectToAction("Details", "Cliente", new { id = Id_Cliente });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}