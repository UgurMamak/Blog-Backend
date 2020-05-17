using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Dtos.PostCategoryDtos;
using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, BlogDbContext>, IPostDal
    {
        //IPostdal'da tanımlaann metotlar buraya implement edilerek içerikleri yazılır.


        public IList<PostListDto> GetAll(Expression<Func<PostListDto, bool>> filter = null)
        {
            using (var context = new BlogDbContext())
            {
                return
                 context.PostCategories
                    .Include(c => c.Category)
                    .Include(p => p.Post)
                    .ThenInclude(cm => cm.Comments)
                    .Select(se => new PostListDto
                    {
                        PostId = se.PostId,
                        Title = se.Post.Title,
                        ImageName = se.Post.ImageName,
                        Content = se.Post.Content,
                        Created = Convert.ToDateTime(se.Post.Created),
                        // Created = DateTime.Now, 

                        UserId = se.Post.UserId,
                        FirstName = se.Post.User.FirstName,
                        LastName = se.Post.User.LastName,

                        CategoryId = se.CategoryId,
                        CategoryName = se.Category.CategoryName,
                        // Comments=new List<CommentListDto>(entity)
                        Comments = new List<CommentListDto>(
                           context.Comments.Where(w => w.PostId == se.PostId)
                                                        .Select(se => new CommentListDto
                                                        {
                                                            Id = se.Id,
                                                            Content = se.Content,
                                                            UserId = se.UserId,
                                                            FirstName = se.User.FirstName,
                                                            LastName = se.User.LastName,
                                                            ImageName = se.User.ImgName,
                                                            created = se.Created,
                                                            PostId = se.PostId

                                                        }))

                    }).Where(filter).ToList();
            }
        }
        public IList<PostListDto2> GetAll2(Expression<Func<PostListDto2, bool>> filter = null)
        {
            using (var context = new BlogDbContext())
            {
                var entity = context.Posts.Include(cm => cm.Comments).Include(pc => pc.PostCategories).ThenInclude(c => c.Category)
                    .Select(se => new PostListDto2
                    {
                        PostId = se.Id,
                        Title = se.Title,
                        ImageName = se.ImageName,
                        Content = se.Content,
                        Created = Convert.ToDateTime(se.Created),

                        UserId = se.UserId,
                        FirstName = se.User.FirstName,
                        LastName = se.User.LastName,

                        postCategoryListDtos = new List<PostCategoryListDto>(
                          context.PostCategories
                          .Where(w => w.PostId == se.Id)
                          .Select(se => new PostCategoryListDto { CategoryId = se.CategoryId, CategoryName = se.Category.CategoryName })),

                        Comments = new List<CommentListDto>(
                           context.Comments.Where(w => w.PostId == se.Id)
                                                        .Select(se => new CommentListDto
                                                        {
                                                            Id = se.Id,
                                                            Content = se.Content,
                                                            UserId = se.UserId,
                                                            FirstName = se.User.FirstName,
                                                            LastName = se.User.LastName,
                                                            ImageName = se.User.ImgName,
                                                            created = se.Created,
                                                            PostId = se.PostId
                                                        }))
                    })
                    .Where(filter)
                    .ToList();
                return entity;

                /*
                return
                    
                 context.PostCategories
                    .Include(c => c.Category)
                    .Include(p => p.Post)
                    .ThenInclude(cm => cm.Comments)
                    .Select(se => new PostListDto
                    {
                        PostId = se.PostId,
                        Title = se.Post.Title,
                        ImageName = se.Post.ImageName,
                        Content = se.Post.Content,
                        Created = Convert.ToDateTime(se.Post.Created),
                        // Created = DateTime.Now, 

                        UserId = se.Post.UserId,
                        FirstName = se.Post.User.FirstName,
                        LastName = se.Post.User.LastName,

                        CategoryId = se.CategoryId,
                        CategoryName = se.Category.CategoryName,
                        // Comments=new List<CommentListDto>(entity)
                        Comments = new List<CommentListDto>(
                           context.Comments.Where(w => w.PostId == se.PostId)
                                                        .Select(se => new CommentListDto
                                                        {
                                                            Id = se.Id,
                                                            Content = se.Content,
                                                            UserId = se.UserId,
                                                            FirstName = se.User.FirstName,
                                                            LastName = se.User.LastName,
                                                            ImageName = se.User.ImgName,
                                                            created = se.Created,
                                                            PostId = se.PostId

                                                        }))

                    }).Where(filter).ToList();*/
            }
        }





        public void Update2(PostUpdateDto postUpdateDto)
        {
            using (var context=new BlogDbContext())
            {
                var entity = context.Posts.SingleOrDefault(w => w.Id == postUpdateDto.Id);

                if (postUpdateDto.Title != null) entity.Title = postUpdateDto.Title;
                
                if (postUpdateDto.Content != null) entity.Content = postUpdateDto.Content;
               
                if (postUpdateDto.ImageName != null) entity.ImageName = postUpdateDto.ImageName;
               
                if (postUpdateDto.Title != null) entity.Title = postUpdateDto.Title;

                entity.Updated = DateTime.Now;
                context.SaveChanges();

            }
        }

    }
}
