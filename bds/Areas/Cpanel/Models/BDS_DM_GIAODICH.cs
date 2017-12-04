namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDS_DM_GIAODICH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDM { get; set; }

        [StringLength(50)]
        public string TenDMGiaoDich { get; set; }

        public int? STT { get; set; }
    }
}
