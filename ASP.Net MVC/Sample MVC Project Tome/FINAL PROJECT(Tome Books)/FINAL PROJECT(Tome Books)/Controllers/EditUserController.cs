using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FINAL_PROJECT_Tome_Books_.Models;
using System.Data.Entity;

namespace FINAL_PROJECT_Tome_Books_.Controllers
{

    [HandleError]
    public class EditUserController : Controller
    {

        TomeEntities db = new TomeEntities();
        // GET: EditUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditAccount() {

            return View();
        }


        //[HttpPost]
        //public ActionResult EditAccount(User obj)
        //{
        //    obj.email = "sri@gmail.com";

        //    db.Entry(obj).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Home");

        //    //if (ModelState.IsValid)
        //    //{

        //    //}

        //    //return RedirectToAction("SignIn", "Home");
        //}

       
        public ActionResult Editt() {

            int UID = (int)Session["UserID"];
        
            if (UID == null) {
                return View();
            }
            User users = db.Users.Find(UID);

            if (users == null) {
                return HttpNotFound();
            }
            return View(users);
        }

        [HttpPost]
        public ActionResult Editt([Bind(Include = "userName, userID, email, address, phone")] User obj)
        {

            User user = db.Users.Find(obj.userID);
            user.userName = obj.userName;
            user.email = obj.email;
            user.address = obj.address;
            user.phone = obj.phone;
            //user.name = obj.name;
            //user.password = obj.password;


            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult changePassword ()
        {

            return View();
        }

        [HttpPost]
        public ActionResult changePassword(User obj,FormCollection frm)
        {
            int UID = (int)Session["UserID"];
            var result = (from s in db.Users
                          where s.userID == UID
                          select s.password).SingleOrDefault();

            var pass = PasswordSecurity.HashSHA1(frm["password"]);

            if (pass  == result)
            {
                if (frm["NewPassword"] == frm["ConfirmPassword"])
                {

                    User user = db.Users.Find(UID);
                    user.password = PasswordSecurity.HashSHA1(frm["NewPassword"]);

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.errorMessage = "NewPassword and Confirm new password are not same.";
                    return Notfound();
                }
            }
            ViewBag.errorMessage = "Please enter old password Correctly.";
            return Notfound();
        }

        public ActionResult Notfound()
        {
            return View();
        }

    }
}