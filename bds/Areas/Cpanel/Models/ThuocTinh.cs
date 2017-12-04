namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuocTinh")]
    public partial class ThuocTinh
    {
        [Key]
        public int IDThuocTinh { get; set; }

        [StringLength(150)]
        public string ThuocTinhName { get; set; }

        public int? IDMuaBan { get; set; }

        public virtual BDS_MuaBan BDS_MuaBan { get; set; }
    }
}
