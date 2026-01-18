using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Bộ màu nước Deli 24 màu", Brand = "Deli", Price = 120000, Category = "Màu vẽ", ImageUrl = "https://bookbuy.vn/Res/Images/Product/135315_mau-nuoc-mat-water-colors-5ml-bo-24-mau_109166_1.jpg", Description = "Màu nước dạng nén xịn xò, kèm cọ nước." },
            new Product { Id = 2, Name = "Bút chì kỹ thuật HB", Brand = "Pentel", Price = 25000, Category = "Bút vẽ", ImageUrl = "https://bizweb.dktcdn.net/thumb/1024x1024/100/414/082/products/but-chi-go-pentel-hb.jpg", Description = "Bút chì gỗ cao cấp, ngòi chắc, không gãy." },
            new Product { Id = 3, Name = "Cọ vẽ đầu tròn số 5", Brand = "Colormate", Price = 15000, Category = "Cọ vẽ", ImageUrl = "https://salt.tikicdn.com/cache/w1200/ts/product/9a/32/38/2006e80b674d80848030218151322197.jpg", Description = "Lông cọ mềm mượt, ngậm nước tốt." },
            new Product { Id = 4, Name = "Giá vẽ gỗ để bàn", Brand = "Handmade", Price = 150000, Category = "Dụng cụ", ImageUrl = "https://bizweb.dktcdn.net/100/343/208/products/gia-ve-de-ban-min.jpg", Description = "Giá vẽ gỗ thông gọn nhẹ, chỉnh được độ nghiêng." },
             new Product { Id = 5, Name = "Sổ Phác Thảo A4", Brand = "Klong", Price = 50000, Category = "Giấy vẽ", ImageUrl = "https://down-vn.img.susercontent.com/file/18329681023c6838df2502213768393e", Description = "Giấy định lượng 100gsm, chuyên dùng sketch." }
        };
        //trang danh sách
        public IActionResult DanhSach()
        {
            return View(products);
        }
        public IActionResult DSSachTruyen()
        {
            return View(products);
        }
        public IActionResult DSSachGiaoKhoa()
        {
            return View(products);
        }
    }
}