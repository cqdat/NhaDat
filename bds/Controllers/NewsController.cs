using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;

namespace bds.Controllers
{
    public class NewsController : Controller
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Thread(int? id)
        {
            NewsViewModel model = new NewsViewModel();
            model.TinTuc = db.BDS_TinTuc.Where(q => q.IDMenu == id && q.Visible == true).Take(15).OrderByDescending(o => o.CreateBy).ToList();
            model.TinNoiBat = db.BDS_TinTuc.Where(q => q.NoiBat == true && q.Visible == true).Take(15).OrderByDescending(o => o.CreateBy).ToList();
            model.NhieuNguoiDoc = db.BDS_TinTuc.Where(q => q.NhieuNguoiDoc == true && q.Visible == true).Take(15).OrderByDescending(o => o.CreateBy).ToList();
            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            NewsDetailModel model = new NewsDetailModel();
            model.ChiTiet = db.BDS_TinTuc.Find(id);
            model.TinKhac = db.BDS_TinTuc.Where(q => q.Visible == true).ToList();
            model.TinNoiBat = db.BDS_TinTuc.Where(q => q.NoiBat == true && q.Visible == true).Take(15).OrderByDescending(o => o.CreateBy).ToList();
            model.NhieuNguoiDoc = db.BDS_TinTuc.Where(q => q.NhieuNguoiDoc == true && q.Visible == true).Take(15).OrderByDescending(o => o.CreateBy).ToList();
            return View(model);
        }
    }
}