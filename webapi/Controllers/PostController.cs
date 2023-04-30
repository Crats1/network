using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly NetworkAppContext _context;

    public PostController(NetworkAppContext context)
    {
        _context = context;
    }

    [HttpGet, Authorize]
    public async Task<ActionResult<List<Post>>> GetAll()
    {
        return await _context.Posts.ToListAsync();
    }

    [HttpGet("{id}"), Authorize]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();
        return post;
    }

    [HttpPost, Authorize, ValidateAntiForgeryToken]
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
            return CreatedAtAction(nameof(GetPost), new { id = post.ID }, post);
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to add post");
            throw;
        }
    }

    [HttpPut("{id}"), Authorize, ValidateAntiForgeryToken]
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

    [HttpPut("like/{id}"), Authorize]
    public async Task<IActionResult> Like(int id, [FromBody] int userId)
    {
        return NoContent();
    }
}
