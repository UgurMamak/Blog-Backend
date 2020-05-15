using Application.Core.DataAccsess;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.DataAccsess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        void Update2(CommentUpdateDto comment);
        IList<CommentListDto> GetByPostId(Expression<Func<CommentListDto, bool>> filter = null);
    }
}
