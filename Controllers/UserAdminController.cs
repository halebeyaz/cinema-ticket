using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using web_cinema.Models;
namespace web_cinema.Controllers
{
    public class UserAdminController : Controller
    {
        cinemaEntities db = new cinemaEntities();

        // GET: UserAdmin
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(users u)
        {
            var mExist = db.users.Any(x => x.user_id == u.user_id);
            if (mExist == false)
            {

                db.users.Add(u);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id) //soru işareti:  int ya da null olabilir
        {
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");
            }


            users u = db.users.Find(id);
            db.users.Remove(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Error404", "Error");
            }

            users u = db.users.Find(id);
            return PartialView(u);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Error404", "Error");
            }

            users u = db.users.Find(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(users u)
        {


            if (u != null)
            {
                db.Entry(u).State = System.Data.Entity.EntityState.Modified; //güncelleme için gerekiyor değişiklik yapma hakkı tanıyor
                db.Entry(u).Property(x => x.user_id).IsModified = false;

                

            }
            db.SaveChanges();
            return RedirectToAction("Index", "UserAdmin");
        }


    }
}