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

    /*
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
    }
    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
    }
    */

  }
}
