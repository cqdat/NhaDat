namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIOITHIEU")]
    public partial class GIOITHIEU
    {
        [Key]
        public int IDTT { get; set; }

        public int? THUTU { get; set; }

        [StringLength(4000)]
        public string TIEUDE { get; set; }

        [Column(TypeName = "ntext")]
        public string TOMTAT { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        [StringLength(1000)]
        public string HINHANH { get; set; }

        public DateTime? NGAYCAPNHAT { get; set; }

        public int? TINNOIBAT { get; set; }

        public int? HIENTHI { get; set; }

        public int? HIEULUC { get; set; }

        public int? SOLANXEM { get; set; }

        [Column(TypeName = "ntext")]
        public string TUKHOA1 { get; set; }

        [Column(TypeName = "ntext")]
        public string TUKHOA2 { get; set; }

        [Column(TypeName = "ntext")]
        public string TUKHOA3 { get; set; }
    }
}
