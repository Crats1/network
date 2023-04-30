using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;

namespace webapi.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly NetworkAppContext _context;

    public UserController(NetworkAppContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}/posts")]
    public ActionResult GetUserPosts(int userId)
    {
        return NoContent();
    }

    [HttpGet("{userId}/followers")]
    public ActionResult GetUserFollowers(int userId)
    {
        return NoContent();
    }

    [HttpPost("follow/{id}")]
    public IActionResult Follow(int id)
    {
        return NoContent();
    }
}
