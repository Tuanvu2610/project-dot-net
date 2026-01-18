using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Các DbSet chính - đặt tên plural (số nhiều) theo convention EF Core
        public DbSet<Sach> Sach { get; set; }
        public DbSet<Category> category { get; set; }

        //public DbSet<Kho> Khos { get; set; }
        //public DbSet<HoaDon> HoaDons { get; set; }
        //public DbSet<CT_HoaDon> CT_HoaDons { get; set; }
        //public DbSet<KhachHang> KhachHangs { get; set; }
        //public DbSet<NhanVien> NhanViens { get; set; }
        //public DbSet<TacGia> TacGias { get; set; }
        //public DbSet<TheLoai> TheLoais { get; set; }
        //public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        //public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        //public DbSet<CT_PhieuNhap> CT_PhieuNhaps { get; set; }

        // Nếu có bảng phụ khác (ví dụ SachKhuyenMai, ThongBao, Log,...)
        // public DbSet<SachKhuyenMai> SachKhuyenMais { get; set; }
        // public DbSet<ThongBao> ThongBaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config primary key và các ràng buộc (nếu cần)
            modelBuilder.Entity<Sach>().HasKey(s => s.Ma_sach);
            modelBuilder.Entity<Category>().HasKey(s => s.category_id);
            //modelBuilder.Entity<Kho>().HasKey(k => k.Ma_sach);
            //modelBuilder.Entity<HoaDon>().HasKey(h => h.Ma_HD);
            //modelBuilder.Entity<CT_HoaDon>().HasKey(ct => new { ct.Ma_HD, ct.Ma_sach }); // composite key
            //modelBuilder.Entity<KhachHang>().HasKey(kh => kh.Ma_KH);
            //modelBuilder.Entity<NhanVien>().HasKey(nv => nv.Ma_NV);
            //modelBuilder.Entity<TacGia>().HasKey(tg => tg.Ma_TG);
            //modelBuilder.Entity<TheLoai>().HasKey(tl => tl.Ma_TLoai);
            //modelBuilder.Entity<NhaCungCap>().HasKey(ncc => ncc.Ma_NCC);
            //modelBuilder.Entity<PhieuNhap>().HasKey(pn => pn.Ma_PN);
            //modelBuilder.Entity<CT_PhieuNhap>().HasKey(ctpn => new { ctpn.Ma_PN, ctpn.Ma_sach });

            //// Config relationship (ví dụ)
            //modelBuilder.Entity<Sach>()
            //    .HasOne(s => s.TacGia)
            //    .WithMany(tg => tg.Sachs)
            //    .HasForeignKey(s => s.Ma_TG);

            //modelBuilder.Entity<Sach>()
            //    .HasOne(s => s.TheLoai)
            //    .WithMany(tl => tl.Sachs)
            //    .HasForeignKey(s => s.Ma_TLoai);

            //modelBuilder.Entity<CT_HoaDon>()
            //    .HasOne(ct => ct.HoaDon)
            //    .WithMany(hd => hd.CT_HoaDons)
            //    .HasForeignKey(ct => ct.Ma_HD);

            //modelBuilder.Entity<CT_HoaDon>()
            //    .HasOne(ct => ct.Sach)
            //    .WithMany(s => s.CT_HoaDons)
            //    .HasForeignKey(ct => ct.Ma_sach);

        }
    }
}