namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_LOAIBDS
    {
        [Key]
        public int IDBDS { get; set; }

        public int? THUTU { get; set; }

        [StringLength(1000)]
        public string TENBDS { get; set; }

        public int? HIENTHI { get; set; }

        public int? HIEULUC { get; set; }
    }
}
