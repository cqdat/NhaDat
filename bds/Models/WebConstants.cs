using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bds.Models
{
    public class WebConstants
    {
        public class Menu
        {
            public static string MENUTOP = "TOP";
            public static string MENULEFT = "LEFT";
        }
        public class Session
        {
            public static string WebInfors = "WEBINFORS";
        }
        public class Infomation
        {
            public static string IMAGEPATH = "/images/Upload/";
            public static string IMAGETHUMB = "/images/Upload/Thumbs/";
            public static int IMAGETHUMBWIDTH = 196;
            public static int IMAGETHUMBHEIGHT = 196;
            public static string REGEXREPLACE_NAME = @"[^a-zA-Z0-9.]";

            public static string TITLE = "Title";
            public static string LOGOPATH = "LogoPath";
            public static string COMPANYNAME = "CompanyName";
            public static string ADDRESS = "Address";
            public static string TELEPHONE = "Telephone";
            public static string FAX = "Fax";

        }
    }
}