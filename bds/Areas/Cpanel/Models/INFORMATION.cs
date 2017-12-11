namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INFORMATION
    {
        [Key]
        public int InfoID { get; set; }

        [StringLength(150)]
        public string InfoContent { get; set; }

        [StringLength(10)]
        public string Code { get; set; }
    }
}
