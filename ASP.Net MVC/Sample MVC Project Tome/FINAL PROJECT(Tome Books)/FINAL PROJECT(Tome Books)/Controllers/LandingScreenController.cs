using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINAL_PROJECT_Tome_Books_.Controllers
{
    public class LandingScreenController : Controller
    {
        // GET: Landing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notfound()
        {
            return View();
        }
    }
}