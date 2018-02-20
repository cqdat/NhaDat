using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;
using System.Net;
using System.Data.Entity;

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
            model.SOLANXEM = model.SOLANXEM + 1;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return View(model);

        }
    }
}