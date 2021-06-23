﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_cinema.Models;
namespace web_cinema.Controllers
{
    public class HomeController : Controller
    {
        cinemaEntities db = new cinemaEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.movies.ToList());
        }
    }
}