using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;
using System.Net;


namespace bds.Controllers
{
    public class BaiVietController : Controller
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: GioiThieu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.GIOITHIEUx.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }
    }
}