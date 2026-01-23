using project.Models;

public class ResetPassword
{
    public int Id { get; set; }

    public int AccountId { get; set; }
    public string Email { get; set; }

    public string Otp { get; set; }
    public DateTime ExpiredAt { get; set; }

    public bool IsUsed { get; set; }
    public DateTime CreatedAt { get; set; }

    public Account Account { get; set; }
}
