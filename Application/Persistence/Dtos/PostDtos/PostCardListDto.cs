using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.PostDtos
{
    public class PostCardListDto
    {

        public string PostId { get; set; }//Post
        public string Title { get; set; }//Post
        public string ImageName { get; set; }//Post
        public DateTime Created { get; set; }//Post

        public string UserId { get; set; }//User
        public string FirstName { get; set; }//User 
        public string LastName { get; set; }//User

        public string CategoryId { get; set; }//Category
        public string CategoryName { get; set; }//Category


    }
}
