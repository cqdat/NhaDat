using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;
using bds.Models;
using bds.Controllers;

namespace bds.Areas.Cpanel.Controllers
{
    public class GIOITHIEUController : BaseController
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/GIOITHIEU
        public ActionResult Index()
        {
            return View(db.GIOITHIEUx.ToList());
        }

        // GET: Cpanel/GIOITHIEU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(id);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
        }

        // GET: Cpanel/GIOITHIEU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/GIOITHIEU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "IDTT,THUTU,TIEUDE,TOMTAT,NOIDUNG,HINHANH,NGAYCAPNHAT,TINNOIBAT,HIENTHI,HIEULUC,SOLANXEM,URLRewrite,TUKHOA1,TUKHOA2,TUKHOA3,HIENTHIMENU")] GIOITHIEU gIOITHIEU)
        {
            if (ModelState.IsValid)
            {
                gIOITHIEU.HINHANH = "";
                gIOITHIEU.NGAYCAPNHAT = DateTime.Now;
                gIOITHIEU.URLRewrite = Helper.ConvertToUpperLower(gIOITHIEU.TIEUDE);
                db.GIOITHIEUx.Add(gIOITHIEU);
                db.SaveChanges();
                Success(string.Format("Thêm mới thành công"), true);
                return RedirectToAction("Index");
            }

            return View(gIOITHIEU);
        }

        // GET: Cpanel/GIOITHIEU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(id);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
        }


        // POST: Cpanel/GIOITHIEU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "IDTT,THUTU,TIEUDE,TOMTAT,NOIDUNG,HINHANH,NGAYCAPNHAT,TINNOIBAT,HIENTHI,HIEULUC,SOLANXEM,URLRewrite,TUKHOA1,TUKHOA2,TUKHOA3,HIENTHIMENU")] GIOITHIEU gIOITHIEU)
        {
            if (ModelState.IsValid)
            {
                //gIOITHIEU.IDTT = gIOITHIEU.IDTT;
                //gIOITHIEU.THUTU = 1;
                //gIOITHIEU.TIEUDE = gIOITHIEU.TIEUDE;
                //gIOITHIEU.TOMTAT = gIOITHIEU.TOMTAT;
                //gIOITHIEU.NOIDUNG = gIOITHIEU.NOIDUNG;
                //gIOITHIEU.HINHANH = gIOITHIEU.HINHANH;
                gIOITHIEU.URLRewrite = Helper.ConvertToUpperLower(gIOITHIEU.TIEUDE);
                gIOITHIEU.NGAYCAPNHAT = DateTime.Now;
                //gIOITHIEU.TINNOIBAT = 1;
                //gIOITHIEU.HIENTHI = 1;
                //gIOITHIEU.HIEULUC = 1;
                //gIOITHIEU.SOLANXEM = gIOITHIEU.SOLANXEM;
                //gIOITHIEU.TUKHOA1 = gIOITHIEU.TIEUDE;
                //gIOITHIEU.TUKHOA2 = gIOITHIEU.TUKHOA2;
                //gIOITHIEU.TUKHOA3 = gIOITHIEU.TUKHOA3;
                //gIOITHIEU.HIENTHIMENU = gIOITHIEU.HIENTHIMENU;

                db.Entry(gIOITHIEU).State = EntityState.Modified;
                db.SaveChanges();
                Success(string.Format("Cập nhật thành công"), true);
                return RedirectToAction("Edit", "GIOITHIEU", new { id = gIOITHIEU.IDTT });
            }
            return View(gIOITHIEU);
        }



        // GET: Cpanel/GIOITHIEU/Edit/2 // CHỈNH SỬA NỘI DUNG FOOTER
        public ActionResult Footer_ContactInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(2);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Footer_ContactInfo([Bind(Include = "IDTT,THUTU,TIEUDE,TOMTAT,NOIDUNG,HINHANH,NGAYCAPNHAT,TINNOIBAT,HIENTHI,HIEULUC,SOLANXEM,TUKHOA1,TUKHOA2,TUKHOA3")] GIOITHIEU gIOITHIEU)
        {
            if (ModelState.IsValid)
            {
                gIOITHIEU.IDTT = 2;
                gIOITHIEU.THUTU = 1;
                gIOITHIEU.TIEUDE = gIOITHIEU.TIEUDE;
                gIOITHIEU.TOMTAT = gIOITHIEU.TOMTAT;
                gIOITHIEU.NOIDUNG = gIOITHIEU.NOIDUNG;
                gIOITHIEU.HINHANH = gIOITHIEU.HINHANH;
                gIOITHIEU.NGAYCAPNHAT = DateTime.Now;
                gIOITHIEU.TINNOIBAT = 1;
                gIOITHIEU.HIENTHI = 1;
                gIOITHIEU.HIEULUC = 1;
                gIOITHIEU.SOLANXEM = gIOITHIEU.SOLANXEM;
                gIOITHIEU.TUKHOA1 = gIOITHIEU.TIEUDE;
                gIOITHIEU.TUKHOA2 = gIOITHIEU.TUKHOA2;
                gIOITHIEU.TUKHOA3 = gIOITHIEU.TUKHOA3;


                db.Entry(gIOITHIEU).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Cập nhật thành công";
                return RedirectToAction("Footer_ContactInfo", "GIOITHIEU", new { id = gIOITHIEU.IDTT });
            }
            return View(gIOITHIEU);
        }

        // GET: Cpanel/GIOITHIEU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(id);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
        }

        // POST: Cpanel/GIOITHIEU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(id);
            db.GIOITHIEUx.Remove(gIOITHIEU);
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
