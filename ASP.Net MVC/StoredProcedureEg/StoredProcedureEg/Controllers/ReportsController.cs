using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedureEg.Models;
namespace StoredProcedureEg.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult TenExpProducts()
        {
            var result = db.Ten_Most_Expensive_Products().ToList();
            return View(result);
        }

        public ActionResult Sales()
        {
            return View(db.SalesByCategory("Seafood", "1996"));
        }
        public ActionResult AcceptCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AcceptCategory(string txtCategory)
        {
            var result = db.SalesByCategory(txtCategory, "1996");
            return View(result);
          //  return RedirectToAction("SalesByCategory", new { category = @txtCategory });
        }
        public ActionResult SalesByCategory(string category)
        {
            return View(db.SalesByCategory(category,"1996"));
        }
    }
}