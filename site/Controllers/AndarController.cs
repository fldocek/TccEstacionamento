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
    public class AndarController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Andar/

        public ActionResult Index()
        {
            return View(db.Andar.ToList());
        }

        //
        // GET: /Andar/Details/5

        public ActionResult Details(int id = 0)
        {
            Andar andar = db.Andar.Find(id);
            if (andar == null)
            {
                return HttpNotFound();
            }
            return View(andar);
        }

        //
        // GET: /Andar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Andar/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Andar andar)
        {
            if (ModelState.IsValid)
            {
                db.Andar.Add(andar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(andar);
        }

        //
        // GET: /Andar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Andar andar = db.Andar.Find(id);
            if (andar == null)
            {
                return HttpNotFound();
            }
            return View(andar);
        }

        //
        // POST: /Andar/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Andar andar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(andar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(andar);
        }

        //
        // GET: /Andar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Andar andar = db.Andar.Find(id);
            if (andar == null)
            {
                return HttpNotFound();
            }
            return View(andar);
        }

        //
        // POST: /Andar/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Andar andar = db.Andar.Find(id);
            db.Andar.Remove(andar);
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