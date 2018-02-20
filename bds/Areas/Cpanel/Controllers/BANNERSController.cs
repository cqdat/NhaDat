using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Controllers;
using bds.Models;
using bds.Areas.Cpanel.Models;
using System.IO;
using System.Data.Entity;

namespace bds.Areas.Cpanel.Controllers
{
    public class BANNERSController : BaseController
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: Cpanel/BANNERS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdLogo()
        {
            var logo = db.BANNERS.Where(b => b.TypeBanner == 1).SingleOrDefault();//Where = 1: Logo chỉ 1 dòng duy nhất
            return View(logo);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveLogo(FormCollection f, HttpPostedFileBase ImageURL)
        {
            var user = db.USERs.SingleOrDefault(u => u.UserName.ToUpper() == User.Identity.Name.ToUpper());

            var logo = db.BANNERS.Where(b => b.TypeBanner == 1).SingleOrDefault();//Where = 1: Logo chỉ 1 dòng duy nhất
            if (ImageURL != null && ImageURL.ContentLength > 0)
            {
                

                var allowedExtensions = new[] {
                            ".Jpg", ".png", ".jpg", "jpeg"
                            };
                var fileName = Path.GetFileName(ImageURL.FileName);
                var ext = Path.GetExtension(ImageURL.FileName);

                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = name + "_" + DateTime.Now.Millisecond + ext; //appending the name with id  
                                                                                 // store the file inside ~/project folder(Img)  

                    var path = Path.Combine(Server.MapPath("~/Areas/Cpanel/Images/Logo"), myfile);
                    //var dir = Directory.CreateDirectory(path);
                    //HinhAnh.SaveAs(Path.Combine(path, myfile));

                    logo.ImageURL = myfile;
                    logo.NameBanner = "Logo";
                    logo.LinkBanner = f["LinkBanner"];
                    logo.KieuChuyenHuong = f["KieuChuyenHuong"];
                    logo.ViTri = 1;
                    logo.HienThi = Convert.ToInt32(f["HienThi"]);
                    logo.TypeBanner = 1;
                    logo.NgayCapNhat = DateTime.Now;
                    logo.UpdateBy = user.FullName;
                    ImageURL.SaveAs(path);

                    db.Entry(logo).State = EntityState.Modified;
                    db.SaveChanges();
                    Success(string.Format("Lưu thành công"), true);
                    return RedirectToAction("UpdLogo", "BANNERS", new { area = "Cpanel" });
                }
                else
                {
                    Danger(string.Format("Bạn chọn định dạng hình ảnh không đúng!"), true);
                    db.SaveChanges();
                    return RedirectToAction("UpdLogo", "BANNERS", new { area = "Cpanel" });
                }
            }
            else
            {
                logo.NameBanner = "Logo";
                logo.LinkBanner = f["LinkBanner"];
                logo.KieuChuyenHuong = f["KieuChuyenHuong"];
                logo.ViTri = 1;
                logo.HienThi = Convert.ToInt32(f["HienThi"]);
                logo.TypeBanner = 1;
                logo.NgayCapNhat = DateTime.Now;
                logo.UpdateBy = user.FullName;

                db.Entry(logo).State = EntityState.Modified;
                db.SaveChanges();
                Success(string.Format("Lưu thành công"), true);
                return RedirectToAction("UpdLogo", "BANNERS", new { area = "Cpanel" });
            }

        }

        public ActionResult BannersLst()
        {
            return View();
        }
    }
}