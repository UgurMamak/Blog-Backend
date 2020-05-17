using Application.Core.Utilities.Results;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostCategoryDtos;
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
        IDataResult<List<PostCardList2Dto>> GetAll2();//iç içe gösterlmiş hali
        IDataResult<List<PostCardListDto>> GetAll();
        IDataResult<List<PostCardList2Dto>> GetByCategoryId(string categoryId);
        IDataResult<List<PostCardList2Dto>> GetByUserId(string userId);
        IResult DeleteByPostId(string postId);









    }
}
