using Application.Core.Entities;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos
{
    class CategoryListDto:IDto
    {
        public string Id { get; set; }       
        public string CategoryName { get; set; }
        public List<PostCategory> PostCategories { get; set; }
    }
}
