namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DUAN_LOAI
    {
        [Key]
        public int IDLOAI { get; set; }

        public int? THUTU { get; set; }

        [StringLength(1000)]
        public string TENLOAI { get; set; }

        public int? HIENTHI { get; set; }

        public int? HIEULUC { get; set; }

        public int? IDCHA { get; set; }

        [StringLength(1000)]
        public string URL { get; set; }

        public DateTime? NGAY { get; set; }

        public int? CAP { get; set; }

        [StringLength(1000)]
        public string HINHANH { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        public int? TINNOIBAT { get; set; }
    }
}
