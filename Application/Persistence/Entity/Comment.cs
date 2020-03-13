using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Persistence.Entity
{
  public class Comment : AuditableEntity
  {
    public long Id { get; set; }
 
    public string Content { get; set; } //yorum içerik

    public bool ConfirmStatus { get; set; } //yorumun onaylanmış olup olmamasını kontrol etmek için

    public bool LikeStatus { get; set; } //yorumun like dislike durumunu tutmak için

    public Guid UserId { get; set; }

    public long PostId { get; set; }

    public User User { get; set; }

    public Post Post { get; set; }
  }
}
