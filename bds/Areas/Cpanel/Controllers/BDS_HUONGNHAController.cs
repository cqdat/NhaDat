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
    public class BDS_HUONGNHAController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/BDS_HUONGNHA
        public ActionResult Index()
        {
            return View(db.BDS_HUONGNHA.ToList().OrderBy(h=>h.STT));
        }

        // GET: Cpanel/BDS_HUONGNHA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_HUONGNHA bDS_HUONGNHA = db.BDS_HUONGNHA.Find(id);
            if (bDS_HUONGNHA == null)
            {
                return HttpNotFound();
            }
            return View(bDS_HUONGNHA);
        }

        // GET: Cpanel/BDS_HUONGNHA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpanel/BDS_HUONGNHA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHuongNha,TenHuongNha,STT")] BDS_HUONGNHA bDS_HUONGNHA)
        {
            if (ModelState.IsValid)
            {
                db.BDS_HUONGNHA.Add(bDS_HUONGNHA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bDS_HUONGNHA);
        }

        // GET: Cpanel/BDS_HUONGNHA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_HUONGNHA bDS_HUONGNHA = db.BDS_HUONGNHA.Find(id);
            if (bDS_HUONGNHA == null)
            {
                return HttpNotFound();
            }
            return View(bDS_HUONGNHA);
        }

        // POST: Cpanel/BDS_HUONGNHA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHuongNha,TenHuongNha,STT")] BDS_HUONGNHA bDS_HUONGNHA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bDS_HUONGNHA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bDS_HUONGNHA);
        }

        // GET: Cpanel/BDS_HUONGNHA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_HUONGNHA bDS_HUONGNHA = db.BDS_HUONGNHA.Find(id);
            if (bDS_HUONGNHA == null)
            {
                return HttpNotFound();
            }
            return View(bDS_HUONGNHA);
        }

        // POST: Cpanel/BDS_HUONGNHA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BDS_HUONGNHA bDS_HUONGNHA = db.BDS_HUONGNHA.Find(id);
            db.BDS_HUONGNHA.Remove(bDS_HUONGNHA);
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
