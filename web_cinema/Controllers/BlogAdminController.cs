using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using web_cinema.Models;

namespace web_cinema.Controllers
{
    public class BlogAdminController : Controller
    {
        // GET: BlogAdmin
        cinemaEntities db = new cinemaEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


       
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(admin ad)
        {
            var lg = db.admin.FirstOrDefault(a => a.admin_name==ad.admin_name && a.admin_password==ad.admin_password);
            if (lg != null)
            {
                FormsAuthentication.SetAuthCookie(lg.admin_name, false);
                return RedirectToAction("Index", "BlogAdmin");
            }
            else
            {
                return RedirectToAction("Login", "BlogAdmin");
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}