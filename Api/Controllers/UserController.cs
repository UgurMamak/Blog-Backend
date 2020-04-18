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
  public class UserController : AbstractController
  {
    public UserController(BlogDbContext context) :
      base(context)
    {
    }

    

    public int MetotDeneme(int candidate)
    {
      return candidate*10;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var entity = await Context.Users.AsNoTracking().ToListAsync();
      return Ok(entity);
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
      var entity = await Context.Users.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);

      if (entity == null) return NotFound();
      return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
      Context.Users.Add (user);
      await Context.SaveChangesAsync();
      return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var entity = await Context.Users.FindAsync(id);
      if (entity == null) return NotFound();

      Context.Users.Remove (entity);
      await Context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, User user)
    {
      var entity = await Context.Users.SingleOrDefaultAsync(s => s.Id == id);
      if (entity == null) return NotFound();

      entity.Email = user.Email;

      entity.Updated =DateTime.Now;
      entity.UpdatedBy = user.UpdatedBy;

      await Context.SaveChangesAsync();
      return NoContent();
    }
  }
}
