using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Day10_Project.Models;

namespace Day10_Project.Controllers
{
    public class LoginController : Controller
    {
        List<User> users = new List<User>()
       {
           new User("Kavin","1234"),
           new User("Kanav","4321"),
           new User("Sumedha","1111")
       };
        // GET: Login

        public ActionResult UserDetails()
        {
            return View(users);
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            User logedinUser = users.Find(u => u.Username == user.Username && u.Password == user.Password);
            if (logedinUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                TempData["user"] = user.Username;
                //the username value and if the cookie should be stored forever
                //The cookie policy of ur browser will be implemented.
                return RedirectToAction("About", "Home");
            }
              
            else
                return View();
        }
        [ChildActionOnly]
        public PartialViewResult SamplePartial()
        {
            return PartialView();
        }
    }
}