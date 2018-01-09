namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINHTHANH")]
    public partial class TINHTHANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINHTHANH()
        {
            BDS_MUABAN = new HashSet<BDS_MUABAN>();
            DUONGPHOes = new HashSet<DUONGPHO>();
        }

        [Key]
        public int IdTT { get; set; }

        [StringLength(100)]
        public string TenTT { get; set; }

        public int? IDCha { get; set; }

        public int? Cap { get; set; }

        public int? DemChoThue { get; set; }

        public int? DemMuaban { get; set; }

        public int? HienThi { get; set; } //HienThi

        public int? ThuTu { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_MUABAN> BDS_MUABAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DUONGPHO> DUONGPHOes { get; set; }
    }
}
