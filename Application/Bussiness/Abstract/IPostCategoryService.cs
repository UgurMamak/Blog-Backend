using Application.Core.Utilities.Results;
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
        IResult Add(PostCategory postCategory);
        IResult Delete(PostCategory postCategory);
        IResult Update(PostCategory postCategory);
    }
}
