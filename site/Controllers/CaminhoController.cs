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
    public class CaminhoController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Caminho/

        public ActionResult Index()
        {
            var caminho = db.Caminho.Include(c => c.Totem).Include(c => c.Vaga);
            return View(caminho.ToList());
        }

        //
        // GET: /Caminho/Details/5

        public ActionResult Details(int id = 0)
        {
            Caminho caminho = db.Caminho.Find(id);
            if (caminho == null)
            {
                return HttpNotFound();
            }
            return View(caminho);
        }

        //
        // GET: /Caminho/Create

        public ActionResult Create()
        {
            ViewBag.Id_Totem = new SelectList(db.Totem, "Id", "Localizacao");
            ViewBag.Id_Vaga = new SelectList(ListarVagas(), "Id", "Nome");

            var model = new Caminho();
            return View(model);
        }

        //
        // POST: /Caminho/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caminho caminho)
        {
            if (ModelState.IsValid)
            {
                db.Caminho.Add(caminho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Totem = new SelectList(db.Totem, "Id", "Localizacao", caminho.Id_Totem);
            ViewBag.Id_Vaga = new SelectList(ListarVagas(), "Id", "Nome", caminho.Id_Vaga);
            return View(caminho);
        }

        //
        // GET: /Caminho/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Caminho caminho = db.Caminho.Find(id);
            if (caminho == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Totem = new SelectList(db.Totem, "Id", "Localizacao", caminho.Id_Totem);
            ViewBag.Id_Vaga = new SelectList(ListarVagas(), "Id", "Nome", caminho.Id_Vaga);
            return View(caminho);
        }

        //
        // POST: /Caminho/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Caminho caminho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caminho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Totem = new SelectList(db.Totem, "Id", "Localizacao", caminho.Id_Totem);
            ViewBag.Id_Vaga = new SelectList(ListarVagas(), "Id", "Nome", caminho.Id_Vaga);
            return View(caminho);
        }

        //
        // GET: /Caminho/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Caminho caminho = db.Caminho.Find(id);
            if (caminho == null)
            {
                return HttpNotFound();
            }
            return View(caminho);
        }

        //
        // POST: /Caminho/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caminho caminho = db.Caminho.Find(id);
            db.Caminho.Remove(caminho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private IEnumerable<object> ListarVagas()
        {
            return (from V in db.Vaga
                    select new 
                    {
                        Id = V.Id,
                        Nome = "Andar " + V.Bloco.Andar.Nome + 
                               " - Bloco " + V.Bloco.Nome +
                               " - Vaga " + V.Nome
                    });
        }
    }
}