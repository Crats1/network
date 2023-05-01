using Microsoft.AspNetCore.Authorization;
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

    public PostController(NetworkAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDTO>>> GetAll()
    {
        var test = User;
        return await _context.Posts
            .Select(post => new PostDTO()
            {
                ID = post.ID,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                IsCreatedByUser = false, // TODO
                Username = post.User != null ? post.User.Username : "",
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDTO>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();
        return new PostDTO()
        {
            ID = post.ID,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
            IsCreatedByUser = false, // TODO
            Username = post.User?.Username ?? ""
        };
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<ActionResult<Post>> CreatePost([Bind("Content", "UserID")] Post post)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = post.ID }, post); // TODO
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to add post");
            throw;
        }
    }

    [HttpPut("{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.ID)
        {
            return BadRequest();
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }

        return NoContent();
    }

    [HttpGet("{id}/likes")]
    public async Task<IActionResult> GetLikes(int id)
    {
        return NoContent();
    }

    [HttpPost("{id}/likes")]
    public async Task<IActionResult> Like(int id, [FromBody] int userId)
    {
        return NoContent();
    }
}
