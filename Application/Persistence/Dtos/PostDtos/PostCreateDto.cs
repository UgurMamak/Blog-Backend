using Application.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos
{
    public class PostCreateDto : IDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public IFormFile Image { get; set; } //gelen resimler tutması için
        public string CategoryId { get; set; }
    }
}
