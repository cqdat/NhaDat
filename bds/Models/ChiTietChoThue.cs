using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class ChiTietChoThue
    {
        public List<TINHTHANH> TinhThanh;
        public BDS_MuaBan ChiTiet;
        public List<BDS_MuaBan> TinKhac;
    }
}