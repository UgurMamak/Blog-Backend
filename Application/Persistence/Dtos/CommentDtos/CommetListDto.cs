using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Persistence.Dtos.CommentDtos
{
    public class CommentListDto
    {
        public CommentListDto() { }
        public CommentListDto(Comment comment)
        {
            Id = comment.Id;
            Content = comment.Content;

            UserId = comment.UserId;
            FirstName = comment.User.FirstName;
            LastName = comment.User.LastName;
            ImageName = comment.User.ImgName;

            PostId = comment.PostId;
            created =comment.Created.ToString();
        }


        public string Id { get; set; }//comment Id
        public string Content { get; set; }
        public string UserId { get; set; }//yorumu yapan Id
        public string FirstName { get; set; }//yorumu yapan 
        public string LastName { get; set; }//yorumu yapan 
        public string ImageName { get; set; }//yorumu yapan 
        public string PostId { get; set; }
       // public DateTime created { get; set; }
        public string created { get; set; }

    }
}
