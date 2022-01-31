using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokProjesi.Models.Entity;

namespace StokProjesi.Controllers
{
    public class SatisController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Sales()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sales(SATISTABLO sts)
        {
            db.SATISTABLO.Add(sts);
            db.SaveChanges();
            return View("Index");
        }
    }
}