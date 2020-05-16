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
    
        // IDataResult<LikePost> GetById(string postId);

        //  IResult Delete(LikePost likePos);
        // IResult Update(LikePost likePos);


        IResult Add(LikePostCreateDto likePost);
        IDataResult<List<LikePost>> GetList();

        IDataResult<LikePostNumberStatusDto> GetNumberStatus(string postId);//like ve dislike sayıları çekmek için yazdım.

        string LikePostExists(LikePostCreateDto likePost);//gelen datanın db olup olmadığına bakılır.

    }
}
