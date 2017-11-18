using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bds.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Thread(int? id)
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}