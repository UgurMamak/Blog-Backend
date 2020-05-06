using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Entity
{
    public class LikePost : AuditableEntity
    {
        //Postların beğenilme durumlarını tutacak.

        public LikePost()
        {
            Id = Guid.NewGuid().ToString();
        }  
  
        // public int Id { get; set; }

        public string PostId { get; set; } //beğenilen post
        //public long PostId { get; set; } //beğenilen post

        public string UserId { get; set; } //postu beğenen kullanıcı
        //public Guid UserId { get; set; } //postu beğenen kullanıcı

        public bool LikeStatus { get; set; } //Like dislike durumu için (True Like) (False Dislike)

        public Post Post { get; set; }

        public User User { get; set; }
    }
}
