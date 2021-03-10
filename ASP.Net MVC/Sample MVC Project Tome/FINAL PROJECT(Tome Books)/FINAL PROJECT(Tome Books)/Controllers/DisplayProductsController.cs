using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FINAL_PROJECT_Tome_Books_.Models;

namespace FINAL_PROJECT_Tome_Books_.Controllers
{
    [HandleError]
    public class DisplayProductsController : Controller
    {

        TomeEntities db = new TomeEntities();

        // GET: DisplayProducts
        public ActionResult Index()
        {
            return View();
        }

        #region DisplayBooks
        public ActionResult DisplayBooks()
        {

            var result = db.BookDetails.ToList();
            return PartialView("_DisplayBooks", result);
        }

        public ActionResult DisplayBooks1(int id)
        {
            try
            {
                CartDetail obj = new CartDetail();
                int UID = (int)Session["UserID"];

                obj.bookID = id;
                obj.quantity = 1;
                obj.userID = UID;
                db.CartDetails.Add(obj);
                db.SaveChanges();

                return RedirectToAction("ViewCart", "ViewCart", "");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "user", "Create"));
            } 
         
        }

        #endregion


        #region DisplayMostExpensiveBooks
        public ActionResult DisplayMostExpensiveBooks()
        {

            var result = db.BookDetails.OrderByDescending(x => x.bookPrice).ToList();
            return PartialView("_DisplayBooks", result);
        }
        #endregion


        #region DisplayLeastExpensiveBooks
        public ActionResult DisplayLeastExpensiveBooks()
        {
            var result = db.BookDetails.OrderBy(x => x.bookPrice).ToList();
            return PartialView("_DisplayBooks", result);
        }
        #endregion

        //According to subcategory
        public ActionResult DisplayFilterBooks(string bookName)
        {
            var result = (from s in db.BookDetails
                          where s.bookName.Contains(bookName)
                          select s).ToList();

            return PartialView("_DisplayBooks", result);
        }

        #region DisplayTopSellingBooks
        public ActionResult DisplayTopSellingBooks()
        {
            var result = db.BookDetails.OrderByDescending(x => x.viewCount).ToList();

            return View(result);
        }
        #endregion


        #region DisplayNewBooks
        public ActionResult DisplayNewBooks()
        {
            var result = db.BookDetails.OrderByDescending(x => x.publishedDate).ToList();

            return View(result);
        }

        #endregion


        #region DisplayMostviewedBooks
        public ActionResult DisplayMostviewedBooks()
        {
            var result = db.BookDetails.OrderByDescending(x => x.viewCount).ToList();

            return View(result);
        }
        #endregion


        #region DisplayHighRatedBooks
        public ActionResult DisplayHighRatedBooks()
        {
            var result = db.BookDetails.OrderByDescending(x => x.RatingDetails).ToList();

            return View(result);
        }
        #endregion


        #region DisplayBudgetBooks
        public ActionResult DisplayBudgetBooks()
        {
            var result = db.BookDetails.OrderBy(x => x.bookPrice).ToList();

            return View(result);
        }
        #endregion


        //Display book post write Add to cart LIMQ
        #region DisplayBookDetails
        public ActionResult DisplayBookDetails()
        {
            var bookId = Int32.Parse(Request.QueryString["BookID"]);

            var result = (from a in db.BookDetails
                          where a.bookID == bookId
                          select a).SingleOrDefault();

            return View(result);

        }
        #endregion


        #region DisplayCartDetails
        public ActionResult DisplayCartDetails()
        {
            //var bookId = Int32.Parse(Request.QueryString["BookID"]);

            //var result = from a in db.BookDetails
            //             where a.bookID = 1
            //             select a;
            var result = db.BookDetails.ToList();
            return View();

        }
        #endregion

        #region Notfound
        public ActionResult NotFound()
        {
            return View();
        }

        #endregion
    }
}