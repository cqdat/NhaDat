using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class NewsViewModel
    {
        public List<BDS_TinTuc> TinTuc;
        public List<BDS_TinTuc> TinNoiBat;
        public List<BDS_TinTuc> NhieuNguoiDoc;
    }
}