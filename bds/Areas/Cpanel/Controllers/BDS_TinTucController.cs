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
    public class BDS_TINTUCController : BaseController
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        // GET: Cpanel/BDS_TINTUC
        [Authorize]
        public ActionResult Index()
        {
            //var BDS_TINTUC = db.BDS_TINTUC.Include(b => b.MENU).Include(b => b.THANHVIEN).Include(b => b.THANHVIEN1);
            ViewBag.IDMenuCha = new SelectList(db.MENUs.Where(m => m.IdCha == 0 && m.IsTypeTT == true), "IdMenu", "TenMenu");
            return View();
        }

        public ActionResult _PartialIndex(int? pageNumber, int? pageSize, string TieuDe, int? IDMenuCha, int? IDMenu)
        {
            TieuDe = TieuDe ?? "";
            ViewBag.TieuDe = TieuDe;
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 10;

            if (pageSize == -1)
            {
                pageSize = db.BDS_TINTUC.Include(b => b.MENU).Include(b => b.THANHVIEN).Include(b => b.THANHVIEN1).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstTintucs = db.BDS_TINTUC.Include(b => b.MENU).Include(b => b.THANHVIEN).Include(b => b.THANHVIEN1).ToList();

            if (!string.IsNullOrEmpty(TieuDe))
            {
                lstTintucs = lstTintucs.Where(s => s.TintucName.Contains(TieuDe)).ToList();
            }
            ViewBag.TieuDe = TieuDe;

            if (!string.IsNullOrEmpty(IDMenuCha.ToString()))
            {
                lstTintucs = lstTintucs.Where(s => s.IDMenuCha == IDMenuCha).ToList();
            }
            ViewBag.IDMenuCha = IDMenuCha;

            if (!string.IsNullOrEmpty(IDMenu.ToString()))
            {
                lstTintucs = lstTintucs.Where(s => s.IDMenu == IDMenu).ToList();
            }
            ViewBag.IDMenu = IDMenu;

            //var nb = Convert.ToBoolean(NoiBat);
            //if (!string.IsNullOrEmpty(NoiBat.ToString()))
            //{
            //    lstTintucs = lstTintucs.Where(s => s.NoiBat == nb).ToList();
            //}
            //ViewBag.NoiBat = NoiBat;

            lstTintucs = lstTintucs.OrderBy(s => s.Vitri).ToList();
            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstTintucs.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Cpanel/Views/BDS_TinTuc/_PartialIndex.cshtml", lstTintucs.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));

            }
            return View(lstTintucs.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }

        // GET: Cpanel/BDS_TINTUC/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDMenuCha = new SelectList(db.MENUs.Where(m=>m.IdCha == 0 && m.IsTypeTT == true).OrderBy(m=>m.ThuTu), "IdMenu", "TenMenu");
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
        public ActionResult Create([Bind(Include = "TinTucID,TintucName,HinhAnh,MoTa,NoiDung,Vitri,IDMenuCha,IDMenu,NoiBat,NhieuNguoiDoc,CountView,HotIcon,Created,CreateBy,Updated,UpdateBy,Visible,URL,MetaKeyword,MetaDescrip")] BDS_TINTUC BDS_TINTUC, HttpPostedFileBase HinhAnh)
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
                BDS_TINTUC.URL = Helper.ConvertToUpperLower(BDS_TINTUC.TintucName);
                BDS_TINTUC.Created = DateTime.Now;
                BDS_TINTUC.Updated = DateTime.Now;
                db.BDS_TINTUC.Add(BDS_TINTUC);
                Success(string.Format("Lưu thành công"), true);
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


            ViewBag.IDMenuCha = new SelectList(db.MENUs.Where(m => m.IdCha == 0 && m.IsTypeTT == true).OrderBy(m => m.ThuTu), "IdMenu", "TenMenu", BDS_TINTUC.IDMenuCha);
            ViewBag.IDMenu = new SelectList(db.MENUs.Where(m=>m.IdCha == BDS_TINTUC.IDMenuCha), "IdMenu", "TenMenu", BDS_TINTUC.IDMenu);
            ViewBag.CreateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.CreateBy);
            ViewBag.UpdateBy = new SelectList(db.THANHVIENs, "idTV", "TenTruyCap", BDS_TINTUC.UpdateBy);
            return View(BDS_TINTUC);
        }

        // POST: Cpanel/BDS_TINTUC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "TinTucID,TintucName,HinhAnh,MoTa,NoiDung,Vitri,IDMenuCha,IDMenu,NoiBat,NhieuNguoiDoc,CountView,HotIcon,Created,CreateBy,Updated,UpdateBy,Visible,URL,MetaKeyword,MetaDescrip")] BDS_TINTUC BDS_TINTUC, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
                };
                
                if(HinhAnh.FileName == "" || HinhAnh.FileName == null)
                {
                    BDS_TINTUC.HinhAnh = BDS_TINTUC.HinhAnh;
                }
                else
                {
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
                }

                
                BDS_TINTUC.URL = Helper.ConvertToUpperLower(BDS_TINTUC.TintucName);
                BDS_TINTUC.Updated = DateTime.Now;

                db.Entry(BDS_TINTUC).State = EntityState.Modified;
                db.SaveChanges();
                Success(string.Format("Lưu thành công"), true);
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
