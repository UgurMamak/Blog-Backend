using Application.Core.Utilities.Results;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    interface ILikePostService
    {
        IDataResult<List<LikePost>> GetList();
        IDataResult<LikePost> GetById(string postId);
        IResult Add(LikePost likePost);
        IResult Delete(LikePost likePos);
        IResult Update(LikePost likePos);
    }
}
