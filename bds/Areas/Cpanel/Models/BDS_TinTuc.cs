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
    
    public partial class BDS_TINTUC
    {
        public int TinTucID { get; set; }
        public string TintucName { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> IDMenu { get; set; }
        public Nullable<bool> NoiBat { get; set; }
        public Nullable<bool> NhieuNguoiDoc { get; set; }
        public Nullable<int> CountView { get; set; }
        public Nullable<bool> HotIcon { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> Visible { get; set; }
        public string URL { get; set; }
    
        public virtual MENU MENU { get; set; }
        public virtual THANHVIEN THANHVIEN { get; set; }
        public virtual THANHVIEN THANHVIEN1 { get; set; }
    }
}
