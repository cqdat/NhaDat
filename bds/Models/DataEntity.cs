namespace bds.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataEntity : DbContext
    {
        public DataEntity()
            : base("name=DataEntity")
        {
        }

        public virtual DbSet<BDS_DIENTICH> BDS_DIENTICH { get; set; }
        public virtual DbSet<BDS_DM_GIAODICH> BDS_DM_GIAODICH { get; set; }
        public virtual DbSet<BDS_GIA> BDS_GIA { get; set; }
        public virtual DbSet<BDS_HUONGNHA> BDS_HUONGNHA { get; set; }
        public virtual DbSet<BDS_LOAIBDS> BDS_LOAIBDS { get; set; }
        public virtual DbSet<DUAN> DUANs { get; set; }
        public virtual DbSet<DUAN_HINH> DUAN_HINH { get; set; }
        public virtual DbSet<DUAN_LOAI> DUAN_LOAI { get; set; }
        public virtual DbSet<GIOITHIEU> GIOITHIEUx { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<TINHTHANH> TINHTHANHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DUAN>()
                .Property(e => e.IDTT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DUAN_HINH>()
                .Property(e => e.IDTT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.TenTruyCap)
                .IsUnicode(false);
        }
    }
}
