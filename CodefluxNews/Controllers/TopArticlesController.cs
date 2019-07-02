using CodefluxNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodefluxNews.Controllers
{
    public class TopArticlesController : Controller
    {
        NewsDBEntities _db = new NewsDBEntities();
        // GET: TopArticles
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Top8()
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var json = _db.selectTop8Articles().ToList();
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}