using Application.Core.Entities;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos
{
    public class PostCategoryCreateDto : IDto
    {
        public string CategoryId { get; set; }
        public string PostId { get; set; }
    }
}
