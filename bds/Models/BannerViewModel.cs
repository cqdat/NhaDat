using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class BannerViewModel
    {
        public BANNER Logo;
        public BANNER BannerTop;
        public List<BANNER> BannerLeft;
        public List<BANNER> BannerRight;
        public List<BANNER> BannerTrangChu;
        public List<BANNER> BannerChiTiet;
    }
}