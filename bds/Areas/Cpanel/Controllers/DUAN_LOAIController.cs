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
    public class DUAN_LOAIController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/DUAN_LOAI
        public ActionResult Index()
        {
            return View(db.DUAN_LOAI.ToList());
        }

        // GET: Cpanel/DUAN_LOAI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN_LOAI dUAN_LOAI = db.DUAN_LOAI.Find(id);
            if (dUAN_LOAI == null)
            {
                return HttpNotFound();
            }
            return View(dUAN_LOAI);
        }

        // GET: Cpanel/DUAN_LOAI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/DUAN_LOAI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLOAI,THUTU,TENLOAI,HIENTHI,HIEULUC,IDCHA,URL,NGAY,CAP,HINHANH,NOIDUNG,TINNOIBAT")] DUAN_LOAI dUAN_LOAI)
        {
            if (ModelState.IsValid)
            {
                db.DUAN_LOAI.Add(dUAN_LOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dUAN_LOAI);
        }

        // GET: Cpanel/DUAN_LOAI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN_LOAI dUAN_LOAI = db.DUAN_LOAI.Find(id);
            if (dUAN_LOAI == null)
            {
                return HttpNotFound();
            }
            return View(dUAN_LOAI);
        }

        // POST: Cpanel/DUAN_LOAI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLOAI,THUTU,TENLOAI,HIENTHI,HIEULUC,IDCHA,URL,NGAY,CAP,HINHANH,NOIDUNG,TINNOIBAT")] DUAN_LOAI dUAN_LOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dUAN_LOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dUAN_LOAI);
        }

        // GET: Cpanel/DUAN_LOAI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN_LOAI dUAN_LOAI = db.DUAN_LOAI.Find(id);
            if (dUAN_LOAI == null)
            {
                return HttpNotFound();
            }
            return View(dUAN_LOAI);
        }

        // POST: Cpanel/DUAN_LOAI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DUAN_LOAI dUAN_LOAI = db.DUAN_LOAI.Find(id);
            db.DUAN_LOAI.Remove(dUAN_LOAI);
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
