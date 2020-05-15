using Application.Core.Utilities.Results;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface IPostCategoryService
    {
        IDataResult<List<PostCategory>> GetList();
        IDataResult<PostCategory> GetById(string postCategoryId);
        IDataResult<List<PostCategory>> GetListByCategoryId(string categoryId);//categorye göre postları getirmek için
        IResult Add(PostCategoryCreateDto postCategoryCreateDto);
        IResult Delete(PostCategory postCategory);
        IResult Update(PostCategory postCategory);




        //********************************
        IDataResult<List<PostCardListDto>> GetAll();
        IDataResult<List<PostCardListDto>> GetByCategoryId(string categoryId);
        IDataResult<List<PostCardListDto>> GetByUserId(string userId);

       







    }
}
