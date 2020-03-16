using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistence;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  public class PostController : AbstractController
  {
    public PostController(BlogDbContext context) :
      base(context)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var entity =
        await Context
          .Posts
          .Join(Context.Users, p => p.UserId, u => u.Id, (p, u) => new { p, u })
          .AsNoTracking()
          .ToListAsync();
      return Ok(entity);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
      // var entity = await Context.Posts.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
      var entity =
        await Context
          .Posts
          .Join(Context.Users, p => p.UserId, u => u.Id, (p, u) => new { p, u })
          .AsNoTracking()
          .SingleOrDefaultAsync(t => t.p.Id == id);

      if (entity == null) return NotFound();
      return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
      Context.Posts.Add (post);
      await Context.SaveChangesAsync();
      return Ok(post);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
      var entity = await Context.Posts.FindAsync(id);
      if (entity == null) return NotFound();

      Context.Posts.Remove (entity);
      await Context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Post post)
    {
      var entity = await Context.Posts.SingleOrDefaultAsync(s => s.Id == id);
      if (entity == null) return NotFound();

      entity.Title = post.Content;
      entity.Content = post.Content;
      entity.UserId = post.UserId;
      entity.Updated = DateTime.Now;
      entity.UpdatedBy = post.UpdatedBy;

      await Context.SaveChangesAsync();
      return NoContent();
    }
  }
}
