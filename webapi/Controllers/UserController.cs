using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly NetworkAppContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(NetworkAppContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("me")]
    public async Task<ActionResult<UserDTO>> GetMe()
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        return NoContent();
    }

    [HttpGet("{userId}")]
    public ActionResult GetUser(int userId)
    {
        return NoContent();
    }

    [HttpGet("{userId}/posts")]
    public async Task<ActionResult<List<PostDTO>>> GetUserPosts(int userId)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return BadRequest("Invalid user");
        }
        return await _context.Posts
            .Where(post => post.UserID == userId)
            .Include(post => post.User)
            .Select(post => new PostDTO(post, user.Id))
            .ToListAsync();
    }

    [HttpGet("{userId}/followers")]
    public ActionResult GetUserFollowers(int userId)
    {
        return NoContent();
    }

    [HttpPost("{userId}/follow")]
    public IActionResult Follow(int userId)
    {
        return NoContent();
    }

    [HttpDelete("{userId}/follow")]
    public IActionResult Unfollow(int userId)
    {
        return NoContent();
    }
}
