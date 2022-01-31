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
    public class kategoriController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        // GET: kategori
        public ActionResult Index()
        {
            var degerler = db.KATEGORITABLO.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(KATEGORITABLO ktg)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            db.KATEGORITABLO.Add(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var kategori = db.KATEGORITABLO.Find(id);
            return View(kategori);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var kategori = db.KATEGORITABLO.Find(id);
            db.KATEGORITABLO.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ktg = db.KATEGORITABLO.Find(id);
            return View(ktg);
        }
        [HttpPost]
        public ActionResult Edit(KATEGORITABLO kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            db.Entry(kategori).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
