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
            BDS_MuaBan = new HashSet<BDS_MuaBan>();
            BDS_MuaBan1 = new HashSet<BDS_MuaBan>();
            BDS_TinTuc = new HashSet<BDS_TinTuc>();
            BDS_TinTuc1 = new HashSet<BDS_TinTuc>();
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
        public virtual ICollection<BDS_MuaBan> BDS_MuaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_MuaBan> BDS_MuaBan1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_TinTuc> BDS_TinTuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_TinTuc> BDS_TinTuc1 { get; set; }
    }
}
