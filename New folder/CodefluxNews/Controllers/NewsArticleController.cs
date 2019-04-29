using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    
    public class NewsArticleController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();

        // GET: NewsArticle
        [Authorize]
        public ActionResult Index()
        {
            return View(db.NewsArticles.ToList());
        }

        // GET: NewsArticle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsArticle/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = db.NewsCategories.OrderBy(p => p.CategoryName).ToList();
            SelectList listCategories = new SelectList(model, "CategoryId", "CategoryName");
            ViewBag.Category = model;

            var data = db.NewsProviders.OrderBy(p => p.Name).ToList();
            SelectList list = new SelectList(data, "ProviderId", "Name");
            ViewBag.Provider = data;

            return View();
        }

        // POST: NewsArticle/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(NewsArticle article, HttpPostedFileBase Picture)
        {
            try
            {
                //Extract Image File Name.
                string fileName = Path.GetFileName(Picture.FileName);

                //Set the Image File Path.
                string filePath = "/UploadedImages/" + fileName;

                //Save the Image File in Folder.
                Picture.SaveAs(Server.MapPath(filePath));


                var insert = db.insertNewsArticle
                    (
                    article.Title,
                    article.Summary,
                    article.ProviderId,
                   filePath,
                    article.Url,article.CategoryId
                    ).ToString();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsArticle/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = db.NewsCategories.OrderBy(p => p.CategoryName).ToList();
            SelectList listCategories = new SelectList(model, "CategoryId", "CategoryName");
            ViewBag.Category = model;

            var data = db.NewsProviders.OrderBy(p => p.Name).ToList();
            SelectList list = new SelectList(data, "ProviderId", "Name");
            ViewBag.Provider = data;

            NewsArticle article = db.NewsArticles.Find(id);
            return View(article);

        }

        // POST: NewsArticle/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ArticleId,Title,Summary,ProviderId,Picture,Url,CategoryId")]
        int id, NewsArticle article, HttpPostedFileBase Picture)
        {
            try
            {
                //Extract Image File Name.
                string fileName = Path.GetFileName(Picture.FileName);

                //Set the Image File Path.
                string filePath = "~/UploadedImages/" + fileName;

                //Save the Image File in Folder.
                Picture.SaveAs(Server.MapPath(filePath));


                var update = db.updateNewsArticle
                    (article.ArticleId,
                    article.Title, 
                    article.Summary,
                    article.ProviderId,
                   filePath,
                   article.Url,article.CategoryId).ToString();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {

            var delete = db.deleteNewsArticle(id);
                return RedirectToAction("Index");
           
        }
    }
}
