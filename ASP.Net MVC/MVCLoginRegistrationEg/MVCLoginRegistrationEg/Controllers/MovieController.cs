using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLoginRegistrationEg.Controllers
{
    public class MovieController : Controller
    {
        dbMovieShopEntities db = new dbMovieShopEntities();
        // GET: Movie
        public ActionResult Index()
        {
            ViewData["ServerTime"] = DateTime.Now;
            return View(db.tblMovies.ToList());
        }
        public ActionResult DisplayMovie()
        {
            tblMovie movie1111 = new tblMovie();
            movie1111.id = 10;
            movie1111.name = "Drishyam-2";
            movie1111.duration = 3;
            return View(movie1111);
        }
    }
}