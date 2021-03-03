using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCViewsEg.Models;

namespace MVCViewsEg.Controllers
{
    public class LoginController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(LoginDemoVM login)
        {
            if (ModelState.IsValid)
            {
                var result = (from c in db.Customers
                              where c.CustomerID == login.CustomerID
                              && c.CompanyName == login.CompanyNme
                              select c.ContactName).SingleOrDefault();

                if (result != null)
                {
                    Session["Name"] = result;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("","Invalid Login Credentials...Pls try again");
                    return View();
                }
            }
            return View();
        }

    }
}