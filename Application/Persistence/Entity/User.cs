using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Application.Persistence.Entity
{
    public class User : AuditableEntity
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        //public Guid Id { get; set; }

        public string Email { get; set; }

        public List<Post> Posts { get; set; }
        public List<LikePost> LikePosts { get; set; }
    }
}
