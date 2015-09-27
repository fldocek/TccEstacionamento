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
    public class BlocoController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Bloco/

        public ActionResult Index()
        {
            var bloco = db.Bloco.Include(b => b.Andar);
            return View(bloco.ToList());
        }

        //
        // GET: /Bloco/Details/5

        public ActionResult Details(int id = 0)
        {
            Bloco bloco = db.Bloco.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        //
        // GET: /Bloco/Create

        public ActionResult Create()
        {
            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome");
            return View();
        }

        //
        // POST: /Bloco/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Bloco.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome", bloco.Id_Andar);
            return View(bloco);
        }

        //
        // GET: /Bloco/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bloco bloco = db.Bloco.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome", bloco.Id_Andar);
            return View(bloco);
        }

        //
        // POST: /Bloco/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { bloco.Id });
            }
            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome", bloco.Id_Andar);
            return View(bloco);
        }

        //
        // GET: /Bloco/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bloco bloco = db.Bloco.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        //
        // POST: /Bloco/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloco bloco = db.Bloco.Find(id);
            db.Bloco.Remove(bloco);
            db.SaveChanges();
            return RedirectToAction("Index","Andar",null);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}