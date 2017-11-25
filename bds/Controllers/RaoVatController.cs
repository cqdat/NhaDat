using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;

namespace bds.Controllers
{
    public class RaoVatController : Controller
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: RaoVat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChoThue(int? id)
        {
            ChoThueViewModel model = new ChoThueViewModel();
            model.ListChoThue = db.BDS_MuaBan.Where(q => q.IDMenu == id && q.Visible == true).ToList();
            model.TinhThanh = db.TINHTHANHs.ToList();
            return View(model);
        }

        public  ActionResult GetChoThue(int? id)
        {
            ChiTietChoThue model = new ChiTietChoThue();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ChiTiet = db.BDS_MuaBan.Find(id);
            model.TinKhac = db.BDS_MuaBan.Where(q => q.Visible == true).ToList();
            return View(model);
        }

        public ActionResult MuaBan(int? id)
        {
            MuaBanViewModel model = new MuaBanViewModel();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ListMuaBan = db.BDS_MuaBan.Where(q => q.IDMenu == id && q.Visible == true).ToList();
            return View(model);
        }

        public ActionResult GetMuaBan(int? id)
        {
            ChiTietMuaBan model = new ChiTietMuaBan();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ChiTiet = db.BDS_MuaBan.Find(id);
            model.TinKhac = db.BDS_MuaBan.Where(q => q.Visible == true).ToList();
            return View(model);
        }
    }
}