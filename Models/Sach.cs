using System;
using System.ComponentModel.DataAnnotations;  // Để dùng [Key], [Required], [MaxLength]...
using System.ComponentModel.DataAnnotations.Schema;  // Để dùng [Column] nếu cần

namespace WebApplication1.Models
{
    public class Sach
    {
        [Key]  // Đánh dấu đây là Primary Key
        public int Ma_sach { get; set; }  

        [Required]                       // Bắt buộc NOT NULL
        [StringLength(200)]              // VARCHAR(200) hoặc NVARCHAR(200)
        public string Ten_Sach { get; set; } = null!;

        [StringLength(20)]               // FK đến TacGia.Ma_TG
        public string? TG { get; set; }   // Có thể null nếu sách không bắt buộc có tác giả

        [StringLength(20)]               // FK đến TheLoai.Ma_TLoai
        public string? TLoai { get; set; }  // Đổi tên cho khớp script SQL (Ma_TLoai thay vì Ma_TL)

        [StringLength(20)]               // FK đến NhaXuatBan nếu có
        public string? NXB { get; set; }
        public string? img { get; set; }
        public DateOnly? Nam_XB { get; set; }  // Năm xuất bản, có thể null
     
        public int? Don_gia { get; set; }  // Dùng decimal thay vì double cho tiền tệ

        public int? Gia_Ban { get; set; }
        [NotMapped]
        public int Percent
        {
            get
            {
                if (!Don_gia.HasValue || !Gia_Ban.HasValue)
                    return 0;

                if (Don_gia <= 0 || Gia_Ban >= Don_gia)
                    return 0;

                double percent = (double)(Don_gia.Value - Gia_Ban.Value) * 100 / Don_gia.Value;
                return (int)Math.Round(percent, MidpointRounding.AwayFromZero);
            }
        }



    }
}