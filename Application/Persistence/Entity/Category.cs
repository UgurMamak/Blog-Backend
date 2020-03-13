using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Entity
{
  public class Category : AuditableEntity
  {
    public int Id { get; set; }

    public string CategoryName { get; set; }

    public List<PostCategory> PostCategories { get; set; }
    /*
    public int Id { get; set; }

    public int CategoryName { get; set; }
    public List<Post> Posts { get; set; }
    */
  }
}
