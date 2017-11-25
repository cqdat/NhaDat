using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;
using bds.Models;

namespace bds.Controllers
{
    public class HomeController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        public ActionResult Index()
        {
            /// type == true => mua bán, type=false ==> cho thue
            IndexModel index = new IndexModel();
            index.TinhThanh = db.TINHTHANHs.Where(q => q.IDCha == 0).ToList();
            index.BDSNoiBat = db.BDS_MuaBan.Where(q => q.NoiBat == true && q.Visible == true && q.Type == true).Take(15).ToList();
            index.BDSMoi = db.BDS_MuaBan.Where(q => q.Visible == true && q.Type == true).OrderBy(o => o.Created).Take(15).ToList();
            index.TinTucNoiBat = db.BDS_TinTuc.Where(q => q.Visible == true && q.NoiBat == true).Take(10).ToList();
            index.FirstNEWS = db.BDS_TinTuc.FirstOrDefault(q => q.NoiBat == true && q.Visible == true);
            return View(index);
        }

        public ActionResult About()
        {
            GIOITHIEU gIOITHIEU = db.GIOITHIEUx.Find(1);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
            
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Question()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult getMenu()
        {
            var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);
            return PartialView("_menubar", model);
        }

        private static string GetSHA512(string text)
        {
            System.Text.UnicodeEncoding UE = new System.Text.UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            System.Security.Cryptography.SHA512Managed hashString = new System.Security.Cryptography.SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);

            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public static string HashPasswordUser(string password)
        {
            string hashpass = null;

            hashpass = GetSHA512(password).Substring(0, 75).ToString();

            return hashpass;
        }
        [HttpGet]
        public ActionResult Login(int? id)
        {
            if(id ==0)
            {
                ViewBag.Error = "Đăng nhập không thành công ! Vui lòng thử lại !";
            }
            if(Session["username"] != null)
            {
                return Redirect("~/home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password, bool? ckRemember)
        {

            string hasspass = HashPasswordUser(password);
            var model = db.THANHVIENs.FirstOrDefault(q => q.TinhTrang == 1 && q.TenTruyCap == username && q.MatKhau == hasspass);
            if (model != null)
            {
                Session["username"] = model.TenTruyCap;
                Session["uid"] = model.idTV;
                if (ckRemember != null)
                {
                    HttpCookie cookie = new HttpCookie("Login");
                    cookie.Values["username"] = model.TenTruyCap;
                    cookie.Values["uid"] = model.idTV.ToString();
                    cookie.Expires = DateTime.Now.AddMonths(2);
                    Response.Cookies.Add(cookie);
                }               
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                return Redirect("~/home/login/0");
            }            
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(int? id)
        {
            return View();
        }
    }
}