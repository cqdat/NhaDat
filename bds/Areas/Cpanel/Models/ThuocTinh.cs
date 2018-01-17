namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOCTINH")]
    public partial class THUOCTINH
    {
        public int ThuocTinhID { get; set; }

        [StringLength(150)]
        public string ThuocTinhName { get; set; }

        public int? Type { get; set; }
    }
}
