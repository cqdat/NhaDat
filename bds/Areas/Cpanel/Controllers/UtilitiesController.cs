using bds.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace bds.Areas.Cpanel.Controllers
{
    public class UtilitiesController : Controller
    {
        // GET: Cpanel/Utilities
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            //langCode=en, =vi
            string url; // url to return
            string message = ""; // message to display (optional)
            string path = WebConstants.Infomation.IMAGEPATH;
            string paththumb = WebConstants.Infomation.IMAGETHUMB;
            if (upload.ContentLength > 0)
            {
                if (upload.ContentType.Contains("image"))
                {
                    string filename = Regex.Replace(upload.FileName, WebConstants.Infomation.REGEXREPLACE_NAME, "_");
                    path += filename;
                    paththumb += filename;
                    //Kiểm tra trùng tên
                    if (CheckExistsFile(Server.MapPath(path)))
                    {
                        message = "Exist Image";
                    }
                    else
                    {
                        upload.SaveAs(Server.MapPath(path));
                        ImageResizer img = new ImageResizer();
                        bool result = img.ResizeImage(Server.MapPath(path), Server.MapPath(img.ConvertExtention(paththumb, "jpg")), WebConstants.Infomation.IMAGETHUMBWIDTH, WebConstants.Infomation.IMAGETHUMBHEIGHT);
                        if (result == false)
                        {
                            message = "Error Convert Image";
                        }
                    }
                }
            }

            // will create http://localhost:1457/Content/Images/my_uploaded_image.jpg
            url = Request.Url.GetLeftPart(UriPartial.Authority) + "/" + path;

            if (message != "")
            {
                url = "";
                string output = @"<html><body><script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\", \"" + message + "\");window.close();</script></body></html>";
                return Content(output);
            }
            else
            {
                string output = @"<html><body><script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");window.close();</script></body></html>";
                return Content(output);
            }
        }

        public ActionResult ImageBrowser()
        {
            ImageResizer img = new ImageResizer();
            List<ImageBrowserItem> list = new List<ImageBrowserItem>();
            string path = Server.MapPath(WebConstants.Infomation.IMAGEPATH);
            //Duyệt thư mục hình
            string[] Files = Directory.GetFiles(path)
                                     .Select(p => Path.GetFileName(p))
                                     .ToArray();
            foreach (String image in Files)
            {
                ImageBrowserItem node = new ImageBrowserItem
                {
                    image = WebConstants.Infomation.IMAGEPATH + image,
                    thumb = img.ConvertExtention(WebConstants.Infomation.IMAGETHUMB + image, "jpg"),
                    folder = ""
                };
                list.Add(node);
                //if (image.ToLower().EndsWith(".jpg") || image.ToLower().EndsWith(".GIF") ||
                //image.ToLower().EndsWith(".png") || image.ToLower().EndsWith(".bmp") ||
                //image.ToLower().EndsWith(".jpeg"))
                //{
                //PictureBox display = new PictureBox();
                //display.SizeMode = PictureBoxSizeMode.StretchImage;
                //display.Image = Image.FromFile(image);
                //display.Height = 80;
                //display.Width = 80;
                //display.Cursor = Cursors.Hand;
                //thumbnailsFLP.Controls.Add(display);
                //display.Click += new EventHandler(pic_Click);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteImage(string imageUrl, string thumbUrl, string listUrl, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            ImageResizer img = new ImageResizer();
            string response = "true";
            string fileimage = Path.GetFileName(imageUrl);
            string fileimagethumb = Path.GetFileName(thumbUrl);
            System.IO.File.Delete(Server.MapPath(WebConstants.Infomation.IMAGEPATH + fileimage));
            System.IO.File.Delete(img.ConvertExtention(Server.MapPath(WebConstants.Infomation.IMAGETHUMB + fileimage), "jpg"));

            return Content(response);
        }
        [ChildActionOnly]
        public bool CheckExistsFile(string FullPath)
        {
            if (System.IO.File.Exists(FullPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}