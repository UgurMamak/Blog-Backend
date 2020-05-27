using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostCategoryDtos;
using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
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


        public IList<PostCardList2Dto> GetAll2(Expression<Func<PostCardList2Dto, bool>> filter = null)
        {
            using (var context = new BlogDbContext())
            {
                if(filter==null)
                {
                    return
                    context.Posts
                    .Include(pc => pc.PostCategories).ThenInclude(c => c.Category).OrderByDescending(o=>o.Created)
                    .Select(se => new PostCardList2Dto
                    {

                        PostId = se.Id,
                        Title = se.Title,
                        ImageName = se.ImageName,
                        Created = DateTime.Now,

                        UserId = se.UserId,
                        FirstName = se.User.FirstName,
                        LastName = se.User.LastName,

                        CommentNumber = context.Comments.Where(w => w.PostId == se.Id).Count(),
                        LikeNumber=context.LikePosts.Where(w=>w.PostId==se.Id && w.LikeStatus==true).Count(),

                        postCategoryListDtos = new List<PostCategoryListDto>(
                            context.PostCategories.Where(w => w.PostId == se.Id)
                            .Select(se => new PostCategoryListDto
                            {
                                CategoryId = se.CategoryId,
                                CategoryName = se.Category.CategoryName
                            }))
                    }).ToList();
                }
                

                return
                 context.Posts
                   .Include(pc => pc.PostCategories).ThenInclude(c => c.Category)
                   .Select(se => new PostCardList2Dto
                   {
                       PostId = se.Id,
                       Title = se.Title,
                       ImageName = se.ImageName,
                       Created = DateTime.Now,

                       UserId = se.UserId,
                       FirstName = se.User.FirstName,
                       LastName = se.User.LastName,

                       CommentNumber = context.Comments.Where(w => w.PostId == se.Id).Count(),
                       LikeNumber = context.LikePosts.Where(w => w.PostId == se.Id && w.LikeStatus == true).Count(),

                       postCategoryListDtos = new List<PostCategoryListDto>(
                           context.PostCategories.Where(w => w.PostId == se.Id)
                           .Select(se => new PostCategoryListDto
                           {
                               CategoryId = se.CategoryId,
                               CategoryName = se.Category.CategoryName
                           }))
                   })
                   .Where(filter)
                   .ToList();           
            }
        }



        public IList<PostCardList2Dto> GetByCategoryId(string categoryId)
        {
            using (var context=new BlogDbContext())
            {
                var entity = context.Posts.Include(pc => pc.PostCategories).ThenInclude(c => c.Category)
                  .Select(se => new PostCardList2Dto
                  {
                      PostId = se.Id,
                      Title = se.Title,
                      ImageName = se.ImageName,
                      Created = DateTime.Now,
                      UserId = se.UserId,
                      FirstName = se.User.FirstName,
                      LastName = se.User.LastName,
                      postCategoryListDtos = new List<PostCategoryListDto>(
                          context.PostCategories
                          .Where(w => w.PostId == se.Id && w.CategoryId==categoryId)
                          .Select(se => new PostCategoryListDto { CategoryId = se.CategoryId, CategoryName = se.Category.CategoryName }))
                  })
                  .ToList();
                var control = new List<PostCardList2Dto>();
                foreach (var item in entity)
                {
                    if (!item.postCategoryListDtos.IsNullOrEmpty())
                    {control.Add(item);}
                }
                return control;
            }
        }



       public void MultipleAdd(PostCategoryCreateDto postCategoryCreateDto)
        {
            using (var context=new BlogDbContext())
            {
                var sorgu = new PostCategory
                {
                    CategoryId = postCategoryCreateDto.CategoryId,
                    PostId = postCategoryCreateDto.PostId
                };

                context.PostCategories.Add(sorgu);
                context.SaveChanges();       
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
