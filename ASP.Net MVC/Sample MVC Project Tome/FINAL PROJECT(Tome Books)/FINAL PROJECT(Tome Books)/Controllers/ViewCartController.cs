using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FINAL_PROJECT_Tome_Books_.Models;

namespace FINAL_PROJECT_Tome_Books_.Views.DisplayProducts
{
    [HandleError]
    public class ViewCartController : Controller
    {

        TomeEntities db = new TomeEntities();
        // GET: ViewCart
        public ActionResult Index()
        {
            
            return View();
        }


        #region ViewCart
        public ActionResult ViewCart()
        {
            int UID = (int)Session["UserID"];
            if (UID == 0)
            {
               
                return View();
            }
            else {
                var result = (from s in db.CartDetails
                              where s.userID == UID
                              select s).ToList();

                ViewBag.FinalPrice = (from CartDetails in db.CartDetails
                                      group CartDetails by new
                                      {
                                          CartDetails.userID
                                      } into g
                                      select new
                                      {
                                          userID = (System.Int32?)g.Key.userID,
                                          TotalAmount = (System.Int32?)g.Sum(p => p.quantity * p.BookDetail.bookPrice)
                                      }).ToList();

                return View(result);
            }  
        }
        #endregion

        [HttpGet]
        public ActionResult placeOrder(Order obj)
        {
            int UID = (int)Session["UserID"];

            obj.userID = UID;
            obj.shipperID = 1;
            obj.supplierID = 2;
            obj.orderDate = DateTime.Now;
            obj.deliveryDate = DateTime.Now.AddDays(2);
            obj.lendingDate = DateTime.Now.AddDays(2);
            obj.returnDate = DateTime.Now.AddDays(30);
            obj.totalPrice = 125;
            obj.totalQuantity = 1;
            obj.orderStatus = "Ordered";

            db.Orders.Add(obj);
            db.SaveChanges();

            try
            {
                if (ModelState.IsValid == true)
                {

                    var cartList = (from cd in db.CartDetails
                                    where cd.userID == UID
                                    select cd).ToList();


                    foreach (var deleteList in cartList)
                    {
                        db.CartDetails.Remove(deleteList);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Thankyou", "ViewCart", "");
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

        //[HttpPost]
        //public ActionResult placeOrder() {

           
        //}


        public ActionResult ThankYou()
        {
            return View();
        }
        public ActionResult CartDetails(CartDetail obj)
        {
           int UID = (int)Session["UserID"];
            var result = (from s in db.CartDetails
                          where s.userID == obj.userID
                          select s).ToList();

            ViewBag.FinalPrice = (from CartDetails in db.CartDetails
                                  group CartDetails by new
                                  {
                                      CartDetails.userID
                                  } into g
                                  select new
                                  {
                                      userID = (System.Int32?)g.Key.userID,
                                      TotalAmount = (System.Int32?)g.Sum(p => p.quantity * p.BookDetail.bookPrice)
                                  }).SingleOrDefault();

            return View();
        }

        public ActionResult SubTotal() {
         //   int UID = (int)Session["UserID"];
            int UID = 79;
        ViewBag.result = db.DisplayCartDetails(UID);

           
            return View();
        }


        public ActionResult Notfound()
        {
            return View();
        }
    }
}