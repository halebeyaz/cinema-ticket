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
            var model = db.admin.ToList();
            return View();
        }
        public bool isLogin(string username, string pass)
        {
            admin ad = db.admin.Where(x => x.admin_name.Equals(username) && x.admin_password.Equals(pass)).FirstOrDefault();
            if (ad != null)
            {
                return true;
            }
            return new bool();
            
        }
       }
}