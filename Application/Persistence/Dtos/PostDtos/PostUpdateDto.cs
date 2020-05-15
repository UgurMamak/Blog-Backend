using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.PostDtos
{
    public class PostUpdateDto
    {
        public string Id { get; set; }//postId
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Updated { get; set; }
        public string ImageName { get; set; }


        public string PostCategoryId { get; set; }//
        public string CategoryId { get; set; }//postu yazan
        public string UserId { get; set; }//postu yazan
    }
}
