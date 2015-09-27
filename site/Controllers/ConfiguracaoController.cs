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
    public class ConfiguracaoController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Configuracao/

        public ActionResult Index()
        {
            return View(db.Configuracao.ToList());
        }

        //
        // GET: /Configuracao/Edit/5

        public ActionResult Edit(string Chave)
        {
            Configuracao configuracao = db.Configuracao.Find(Chave);
            if (configuracao == null)
            {
                return HttpNotFound();
            }
            return View(configuracao);
        }

        //
        // POST: /Configuracao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Configuracao entrada)
        {
            Configuracao configuracao = db.Configuracao.Find(entrada.Chave);

            configuracao.Valor = entrada.Valor;

            if (ModelState.IsValid)
            {
                db.Entry(configuracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(configuracao);
        }

    }
}