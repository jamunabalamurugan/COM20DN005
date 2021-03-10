using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FINAL_PROJECT_Tome_Books_.Models;

namespace FINAL_PROJECT_Tome_Books_.Controllers
{

    [HandleError]

    public class HomeController : Controller
    {

        TomeEntities db = new TomeEntities();
        public ActionResult Index()
        {

            Session["Categories"] = db.Categories.ToList();
            Session["prods"] = db.BookDetails.ToList();

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        #region Categories
        public ActionResult CategoriesPartialPage() {

            return View(db.Categories.ToList());
        }
        #endregion
        

        #region SignIn
        [HttpGet]
        public ActionResult SignIn() {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User obj)
        {
            try
            {
                obj.password = PasswordSecurity.HashSHA1(obj.password);
                var result = (from s in db.Users
                              where s.email == obj.email &&
                               s.password == obj.password
                              select s).SingleOrDefault();

                if (result != null)
                {
                    Session["username"] = result.userName;
                    Session["UserID"] = result.userID;
                    Session["email"] = result.email;
                    return RedirectToAction("Index");
                }
                else {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "user", "Create"));
            }
        }
        #endregion


        public ActionResult welcome() {
            return View();
        }
        #region RegisterSsignUp
        public ActionResult RegisterSsignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterSsignUp(User obj)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    obj.password = PasswordSecurity.HashSHA1(obj.password);
                    db.Users.Add(obj);
                    db.SaveChanges();
                    Session["username"] = obj.userName;
                    Session["UID"] = obj.userID;
                    Session["email"] = obj.email;

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "user", "Create"));
            }

        }
        #endregion


        public ActionResult Logout() {
            Session.Clear();
            Session.Abandon();
            return View("Index");
        }

        public ActionResult DisplayBooks()
        {
            var result = db.BookDetails.ToList();
            return View(result);
        }


        public ActionResult TermsOfUse()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();

        }
        public ActionResult HowToPay()
        {
           return View();
        }
        public ActionResult PrivacyPolicy()
        {
           return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult Notfound()
        {
            return View();
        }
        }
    }