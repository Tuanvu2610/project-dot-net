namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }       // Tên dụng cụ
        public string Brand { get; set; }      // Hãng (Deli, Pentel...)
        public double Price { get; set; }      // Giá tiền
        public string ImageUrl { get; set; }   // Link ảnh
        public string Category { get; set; }   // Loại (Màu, Bút...)
        public string Description { get; set; } // Mô tả chi tiết
    }
}
