using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Persistence.Entity
{
  public class Post : AuditableEntity
  {
    public long Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public Guid UserId { get; set; } //postu ekleyen kullanıcı

    // public int PostCategoryId { get; set; }

    //public PostCategory PostCategory { get; set; }
    public List<PostCategory> PostCategories { get; set; }

    public User User { get; set; }

    public List<Comment> Comments { get; set; }
  }
}
