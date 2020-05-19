using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence;
using Application.Persistence.Dtos.LikePostDto;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataAccsess.Concrete.EntityFramework
{
    public class EfLikePostDal : EfEntityRepositoryBase<LikePost, BlogDbContext>, ILikePostDal
    {
        public LikePostNumberStatusDto GetNumberStatus(string postId)
        {
            using (var context = new BlogDbContext())
            {
                var trueNumber = context.LikePosts.Where(w => w.PostId == postId && w.LikeStatus == true).Count();
                var falseNumber = context.LikePosts.Where(w => w.PostId == postId && w.LikeStatus == false).Count();

               var entity = new LikePostNumberStatusDto {FalseNumber=falseNumber,TrueNumber=trueNumber };

                //List<LikePostNumberStatusDto> entity = new List<LikePostNumberStatusDto>();
                /*
                var s = context.LikePosts.Where(w => w.PostId == postId)
                    .GroupBy(g =>  g.LikeStatus)                 
                    .Select(se=>new LikePostNumberStatusDto { deneme=se.Key,count=se.Count()})
                    .ToList();
                */
                /*
                var s = context.LikePosts
                    .Select(se => new LikePostNumberStatusDto{ 
                        TrueNumber=context.LikePosts.Where(w=>w.PostId==postId && w.LikeStatus==true ).Count(),
                        FalseNumber=context.LikePosts.Where(w=>w.PostId==postId && w.LikeStatus==false).Count()
                    }).ToList();
                    */
                return entity;
            }
        }     
    }
}
