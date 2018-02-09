namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HINHANH")]
    public partial class HINHANH
    {
        public int HINHANHID { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }

        [StringLength(200)]
        public string THUMBNAIL { get; set; }

        [StringLength(200)]
        public string IMAGEURL { get; set; }

        public int? IDLIENKET { get; set; }

        public int? LOAI { get; set; }
    }
}
