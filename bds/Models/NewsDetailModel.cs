using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class NewsDetailModel
    {
        public BDS_TinTuc ChiTiet;
        public List<BDS_TinTuc> TinKhac;
        public List<BDS_TinTuc> TinNoiBat;
        public List<BDS_TinTuc> NhieuNguoiDoc;
    }
}