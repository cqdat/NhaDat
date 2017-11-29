using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;

namespace bds.Areas.Cpanel.Controllers
{
    public class BDS_TinTucController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/BDS_TinTuc
        public ActionResult Index()
        {
            var bDS_TinTuc = db.BDS_TinTuc.Include(b => b.MENU).Include(b => b.THANHVIEN).Include(b => b.THANHVIEN1);
            return View(bDS_TinTuc.ToList());
        }

        // GET: Cpanel/BDS_TinTuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_TinTuc bDS_TinTuc = db.BDS_TinTuc.Find(id);
            if (bDS_TinTuc == null)
            {
                return HttpNotFound();
            }
            return View(bDS_TinTuc);
        }

        // GET: Cpanel/BDS_TinTuc/Create
        public ActionResult Create()
        {
            ViewBag.MenuCha = new SelectList(db.MENUs.Where(m=>m.IdCha == 0).OrderBy(m=>m.ThuTu), "IdMenu", "TenMenu");
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap");
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap");
            return View();
        }

        public JsonResult FillMenuL2(int idCha)
        {
            //var tmp = from s in db.MODELDEVICEs
            //          where s.IDCate == idCate
            //          select s.NameModel;
            //var sItems = new SelectList(tmp);
            //return Json(sItems, JsonRequestBehavior.AllowGet);

            var result = new SelectList(db.MENUs.Where(m=>m.IdCha == idCha), "IdMenu", "TenMenu");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Cpanel/BDS_TinTuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TinTucID,TintucName,HinhAnh,MoTa,NoiDung,IDMenu,NoiBat,NhieuNguoiDoc,CountView,HotIcon,Created,CreateBy,Updated,UpdateBy,Visible,URL")] BDS_TinTuc bDS_TinTuc)
        {
            if (ModelState.IsValid)
            {
                db.BDS_TinTuc.Add(bDS_TinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMenu = new SelectList(db.MENUs, "IdMenu", "TenMenu", bDS_TinTuc.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", bDS_TinTuc.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", bDS_TinTuc.UpdateBy);
            return View(bDS_TinTuc);
        }

        // GET: Cpanel/BDS_TinTuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_TinTuc bDS_TinTuc = db.BDS_TinTuc.Find(id);
            if (bDS_TinTuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMenu = new SelectList(db.MENUs, "IdMenu", "TenMenu", bDS_TinTuc.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", bDS_TinTuc.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", bDS_TinTuc.UpdateBy);
            return View(bDS_TinTuc);
        }

        // POST: Cpanel/BDS_TinTuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TinTucID,TintucName,HinhAnh,MoTa,NoiDung,IDMenu,NoiBat,NhieuNguoiDoc,CountView,HotIcon,Created,CreateBy,Updated,UpdateBy,Visible,URL")] BDS_TinTuc bDS_TinTuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bDS_TinTuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMenu = new SelectList(db.MENUs, "IdMenu", "TenMenu", bDS_TinTuc.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", bDS_TinTuc.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", bDS_TinTuc.UpdateBy);
            return View(bDS_TinTuc);
        }

        // GET: Cpanel/BDS_TinTuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_TinTuc bDS_TinTuc = db.BDS_TinTuc.Find(id);
            if (bDS_TinTuc == null)
            {
                return HttpNotFound();
            }
            return View(bDS_TinTuc);
        }

        // POST: Cpanel/BDS_TinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BDS_TinTuc bDS_TinTuc = db.BDS_TinTuc.Find(id);
            db.BDS_TinTuc.Remove(bDS_TinTuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
