using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class CategoryController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();
        // GET: Category
        [Authorize]
        public ActionResult Index()
        {
            return View(db.NewsCategories.ToList());
        }
        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: Category/Create
        public ActionResult Create()
        {
            var data = db.ParentCategories.OrderBy(p => p.ParentName).ToList();
            SelectList list = new SelectList(data, "ParentId", "ParentName");
            ViewBag.Parent = data;
            return View();
        }
        // POST: Category/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(NewsCategory category)
        {
            try
            {
                db.insertNewsCategory(category.CategoryName, category.ParentId).ToString();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.ParentCategories.OrderBy(p => p.ParentName).ToList();
            SelectList list = new SelectList(data, "ParentId", "ParentName");
            ViewBag.Parent = data;

            NewsCategory category = db.NewsCategories.Find(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include ="CategoryId,CategoryName,ParentId")] NewsCategory category, int id)
        {
            try
            {
                var update = db.updateNewsCategory(category.CategoryId, category.CategoryName, category.ParentId).ToString();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Category/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var delete = db.deleteNewsCategory(id);
                return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult ParentList()
        {
            return View(db.ParentCategories.ToList());
        }
        
        public ActionResult CreateParentCategory()
        {
            //var data = db.ParentCategories.OrderBy(p => p.ParentName).ToList();
            //SelectList list = new SelectList(data, "ParentId", "ParentName");
            //ViewBag.Parent = data;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateParentCategory(ParentCategory pcat)
        {

            if (pcat.ParentName != null || pcat.ParentName != "")
            {
                var addParent = db.insertParentCategory(pcat.ParentName);
                return RedirectToAction("ParentList");
            }
            else
            {
                return View();
            }
        }
        public ActionResult DeleteParent(int id)
        {
            var delete = db.deleteParentCategory(id);
            return RedirectToAction("ParentList");
        }

    }
}
