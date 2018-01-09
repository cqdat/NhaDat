namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TABDUAN")]
    public partial class TABDUAN
    {
        [Key]
        public int IDTABDUAN { get; set; }

        [StringLength(200)]
        public string NAMETAB { get; set; }

        public string CONTENTTAB { get; set; }

        public int? THUTU { get; set; }

        public bool? HIENTHI { get; set; }
    }
}
