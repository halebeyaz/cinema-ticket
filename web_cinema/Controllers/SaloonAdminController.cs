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
    public class SaloonAdminController : Controller
    {
        // GET: SaloonAdmin
        cinemaEntities db = new cinemaEntities();
        public ActionResult Index()
        {
            return View(db.saloon.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");
            }


            new_records nr = db.new_records.Find(id);

            //users u = db.users.Find(id);
            return View(nr);
        }

        [HttpPost]
        public ActionResult Edit(new_records nr, HttpPostedFileBase File)
        {
            using (var context = new cinemaEntities())
            {
                var data = context.new_records.FirstOrDefault(x => x.s_id == nr.s_id);

                if (data != null)
                {
                    context.Entry(nr).State = System.Data.Entity.EntityState.Modified; //güncelleme için gerekiyor değişiklik yapma hakkı tanıyor
                    context.Entry(nr).Property(x => x.s_id).IsModified = false;

                    data.saloon_name = nr.saloon_name;
                    data.movie_name = nr.movie_name;
                    data.movie_id = nr.movie_id;
                    data.movie_description = nr.movie_description;
                    data.movie_beg_date = nr.movie_beg_date;
                    data.movie_end_date = nr.movie_end_date;
                    if (File != null)
                    {
                        FileInfo fileInfo = new FileInfo(File.FileName);
                        WebImage img = new WebImage(File.InputStream);
                        string uzanti = (Guid.NewGuid().ToString() + fileInfo.Extension);
                        img.Resize(275, 183, false, false);
                        string fullPath = "~/Content/Posters/" + uzanti;

                        img.Save(Server.MapPath(fullPath));

                        data.movie_poster = "/Content/Posters/" + uzanti;
                    }

                }
                context.SaveChanges();


            }
            return RedirectToAction("Index", "SaloonAdmin");
        }


    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");
            }

            //List<movies> moviesList = db.movies.ToList();
            //List<saloon> saloonList = db.saloon.ToList();



            //var query = from mov in moviesList
            //            join sal in saloonList on mov.s_id equals sal.saloon_id into table_ms
            //            from sal in table_ms.DefaultIfEmpty()
            //            select new MVC_Join { moviedetails = mov, saloondetails = sal};




            //var item = query.First(a => a.saloondetails.saloon_id.Equals(id));

            //var variable = db.new_records.Where(a => a.s_id.Equals(id));
            new_records nr = db.new_records.Find(id);

            return PartialView(nr);
        }
    }
}