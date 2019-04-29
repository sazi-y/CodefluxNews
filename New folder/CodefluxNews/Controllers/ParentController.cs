using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class ParentController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();
        // GET: Parent
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ParentCategories.ToList());
        }

        // GET: Parent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parent/Create
        [Authorize]
        public ActionResult Create()
        {
            var data = db.ParentCategories.OrderBy(p => p.ParentName).ToList();
            SelectList list = new SelectList(data, "ParentId", "ParentName");
            ViewBag.Parent = data;
            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parent/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parent/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
