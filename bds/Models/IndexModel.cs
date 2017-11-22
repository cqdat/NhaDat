using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class IndexModel
    {
        public List<TINHTHANH> TinhThanh;
        public List<BDS_TinTuc> TinTucNoiBat;
        public BDS_TinTuc FirstNEWS;
        public List<BDS_MuaBan> BDSNoiBat;
        public List<BDS_MuaBan> BDSMoi;
    }
}