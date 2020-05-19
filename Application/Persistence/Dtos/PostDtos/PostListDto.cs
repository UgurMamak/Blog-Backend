﻿using Application.Core.Entities;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos
{
    public class PostListDto : IDto
    {

        public PostListDto()
        {

        }
        public string PostId { get; set; }//Post
        public string Title { get; set; }//Post
        public string Content { get; set; }//Post
        public string ImageName { get; set; }//Post
        public DateTime Created { get; set; }//Post

        public string UserId { get; set; }//User
        public string FirstName { get; set; }//User 
        public string LastName { get; set; }//User
        public string CategoryId { get; set; }//Category
        public string CategoryName { get; set; }//Category

        public List<CommentListDto> Comments { get; set; }
    }
}
