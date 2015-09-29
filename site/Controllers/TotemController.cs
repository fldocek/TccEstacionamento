using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dados;
using MessagingToolkit.QRCode.Codec;

namespace site.Controllers
{
    public class TotemController : Controller
    {
        private ParkingDBEntities db = new ParkingDBEntities();

        //
        // GET: /Totem/

        public ActionResult Index()
        {
            var totem = db.Totem.Include(t => t.Andar);
            return View(totem.ToList());
        }

        //
        // GET: /Totem/Details/5

        public ActionResult Details(int id = 0)
        {
            Totem totem = db.Totem.Find(id);
            if (totem == null)
            {
                return HttpNotFound();
            }

            ViewBag.imgSrc = GerarQRCode(id);

            return View(totem);
        }

        //
        // GET: /Totem/Create

        public ActionResult Create()
        {
            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome");
            return View();
        }

        //
        // POST: /Totem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Totem totem)
        {
            if (ModelState.IsValid)
            {
                db.Totem.Add(totem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome", totem.Id_Andar);
            return View(totem);
        }

        //
        // GET: /Totem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Totem totem = db.Totem.Find(id);
            if (totem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome", totem.Id_Andar);
            return View(totem);
        }

        //
        // POST: /Totem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Totem totem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Andar = new SelectList(db.Andar, "Id", "Nome", totem.Id_Andar);
            return View(totem);
        }

        //
        // GET: /Totem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Totem totem = db.Totem.Find(id);
            if (totem == null)
            {
                return HttpNotFound();
            }

            ViewBag.imgSrc = GerarQRCode(id);

            return View(totem);
        }

        //
        // POST: /Totem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Totem totem = db.Totem.Find(id);
            db.Totem.Remove(totem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Print(int id = 0)
        {
            ViewBag.imgSrc = GerarQRCode(id);

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private string GerarQRCode(int id)
        {
            if (id == 0)
            {
                return null;
            }

            // Criar o QR code
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap bitmapImage = encoder.Encode(id.ToString());

            // Transforma em bytes
            MemoryStream ms = new MemoryStream();
            bitmapImage.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();
            
            // Cria o source da imagem
            string base64 = Convert.ToBase64String(bitmapData);
            string imgSrc = String.Format("data:image/jpeg;base64,{0}", base64);

            return imgSrc;
        }
    }
}