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
    public class BDS_LOAIBDSController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/BDS_LOAIBDS
        public ActionResult Index()
        {
            return View(db.BDS_LOAIBDS.ToList().OrderBy(b=>b.THUTU));
        }

        // GET: Cpanel/BDS_LOAIBDS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_LOAIBDS bDS_LOAIBDS = db.BDS_LOAIBDS.Find(id);
            if (bDS_LOAIBDS == null)
            {
                return HttpNotFound();
            }
            return View(bDS_LOAIBDS);
        }

        // GET: Cpanel/BDS_LOAIBDS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/BDS_LOAIBDS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBDS,THUTU,TENBDS,HIENTHI")] BDS_LOAIBDS bDS_LOAIBDS)
        {
            if (ModelState.IsValid)
            {
                db.BDS_LOAIBDS.Add(bDS_LOAIBDS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bDS_LOAIBDS);
        }

        // GET: Cpanel/BDS_LOAIBDS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_LOAIBDS bDS_LOAIBDS = db.BDS_LOAIBDS.Find(id);
            if (bDS_LOAIBDS == null)
            {
                return HttpNotFound();
            }
            return View(bDS_LOAIBDS);
        }

        // POST: Cpanel/BDS_LOAIBDS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBDS,THUTU,TENBDS,HIENTHI")] BDS_LOAIBDS bDS_LOAIBDS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bDS_LOAIBDS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bDS_LOAIBDS);
        }

        // GET: Cpanel/BDS_LOAIBDS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_LOAIBDS bDS_LOAIBDS = db.BDS_LOAIBDS.Find(id);
            if (bDS_LOAIBDS == null)
            {
                return HttpNotFound();
            }
            return View(bDS_LOAIBDS);
        }

        // POST: Cpanel/BDS_LOAIBDS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BDS_LOAIBDS bDS_LOAIBDS = db.BDS_LOAIBDS.Find(id);
            db.BDS_LOAIBDS.Remove(bDS_LOAIBDS);
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
