using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Entity
{
  public class LikePost
  {
    public int Id { get; set; }

    public int PostId { get; set; } //beğenilen post

    public int UserId { get; set; } //postu beğenen kullanıcı

    public bool LikeStatus { get; set; } //Like dislike durumu için

    public Post Post { get; set; }

    public User User { get; set; }
  }
}
