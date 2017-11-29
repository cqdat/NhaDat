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

namespace bds.Areas.Cpanel.Controllers
{
    public class TINHTHANHController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/TINHTHANH
        public ActionResult Index()
        {
            var model = db.TINHTHANHs.Where(t=>t.IDCha == 0).OrderBy(t=>t.ThuTu).ToList();
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult _PartialViewChildTinhThanh(int ParentID)
        {

            var _loca = from tt in db.TINHTHANHs
                        where tt.IDCha == ParentID
                        select tt;

            return PartialView(_loca.ToList());

        }
        // GET: Cpanel/TINHTHANH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // GET: Cpanel/TINHTHANH/Create
        public ActionResult Create()
        {
            ViewBag.IDCha = new SelectList(db.TINHTHANHs.Where(l => l.IDCha == 0), "IdTT", "TenTT");
            return View();
        }

        // POST: Cpanel/TINHTHANH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTT,TenTT,IDCha,Cap,DemChoThue,DemMuaban,HienThi,ThuTu,url")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                if (tINHTHANH.IDCha == null)
                {
                    tINHTHANH.IDCha = 0;
                }
                tINHTHANH.url = Helper.ConvertToUpperLower(tINHTHANH.TenTT);
                tINHTHANH.Cap = 1;
                tINHTHANH.DemChoThue = 0;
                tINHTHANH.DemMuaban = 0;

                db.TINHTHANHs.Add(tINHTHANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tINHTHANH);
        }

        // GET: Cpanel/TINHTHANH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            ViewBag.IDCha = new SelectList(db.TINHTHANHs.Where(m => m.IDCha == 0).OrderBy(b => b.ThuTu), "IdTT", "TenTT", tINHTHANH.IDCha);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: Cpanel/TINHTHANH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTT,TenTT,IDCha,Cap,DemChoThue,DemMuaban,HienThi,ThuTu,url")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                if (tINHTHANH.IDCha == null)
                {
                    tINHTHANH.IDCha = 0;
                }
                tINHTHANH.url = Helper.ConvertToUpperLower(tINHTHANH.TenTT);
                tINHTHANH.Cap = tINHTHANH.Cap;
                tINHTHANH.DemChoThue = tINHTHANH.DemChoThue;
                tINHTHANH.DemMuaban = tINHTHANH.DemMuaban;
                db.Entry(tINHTHANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tINHTHANH);
        }

        // GET: Cpanel/TINHTHANH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: Cpanel/TINHTHANH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            db.TINHTHANHs.Remove(tINHTHANH);
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
