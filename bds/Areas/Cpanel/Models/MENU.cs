namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENU()
        {
            BDS_MuaBan = new HashSet<BDS_MuaBan>();
            BDS_TinTuc = new HashSet<BDS_TinTuc>();
        }

        [Key]
        public int IdMenu { get; set; }

        [Required]
        [StringLength(200)]
        public string TenMenu { get; set; }

        public int? IdCha { get; set; }

        public int? ThuTu { get; set; }

        public int? HienThi { get; set; }

        public bool? IsMenu { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        public int? Cap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_MuaBan> BDS_MuaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_TinTuc> BDS_TinTuc { get; set; }
    }
}
