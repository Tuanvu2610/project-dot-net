using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
        public string Status { get; set; }

        public User User { get; set; }
        public ICollection<ResetPassword> ResetPasswords { get; set; }

    }
}
