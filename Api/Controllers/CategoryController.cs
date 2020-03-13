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
  public class CategoryController : AbstractController
  {
    public CategoryController(BlogDbContext context) :
      base(context)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var entity = await Context.Categories.AsNoTracking().ToListAsync();
      return Ok(entity);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var entity = await Context.Categories.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);

      if (entity == null) return NotFound();
      return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
      Context.Categories.Add (category);
      await Context.SaveChangesAsync();
      return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var entity = await Context.Categories.FindAsync(id);
      if (entity == null) return NotFound();

      Context.Categories.Remove (entity);
      await Context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
      var entity = await Context.Categories.SingleOrDefaultAsync(s => s.Id == id);
      if (entity == null) return NotFound();

      entity.CategoryName = category.CategoryName;
      entity.Updated =DateTime.Now;
      entity.UpdatedBy = category.UpdatedBy;
      await Context.SaveChangesAsync();
      return NoContent();
    }
  }
}
