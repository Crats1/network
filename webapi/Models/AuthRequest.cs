using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public class AuthRequest
{
    [Required]
    [MaxLength(255)]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
