using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;
using System.Net;

namespace bds.Areas.Cpanel.Controllers
{
    public class DefaultController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        Helper h = new Helper();
        // GET: Cpanel/Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult getDichVuVIP()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            GIOITHIEU model = new GIOITHIEU();
            //model.MuaBan = db.MENUs.Find(1);
            //model.CHoThue = db.MENUs.Find(2);
            //model.DuAn = db.MENUs.Find(3);
            //model.TinTuc = db.MENUs.Where(q => q.IdCha == 0 && q.HienThi == 1 && q.IdMenu != 1 && q.IdMenu != 2 && q.IdMenu != 3).OrderBy(o => o.ThuTu).ToList();
            model.DichVuVIP = db.GIOITHIEUx.Where(g => g.HIENTHI == 1).OrderBy(g => g.THUTU).ToList();

            return PartialView("_PartialViewMenuDichVuVIP", model);
        }
    }
}