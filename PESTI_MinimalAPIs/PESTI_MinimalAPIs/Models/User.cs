namespace PESTI_MinimalAPIs.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required byte[]? PasswordHash { get; set; } = new byte[32];
    public required byte[] PasswordSalt { get; set; } = new byte[32];
    public string? PasswordResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
}