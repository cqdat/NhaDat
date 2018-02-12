using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using bds.Areas.Cpanel.Models;

namespace bds.Controllers
{
    public class LienHeController : BaseController
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: LienHe
        public ActionResult Index()
        {
            THANHVIEN us = (THANHVIEN)Session["userlogin"];
            string TenLH="";
            string SDT="";
            string emailLH = "";
            if (us != null)
            {
                TenLH = us.HoTen;
                SDT = us.SoDiDong;
                emailLH = us.EmailLH;
            }
            ViewBag.TenLH = TenLH;
            ViewBag.SDT = SDT;
            ViewBag.emailLH = emailLH;
            return View();
        }

        [HttpPost]
        public ActionResult SaveContact(string TenLienHe, string emailLH, string phonenumber, string tieude, string NoiDung, string CaptchaInputText)
        {
            if (this.IsCaptchaValid(CaptchaInputText))
            {
                LIENHE_GOPY lh = new LIENHE_GOPY();
                lh.TenLH = TenLienHe;
                lh.UsernameLH = emailLH;
                lh.SDT = phonenumber;
                lh.EmailLH = "";
                lh.TieuDe = tieude;
                lh.NoiDung = NoiDung;
                lh.TrangThai = 1;
                lh.NoiDungTraLoi = "";
                lh.ThoiGianGui = DateTime.Now;
                lh.ThoiGianTraloi = null;
                lh.HienThi = 1;
                
                db.LIENHE_GOPY.Add(lh);
                db.SaveChanges();

                Success(string.Format("Cảm ơn bạn đã liên hệ với chúng tôi! Chúng tôi sẽ phản hồi tới bạn trong thời gian sớm nhất."), true);
                return RedirectToAction("Index","LienHe");
            }
            else
            {
                Danger(string.Format("Bạn nhập mã bảo vệ không khớp, vui lòng thử lại."), true);
                return RedirectToAction("Index", "LienHe");
            }
            
        }
    }
}