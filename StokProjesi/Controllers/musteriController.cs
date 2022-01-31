using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using StokProjesi.Models.Entity;

namespace StokProjesi.Controllers
{
    public class musteriController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        // GET: musteri
        public ActionResult Index()
        {
            var degerler = db.MUSTERITABLO.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MUSTERITABLO mst)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            db.MUSTERITABLO.Add(mst);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var musteri = db.MUSTERITABLO.Find(id);
            return View(musteri);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var musteri = db.MUSTERITABLO.Find(id);
            db.MUSTERITABLO.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var musteri = db.MUSTERITABLO.Find(id);
            return View(musteri);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(MUSTERITABLO musteri)
        {
            db.Entry(musteri).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}