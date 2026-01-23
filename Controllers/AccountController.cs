using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Models;
using WebApplication1.Data;
using WebApplication1.Models;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            ViewBag.ActiveModal = "login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                ViewBag.ActiveModal = "login";
                return View();
            }

            var acc = _context.Accounts
                .Include(a => a.User)
                .FirstOrDefault(a =>
                    a.Username == username &&
                    a.Password == password &&
                    a.Status == "active"
                );

            if (acc == null || acc.Password != password)
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";
                ViewBag.ActiveModal = "login";
                return View();
            }

            HttpContext.Session.SetString("USERNAME", acc.Username);
            HttpContext.Session.SetString("ROLE", acc.Role);
            HttpContext.Session.SetInt32("USERID", acc.UserId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Register(AccountModel.RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorRegister = "Dữ liệu không hợp lệ";
                ViewBag.ActiveModal = "register";
                return View("Login");
            }

            if (_context.Accounts.Any(a => a.Username == model.Username))
            {
                ViewBag.ErrorRegister = "Tên đăng nhập đã tồn tại";
                ViewBag.ActiveModal = "register";
                return View("Login");
            }

            var u = new User
            {
                Name = model.Name,
                Email = model.Email
            };
            _context.Users.Add(u);
            _context.SaveChanges();

            var acc = new Account
            {
                UserId = u.Id,
                Username = model.Username,
                Password = model.Password,
                Role = "user",
                Status = "active"
            };

            //dang ky thanh cong
            _context.Accounts.Add(acc);
            _context.SaveChanges();
            ViewBag.Success = "Đăng ký thành công! Vui lòng đăng nhập.";
            ViewBag.ActiveModal = "login";
            return View("Login");
        }

        [HttpPost]
        public IActionResult Forgot(AccountModel.ForgotModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorForgot = "Vui lòng nhập email";
                ViewBag.ActiveModal = "forgot";
                return View("Login");
            }

            var acc = _context.Accounts
                .Include(a => a.User)
                .FirstOrDefault(a => a.User.Email == model.Email);

            if (acc == null)
            {
                ViewBag.ErrorForgot = "Email không tồn tại";
                ViewBag.ActiveModal = "forgot";
                return View("Login");
            }

            //tao otp
            var otp = new Random().Next(100000, 999999).ToString();

            var reset = new ResetPassword
            {
                AccountId = acc.Id,
                Email = model.Email,
                Otp = otp,
                ExpiredAt = DateTime.Now.AddMinutes(5),
                IsUsed = false,
                CreatedAt = DateTime.Now
            };

            //reset pass thanh cong
            _context.ResetPasswords.Add(reset);
            _context.SaveChanges();
            ViewBag.Otp = otp;
            ViewBag.Email = model.Email;
            ViewBag.Step = "otp";
            ViewBag.ActiveModal = "forgot";
            return View("Login");
        }

        [HttpPost]
        public IActionResult Verify(AccountModel.VerifyModel model)
        {
            var reset = _context.ResetPasswords
                .Include(r => r.Account)
                .ThenInclude(a => a.User)
                .FirstOrDefault(r =>
                    r.Email == model.Email &&
                    r.Otp == model.Otp &&
                    r.IsUsed == false &&
                    r.ExpiredAt > DateTime.Now
                );

            if (reset == null)
            {
                ViewBag.ErrorOtp = "OTP không đúng hoặc đã hết hạn";
                ViewBag.Email = model.Email;
                ViewBag.ActiveModal = "forgot";
                return View("Login");
            }

            ViewBag.Email = model.Email;
            ViewBag.ActiveModal = "forgot";
            ViewBag.Step = "reset";
            return View("Login");
        }

        [HttpPost]
        public IActionResult Reset(AccountModel.ResetModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorReset = "Mật khẩu xác nhận không khớp";
                ViewBag.ActiveModal = "forgot";
                ViewBag.Email = model.Email;
                return View("Login");
            }

            var reset = _context.ResetPasswords
                .Include(r => r.Account)
                .FirstOrDefault(r =>
                    r.Email == model.Email &&
                    r.IsUsed == false &&
                    r.ExpiredAt > DateTime.Now
                );

            //update pass
            reset.Account.Password = model.NewPassword;
            reset.IsUsed = true;
            _context.SaveChanges();
            ViewBag.SuccessReset = "Đổi mật khẩu thành công! Vui lòng đăng nhập.";
            ViewBag.ActiveModal = "login";
            return View("Login");
        }
    }
}
