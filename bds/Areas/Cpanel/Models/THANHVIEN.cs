namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHVIEN")]
    public partial class THANHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THANHVIEN()
        {
            BDS_MUABAN = new HashSet<BDS_MUABAN>();
            BDS_MUABAN1 = new HashSet<BDS_MUABAN>();
            BDS_TINTUC = new HashSet<BDS_TINTUC>();
            BDS_TINTUC1 = new HashSet<BDS_TINTUC>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTV { get; set; }

        [StringLength(20)]
        public string TenTruyCap { get; set; }

        [StringLength(200)]
        public string MatKhau { get; set; }

        [StringLength(200)]
        public string HoTen { get; set; }

        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDiDong { get; set; }

        [StringLength(100)]
        public string EmailLH { get; set; }

        public int? TinhTrang { get; set; }

        public int? VIP { get; set; }

        public DateTime? LanDangNhapCuoi { get; set; }

        public int? VIPMoney { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_MUABAN> BDS_MUABAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_MUABAN> BDS_MUABAN1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_TINTUC> BDS_TINTUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_TINTUC> BDS_TINTUC1 { get; set; }
    }
}
