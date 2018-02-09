using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bds.Models;
using bds.Areas.Cpanel.Models;
using System.Net;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;

namespace bds.Areas.Cpanel.Controllers
{
    public class USERController : Controller
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();
        // GET: Cpanel/USER
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUserAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserAdmin([Bind(Include = "UserName,Active,FullName,Password")] USER user)
        {
            if (ModelState.IsValid)
            {
                user.Password= EnCrypt(user.Password.Trim(), user.UserName.PadRight(1));
                user.Lastlogin = DateTime.Now;
                user.AddDate = DateTime.Now;
                user.UpdateDate = DateTime.Now;
                user.CreatedBy = "DANNY CAO";
                user.UpdateBy = "";

                db.USERs.Add(user);
                db.SaveChanges();
                //Success(string.Format("<b>{0}</b> was added to the database successfully.", user.FullName), true);
                return RedirectToAction("CreateUserAdmin");
            }

            return View(user);
        }

        //================================================================================
        // LOGIN FUNCTION
        //================================================================================
        #region Login functionaly 
        public ActionResult LoginAdmin(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnURL = returnUrl;
                //return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.ReturnURL = "/Cpanel/Default/Index";
            }
            //return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(USER model, string returnUrl)
        {
            //returnUrl = ViewBag.ReturnURL;
            ViewBag.Error = "";
            if (returnUrl == "")
            {
                returnUrl = ViewBag.ReturnURL;
            }
            try
            {
               
                var user = db.USERs.Where(o => o.UserName == model.UserName && o.Active == true).SingleOrDefault();
                if (user != null)
                {

                    if (IsValid(model.UserName, model.Password))
                    {
                        if (model.UserName == "Admin")
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName.ToLower(), false);
                        }

                        if ((Url.IsLocalUrl(returnUrl) &&
                            returnUrl.Length > 1 &&
                            returnUrl.StartsWith("/")) &&
                            !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Error");
                            return RedirectToAction("Index", "Home");

                        }
                    }

                    else
                    {

                        ModelState.AddModelError("", "User name or password not correct");

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You do not have authority for this function");
                    return View(model);
                }
            }
            catch
            {
                ModelState.AddModelError("", "");

                return View(model);
            }

        }

        //=======================
        //Check login
        //=======================
        private bool IsValid(string username, string password)
        {
            bool b = false;
            if (username.ToString().Trim() != "")
            {
                //var u = context.WNKUSERs.FirstOrDefault(x => x.U_USER == username.ToLower());
                var u = db.USERs.FirstOrDefault(i => i.UserName.ToLower() == username.ToLower());
                if (u != null)
                {
                    if (username != null && password != null
                    && username.Trim() != "" & password.Trim() != "")
                    {
                        string pwd_ = EnCrypt(password.Trim(), u.UserName.PadRight(1));
                        if (u.Password.ToString().Trim() == EnCrypt(password.Trim(), u.UserName.PadRight(1)))
                        {
                            b = true;
                        }
                    }
                }
            }
            return b;
        }
        #endregion

        //================================================================================
        // LOGIN FUNCTION
        //================================================================================
        #region LOGOUT
        [Authorize]
        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("LoginAdmin", "USER", new { area = "Cpanel" }); ;
        }

        #endregion

        //================================================================================
        //Encryption for password
        //================================================================================
        #region Encryption for password
        private string EnCrypt(string strEnCrypt, string key)
        {
            try
            {
                byte[] keyArr;
                byte[] EnCryptArr = UTF8Encoding.UTF8.GetBytes(strEnCrypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
                return Convert.ToBase64String(arrResult, 0, arrResult.Length);
            }
            catch
            {


            }
            return "";
        }

        //=======================
        //Decryption for password
        //=======================
        private string DeCrypt(string strDecypt, string key)
        {
            try
            {
                byte[] keyArr;
                byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] arrResult = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length);
                return UTF8Encoding.UTF8.GetString(arrResult);
            }
            catch { }
            return "";
        }

        #endregion
    }
}