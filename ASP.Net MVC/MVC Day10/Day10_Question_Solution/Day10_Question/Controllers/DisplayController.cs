using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day10_Question.Models;

namespace Day10_Question.Controllers
{
    public class DisplayController : Controller
    {
        private pubsEntities db = new pubsEntities();
        // GET: Display
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<proc_GetTitlesUsingAuthor_Result> titles = db.proc_GetTitlesUsingAuthor(id).ToList();
            return View(titles);
        }
    }
}