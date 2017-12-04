namespace bds.Areas.Cpanel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_BDSEntitiesAdmin : DbContext
    {
        public DB_BDSEntitiesAdmin()
            : base("name=DB_BDSEntitiesAdmin")
        {
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
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<ThuocTinh> ThuocTinhs { get; set; }
        public virtual DbSet<TINHTHANH> TINHTHANHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BDS_MuaBan>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<BDS_MuaBan>()
                .Property(e => e.MapPoint)
                .IsUnicode(false);

            modelBuilder.Entity<BDS_MuaBan>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<BDS_TinTuc>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<BDS_TinTuc>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<DUAN>()
                .Property(e => e.IDTT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DUAN_HINH>()
                .Property(e => e.IDTT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MENU>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.TenTruyCap)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.BDS_MuaBan)
                .WithOptional(e => e.THANHVIEN)
                .HasForeignKey(e => e.UpdateBy);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.BDS_MuaBan1)
                .WithOptional(e => e.THANHVIEN1)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.BDS_TinTuc)
                .WithOptional(e => e.THANHVIEN)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.BDS_TinTuc1)
                .WithOptional(e => e.THANHVIEN1)
                .HasForeignKey(e => e.UpdateBy);

            modelBuilder.Entity<TINHTHANH>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<TINHTHANH>()
                .HasMany(e => e.BDS_MuaBan)
                .WithOptional(e => e.TINHTHANH)
                .HasForeignKey(e => e.IDTinhThanh);
        }
    }
}
