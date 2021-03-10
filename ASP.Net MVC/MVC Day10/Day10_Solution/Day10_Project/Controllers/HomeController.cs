using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Day10_Project.Models;

namespace Day10_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        List<User> users = new List<User>()
       {
           new User("Kavin","1234"),
           new User("Kanav","4321"),
           new User("Sumo","1111")
       };
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            string un = TempData.Peek("user").ToString();
            User user = users.Find(u => u.Username == un);
            return View(user);
        }
        [ActionName("About")]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult About(FormCollection fc)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("About");
        }
    }
}