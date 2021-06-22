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
                saloon s = db.saloon.Find(m.s_id);
                s.saloon_time = m.movie_beg_date; //salonda oynayacak filmin süresini ve seans saatlerini ayarlaması gerek.
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int? id) //soru işareti:  int ya da null olabilir
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            

            movies movie = db.movies.Find(id);
            db.movies.Remove(movie);
            db.SaveChanges();
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


            if(m != null)
            {
                db.Entry(m).State = System.Data.Entity.EntityState.Modified; //güncelleme için gerekiyor değişiklik yapma hakkı tanıyor
                db.Entry(m).Property(x => x.s_id).IsModified = false;
                
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
                    db.Entry(m).Property(x => x.movie_poster).IsModified = false;
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index","MovieAdmin");
        }
    }
}