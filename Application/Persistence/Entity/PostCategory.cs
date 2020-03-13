using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Entity
{
  public class PostCategory : AuditableEntity
  {
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public long PostId { get; set; }


    public Category Category { get; set; }
    public Post Post { get; set; }

    //public List<Post> Posts { get; set; }

  }
}
