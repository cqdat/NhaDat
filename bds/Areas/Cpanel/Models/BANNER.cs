namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANNERS")]
    public partial class BANNER
    {
        [Key]
        public int IdBanner { get; set; }

        [StringLength(200)]
        public string NameBanner { get; set; }

        [StringLength(200)]
        public string ImageURL { get; set; }

        [StringLength(200)]
        public string LinkBanner { get; set; }

        [StringLength(20)]
        public string KieuChuyenHuong { get; set; }

        public int? ViTri { get; set; }

        public int? HienThi { get; set; }
        public int? TypeBanner { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }
    }
}
