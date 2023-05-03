using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly NetworkAppContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public PostController(NetworkAppContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDTO>>> GetAll()
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        return await _context.Posts
            .Include(post => post.User)
            .Select(post => new PostDTO(post, user.Id))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDTO>> GetPost(int id)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        Post? post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();

        return new PostDTO(post, user.Id);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> CreatePost(PostRequest post)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
            Post newPost = new Post
            {
                Content = post.Content,
                UserID = user.Id
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = newPost.ID }, new PostDTO(newPost, user.Id));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to add post");
            throw;
        }
    }

    [HttpPut("{postId}")]
    public async Task<ActionResult<PostDTO>> UpdatePost(int postId, Post post)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        Post? postToUpdate = await _context.Posts.FindAsync(postId);
        if (postToUpdate is null)
        {
            return BadRequest();
        }
        else if (postToUpdate.UserID != user.Id)
        {
            return Unauthorized();
        }

        postToUpdate.Content = post.Content;
        postToUpdate.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPost), new { id = postToUpdate.ID }, new PostDTO(postToUpdate, user.Id));
    }

    [HttpGet("{postId}/likes")]
    public async Task<ActionResult<int>> GetLikes(int postId)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        Post? post = await _context.Posts.FirstOrDefaultAsync(post => post.ID == postId);
        if (post == null)
        {
            return NotFound();
        }

        int numLikes = _context.UsersLikesPosts
            .Where(entry => entry.PostID == post.ID)
            .Count();
        return numLikes;
    }

    [HttpPost("{postId}/likes")]
    public async Task<ActionResult<int>> Like(int postId)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        Post? post = await _context.Posts
            .Include(post => post.UserLikesPosts)
            .FirstOrDefaultAsync(post => post.ID == postId);
        if (post == null)
        {
            return NotFound();
        }

        UserLikesPosts? hasUserLikedPost = await _context.UsersLikesPosts.FirstOrDefaultAsync(entry => entry.UserID == user.Id);
        if (hasUserLikedPost == null)
        {
            await _context.UsersLikesPosts.AddAsync(new UserLikesPosts { UserID = user.Id, PostID = post.ID, IsLiked = true });
            _context.SaveChanges();
        }
        return post.UserLikesPosts.Count();
    }

    [HttpDelete("{postId}/likes")]
    public async Task<ActionResult<int>> RemoveLike(int postId)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(User.Identity.Name);
        Post? post = await _context.Posts
            .Include(post => post.UserLikesPosts)
            .FirstOrDefaultAsync(post => post.ID == postId);
        if (post == null)
        {
            return NotFound();
        }

        UserLikesPosts? userLikedPost = await _context.UsersLikesPosts.FirstOrDefaultAsync(entry => entry.UserID == user.Id);
        if (userLikedPost != null)
        {
            _context.UsersLikesPosts.Remove(userLikedPost);
            _context.SaveChanges();
        }
        return post.UserLikesPosts.Count();
    }
}
