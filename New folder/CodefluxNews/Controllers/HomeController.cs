using System;
using System.Collections.Generic;
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

        public JsonResult GetCategory(string Category)
        {
            _db.Configuration.ProxyCreationEnabled = false;

            //int imageCount = Convert.ToInt32(Category);

            if (Category == "0")
            {
                var allImages =  _db.NewsArticles.ToList();

                return Json(allImages,JsonRequestBehavior.AllowGet);
            }
            else
            {
              
                var imageCounter = _db.NewsArticles.Where(x=>x.NewsCategory.CategoryName==Category).ToList();

                //var imageCounter = _db.NewsArticles.Where(x => x.CategoryId == imageCount).ToList();

                return Json(imageCounter,JsonRequestBehavior.AllowGet);
            }

        }


    }
}