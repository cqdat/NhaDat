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
        [Authorize]
        public ActionResult Index()
        {
            IndexAdminModel index = new IndexAdminModel();
            index.LienHeGopy = db.LIENHE_GOPY.Where(l => l.TrangThai == 1).Take(10).OrderByDescending(l=>l.Id).ToList();
            index.ThanhVien = db.THANHVIENs.Take(10).OrderByDescending(t => t.idTV).ToList();
            return View(index);
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

        #region Đếm số lien he - Gop y
        public JsonResult CountLH_GOPY()
        {

            var lh = db.LIENHE_GOPY.ToList();
            //var Datelst = db.AL_Details.Where(p => p.Year == 2017 && p.IsDelete == false).OrderByDescending(p => p.DateAL);


            double total = lh.Count();

            return Json(total, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Đếm số Số Thành Viên
        public JsonResult CountTV()
        {

            var lh = db.THANHVIENs.ToList();
            //var Datelst = db.AL_Details.Where(p => p.Year == 2017 && p.IsDelete == false).OrderByDescending(p => p.DateAL);


            double total = lh.Count();

            return Json(total, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}