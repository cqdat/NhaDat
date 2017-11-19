namespace bds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DUAN")]
    public partial class DUAN
    {
        public int? IDLOAI { get; set; }

        public int? THUTU { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDTT { get; set; }

        [StringLength(1000)]
        public string TIEUDE { get; set; }

        [StringLength(4000)]
        public string TOMTAT { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        [StringLength(1000)]
        public string HINHNHO { get; set; }

        [StringLength(1000)]
        public string HINHLON { get; set; }

        public DateTime? NGAY { get; set; }

        public int? TINNOIBAT { get; set; }

        public int? HIENTHI { get; set; }

        public int? HIEULUC { get; set; }

        public int? SOLANXEM { get; set; }
    }
}
