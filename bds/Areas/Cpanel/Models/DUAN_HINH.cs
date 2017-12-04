namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DUAN_HINH
    {
        [Column(TypeName = "numeric")]
        public decimal IDTT { get; set; }

        public int? THUTU { get; set; }

        [Key]
        public int IDH { get; set; }

        [StringLength(1000)]
        public string TENHINH { get; set; }

        [StringLength(1000)]
        public string HINHNHO { get; set; }

        [StringLength(1000)]
        public string HINHLON { get; set; }

        [Column(TypeName = "ntext")]
        public string MOTA { get; set; }

        public int? HIEULUC { get; set; }

        public int? HIENTHI { get; set; }
    }
}
