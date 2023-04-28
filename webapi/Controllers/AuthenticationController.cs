using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;


[ApiController]
[Route("api")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login()
    {
        return CreatedAtAction("login", null);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return CreatedAtAction("logout", null);
    }

    [HttpPost("register")]
    public IActionResult Register()
    {
        return CreatedAtAction("register", null);
    }

}
