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
        public int TABDUANID { get; set; }

        [StringLength(100)]
        public string TABNAME { get; set; }

        public string TABCONTENT { get; set; }

        public int? IDDUAN { get; set; }

        public virtual DUAN DUAN { get; set; }
    }
}
