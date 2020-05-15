using Application.Core.Utilities.Results;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetList();
        IDataResult<List<CommentListDto>> GetByPostId(string postId);//seçilen postların yorumlarını çekmek için
        

        IDataResult<Comment> GetById(string commentId);
        IResult Add(CommentCreateDto commentCreateDto);
        IResult Delete(Comment comment);
        IResult Update(CommentUpdateDto comment);
    }
}
