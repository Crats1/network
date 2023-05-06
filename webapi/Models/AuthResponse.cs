namespace webapi.Models;

public class AuthResponse
{
    public int ID { get; set; }
    public string UserName { get; set; } = null!;
    public string Token { get; set; } = null!;
    public DateTime ExpiresIn { get; set; }
}
