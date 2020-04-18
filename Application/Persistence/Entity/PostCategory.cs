using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Entity
{
    public class PostCategory : AuditableEntity
    {
        public PostCategory()
        {
            Id = Guid.NewGuid().ToString();
        }
        //public int Id { get; set; }

        public string CategoryId { get; set; }
        //public int CategoryId { get; set; }

        public string PostId { get; set; }
       // public long PostId { get; set; }

        public Post Post { get; set; }
        public Category Category { get; set; }


        //public List<Post> Posts { get; set; }

    }
}
