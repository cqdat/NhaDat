namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHVIEN")]
    public partial class THANHVIEN
    {
        [Key]
        public int idTV { get; set; }

        [StringLength(20)]
        public string TenTruyCap { get; set; }

        [StringLength(200)]
        public string MatKhau { get; set; }

        [StringLength(200)]
        public string HoTen { get; set; }

        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDiDong { get; set; }

        [StringLength(100)]
        public string EmailLH { get; set; }

        public int? TinhTrang { get; set; }

        public int? VIP { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? LanDangNhapCuoi { get; set; }

        public int? VIPMoney { get; set; }
    }
}
