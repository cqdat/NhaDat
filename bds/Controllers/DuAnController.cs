using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bds.Controllers
{
    public class DuAnController : Controller
    {
        // GET: DuAn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XemDuAn(int? id)
        {
            return View();
        }
    }
}