using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Models;

namespace webapi.Services;

public class TokenService
{
    private const int EXPIRATION_MINUTES = 30;
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public (string, DateTime) CreateToken(ApplicationUser user)
    {
        DateTime expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);
        JwtSecurityToken token = CreateJwtToken(CreateClaims(user), CreateSigningCredentials(), expiration);
        JwtSecurityTokenHandler tokenHandler = new();
        return (tokenHandler.WriteToken(token), expiration);
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration)
    {
        return new(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, expires: expiration, signingCredentials: credentials);
    }

    private List<Claim> CreateClaims(ApplicationUser user)
    {
        try
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SigningCredentials CreateSigningCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }
}
