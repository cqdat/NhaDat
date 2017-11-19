namespace bds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [Key]
        public int IdMenu { get; set; }

        [Required]
        [StringLength(200)]
        public string TenMenu { get; set; }

        public int? IdCha { get; set; }

        public int? ThuTu { get; set; }

        public int? HienThi { get; set; }

        public bool? IsMenu { get; set; }
    }
}
