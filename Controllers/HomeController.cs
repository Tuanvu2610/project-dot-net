using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
            public async Task<IActionResult> Index()
            {
                if (_context == null)
                {
                    return Content("Lỗi: AppDbContext chưa được inject!");
                }
                var sach = await _context.Sach
                    .OrderByDescending(p => p.Ma_sach)
                    .ToListAsync();
                var categories = await _context.category.ToListAsync();
                var menu = categories.ToLookup(c => c.parent_id ?? 0);
                ViewBag.Sachs = sach;
                ViewBag.Categories = menu;

                return View();
            }
    }
}
