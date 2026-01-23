using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AccountModel
    {
        public class LoginModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public class RegisterModel
        {
            [Required(ErrorMessage = "Vui lòng nhập họ tên")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập email")]
            [EmailAddress(ErrorMessage = "Email không hợp lệ")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
            public string ConfirmPassword { get; set; }
        }

        public class ForgotModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public class VerifyModel
        {
            public string Email { get; set; }
            public string Otp { get; set; }
        }

        public class ResetModel
        {
            public string Email { get; set; }

            [Required]
            public string NewPassword { get; set; }

            [Compare("NewPassword")]
            public string ConfirmPassword { get; set; }
        }
    }
}
