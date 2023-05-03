using Microsoft.AspNetCore.Identity;
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
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly TokenService _tokenService;

    public AuthController(NetworkAppContext context, UserManager<ApplicationUser> userManager, TokenService tokenService)
    {
        _context = context;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ApplicationUser? managedUser = await _userManager.FindByNameAsync(request.Username);
        var invalidResponse = BadRequest("Username or password was incorrect");
        if (managedUser == null)
        {
            return invalidResponse;
        }

        bool isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        if (!isPasswordValid)
        {
            return invalidResponse;
        }

        (string token, DateTime expiresIn) = _tokenService.CreateToken(managedUser);
        return Ok(new AuthResponse
        { 
            ID = managedUser.Id,
            Username = managedUser.UserName ?? "",
            Token = token,
            ExpiresIn = expiresIn
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(
            new ApplicationUser { UserName = request.Username },
            request.Password
        );

        if (result.Succeeded)
        {
            request.Password = "";
            return CreatedAtAction(nameof(Register), new { UserName = request.Username }, request);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }
}
