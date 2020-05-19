using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        public string Content { get; set;}//yorum
        public string UserId { get; set;}//yorumu yazan
        public string PostId { get; set;}//yazdığı post
        //public string Created { get; set;}//yorum yazılma tarihi
    }
}
