//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TINHTHANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINHTHANH()
        {
            this.BDS_MuaBan = new HashSet<BDS_MuaBan>();
        }
    
        public int IdTT { get; set; }
        public string TenTT { get; set; }
        public Nullable<int> IDCha { get; set; }
        public Nullable<int> Cap { get; set; }
        public Nullable<int> DemChoThue { get; set; }
        public Nullable<int> DemMuaban { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDS_MuaBan> BDS_MuaBan { get; set; }
    }
}
