using Application.Core.Utilities.Results;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetList(); 
        IDataResult<Post> GetById(string postId);
        IResult Add(PostCreateDto postCreateDto,string imageName);
        IResult Delete(Post post);
        IResult Update(Post post);
    }
}
