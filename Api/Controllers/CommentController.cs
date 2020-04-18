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
  public class CommentController : AbstractController
  {
    public CommentController(BlogDbContext context) :
      base(context)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var entity = await Context.Comments.AsNoTracking().ToListAsync();
      return Ok(entity);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
      var entity = await Context.Comments.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);

      if (entity == null) return NotFound();
      return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Comment comment)
    {
      Context.Comments.Add (comment);
      await Context.SaveChangesAsync();
      return Ok(comment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
      var entity = await Context.Comments.FindAsync(id);
      if (entity == null) return NotFound();

      Context.Comments.Remove (entity);
      await Context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Comment comment)
    {
      var entity = await Context.Comments.SingleOrDefaultAsync(s => s.Id == id);
      if (entity == null) return NotFound();

      entity.Content = comment.Content;
      entity.LikeStatus = comment.LikeStatus;
      entity.UserId = comment.UserId;
      entity.PostId = comment.PostId;
      entity.ConfirmStatus = comment.ConfirmStatus;

      entity.Updated =DateTime.Now;
      entity.UpdatedBy =comment.UpdatedBy;
      
      await Context.SaveChangesAsync();
      return NoContent();
    }
  }
}
