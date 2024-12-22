using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Service_PhongTro.Models
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DayTro> dayTro { get; set; }
        public DbSet<DichVu> dichVu { get; set; }
        public DbSet<DichVuSuDung> dichVuSuDung { get; set; }
        public DbSet<DienNuoc> dienNuoc { get; set; }
        public DbSet<HoaDon> hoaDon { get; set; }
        public DbSet<LoaiPhong> loaiPhong { get; set; }
        public DbSet<NguoiThue> nguoiThue { get; set; }
        public DbSet<Phong> phong { get; set; }
        public DbSet<TaiKhoan> taiKhoan { get; set; }
        public DbSet<TaiKhoanNguoiDung> taiKhoanNguoiDung { get; set; }
        public DbSet<ThongBao> thongBao { get; set; }
        public DbSet<ThuePhong> thuePhong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DayTro>(
             entity =>
             {
                 entity.Property(m => m.tenDayTro).IsRequired().HasMaxLength(100).IsUnicode(true);
                 entity.Property(m => m.soLuongPhong).IsRequired();
             });

            modelBuilder.Entity<DichVu>(
             entity =>
             {
                 entity.Property(m => m.tenDichVu).IsRequired().HasMaxLength(100).IsUnicode(true);
                 entity.Property(m => m.giaDichVu).IsRequired();
             });

            modelBuilder.Entity<DichVuSuDung>(
             entity =>
             {
                 entity.HasKey(m => new {m.IDDichVu, m.IDPhong });
                 entity.HasOne(m => m.phong)
                       .WithMany(b => b.dichVuSuDung)
                       .HasForeignKey(c => c.IDPhong)
                       .HasConstraintName("FK_DichVuSuDung_Phong");
                 entity.HasOne(d => d.dichVu)
                    .WithMany(b => b.dichVuSuDung)
                    .HasForeignKey(d => d.IDDichVu)
                    .HasConstraintName("FK_DichVuSuDung_DichVu");

             });

            modelBuilder.Entity<DienNuoc>(
             entity =>
             {
                 entity.Property(e => e.thoiGianHoaDon)
                    .IsRequired();
                 entity.Property(e => e.dienTieuThu)
                     .IsRequired();
                 entity.Property(e => e.giaDien)
                     .IsRequired();
                 entity.Property(e => e.nuocTieuThu)
                     .IsRequired();
                 entity.Property(e => e.giaNuoc)
                     .IsRequired();
                 entity.HasOne(d => d.phong)
                     .WithMany(b => b.dienNuoc)
                     .HasForeignKey(d => d.IDPhong)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_DienNuoc_Phong");
             });

            modelBuilder.Entity<HoaDon>(
             entity =>
             {
                 entity.Property(e => e.ngayThanhToan)
                    .IsRequired();
                 entity.Property(e => e.soTienThanhToan)
                     .IsRequired();
                 entity.Property(e => e.trangThai)
                     .IsRequired();
                 entity.Property(e => e.CMND_CCCD)
                     .IsRequired();
                 entity.Property(e => e.tenPhong)
                     .IsUnicode(true)
                     .IsRequired();
                 entity.Property(e => e.loaiPhong)
                     .IsUnicode(true)
                     .IsRequired();
                 entity.Property(e => e.giaPhong)
                     .IsRequired();
                 entity.Property(e => e.dienTieuThu)
                     .IsRequired();
                 entity.Property(e => e.giaDien)
                     .IsRequired();
                 entity.Property(e => e.nuocTieuThu)
                     .IsRequired();
                 entity.Property(e => e.giaNuoc)
                     .IsRequired();
                 entity.Property(e => e.DSdichVuSuDung)
                     .HasMaxLength(500)
                     .IsUnicode(true)
                     .IsRequired();
                 entity.Property(e => e.DSGiaDichVuSuDung)
                     .HasMaxLength(500)
                     .IsRequired();
                 entity.HasOne(d => d.thuePhong)
                     .WithMany(b => b.hoaDon)
                     .HasForeignKey(d => d.IDThuePhong)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_HoaDon_ThuePhong"); 
             });

            modelBuilder.Entity<LoaiPhong>(
             entity =>
             {
                 entity.Property(e => e.tenLoaiPhong)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(true);
                 entity.Property(e => e.gia)
                     .IsRequired();
                 entity.Property(e => e.soNguoi)
                     .IsRequired();
             });

            modelBuilder.Entity<NguoiThue>(
             entity =>
             {
                 entity.Property(e => e.hoTen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(true);
                 entity.Property(e => e.gioiTinh)
                     .IsRequired();
                 entity.Property(e => e.SDT)
                     .IsRequired();
                 entity.Property(e => e.queQuan)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(true);
                 entity.Property(e => e.ngaySinh)
                     .IsRequired();
                 entity.Property(e => e.CMND_CCCD)
                     .IsRequired()
                     .HasMaxLength(100);
                 entity.Property(e => e.Email)
                     .IsRequired()
                     .HasMaxLength(100);
                 entity.Property(e => e.anhDaiDien)
                     .IsRequired()
                     .IsUnicode(true)
                     .HasMaxLength(100);
                 entity.Property(e => e.matTruocCCCD)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(true);
                 entity.Property(e => e.matSauCMND)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(true);
             });

            modelBuilder.Entity<Phong>(
             entity =>
             {
                 entity.Property(e => e.tenPhong)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(true);
                 entity.Property(e => e.conPhong)
                     .IsRequired();
                 entity.Property(e => e.SoNguoiDangO)
                     .IsRequired();
                 entity.HasOne(d => d.dayTro)
                     .WithMany(b => b.phong)
                     .HasForeignKey(d => d.IDDayTro)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Phong_DayTro");
                 entity.HasOne(d => d.loaiPhong)
                     .WithMany(b => b.phong)
                     .HasForeignKey(d => d.IDLoaiPhong)
                     .HasConstraintName("FK_Phong_LoaiPhong");
             });

            modelBuilder.Entity<TaiKhoan>(
             entity =>
             {
                 entity.Property(e => e.taiKhoan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                 entity.Property(e => e.matKhau)
                     .IsRequired()
                     .HasMaxLength(50)
                     .IsUnicode(false);
             });

            modelBuilder.Entity<TaiKhoanNguoiDung>(
             entity =>
             {
                 entity.Property(e => e.CMND_CCCD)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(true);
                 entity.Property(e => e.matKhau)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(true);
             });

            modelBuilder.Entity<ThongBao>(
             entity =>
             {
                 entity.Property(e => e.tieuDe)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(true);
                 entity.Property(e => e.ngayDang)
                     .IsRequired();
                 entity.Property(e => e.moTa)
                     .IsRequired()
                     .IsUnicode(true);
             });

            modelBuilder.Entity<ThuePhong>(
             entity =>
             {
                 entity.Property(e => e.ngayThue)
                    .IsRequired();
                 entity.Property(e => e.ngayTra)
                     .IsRequired();
                 entity.Property(e => e.tienCoc)
                     .IsRequired();
                 entity.HasOne(d => d.nguoiThue)
                     .WithMany(b => b.thuePhong)
                     .HasForeignKey(d => d.IDNguoiThue)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_ThuePhong_NguoiThue");
                 entity.HasOne(d => d.phong)
                     .WithMany(b => b.thuePhong)
                     .HasForeignKey(d => d.IDPhong)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_ThuePhong_Phong");
             });
        }

    }
}
