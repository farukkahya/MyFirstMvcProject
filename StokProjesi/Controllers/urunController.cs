using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokProjesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace StokProjesi.Controllers
{
    public class urunController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        // GET: urun
        public ActionResult Index()
        {
            var degerler = db.URUNTABLO.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> degerler = (from i in db.KATEGORITABLO.ToList() select new SelectListItem { Text = i.kategoriAd, Value = i.kategoriID.ToString()}).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult Create(URUNTABLO urun)
        {
            if (ModelState.IsValid)
            {
                return View(urun);
            }
            var ktg = db.KATEGORITABLO.Where(m => m.kategoriID == urun.KATEGORITABLO.kategoriID).FirstOrDefault();
            urun.KATEGORITABLO = ktg;
            db.URUNTABLO.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var urun = db.URUNTABLO.Find(id);
            return View(urun);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var urun = db.URUNTABLO.Find(id);
            db.URUNTABLO.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var urun = db.URUNTABLO.Find(id);
            List<SelectListItem> degerler = (from i in db.KATEGORITABLO.ToList() select new SelectListItem { Text = i.kategoriAd, Value = i.kategoriID.ToString() }).ToList();
            ViewBag.dgr = degerler;
            
            return View(urun);
        }
        [HttpPost]
        public ActionResult Edit(URUNTABLO urun)
        {
            var u = db.URUNTABLO.Find(urun.urunID);
            var ktg = db.KATEGORITABLO.Where(m => m.kategoriID == urun.KATEGORITABLO.kategoriID).FirstOrDefault();
            u.uurnAd = urun.uurnAd;
            u.urunMarka = urun.urunMarka;
            u.urunKategori = ktg.kategoriID;
            u.urunFiyat = urun.urunFiyat;
            u.urunStok = urun.urunStok;
            //db.Entry(urun).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}