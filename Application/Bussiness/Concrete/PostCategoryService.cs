using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Aspects.Autofac.Transaction;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Bussiness.Concrete
{
    public class PostCategoryService : IPostCategoryService
    {

        private IPostCategoryDal _postCategoryDal;
        public PostCategoryService(IPostCategoryDal postCategoryDal)
        {
            _postCategoryDal = postCategoryDal;
        }

        
        public IDataResult<List<PostCategory>> GetList()
        {
            return new SuccessDataResult<List<PostCategory>>(_postCategoryDal.GetList().ToList());
        }
        public IDataResult<PostCategory> GetById(string postCategoryId)
        {
            return new SuccessDataResult<PostCategory>(_postCategoryDal.Get(p => p.Id == postCategoryId));
        }

        public IDataResult<List<PostCategory>> GetListByCategoryId(string categoryId)
        {
            //CategoryId'ye göre listeleme işlemi için yazıldı.
            return new SuccessDataResult<List<PostCategory>>(_postCategoryDal.GetList(p => p.CategoryId == categoryId).ToList());
        }
        /*
        public IResult Add(PostCategory postCategory)
        {

            _postCategoryDal.Add(postCategory);
            return new SuccessResult(Messages.CategoryAdded);
        }
        */

        public IResult Delete(PostCategory postCategory)
        {
            _postCategoryDal.Delete(postCategory);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IResult Update(PostCategory postCategory)
        {
            _postCategoryDal.Update(postCategory);
            return new SuccessResult(Messages.CategoryAdded);
        }


        [TransactionScopeAspect]
        public IResult Add(PostCategoryCreateDto postCategoryCreateDto)
        {
            var postCategory = new PostCategory {
                CategoryId=postCategoryCreateDto.CategoryId,
                PostId=postCategoryCreateDto.PostId
            };
            _postCategoryDal.Add(postCategory);
            return new SuccessResult(Messages.CategoryAdded);
        }

       
    }
}
