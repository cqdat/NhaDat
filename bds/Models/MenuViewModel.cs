using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class MenuViewModel
    {
        public MENU MuaBan;
        public MENU CHoThue;
        public MENU DuAn;
        public List<MENU> TinTuc;
        public List<GIOITHIEU> DichVuVIP;
    }
}