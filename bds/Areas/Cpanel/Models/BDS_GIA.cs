namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_GIA
    {
        [Key]
        public int IdGia { get; set; }

        [StringLength(100)]
        public string TenGia { get; set; }

        public int? STT { get; set; }
    }
}
