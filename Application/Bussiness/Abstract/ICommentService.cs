using Application.Core.Utilities.Results;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetList();
        IDataResult<Comment> GetById(string commentId);
        IResult Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
    }
}
