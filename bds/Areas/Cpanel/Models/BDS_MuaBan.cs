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
    
    public partial class BDS_MuaBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BDS_MuaBan()
        {
            this.PropertyMuaBans = new HashSet<PropertyMuaBan>();
        }
    
        public int IDMuaBan { get; set; }
        public string Name { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> IDMenu { get; set; }
        public Nullable<bool> NoiBat { get; set; }
        public Nullable<int> CountView { get; set; }
        public Nullable<bool> HotIcon { get; set; }
        public string Gia { get; set; }
        public string DienTich { get; set; }
        public string DiaChi { get; set; }
        public string MapPoint { get; set; }
        public Nullable<int> PropertyID { get; set; }
        public bool Type { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> IsVip { get; set; }
        public Nullable<bool> Visible { get; set; }
        public Nullable<int> Rating { get; set; }
        public string URL { get; set; }
        public Nullable<int> IDTinhThanh { get; set; }
        public string KichThuoc { get; set; }
    
        public virtual THANHVIEN THANHVIEN { get; set; }
        public virtual MENU MENU { get; set; }
        public virtual THANHVIEN THANHVIEN1 { get; set; }
        public virtual TINHTHANH TINHTHANH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyMuaBan> PropertyMuaBans { get; set; }
    }
}
