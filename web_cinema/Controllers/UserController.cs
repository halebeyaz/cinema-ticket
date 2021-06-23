using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_cinema.Models;

namespace web_cinema.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        cinemaEntities db = new cinemaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registration(users user)
        {
            db.users.Add(user);
            db.SaveChanges();

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users user)
        {
            var lg = db.users.Where(a => a.user_name.Equals(user.user_name) && a.user_password.Equals(user.user_password));
            if (lg != null)
            {
                return RedirectToAction("Index", "User");//home'a gitsin user unutmayalım diye yazdım
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }
    }
}