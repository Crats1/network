using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly NetworkAppContext _context;
    private readonly TokenService _tokenService;

    public AuthController(NetworkAppContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User? user = await _context.Users.SingleOrDefaultAsync(user => user.Username == request.Username);
            if (user == null || user.PasswordHash != request.Password)
            {
                return BadRequest("Bad credentials");
            }

            var token = _tokenService.CreateToken(user);

            return Ok(new AuthResponse
            { 
                ID = user.ID,
                Username = user.Username,
                Token = token
            });
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to login {ex.Message}");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(new User { Username = request.Username, PasswordHash = request.Password });
            await _context.SaveChangesAsync();
            request.Password = "";
            return CreatedAtAction(nameof(Register), new { Username = request.Username }, request);
        } catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
