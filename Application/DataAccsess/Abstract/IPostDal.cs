using Application.Core.DataAccsess;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccsess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        IList<PostListDto2> GetAll2(Expression<Func<PostListDto2, bool>> filter = null);
        public IList<PostListDto> GetAll(Expression<Func<PostListDto, bool>> filter = null);
        void Update2(PostUpdateDto postUpdateDto);
    }
}
