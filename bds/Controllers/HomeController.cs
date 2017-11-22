using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;
using bds.Models;

namespace bds.Controllers
{
    public class HomeController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        public ActionResult Index()
        {
            /// type == true => mua bán, type=false ==> cho thue
            IndexModel index = new IndexModel();
            index.TinhThanh = db.TINHTHANHs.Where(q => q.IDCha == 0).ToList();
            index.BDSNoiBat = db.BDS_MuaBan.Where(q => q.NoiBat == true && q.Visible == true && q.Type == true).Take(15).ToList();
            index.BDSMoi = db.BDS_MuaBan.Where(q => q.Visible == true && q.Type == true).OrderBy(o => o.Created).Take(15).ToList();
            index.TinTucNoiBat = db.BDS_TinTuc.Where(q => q.Visible == true && q.NoiBat == true).Take(10).ToList();
            index.FirstNEWS = db.BDS_TinTuc.FirstOrDefault(q => q.NoiBat == true && q.Visible == true);
            return View(index);
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