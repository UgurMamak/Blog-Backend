using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.DataAccsess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, BlogDbContext>, ICommentDal
    {
        public IList<CommentListDto> GetByPostId(Expression<Func<CommentListDto, bool>> filter = null)
        {
            using (var context = new BlogDbContext())
            {
                //çalışacak
                var entity = context.Comments.Include(u => u.User)
                    .Include(p => p.Post)
                    .Select(se => new CommentListDto
                    {
                        UserId = se.UserId,
                        FirstName = se.User.FirstName,
                        LastName = se.User.LastName,
                        ImageName = se.User.ImgName,
                        PostId = se.PostId,
                        Id = se.Id,//commentId
                        Content = se.Content,
                        created = se.Created,
                    })
                   .Where(filter)
                    .ToList();
                return entity;
            }
        }
        
        public void Update2(CommentUpdateDto comment)
        {
            using (var context = new BlogDbContext())
            {
                var entity = context.Comments.Where(w => w.Id == comment.Id).SingleOrDefault();
                if(entity!=null)
                {
                    entity.Content = comment.Content;
                    //entity.Updated = Convert.ToDateTime(comment.Updated);
                    entity.Updated = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
        
       
    }
}
