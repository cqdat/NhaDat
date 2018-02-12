namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LIENHE_GOPY
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string TenLH { get; set; }

        [StringLength(20)]
        public string UsernameLH { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string EmailLH { get; set; }

        [StringLength(300)]
        public string TieuDe { get; set; }

        [StringLength(400)]
        public string NoiDung { get; set; }

        public int? TrangThai { get; set; }

        public string NoiDungTraLoi { get; set; }

        public DateTime? ThoiGianGui { get; set; }

        public DateTime? ThoiGianTraloi { get; set; }

        public int? HienThi { get; set; }
    }
}
