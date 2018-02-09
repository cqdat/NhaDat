namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DUAN")]
    public partial class DUAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DUAN()
        {
            TABDUANs = new HashSet<TABDUAN>();
        }

        public int DUANID { get; set; }

        [StringLength(200)]
        public string DUANNAME { get; set; }

        [StringLength(200)]
        public string HINHANH { get; set; }

        public string MOTA { get; set; }

        public int? IDTINHTHANH { get; set; }

        public int? SOLANXEM { get; set; }

        public int? RATING { get; set; }

        public bool? DUYET { get; set; }

        [StringLength(200)]
        public string DIACHI { get; set; }

        public int? IDMENU { get; set; }

        [StringLength(50)]
        public string DIENTICH { get; set; }

        [StringLength(50)]
        public string MUCGIA { get; set; }

        public virtual MENU MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABDUAN> TABDUANs { get; set; }
    }
}
