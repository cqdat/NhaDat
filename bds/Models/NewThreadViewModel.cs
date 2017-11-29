using bds.Areas.Cpanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bds.Models
{
    public class NewThreadViewModel
    {
        public List<TINHTHANH> TinhThanh;
        public List<MENU> Menu;
    }

    public class DataNewThread
    {

    }
    public class DuongPho
    {
        public int IDDuongPho;
        public string TenDuongPho;
    }
    public class DuAn
    {
        public int IDDuAn;
        public string TenDuAn;
    }
    public class QuanHuyen
    {
        public int IDQuanHuyen;
        public string TenQuanHuyen;
    }
}