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
        public List<BDS_TINTUC> TinTucNoiBat;
        public BDS_TINTUC FirstNEWS;
        public List<BDS_MUABAN> BDSNoiBat;
        public List<BDS_MUABAN> BDSMoi;
    }
}