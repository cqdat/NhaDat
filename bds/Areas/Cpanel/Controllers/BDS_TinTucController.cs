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

namespace bds.Areas.Cpanel.Controllers
{
    public class BDS_TINTUCController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/BDS_TINTUC
        public ActionResult Index()
        {
            var BDS_TINTUC = db.BDS_TINTUC.Include(b => b.MENU).Include(b => b.THANHVIEN).Include(b => b.THANHVIEN1);
            return View(BDS_TINTUC.ToList());
        }

        // GET: Cpanel/BDS_TINTUC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_TINTUC BDS_TINTUC = db.BDS_TINTUC.Find(id);
            if (BDS_TINTUC == null)
            {
                return HttpNotFound();
            }
            return View(BDS_TINTUC);
        }

        // GET: Cpanel/BDS_TINTUC/Create
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

        // POST: Cpanel/BDS_TINTUC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "TinTucID,TintucName,HinhAnh,MoTa,NoiDung,IDMenu,NoiBat,NhieuNguoiDoc,CountView,HotIcon,Created,CreateBy,Updated,UpdateBy,Visible,URL,MetaKeyword,MetaDescrip")] BDS_TINTUC BDS_TINTUC, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
                };
                var fileName = Path.GetFileName(HinhAnh.FileName);
                var ext = Path.GetExtension(HinhAnh.FileName);

                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = name + "_" + DateTime.Now.Millisecond + ext; //appending the name with id  
                                                                                 // store the file inside ~/project folder(Img)  

                    var path = Path.Combine(Server.MapPath("~/Areas/Cpanel/Images/TinTuc"), myfile);
                    //var dir = Directory.CreateDirectory(path);
                    //HinhAnh.SaveAs(Path.Combine(path, myfile));
                    
                    BDS_TINTUC.HinhAnh = myfile;
                    HinhAnh.SaveAs(path);
                }
                else
                {
                    ViewBag.message = "Please choose only Image file";
                }
                
                db.BDS_TINTUC.Add(BDS_TINTUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMenu = new SelectList(db.MENUs, "IdMenu", "TenMenu", BDS_TINTUC.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.UpdateBy);
            return View(BDS_TINTUC);
        }

        // GET: Cpanel/BDS_TINTUC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_TINTUC BDS_TINTUC = db.BDS_TINTUC.Find(id);
            if (BDS_TINTUC == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMenu = new SelectList(db.MENUs, "IdMenu", "TenMenu", BDS_TINTUC.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.UpdateBy);
            return View(BDS_TINTUC);
        }

        // POST: Cpanel/BDS_TINTUC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TinTucID,TintucName,HinhAnh,MoTa,NoiDung,IDMenu,NoiBat,NhieuNguoiDoc,CountView,HotIcon,Created,CreateBy,Updated,UpdateBy,Visible,URL")] BDS_TINTUC BDS_TINTUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(BDS_TINTUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMenu = new SelectList(db.MENUs, "IdMenu", "TenMenu", BDS_TINTUC.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.UpdateBy);
            return View(BDS_TINTUC);
        }

        // GET: Cpanel/BDS_TINTUC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDS_TINTUC BDS_TINTUC = db.BDS_TINTUC.Find(id);
            if (BDS_TINTUC == null)
            {
                return HttpNotFound();
            }
            return View(BDS_TINTUC);
        }

        // POST: Cpanel/BDS_TINTUC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BDS_TINTUC BDS_TINTUC = db.BDS_TINTUC.Find(id);
            db.BDS_TINTUC.Remove(BDS_TINTUC);
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
