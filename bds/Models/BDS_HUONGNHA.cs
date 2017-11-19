namespace bds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_HUONGNHA
    {
        [Key]
        public int IdHuongNha { get; set; }

        [StringLength(50)]
        public string TenHuongNha { get; set; }

        public int? STT { get; set; }
    }
}
