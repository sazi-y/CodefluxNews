using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class CountryController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();
        // GET: Country
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Country country, HttpPostedFileBase Logo)
        {
           
            //Extract Image File Name.
            string fileName = Path.GetFileName(Logo.FileName);
            
           //Set the Image File Path.
           string filePath = "~/UploadedImages/" + fileName;

              //Save the Image File in Folder.
              Logo.SaveAs(Server.MapPath(filePath));

                

                var insert = db.insertCountry(country.CountryName,filePath);

                return RedirectToAction("Index");
            
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = db.Countries.Find(id);
            return View(country);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="CountryId,CountryName,Logo")] Country country,int id, HttpPostedFileBase Logo)
        {

            try
            {
                //Extract Image File Name.
                string fileName = Path.GetFileName(Logo.FileName);

                //Set the Image File Path.
                string filePath = "~/UploadedImages/" + fileName;

                //Save the Image File in Folder.
                Logo.SaveAs(Server.MapPath(filePath));

                var update = db.updateCountry
                    (
                    country.CountryId,
                    country.CountryName,
                   filePath
                    ).ToString();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = db.deleteCountry(id);
           return RedirectToAction("Index");
            
        }
    }
}
