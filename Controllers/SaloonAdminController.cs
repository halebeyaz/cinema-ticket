using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            saloon s = db.saloon.Find(id);

            return PartialView(s);
        }
    }
}