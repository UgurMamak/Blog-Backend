using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.CommentDtos
{
   public  class CommentUpdateDto
    {
        public string Id { get; set; }//commentId
        public string Content { get; set; }
    }
}
