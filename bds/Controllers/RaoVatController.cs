using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bds.Controllers
{
    public class RaoVatController : Controller
    {
        // GET: RaoVat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChoThue()
        {
            return View();
        }

        public  ActionResult GetChoThue(int? id)
        {
            return View();
        }
    }
}