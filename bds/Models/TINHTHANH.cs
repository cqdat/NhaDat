namespace bds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINHTHANH")]
    public partial class TINHTHANH
    {
        [Key]
        public int IdTT { get; set; }

        [StringLength(100)]
        public string TenTT { get; set; }

        public int? IDCha { get; set; }

        public int? Cap { get; set; }
    }
}
