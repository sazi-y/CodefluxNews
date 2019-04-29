using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CodefluxNews.Models;

namespace CodefluxNews.Controllers
{
    public class AdminController : Controller
    {
        NewsDBEntities db = new NewsDBEntities();

        public static string Hash(string value)
        {
            if(value != null)
            {
               value= Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
            }
            return value;
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }
        [Authorize]
        // GET: Admin
        public ActionResult Create()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            var password = Hash(admin.Password);
            var obj = db.Admins.Where(a => a.UserName.Equals(admin.UserName) && a.Password.Equals(password)).FirstOrDefault();
            if (obj == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            db.insertAdmin(admin.UserName, Hash(admin.Password));

            return RedirectToAction("Index","Home");

        }
        [Authorize]
        public ActionResult Login(Admin objUser)
        {


            //var model = new LogInModel
            //{
            //    ReturnUrl = returnUrl
            //};

          
            var password =Hash(objUser.Password);
            var obj = db.Admins.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(password)).FirstOrDefault();
            if (obj != null)
            {
                Session["UserID"] = obj.AdminId.ToString();
                Session["UserName"] = obj.UserName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Add TempData to check if the password and username are correct
                TempData["Error"] = "Invalid Username or password!";
                return View();
            }

        }

        


        //[HttpPost]
        //public ActionResult Login(LogInModel model)
        //{
        //    Admin admin = new Admin();
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var password = Hash(admin.Password);

        //    if (model.UserName == admin.UserName && model.Password == password)
        //    {
        //        var identity = new ClaimsIdentity(new[] {
        //        new Claim(ClaimTypes.Name, "Ben"),
        //        //new Claim(ClaimTypes.Email, "a@b.com"),
        //        //new Claim(ClaimTypes.Country, "England")
        //    },
        //            "ApplicationCookie");

        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;

        //        authManager.SignIn(identity);

        //        //return Redirect(GetRedirectUrl(model.ReturnUrl));
        //        return RedirectToAction("index","home");
        //    }

        //    // user authN failed
        //    ModelState.AddModelError("", "Invalid email or password");
        //    return View();
        //}

        //private string GetRedirectUrl(string returnUrl)
        //{
        //    if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
        //    {
        //        return Url.Action("index", "home");
        //    }

        //    return returnUrl;
        //}

        //public ActionResult LogOut()
        //{
        //    var ctx = Request.GetOwinContext();
        //    var authManager = ctx.Authentication;

        //    authManager.SignOut("ApplicationCookie");
        //    return RedirectToAction("index", "home");
        //}

    }
}

        

