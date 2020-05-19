using Application.Core.Utilities.Results;
using Application.Persistence.Dtos.LikePostDto;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface ILikePostService
    {
        IResult Add(LikePostCreateDto likePost);
        IDataResult<List<LikePost>> GetList();
        IDataResult<LikePostNumberStatusDto> GetNumberStatus(string postId);//like ve dislike sayıları çekmek için yazdım.
        string LikePostExists(LikePostCreateDto likePost);//gelen datanın db olup olmadığına bakılır.
        IResult Delete(LikePostCreateDto likePost);
    }
}
