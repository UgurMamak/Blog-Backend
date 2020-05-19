using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.PostCategoryDtos
{
    public class PostCardList2Dto
    {
        public string PostId { get; set; }//Post
        public string Title { get; set; }//Post
        public string ImageName { get; set; }//Post
        public DateTime Created { get; set; }//Post

        public string UserId { get; set; }//User
        public string FirstName { get; set; }//User 
        public string LastName { get; set; }//User
        public int CommentNumber { get; set; }//posta yapılan yorum sayısını tutmak için
        public int LikeNumber { get; set; }//postun like sayısnı göstermek için
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public List<PostCategoryListDto> postCategoryListDtos { get; set; }
    }
}
