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
        public ActionResult Index(int? id)
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            MuaBanChoThue model = new MuaBanChoThue();

            if(id==1)
            {
                model.TinhThanh = db.TINHTHANHs.ToList();
                model.ListMuaBan = db.BDS_MUABAN.Where(q => q.Visible == true && q.Type == false).ToList();
                ////TYpe = false => Mua Bán
            }
            else
            {
                model.TinhThanh = db.TINHTHANHs.ToList();
                model.ListMuaBan = db.BDS_MUABAN.Where(q => q.Visible == true && q.Type == true).ToList();
                //// Type = true => Cho Thuê
            }
            return View(model);
        }

        public ActionResult ChiTiet(int? id)
        {
            ChiTietMuaBanChoThue model = new ChiTietMuaBanChoThue();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ChiTiet = db.BDS_MUABAN.Find(id);
            model.TinKhac = db.BDS_MUABAN.Where(q => q.Visible == true).ToList();
            return View(model);
        }

        public ActionResult ChoThue(int? id)
        {
            ChoThueViewModel model = new ChoThueViewModel();
            model.ListChoThue = db.BDS_MUABAN.Where(q => q.IDMenu == id && q.Visible == true).ToList();
            model.TinhThanh = db.TINHTHANHs.ToList();
            return View(model);
        }

        public  ActionResult GetChoThue(int? id)
        {
            ChiTietChoThue model = new ChiTietChoThue();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ChiTiet = db.BDS_MUABAN.Find(id);
            model.TinKhac = db.BDS_MUABAN.Where(q => q.Visible == true).ToList();
            return View(model);
        }

        public ActionResult MuaBan(int? id)
        {
            MuaBanViewModel model = new MuaBanViewModel();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ListMuaBan = db.BDS_MUABAN.Where(q => q.IDMenu == id && q.Visible == true).ToList();
            return View(model);
        }

        public ActionResult GetMuaBan(int? id)
        {
            ChiTietMuaBan model = new ChiTietMuaBan();
            model.TinhThanh = db.TINHTHANHs.ToList();
            model.ChiTiet = db.BDS_MUABAN.Find(id);
            model.TinKhac = db.BDS_MUABAN.Where(q => q.Visible == true).ToList();
            return View(model);
        }
    }
}