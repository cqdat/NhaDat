﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_BDSEntitiesAdmin : DbContext
    {
        public DB_BDSEntitiesAdmin()
            : base("name=DB_BDSEntitiesAdmin")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BDS_DIENTICH> BDS_DIENTICH { get; set; }
        public virtual DbSet<BDS_DM_GIAODICH> BDS_DM_GIAODICH { get; set; }
        public virtual DbSet<BDS_GIA> BDS_GIA { get; set; }
        public virtual DbSet<BDS_HUONGNHA> BDS_HUONGNHA { get; set; }
        public virtual DbSet<BDS_LOAIBDS> BDS_LOAIBDS { get; set; }
        public virtual DbSet<BDS_MuaBan> BDS_MuaBan { get; set; }
        public virtual DbSet<BDS_TinTuc> BDS_TinTuc { get; set; }
        public virtual DbSet<DUAN> DUANs { get; set; }
        public virtual DbSet<DUAN_HINH> DUAN_HINH { get; set; }
        public virtual DbSet<DUAN_LOAI> DUAN_LOAI { get; set; }
        public virtual DbSet<GIOITHIEU> GIOITHIEUx { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<TINHTHANH> TINHTHANHs { get; set; }
        public virtual DbSet<BDS_MuaBan> BDS_MuaBan { get; set; }
        public virtual DbSet<BDS_TinTuc> BDS_TinTuc { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyMuaBan> PropertyMuaBans { get; set; }
    }
}
