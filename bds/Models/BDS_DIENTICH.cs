namespace bds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_DIENTICH
    {
        [Key]
        public int IdDT { get; set; }

        [StringLength(100)]
        public string TenDT { get; set; }

        public int? STT { get; set; }
    }
}
