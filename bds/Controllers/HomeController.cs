using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Areas.Cpanel.Models;
using bds.Models;
using CaptchaMvc.HtmlHelpers;

namespace bds.Controllers
{
    public class HomeController : Controller
    {
        private DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        Helper h = new Helper();
        public ActionResult Index()
        {
            /// type == true => mua bán, type=false ==> cho thue
            IndexModel index = new IndexModel();
            index.TinhThanh = db.TINHTHANHs.Where(q => q.IDCha == 0).ToList();//db.TINHTHANHs.Where(q => q.IDCha == 0).ToList();
            index.BDSNoiBat = db.BDS_MUABAN.Where(q => q.NoiBat == true && q.Visible == true && q.Type == false).Take(15).ToList();
            index.BDSMoi = db.BDS_MUABAN.Where(q => q.Visible == true && q.Type == false).OrderBy(o => o.Created).Take(15).ToList();
            index.TinTucNoiBat = db.BDS_TINTUC.Where(q => q.Visible == true && q.NoiBat == true).Take(10).ToList();
            index.FirstNEWS = db.BDS_TINTUC.FirstOrDefault(q => q.NoiBat == true && q.Visible == true);
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
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            MenuViewModel model = new MenuViewModel();
            model.MuaBan = db.MENUs.Find(1);
            model.CHoThue = db.MENUs.Find(2);
            model.DuAn = db.MENUs.Find(3);
            model.TinTuc = db.MENUs.Where(q => q.IdCha == 0 && q.HienThi == 1 && q.IdMenu != 1 && q.IdMenu != 2 && q.IdMenu != 3).OrderBy(o => o.ThuTu).ToList();
            model.DichVuVIP = db.GIOITHIEUx.Where(g => g.HIENTHIMENU == 1 && g.HIENTHI == 1).OrderBy(g=>g.THUTU).ToList();

            return PartialView("_menubar", model);
        }

        public PartialViewResult getHeader()
        {
            return PartialView("_header");
        }

        public PartialViewResult getFooter()
        {
            return PartialView("_footer");
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
            if(Session["username"] != null)
            {
                return Redirect("~/home");
            }
            else
            {
                if (id == 0)
                {
                    ViewBag.Error = "Đăng nhập không thành công ! Vui lòng thử lại !";
                }
                else if(id == 1)
                {
                    ViewBag.Error = "Vui lòng đăng nhập để được đăng tin !";
                }
                else
                {
                    ViewBag.Error = "Vui lòng đăng nhập website để tiếp tục !";
                }

                return View();
            }            
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
                Session["VIPMoney"] = model.VIPMoney;
                Session["userlogin"] = model;
                if (ckRemember != null)
                {
                    HttpCookie cookie = new HttpCookie("Login");
                    cookie.Values["username"] = model.TenTruyCap;
                    cookie.Values["uid"] = model.idTV.ToString();
                    cookie.Values["VIPMoney"] = model.VIPMoney.ToString();
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
        public ActionResult Register(int? id)
        {
            if(id == 0)
            {
                ViewBag.Success = "Đăng Ký thành công ! Chào mừng đến mới website !";
            }
            else
            {
                ViewBag.Error = "Đăng Ký không thành công ! Vui lòng đăng ký lại !";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(string txtUserName, string txtPassword, string txtFullName, string txtMobile, string txtEmail, int slDistrict, string CaptchaInputText)
        {
            if(this.IsCaptchaValid(CaptchaInputText))
            {
                THANHVIEN t = new THANHVIEN();
                //t.idTV = 3;
                t.TenTruyCap = txtUserName;
                t.MatKhau = HashPasswordUser(txtPassword);
                t.HoTen = txtFullName;
                t.SoDiDong = txtMobile;
                t.EmailLH = txtEmail;
                t.TinhTrang = 1;
                t.VIP = 0;
                t.DiaChi = slDistrict.ToString();
                t.LanDangNhapCuoi = DateTime.Now;
                db.THANHVIENs.Add(t);
                db.SaveChanges();

                return Redirect("/home/register/0");
            }
            else
            {
                return Redirect("/home/register/1");
            }
        }

        [HttpGet]
        public ActionResult NewThread()
        {
            if(Session["username"] != null)
            {
                NewThreadViewModel model = new NewThreadViewModel();
                model.TinhThanh = db.TINHTHANHs.Where(q => q.IDCha == 0).ToList();
                model.Menu = db.MENUs.Where(q => q.IdCha == 1).ToList();
                return View(model);
            }
            else
            {
                return Redirect("~/home/login/1");
            }           
        }
        [HttpPost]
        public ActionResult NewThread(string tieude, string noidung, int slLoaitin, int slLoaiBDS, int slPhuongXa, int slDuongPho, string txtDiachi,
            int slDuAn, string txtDientich, string txtGia, int slTheoGia, string txtNgang, string txtDai, int slHuong, string txtDuongRong, int slPhapLy,
            string txtSolau, string txtPhongngu, bool? ckChinhchu, bool? ckXehoi, bool? ckSanthuong, bool? ckPhongAn, bool? ckBep, /*int? hinhthuc,*/ string CaptchaInputText
            /*int? slLoaiVipNgay, int? slSongay, int? slLoaiVipThang*/)
        {

            if(this.IsCaptchaValid(CaptchaInputText))
            {
                BDS_MUABAN bds = new BDS_MUABAN();
                bds.Name = tieude;
                bds.HinhAnh = "";
                bds.MoTa = "";
                bds.NoiDung = noidung;
                bds.IDMenu = slLoaiBDS;
                bds.NoiBat = false;
                bds.CountView = 1;
                bds.HotIcon = false;
                
                if(slTheoGia == 1)
                {
                    bds.Gia = txtGia + "";
                }
                else
                {
                    bds.Gia = txtGia + "triệu/m2";
                }
                bds.DienTich = txtDientich;
                bds.DiaChi = txtDiachi;
                bds.MapPoint = "";
                bds.Type = false;
                bds.Created = DateTime.Now;
                bds.Updated = DateTime.Now;
                bds.CreateBy = Convert.ToInt32(Session["uid"]);
                bds.IsVip = false;
                bds.Visible = false;
                bds.Rating = 5;
                bds.URL = Helper.ConvertToUpperLower(tieude);
                bds.IDTinhThanh = slPhuongXa;
                bds.LoaiTin = slLoaitin;
                bds.IDDuongPho = 1;
                bds.Duyet = false;
                bds.Ngang = txtNgang;
                bds.Dai = txtDai;
                bds.Huong = slHuong;
                bds.DuongRong = txtDuongRong;
                bds.PhapLy = slPhapLy;
                bds.SoLau = txtSolau;
                bds.PhongNgu = txtPhongngu;
                bds.NhaBep = ckBep;
                bds.PhongAn = ckPhongAn;
                bds.SanThuong = ckSanthuong;
                bds.XeHoi = ckXehoi;
                bds.ChinhChu = ckChinhchu;


                db.BDS_MUABAN.Add(bds);
                db.SaveChanges();


            }
            return View();
        }

        public ActionResult UserControl()
        {
            return View();
        }

        public JsonResult checkUsername(string txtUsername)
        {
            var m = db.THANHVIENs.FirstOrDefault(q => q.TenTruyCap == txtUsername);
            if(m != null)
            {
                return Json("Tài khoản đã có người sử dụng", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }           
        }
        public JsonResult checkEmail(string txtEmail)
        {
            var m = db.THANHVIENs.FirstOrDefault(q => q.EmailLH == txtEmail);
            if (m != null)
            {
                return Json("Email đã có người sử dụng", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult checkMobile(string txtMobile)
        {
            var m = db.THANHVIENs.FirstOrDefault(q => q.SoDiDong == txtMobile);
            if (m != null)
            {
                return Json("Số điện thoại đã có người sử dụng", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getPhuongXa(int? quanhuyenid)
        {
            var model = db.TINHTHANHs.Where(q => q.IDCha == quanhuyenid && q.Cap == 2).Select(x => new {
                IDPhuongXa = x.IdTT,
                NamePhuongXa = x.TenTT
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDuongPho(int? phuongxaid)
        {
            var model = db.TINHTHANHs.Where(q => q.IDCha == phuongxaid && q.Cap == 3).Select(x => new {
                IDDuongPho = x.IdTT,
                NameDuongPho = x.TenTT
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BanDo()
        {
            return View();
        }


    }
}
