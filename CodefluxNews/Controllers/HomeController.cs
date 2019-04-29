using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class HomeController : Controller
    {
        NewsDBEntities _db = new NewsDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCategory(string Category, int pageIndex, int pageSize)
        {
            _db.Configuration.ProxyCreationEnabled = false;

            if (Category == "0"|| Category=="All News")
            {
                return Json(_db.selectNewsArticles().Skip(pageIndex * pageSize).Take(pageSize).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var imageCounter = _db.selectNewsArticles().Where(x=>x.CategoryName == Category).OrderByDescending(x => x.ArticleId).Skip(pageIndex * pageSize).Take(pageSize).ToList();

                return Json(imageCounter,JsonRequestBehavior.AllowGet);
            }
        }
    }
}