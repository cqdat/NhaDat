using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;
using bds.Controllers;

namespace bds.Areas.Cpanel.Controllers
{
    public class LIENHE_GOPYController : BaseController
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/LIENHE_GOPY
        public ActionResult Index()
        {
            return View(db.LIENHE_GOPY.ToList().OrderByDescending(l=>l.Id));
        }

        // GET: Cpanel/LIENHE_GOPY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIENHE_GOPY lIENHE_GOPY = db.LIENHE_GOPY.Find(id);
            if (lIENHE_GOPY == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE_GOPY);
        }

        // GET: Cpanel/LIENHE_GOPY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/LIENHE_GOPY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenLH,UsernameLH,SDT,EmailLH,TieuDe,NoiDung,TrangThai,NoiDungTraLoi,ThoiGianGui,ThoiGianTraloi,HienThi")] LIENHE_GOPY lIENHE_GOPY)
        {
            if (ModelState.IsValid)
            {
                db.LIENHE_GOPY.Add(lIENHE_GOPY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIENHE_GOPY);
        }

        // GET: Cpanel/LIENHE_GOPY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIENHE_GOPY lIENHE_GOPY = db.LIENHE_GOPY.Find(id);
            if (lIENHE_GOPY == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE_GOPY);
        }

        // POST: Cpanel/LIENHE_GOPY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenLH,UsernameLH,SDT,EmailLH,TieuDe,NoiDung,TrangThai,NoiDungTraLoi,ThoiGianGui,ThoiGianTraloi,HienThi")] LIENHE_GOPY lIENHE_GOPY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIENHE_GOPY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIENHE_GOPY);
        }

        // GET: Cpanel/LIENHE_GOPY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIENHE_GOPY lIENHE_GOPY = db.LIENHE_GOPY.Find(id);
            if (lIENHE_GOPY == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE_GOPY);
        }

        // POST: Cpanel/LIENHE_GOPY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIENHE_GOPY lIENHE_GOPY = db.LIENHE_GOPY.Find(id);
            db.LIENHE_GOPY.Remove(lIENHE_GOPY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Phản hồi liên hệ
        [HttpPost]
        public ActionResult PhanHoi(int Id, FormCollection f)
        {
            LIENHE_GOPY lh = db.LIENHE_GOPY.SingleOrDefault(l=>l.Id == Id);
            lh.NoiDungTraLoi = f["NoiDungTL"];
            lh.ThoiGianTraloi = DateTime.Now;
            lh.TrangThai = 2;

            db.Entry(lh).State = EntityState.Modified;
            db.SaveChanges();

            //Send Email gmail

            Success(string.Format("Phản hồi thành công"), true);
            return RedirectToAction("Index", "LIENHE_GOPY");
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
