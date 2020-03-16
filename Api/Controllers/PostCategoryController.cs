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
  public class PostCategoryController : AbstractController
  {
    public PostCategoryController(BlogDbContext context) :
      base(context)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var entity =
        await Context
          .PostCategories
          .Join(Context.Categories, pc => pc.CategoryId, c => c.Id, (pc, c) => new { pc, c })
          .Join(Context.Posts,
          pc2 => pc2.pc.PostId,
          p => p.Id,
          (pc2, p) => new { pc2.pc.Id, pc2.c.CategoryName, pc2.pc.PostId })
          .AsNoTracking()
          .ToListAsync();

      return Ok(entity);
    }

    /*

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
    }
    */
    [HttpPost]
    public async Task<IActionResult> Post(PostCategory postCategory)
    {
      Context.PostCategories.Add (postCategory);
      await Context.SaveChangesAsync();
      return Ok(Context.PostCategories.ToList());
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var entity = await Context.PostCategories.FindAsync(id);
      if (entity == null) return NotFound();

      Context.PostCategories.Remove (entity);
      await Context.SaveChangesAsync();
      return NoContent();
    }
    /*
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
    }
    */
  }
}
