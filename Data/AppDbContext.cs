using Microsoft.EntityFrameworkCore;
using BlazorServerApp.Models;

namespace BlazorServerApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // tbl_DM_Don_Vi_Tinh
        public DbSet<DonViTinh> DonViTinhs { get; set; }

        // tbl_DM_Loai_San_Pham
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        // tbl_DM_San_Pham
        public DbSet<SanPham> SanPhams { get; set; }

        // tbl_DM_Nha_Cung_Cap
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }

        // tbl_DM_Kho
        public DbSet<Kho> Khos { get; set; }

        // tbl_DM_Kho_User
        public DbSet<KhoUser> KhoUsers { get; set; }

        // tbl_DM_Nhap_Kho
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }

        // tbl_DM_Nhap_Kho_Raw_Data
        public DbSet<PhieuNhapRawData> PhieuNhapRawDatas { get; set; }

        // tbl_XNK_Nhap_Kho
        public DbSet<XnkPhieuNhap> XnkPhieuNhaps { get; set; }

        // tbl_DM_Xuat_Kho
        public DbSet<PhieuXuat> PhieuXuats { get; set; }

        // tbl_DM_Xuat_Kho_Raw_Data
        public DbSet<PhieuXuatRawData> PhieuXuatRawDatas { get; set; }

        // tbl_XNK_Xuat_Kho
        public DbSet<XnkPhieuXuat> XnkPhieuXuats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonViTinh>().ToTable("tbl_DM_Don_Vi_Tinh");

            modelBuilder.Entity<LoaiSanPham>().ToTable("tbl_DM_Loai_San_Pham");

            modelBuilder.Entity<SanPham>().ToTable("tbl_DM_San_Pham");

            modelBuilder.Entity<NhaCungCap>().ToTable("tbl_DM_Nha_Cung_Cap");

            modelBuilder.Entity<Kho>().ToTable("tbl_DM_Kho");

            modelBuilder.Entity<KhoUser>().ToTable("tbl_DM_Kho_User");

            modelBuilder.Entity<PhieuNhap>().ToTable("tbl_DM_Nhap_Kho");

            modelBuilder.Entity<PhieuNhapRawData>().ToTable("tbl_DM_Nhap_Kho_Raw_Data");

            modelBuilder.Entity<XnkPhieuNhap>().ToTable("tbl_XNK_Nhap_Kho");

            modelBuilder.Entity<PhieuXuat>().ToTable("tbl_DM_Xuat_Kho");

            modelBuilder.Entity<PhieuXuatRawData>().ToTable("tbl_DM_Xuat_Kho_Raw_Data");

            modelBuilder.Entity<XnkPhieuXuat>().ToTable("tbl_XNK_Xuat_Kho");

            // Đơn vị tính
            modelBuilder.Entity<DonViTinh>()
                .HasIndex(d => d.TenDonViTinh)
                .IsUnique();

            // Loại sản phẩm
            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(l => l.MaLoaiSanPham)
                .IsUnique();
            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(l => l.TenLoaiSanPham)
                .IsUnique();

            // Sản phẩm
            modelBuilder.Entity<SanPham>()
                .HasIndex(s => s.MaSanPham)
                .IsUnique();
            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.DonViTinh)
                .WithMany()
                .HasForeignKey(s => s.DonViTinhId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.LoaiSanPham)
                .WithMany()
                .HasForeignKey(s => s.LoaiSanPhamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Nhà cung cấp
            modelBuilder.Entity<NhaCungCap>()
                .HasIndex(n => n.MaNhaCungCap)
                .IsUnique();
            modelBuilder.Entity<NhaCungCap>()
                .HasIndex(n => n.TenNhaCungCap)
                .IsUnique();

            // Kho
            modelBuilder.Entity<Kho>()
                .HasIndex(k => k.TenKho)
                .IsUnique();

            // Kho user
            modelBuilder.Entity<KhoUser>()
                .HasIndex(k => new { k.MaDangNhap, k.KhoId })
                .IsUnique();
            modelBuilder.Entity<KhoUser>()
                .HasOne(k => k.Kho)
                .WithMany()
                .HasForeignKey(k => k.KhoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Phiếu Nhập
            modelBuilder.Entity<PhieuNhap>()
                .HasIndex(p => p.SoPhieuNhapKho)
                .IsUnique();
            modelBuilder.Entity<PhieuNhap>()
                .HasOne(p => p.Kho)
                .WithMany()
                .HasForeignKey(p => p.KhoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PhieuNhap>()
                .HasOne(p => p.NhaCungCap)
                .WithMany()
                .HasForeignKey(p => p.NhaCungCapId)
                .OnDelete(DeleteBehavior.Restrict);

            // Chi tiết Phiếu Nhập
            modelBuilder.Entity<PhieuNhapRawData>()
                .HasOne(p => p.PhieuNhap)
                .WithMany(p => p.ChiTietPhieuNhap)
                .HasForeignKey(p => p.NhapKhoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhieuNhapRawData>()
                .HasOne(p => p.SanPham)
                .WithMany(p => p.ChiTietPhieuNhap)
                .HasForeignKey(p => p.SanPhamId)
                .OnDelete(DeleteBehavior.Restrict);

            // XNK Phiếu Nhập
            modelBuilder.Entity<XnkPhieuNhap>()
                .HasIndex(x => x.SoPhieuNhapKho)
                .IsUnique();
            modelBuilder.Entity<XnkPhieuNhap>()
                .HasOne(x => x.Kho)
                .WithMany()
                .HasForeignKey(x => x.KhoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<XnkPhieuNhap>()
                .HasOne(x => x.NhaCungCap)
                .WithMany()
                .HasForeignKey(x => x.NhaCungCapId)
                .OnDelete(DeleteBehavior.Restrict);

            // Phiếu Xuất
            modelBuilder.Entity<PhieuXuat>()
                .HasIndex(p => p.SoPhieuXuatKho)
                .IsUnique();
            modelBuilder.Entity<PhieuXuat>()
                .HasOne(p => p.Kho)
                .WithMany()
                .HasForeignKey(p => p.KhoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Chi tiết Phiếu Xuất
            modelBuilder.Entity<PhieuXuatRawData>()
                .HasOne(p => p.PhieuXuat)
                .WithMany(p => p.ChiTietPhieuXuat)
                .HasForeignKey(p => p.XuatKhoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PhieuXuatRawData>()
                .HasOne(p => p.SanPham)
                .WithMany(p => p.ChiTietPhieuXuat)
                .HasForeignKey(p => p.SanPhamId)
                .OnDelete(DeleteBehavior.Restrict);

            // XNK Phiếu Xuất
            modelBuilder.Entity<XnkPhieuXuat>()
                .HasIndex(x => x.SoPhieuXuatKho)
                .IsUnique();
            modelBuilder.Entity<XnkPhieuXuat>()
                .HasOne(x => x.Kho)
                .WithMany()
                .HasForeignKey(x => x.KhoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
