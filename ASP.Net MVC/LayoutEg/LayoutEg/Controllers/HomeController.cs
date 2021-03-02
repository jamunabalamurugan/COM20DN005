using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutEg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] UpcomingMovies = { "Man of Steel", "World War Z", "Monsters University" };
            string[] StarCast = { "Henry Cavill, Amy Adams, Michael Shannon, Diane Lane", "Brad Pitt, Mireille Enos, Daniella Kertesz, Matthew Fox", "Billy Crystal, John Goodman, Steve Buscemi, Helen Mirren" };

            ViewBag.names = UpcomingMovies;
            ViewBag.starcast = StarCast;
           
            return View();
        }
        public ActionResult About()
        {
            string[] UpcomingMovies = { "Man of Steel", "World War Z", "Monsters University" };
            string[] StarCast = { "Henry Cavill, Amy Adams, Michael Shannon, Diane Lane", "Brad Pitt, Mireille Enos, Daniella Kertesz, Matthew Fox", "Billy Crystal, John Goodman, Steve Buscemi, Helen Mirren" };

            ViewBag.names = UpcomingMovies;
            ViewBag.starcast = StarCast;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string[] UpcomingMovies = { "Man of Steel", "World War Z", "Monsters University" };
            string[] StarCast = { "Henry Cavill, Amy Adams, Michael Shannon, Diane Lane", "Brad Pitt, Mireille Enos, Daniella Kertesz, Matthew Fox", "Billy Crystal, John Goodman, Steve Buscemi, Helen Mirren" };

            ViewBag.names = UpcomingMovies;
            ViewBag.starcast = StarCast;
            return View();
        }
    }
}