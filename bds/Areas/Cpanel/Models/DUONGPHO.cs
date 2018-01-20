namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DUONGPHO")]
    public partial class DUONGPHO
    {
        [Key]
        public int IDDP { get; set; }

        [StringLength(100)]
        public string TenTT { get; set; }

        public int? IDTT { get; set; }

        public int? Cap { get; set; }

        public int? DemChoThue { get; set; }

        public int? DemMuaban { get; set; }

        public int? ThuTu { get; set; }

        [StringLength(200)]
        public string url { get; set; }
    }
}
