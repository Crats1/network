using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private const int PAGINATION_LIMIT = 10;
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
        return new UserDTO(user);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDTO>> GetUser(int userId)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        ApplicationUser? fetchedUser = await _context.Users
            .Include(e => e.Followers)
            .Include(e => e.Follows)
            .FirstOrDefaultAsync(e => e.Id == userId);
        if (fetchedUser == null)
        {
            return NotFound();
        }

        return new UserDTO(fetchedUser)
        {
            IsFollowing = user.Follows.FirstOrDefault(e => e.UserID == fetchedUser.Id) != null
        };
    }

    [HttpGet("{userId}/posts")]
    public async Task<ActionResult<PaginatedList<PostDTO>>> GetUserPosts(int userId, string? sortOrder, int limit = PAGINATION_LIMIT, int offset = 0)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return BadRequest("Invalid user");
        }
        var posts = _context.Posts
            .Where(post => post.UserID == userId)
            .Include(post => post.User)
            .Include(post => post.UserLikesPosts)
            .Select(post => new PostDTO(post, user.Id));
        var sortedPosts = Util.SortPosts(posts, sortOrder);
        var paginatedPosts = PaginatedList<PostDTO>.CreateAsync(sortedPosts, limit, offset);
        return paginatedPosts;
    }

    [HttpPost("{userId}/follow")]
    public async Task<IActionResult> Follow(int userId)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        ApplicationUser? toFollow = await _userManager.FindByIdAsync(userId.ToString());
        if (toFollow == null)
        {
            return NotFound();
        }

        await _context.UserFollowers.AddAsync(new UserFollowers { UserID = toFollow.Id, FollowerID = user.Id });
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{userId}/follow")]
    public async Task<IActionResult> Unfollow(int userId)
    {
        ApplicationUser? followingUser = await _userManager.FindByNameAsync(User.Identity.Name);
        UserFollowers? followedUser = _context.UserFollowers.FirstOrDefault(e => e.UserID == userId && e.FollowerID == followingUser.Id);
        if (followedUser == null)
        {
            return NotFound();
        }

        _context.UserFollowers.Remove(followedUser);
        _context.SaveChanges();

        return Ok();
    }
}
