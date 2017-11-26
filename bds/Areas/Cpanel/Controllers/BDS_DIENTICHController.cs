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
    public class BDS_DIENTICHController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/BDS_DIENTICH
        public ActionResult Index()
        {
            return View(db.BDS_DIENTICH.OrderBy(d=>d.STT).ToList());
        }

        // GET: Cpanel/BDS_DIENTICH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_DIENTICH bDS_DIENTICH = db.BDS_DIENTICH.Find(id);
            if (bDS_DIENTICH == null)
            {
                return HttpNotFound();
            }
            return View(bDS_DIENTICH);
        }

        // GET: Cpanel/BDS_DIENTICH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/BDS_DIENTICH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDT,TenDT,STT")] BDS_DIENTICH bDS_DIENTICH)
        {
            if (ModelState.IsValid)
            {
                db.BDS_DIENTICH.Add(bDS_DIENTICH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bDS_DIENTICH);
        }

        // GET: Cpanel/BDS_DIENTICH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_DIENTICH bDS_DIENTICH = db.BDS_DIENTICH.Find(id);
            if (bDS_DIENTICH == null)
            {
                return HttpNotFound();
            }
            return View(bDS_DIENTICH);
        }

        // POST: Cpanel/BDS_DIENTICH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDT,TenDT,STT")] BDS_DIENTICH bDS_DIENTICH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bDS_DIENTICH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bDS_DIENTICH);
        }

        // GET: Cpanel/BDS_DIENTICH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_DIENTICH bDS_DIENTICH = db.BDS_DIENTICH.Find(id);
            if (bDS_DIENTICH == null)
            {
                return HttpNotFound();
            }
            return View(bDS_DIENTICH);
        }

        // POST: Cpanel/BDS_DIENTICH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BDS_DIENTICH bDS_DIENTICH = db.BDS_DIENTICH.Find(id);
            db.BDS_DIENTICH.Remove(bDS_DIENTICH);
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
