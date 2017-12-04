namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_TinTuc
    {
        [Key]
        public int TinTucID { get; set; }

        [Required]
        [StringLength(150)]
        public string TintucName { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [StringLength(400)]
        public string MoTa { get; set; }

        public string NoiDung { get; set; }

        public int? IDMenu { get; set; }

        public bool? NoiBat { get; set; }

        public bool? NhieuNguoiDoc { get; set; }

        public int? CountView { get; set; }

        public bool? HotIcon { get; set; }

        public DateTime? Created { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? Updated { get; set; }

        public int? UpdateBy { get; set; }

        public bool? Visible { get; set; }

        [StringLength(200)]
        public string URL { get; set; }

        public virtual MENU MENU { get; set; }

        public virtual THANHVIEN THANHVIEN { get; set; }

        public virtual THANHVIEN THANHVIEN1 { get; set; }
    }
}
