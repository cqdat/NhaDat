using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class NewsDetailModel
    {
        public BDS_TINTUC ChiTiet;
        public List<BDS_TINTUC> TinKhac;
        public List<BDS_TINTUC> TinNoiBat;
        public List<BDS_TINTUC> NhieuNguoiDoc;
    }
}