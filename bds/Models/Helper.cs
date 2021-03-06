﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class Helper
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        //Get Menu Con
        public List<MENU> getChildMenu(int? idMenu)
        {
            return db.MENUs.Where(q => q.IdCha == idMenu).OrderBy(q=>q.ThuTu).ToList();
        }

        ////Get Menu Con
        //public List<GIOITHIEU> getChildDichVuVIP()
        //{
        //    return db.GIOITHIEUx.OrderBy(g => g.THUTU).ToList();
        //    //.Where(g => g.HIENTHIMENU == 1 && g.HIENTHI == 1)
        //}

        public List<TINHTHANH> getTinhThanh()
        {
            return db.TINHTHANHs.ToList();
        }


        //Get Quan Huyen theo tinh thanh
        public List<TINHTHANH> getChildTinhThanh(int? idTT)
        {
            return db.TINHTHANHs.Where(q => q.IDCha == idTT).OrderBy(q => q.ThuTu).ToList();
        }
        

        // chuyển chữ có dấu thành không dấu, chữ hoa thành chữ thường
        private static string[] VietNamChar = new string[]
        {
           "aAeEoOuUiIdDyY",
           "áàạảãâấầậẩẫăắằặẳẵ",
           "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
           "éèẹẻẽêếềệểễ",
           "ÉÈẸẺẼÊẾỀỆỂỄ",
           "óòọỏõôốồộổỗơớờợởỡ",
           "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
           "úùụủũưứừựửữ",
           "ÚÙỤỦŨƯỨỪỰỬỮ",
           "íìịỉĩ",
           "ÍÌỊỈĨ",
           "đ",
           "Đ",
           "ýỳỵỷỹ",
           "ÝỲỴỶỸ"
        };
        public static string ConvertToUpperLower(string strInput)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    strInput = strInput.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
            }

            string str1 = strInput.Replace(" ", "-").ToLower();
            string str2 = str1.Replace(",", "");
            string str3 = str2.Replace(".", "");
            string str4 = str3.Replace(":", "");
            string str5 = str4.Replace("?", "");
            string str6 = str5.Replace("%", "");
            string str7 = str6.Replace(";", "");
            string str8 = str7.Replace("!", "");
            string str9 = str8.Replace("@", "");


            return str9.ToLower();
        }
    }
}