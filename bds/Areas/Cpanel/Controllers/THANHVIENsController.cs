using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;

using System.IO;
using PagedList;
using PagedList.Mvc;
using bds.Controllers;
using bds.Models;

namespace bds.Areas.Cpanel.Controllers
{
    public class THANHVIENsController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/THANHVIENs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _PartialThanhVien(int? pageNumber, int? pageSize, string TieuDe, int? IDMenuCha, int? IDMenu)
        {
            TieuDe = TieuDe ?? "";
            ViewBag.TieuDe = TieuDe;
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 10;

            if (pageSize == -1)
            {
                pageSize = db.THANHVIENs.ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstTT = db.THANHVIENs.ToList();

            if (!string.IsNullOrEmpty(TieuDe))
            {
                lstTT = lstTT.Where(s => s.HoTen.Contains(TieuDe)).ToList();
            }
            ViewBag.TieuDe = TieuDe;

            if (!string.IsNullOrEmpty(IDMenuCha.ToString()))
            {
                lstTT = lstTT.Where(s => s.VIP == IDMenuCha).ToList();
            }
            ViewBag.IDMenuCha = IDMenuCha;

            if (!string.IsNullOrEmpty(IDMenu.ToString()))
            {
                lstTT = lstTT.Where(s => s.VIPMoney == IDMenu).ToList();
            }
            ViewBag.IDMenu = IDMenu;

            //var nb = Convert.ToBoolean(NoiBat);
            //if (!string.IsNullOrEmpty(NoiBat.ToString()))
            //{
            //    lstTintucs = lstTintucs.Where(s => s.NoiBat == nb).ToList();
            //}
            //ViewBag.NoiBat = NoiBat;

            lstTT = lstTT.OrderByDescending(s => s.LanDangNhapCuoi).ToList();
            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstTT.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Cpanel/Views/THANHVIENs/_PartialThanhVien.cshtml", lstTT.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));

            }
            return View(lstTT.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }

        // GET: Cpanel/THANHVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // GET: Cpanel/THANHVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/THANHVIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTV,TenTruyCap,MatKhau,HoTen,DiaChi,SoDiDong,EmailLH,TinhTrang,VIP,LanDangNhapCuoi,VIPMoney")] THANHVIEN tHANHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.THANHVIENs.Add(tHANHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHANHVIEN);
        }

        // GET: Cpanel/THANHVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // POST: Cpanel/THANHVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTV,TenTruyCap,MatKhau,HoTen,DiaChi,SoDiDong,EmailLH,TinhTrang,VIP,LanDangNhapCuoi,VIPMoney")] THANHVIEN tHANHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHANHVIEN);
        }

        // GET: Cpanel/THANHVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // POST: Cpanel/THANHVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            db.THANHVIENs.Remove(tHANHVIEN);
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
