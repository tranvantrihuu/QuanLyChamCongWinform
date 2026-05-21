using Microsoft.EntityFrameworkCore;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace QuanLyChamCong.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options
        ) : base(options)
        {

        }

        // =========================
        // TABLES
        // =========================
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<CaLam> CaLams { get; set; }
        public DbSet<PhanCa> PhanCas { get; set; }
        public DbSet<ChamCong> ChamCongs { get; set; }
        public DbSet<NghiPhep> NghiPheps { get; set; }
        public DbSet<NghiPhepNam> NghiPhepNams { get; set; }
        public DbSet<ThuongPhat> ThuongPhats { get; set; }
        public DbSet<CauHinhLuong> CauHinhLuongs { get; set; }
        public DbSet<BangLuongChot> BangLuongChots { get; set; }
        public DbSet<VwDanhSachPhanCa> VwDanhSachPhanCas { get; set; }
        public DbSet<VwBaoCaoChamCong> VwBaoCaoChamCongs { get; set; }
        public DbSet<VwDanhSachChamCong> VwDanhSachChamCongs { get; set; }
        public DbSet<VwDanhSachNghiPhep> VwDanhSachNghiPheps { get; set; }
        public DbSet<VwDanhSachThuongPhat> VwDanhSachThuongPhats { get; set; }
        public DbSet<VwDanhSachCauHinhLuong> VwDanhSachCauHinhLuongs { get; set; }
        public DbSet<VwBangLuongChot> VwBangLuongChots { get; set; }
        public DbSet<VwChiTietBangLuong> VwChiTietBangLuongs { get; set; }
        public DbSet<VwDanhSachCaLam> VwDanhSachCaLams { get; set; }
        public DbSet<VwBangLuongRealtime>VwBangLuongRealtime{get;set; }
        // =========================
        // MODEL CONFIG
        // =========================

        protected override void OnModelCreating(
            ModelBuilder modelBuilder
        )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NhanVien>(
                entity =>
                {
                    entity.ToTable("nhan_vien");

                    entity.HasKey(x => x.id);

                    entity.Property(x => x.id)
                        .HasMaxLength(20);

                    entity.Property(x => x.ma_van_tay)
                        .HasMaxLength(50);

                    entity.Property(x => x.ho_ten)
                        .HasMaxLength(255);

                    entity.Property(x => x.so_dien_thoai)
                        .HasMaxLength(20);

                    entity.Property(x => x.dia_chi)
                        .HasMaxLength(500);

                    entity.Property(x => x.vi_tri)
                        .HasMaxLength(100);

                    entity.Property(x => x.vai_tro)
                        .HasMaxLength(50);

                    entity.Property(x => x.trang_thai)
                        .HasMaxLength(50);

                    entity.Property(x => x.pin_code)
                        .HasMaxLength(10);

                    entity.Property(x => x.loai_luong)
                        .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<CaLam>(
                entity =>
                {
                    entity.ToTable("ca_lam");

                    entity.HasKey(x => x.id);

                    entity.Property(x => x.ten_ca)
                        .HasMaxLength(100);
                }
            );

            modelBuilder.Entity<PhanCa>(
                entity =>
                {
                    entity.ToTable("phan_ca");

                    entity.HasKey(x => x.id);

                    entity.Property(x => x.nhan_vien_id)
                        .HasMaxLength(20);
                }
            );
            modelBuilder.Entity<NghiPhepNam>(
                entity =>
                {
                    entity.ToTable("nghi_phep_nam");

                    entity.HasKey(x => x.id);

                    entity.Property(x => x.nhan_vien_id)
                        .HasMaxLength(20);

                    entity.Property(x => x.ho_ten)
                        .HasMaxLength(255);
                }
            );
            
            modelBuilder
                .Entity<VwDanhSachCauHinhLuong>()
                .HasNoKey()
                .ToView("vw_danh_sach_cau_hinh_luong");

            modelBuilder
                .Entity<VwBaoCaoChamCong>()
                .ToView("vw_bao_cao_cham_cong")
                .HasNoKey();
            modelBuilder.Entity<VwDanhSachChamCong>()
                .HasNoKey();
            modelBuilder.Entity<VwDanhSachChamCong>()
                .ToView(
                    "vw_danh_sach_cham_cong"
                );
            modelBuilder
                .Entity<VwDanhSachNghiPhep>()
                .ToView("vw_danh_sach_nghi_phep")
                .HasNoKey();
            modelBuilder
                .Entity<VwDanhSachThuongPhat>()
                .ToView("vw_danh_sach_thuong_phat")
                .HasNoKey();
            modelBuilder
                .Entity<VwBangLuongChot>()
                .ToView("vw_bang_luong_chot")
                .HasNoKey();

            modelBuilder
                .Entity<VwChiTietBangLuong>()
                .ToView("vw_chi_tiet_bang_luong")
                .HasNoKey();
            modelBuilder
                .Entity<VwDanhSachPhanCa>()
                .HasNoKey()
                .ToView("vw_danh_sach_phan_ca");
            modelBuilder
                .Entity<VwBangLuongRealtime>()
                .HasNoKey();
        }

    }
}
