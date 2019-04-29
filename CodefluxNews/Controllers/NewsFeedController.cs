using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class NewsFeedController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();
        //GET: NewsFeed
        [Authorize]
        public ActionResult Index(NewsFeed feed)
        {
            
            return View(db.NewsFeeds.Where(x => x.Active == true).OrderByDescending(x=>x.NewsFeedId).ToList());
        }

        // GET: NewsFeed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsFeed/Create
        [Authorize]
        public ActionResult Create()
        {
            var data = db.NewsProviders.OrderBy(p => p.Name).ToList();
            SelectList list = new SelectList(data, "ProviderId", "Name");
            ViewBag.Provider = data;

            var model = db.NewsCategories.OrderBy(p => p.CategoryName).ToList();
            SelectList listCategories = new SelectList(model, "CategoryId", "CategoryName");
            ViewBag.Category = model;

            return View();
        }

        // POST: NewsFeed/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(NewsFeed feeds, HttpPostedFileBase Picture)
        {
            try
            {

                ////Extract Image File Name.
                //string fileName = Path.GetFileName(Picture.FileName);

                ////Set the Image File Path.
                //string filePath = "~/UploadedImages/" + fileName;

                ////Save the Image File in Folder.
                //Picture.SaveAs(Server.MapPath(filePath));

                var insert = db.insertNewsFeed(feeds.ProviderId, feeds.RssUrl, feeds.CategoryId/*filePath*/).ToString();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsFeed/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {

            var data = db.NewsProviders.OrderBy(p => p.Name).ToList();
            SelectList list = new SelectList(data, "ProviderId", "Name");
            ViewBag.Provider = data;

            var model = db.NewsCategories.OrderBy(p => p.CategoryName).ToList();
            SelectList listCategories = new SelectList(model, "CategoryId", "CategoryName");
            ViewBag.Category = model;

            NewsFeed feed = db.NewsFeeds.Find(id);


            return View(feed);
        }

        // POST: NewsFeed/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "NewsFeedId,ProviderId, RssUrl,CategoryId")] NewsFeed feed, HttpPostedFileBase Picture)
        {
            try
            {
                ////Extract Image File Name.
                //string fileName = Path.GetFileName(Picture.FileName);

                ////Set the Image File Path.
                //string filePath = "~/UploadedImages/" + fileName;

                ////Save the Image File in Folder.
                //Picture.SaveAs(Server.MapPath(filePath));

                var update = db.updateNewsFeed(feed.NewsFeedId, feed.ProviderId, feed.RssUrl, feed.CategoryId/*filePath*/).ToString();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsFeed/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            //To add delete code
            var delete = db.deleteNewsFeed(id);
         return RedirectToAction("Index");
            
        }
    }
}
