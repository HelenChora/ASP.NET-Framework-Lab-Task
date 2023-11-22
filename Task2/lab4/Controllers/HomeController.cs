
using lab4.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Labtask4Entities();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product d)
        {
            var db = new Labtask4Entities();
            db.Products.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");

            
            }


        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new Labtask4Entities();
            var ex = (from d in db.Products
                      where d.productId == id
                      select d).SingleOrDefault();
            return View(ex);

        }
        [HttpPost]
        public ActionResult Edit(Product d)
        {
            var db = new Labtask4Entities();
            var exdata = db.Products.Find(d.productId);
            exdata.productName = d.productName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new Labtask4Entities();
            var exdata = db.Products.Find(id);
            db.Products.Remove(exdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}