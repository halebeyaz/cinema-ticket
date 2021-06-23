using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_cinema.Models;

namespace web_cinema.Controllers
{
    public class LoginController : Controller
    {
        cinemaEntities db = new cinemaEntities();
        // GET: Login
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
            var lg = db.admin.Where(a => a.admin_name.Equals(ad.admin_name) && a.admin_password.Equals(ad.admin_password));
            if (lg != null)
            {
                return RedirectToAction("Index", "BlogAdmin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        
    }
}