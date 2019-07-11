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
    [RoutePrefix("technology")]
    public class HomeController : Controller
    {
        NewsDBEntities _db = new NewsDBEntities();
        public bool canRedirectToExternalNewsSource = false;

        public ActionResult Index()
        {
            return View();
        }
        [Route("news/{id}")]
        public async Task<ActionResult> News(string id)
        {
            try
            {
                var newsArticle = await _db.NewsArticles.Where(x => x.SEOURL == id).FirstOrDefaultAsync();
                //newsArticle.VisitCount = newsArticle.VisitCount + 1;
                if (newsArticle.VisitCount == null)
                    newsArticle.VisitCount = 0;

                newsArticle.VisitCount++;

                await _db.SaveChangesAsync();

                return View(newsArticle);
            }
            catch(Exception ex)
            {
                return View(RedirectToAction(nameof(Index)));
            }
        }
        public async void IncreaseClickCount(string id)
        {
            var newsArticle = await _db.NewsArticles.Where(x => x.SEOURL == id).FirstOrDefaultAsync();
            if (newsArticle.VisitCount == null)
                newsArticle.VisitCount = 0;

            newsArticle.VisitCount++;

            await _db.SaveChangesAsync();
        }
        [Route("redirect/{id}")]
        public async Task<ActionResult> CodeFluxRedirect(int id)
        {
            return View(await _db.NewsArticles.Where(x => x.ArticleId == id).FirstOrDefaultAsync());
        }
        public async Task<JsonResult> GetCategory(string Category, int pageIndex, int pageSize)
        {
            _db.Configuration.ProxyCreationEnabled = false;

            if (Category == "0"|| Category=="All News")
            {
                return Json(_db.selectNewsArticles().OrderByDescending(x => x.CreatedDate).Skip(pageIndex * pageSize).Take(pageSize).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var imageCounter = _db.selectNewsArticles().Where(x=>x.CategoryName == Category).OrderByDescending(x => x.ArticleId).Skip(pageIndex * pageSize).Take(pageSize).ToList();

                return Json(imageCounter,JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult _PartialNews()
        {
            return View(_db.selectTop8Articles().OrderByDescending(x => x.ArticleId).ToList());
        }
    }
}