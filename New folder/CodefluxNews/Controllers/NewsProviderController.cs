using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class NewsProviderController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();

        // GET: NewsProvider
        [Authorize]
        public ActionResult Index()
        {
            return View(db.NewsProviders.ToList());
        }

        // GET: NewsProvider/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsProvider/Create
        [Authorize]
        public ActionResult Create()
        {
            var data = db.Countries.OrderBy(p => p.CountryName).ToList();
            SelectList list = new SelectList(data, "CountryId", "CountryName");
            ViewBag.Country = data;

            return View();
        }

        // POST: NewsProvider/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(NewsProvider provider)
        {
            try
            {
                var data = db.insertNewsProvider(provider.Name, provider.Url, provider.CountryId).ToString();
       
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: NewsProvider/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var data = db.Countries.OrderBy(p => p.CountryName).ToList();
            SelectList list = new SelectList(data, "CountryId", "CountryName");
            ViewBag.Country = data;


            NewsProvider provider = db.NewsProviders.Find(id);
            return View(provider);
        }
        
        // POST: NewsProvider/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ProviderId,Name,Url,CountryId")] NewsProvider provider, int id, Country country)
        {
            try
            {
                var update = db.updateNewsProvider
                    (
                    provider.ProviderId,
                    provider.Name, 
                    provider.Url, 
                    provider.CountryId
                    ).ToString();
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: NewsProvider/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var delete = db.deleteNewsProvider(id);
            return RedirectToAction("Index");
        }
    }
}
