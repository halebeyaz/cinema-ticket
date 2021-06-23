using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

                try
                {                    
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
               
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id) //soru işareti:  int ya da null olabilir
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var data = db.users.FirstOrDefault(x => x.user_id == id);
            if (data != null)
            {
                db.users.Remove(data);
                db.SaveChanges();

            }

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
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");
            }


            var data = db.users.Where(x => x.user_id == id).SingleOrDefault();

            //users u = db.users.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(users u)
        {
            using (var context = new cinemaEntities())
            {
                var data = context.users.FirstOrDefault(x => x.user_id == u.user_id);

                if (data != null)
                {
                    context.Entry(u).State = System.Data.Entity.EntityState.Modified; //güncelleme için gerekiyor değişiklik yapma hakkı tanıyor
                    context.Entry(u).Property(x => x.user_id).IsModified = false;
                    data.user_name = u.user_name;
                    data.user_email = u.user_email;
                    data.user_password = u.user_password;
                    data.user_phone = u.user_phone;
                    context.SaveChanges();
                }
            }

            
            return RedirectToAction("Index", "UserAdmin");
        }


    }
}