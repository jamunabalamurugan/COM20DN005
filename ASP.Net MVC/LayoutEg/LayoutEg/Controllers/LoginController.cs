using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayoutEg.Models;
namespace LayoutEg.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        dbMovieShopEntities db = new dbMovieShopEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyLogin()
        {
            ViewBag.message = "Please enter your name and password";
            return View();
        }
        [HttpPost]
        public ActionResult MyLogin(UserData user)
        {
            if (ModelState.IsValid)
            {
                //select count(*) from userData where username = @username and password = @pass
                int myUser = db.UserDatas.Where(u => u.username == user.username && u.password == user.password).Count();
                if (myUser == 1)
                {
                    ViewBag.message = "Welcome.. Your login is success!!!";
                    Session["username"] = user.username;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.message = "Invalid Username or password";
            }

            return View(user);
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SampleUserLogin()
        {
            return View();
        }
    }
}