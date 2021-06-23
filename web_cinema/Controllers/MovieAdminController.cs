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
    public class MovieAdminController : Controller
    {
        cinemaEntities db = new cinemaEntities();
        // GET: MovieAdmin
        public ActionResult Index()
        {
            return View(db.movies.ToList());
        }        
        
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(movies m, HttpPostedFileBase File)
        {
            var mExist = db.movies.Any(x => x.movie_name == m.movie_name);
            if(mExist == false)
            {
            

                if (File != null)
                {
                    FileInfo fileInfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString()  + fileInfo.Extension);
                    img.Resize(275, 183, false, false);
                    string fullPath = "~/Content/Posters/" + uzanti;

                    img.Save(Server.MapPath(fullPath));

                    m.movie_poster = "/Content/Posters/" + uzanti;
                }
                db.movies.Add(m);
           
                try
                {
                    // Kodlarınız

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

            var data = db.movies.FirstOrDefault(x => x.movie_id == id);
            if(data != null)
            {
                db.movies.Remove(data);
                db.SaveChanges();

            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            movies m = db.movies.Find(id);
            return PartialView(m);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            movies m = db.movies.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(movies m, HttpPostedFileBase File)
        {
            using (var context = new cinemaEntities())
            {
                var data = context.movies.FirstOrDefault(x => x.movie_id == m.movie_id);
                if (data != null)
                {
                    context.Entry(m).State = System.Data.Entity.EntityState.Modified; //güncelleme için gerekiyor değişiklik yapma hakkı tanıyor
                    context.Entry(m).Property(x => x.s_id).IsModified = false;
                    context.Entry(m).Property(x => x.movie_id).IsModified = false;
                    data.movie_name = m.movie_name;
                    data.movie_end_date = m.movie_end_date;
                    data.movie_beg_date = m.movie_beg_date;
                    data.movie_description = m.movie_description;
                    if (File != null)
                    {
                        FileInfo fileInfo = new FileInfo(File.FileName);
                        WebImage img = new WebImage(File.InputStream);
                        string uzanti = (Guid.NewGuid().ToString() + fileInfo.Extension);
                        img.Resize(275, 183, false, false);
                        string fullPath = "~/Content/Posters/" + uzanti;

                        img.Save(Server.MapPath(fullPath));

                        m.movie_poster = "/Content/Posters/" + uzanti;
                    }
                    else
                    {
                        context.Entry(m).Property(x => x.movie_poster).IsModified = false;
                    }

                }
                context.SaveChanges();
            }

            
            return RedirectToAction("Index","MovieAdmin");
        }
    }
}