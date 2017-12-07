using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class ChiTietMuaBanChoThue
    {
        public List<TINHTHANH> TinhThanh;
        public BDS_MUABAN ChiTiet;
        public List<BDS_MUABAN> TinKhac;
    }
}