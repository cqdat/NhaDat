namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHITIET_TT
    {
        [Key]
        public int ChiTietTTID { get; set; }

        public int? IDMuaBan { get; set; }

        public int? IDThuocTinh { get; set; }

        public virtual BDS_MUABAN BDS_MUABAN { get; set; }

        public virtual THUOCTINH THUOCTINH { get; set; }
    }
}
