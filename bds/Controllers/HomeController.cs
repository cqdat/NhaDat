using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;
namespace bds.Controllers
{
    public class HomeController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(1);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
            
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Question()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult getMenu()
        {
            var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);
            return PartialView("_menubar", model);
        }
    }
}