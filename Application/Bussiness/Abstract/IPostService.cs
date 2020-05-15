using Application.Core.Utilities.Results;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface IPostService
    {
      
        IDataResult<List<Post>> GetList(); 
       // IDataResult<Post> GetById(string postId);
        //IDataResult<List<User>> GetByCategoryId(string categoryId); //Kategoriye göre postları listeleme işlemi
       // IDataResult<List<Post>> GetByUserId(string userId); //UserIdye göre postları listeleme işlemi
      

        //*************************************************   
        IDataResult<List<PostListDto>> GetByPostId(string postId);
        IDataResult<Post> Add(PostCreateDto postCreateDto, string imageName);
        IResult Delete(Post post);
        IResult Update(PostUpdateDto post);

    }
}
