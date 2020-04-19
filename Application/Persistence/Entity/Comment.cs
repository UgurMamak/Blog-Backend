using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Persistence.Entity
{
    public class Comment : AuditableEntity
    { 
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
        // public long Id { get; set; }

        public string Content { get; set; } //yorum içerik

        public bool ConfirmStatus { get; set; } //yorumun onaylanmış olup olmamasını kontrol etmek için

        public bool LikeStatus { get; set; } //yorumun like dislike durumunu tutmak için (True Like)(False Dislike)

        public string UserId { get; set; } //yorumu yapan kişi için
        //public Guid UserId { get; set; } //yorumu yapan kişi için

        public string PostId { get; set; } //hangi posta yorum yapıldığını tutmak için
        //public long PostId { get; set; } //hangi posta yorum yapıldığını tutmak için

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
