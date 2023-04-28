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

    [HttpGet]
    public ActionResult<List<Post>> GetAll()
    {
        return _context.Posts.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(CreatePost), new { id = post.ID }, post);
    }

    [HttpPut("{id}")]
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

    [HttpPut("like/{id}")]
    public IActionResult Like(int id, int userId)
    {
        return NoContent();
    }
}
