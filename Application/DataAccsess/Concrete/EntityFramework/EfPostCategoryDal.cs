using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence;

using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.DataAccsess.Concrete.EntityFramework
{
    public class EfPostCategoryDal : EfEntityRepositoryBase<PostCategory, BlogDbContext>, IPostCategoryDal
    {
        public IList<PostCardListDto> GetAll(Expression<Func<PostCardListDto, bool>> filter = null)
        {
            using (var context = new BlogDbContext())
            {
                return filter == null
                 ? context.PostCategories.Include(p => p.Post)
                    .Include(c => c.Category)
                    .Select(se => new PostCardListDto
                    {
                        PostId = se.PostId,
                        Title = se.Post.Title,
                        ImageName = se.Post.ImageName,
                        //Created = se.Post.Created.ToShortDateString(),
                        Created = DateTime.Now,

                        UserId = se.Post.UserId,
                        FirstName = se.Post.User.FirstName,
                        LastName = se.Post.User.LastName,

                        CategoryId = se.CategoryId,
                        CategoryName = se.Category.CategoryName
                    }).ToList()

                    : context.PostCategories.Include(p => p.Post)
                    .Include(c => c.Category)
                    .Select(se => new PostCardListDto
                    {
                        PostId = se.PostId,
                        Title = se.Post.Title,
                        ImageName = se.Post.ImageName,
                       // Created = se.Post.Created.ToShortDateString(),
                        Created = DateTime.Now,

                        UserId = se.Post.UserId,
                        FirstName = se.Post.User.FirstName,
                        LastName = se.Post.User.LastName,

                        CategoryId = se.CategoryId,
                        CategoryName = se.Category.CategoryName
                    }).Where(filter).ToList();                
            }
        }



        public void Update2(PostCategory postCategory)
        {
            using (var context = new BlogDbContext())
            {
                //postCAtegoryId ye göre değilpostId ye göre güncelleme işlemi yapıyorum.
                var entity = context.PostCategories.Where(w => w.PostId == postCategory.PostId).SingleOrDefault();
                if (entity != null)
                {
                    entity.CategoryId = postCategory.CategoryId;
                    entity.Updated = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }



    }
}
