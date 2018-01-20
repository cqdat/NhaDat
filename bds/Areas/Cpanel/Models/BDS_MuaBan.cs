namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_MUABAN
    {
        [Key]
        public int IDMuaBan { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string HinhAnh { get; set; }

        [StringLength(400)]
        public string MoTa { get; set; }

        public string NoiDung { get; set; }

        public int? IDMenu { get; set; }

        public bool? NoiBat { get; set; }

        public int? CountView { get; set; }

        public bool? HotIcon { get; set; }

        [StringLength(50)]
        public string Gia { get; set; }

        [StringLength(20)]
        public string DienTich { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string MapPoint { get; set; }

        public int? PropertyID { get; set; }

        public bool Type { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public int? CreateBy { get; set; }

        public int? UpdateBy { get; set; }

        public bool? IsVip { get; set; }

        public bool? Visible { get; set; }

        public int? Rating { get; set; }

        [StringLength(200)]
        public string URL { get; set; }

        public int? IDTinhThanh { get; set; }

        public int? LoaiTin { get; set; }

        public int? IDDuongPho { get; set; }

        public bool? Duyet { get; set; }
    }
}
