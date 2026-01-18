using System.ComponentModel.DataAnnotations;  // Để dùng [Key], [Required], [MaxLength]...
using System.ComponentModel.DataAnnotations.Schema;  // Để dùng [Column] nếu cần

namespace WebApplication1.Models
{
    public class Sach
    {
        [Key]  // Đánh dấu đây là Primary Key
        [Column(TypeName = "char(20)")]  // Khớp kiểu CHAR(20) trong SQL
        [StringLength(20)]               // Giới hạn độ dài
        public string Ma_sach { get; set; } = null!;  // null! để tránh warning nullable

        [Required]                       // Bắt buộc NOT NULL
        [StringLength(200)]              // VARCHAR(200) hoặc NVARCHAR(200)
        public string Ten_Sach { get; set; } = null!;

        [StringLength(20)]               // FK đến TacGia.Ma_TG
        public string? Ma_TG { get; set; }   // Có thể null nếu sách không bắt buộc có tác giả

        [StringLength(20)]               // FK đến TheLoai.Ma_TLoai
        public string? Ma_TLoai { get; set; }  // Đổi tên cho khớp script SQL (Ma_TLoai thay vì Ma_TL)

        [StringLength(20)]               // FK đến NhaXuatBan nếu có
        public string? Ma_NXB { get; set; }

        public DateOnly? Nam_XB { get; set; }  // Năm xuất bản, có thể null

        //[Column(TypeName = "money")]     // Hoặc decimal(18,2) cho giá tiền chính xác
        //public int Don_gia { get; set; }  // Dùng decimal thay vì double cho tiền tệ

        // Navigation properties (nếu muốn load liên quan)
        //public virtual TacGia? TacGia { get; set; }          // Quan hệ 1 sách - 1 tác giả
        //public virtual TheLoai? TheLoai { get; set; }        // Quan hệ 1 sách - 1 thể loại
        //public virtual ICollection<CT_HoaDon>? CT_HoaDons { get; set; }  // Danh sách chi tiết hóa đơn
        //public virtual Kho? Kho { get; set; }                // Quan hệ 1-1 với kho
    }
}