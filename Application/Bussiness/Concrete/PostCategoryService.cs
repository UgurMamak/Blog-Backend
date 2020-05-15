using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Aspects.Autofac.Transaction;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostDtos;
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

        public IResult Delete(PostCategory postCategory)
        {
            _postCategoryDal.Delete(postCategory);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IResult Update(PostCategory postCategory)//+++
        {
            _postCategoryDal.Update2(postCategory);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [TransactionScopeAspect]//+++++
        public IResult Add(PostCategoryCreateDto postCategoryCreateDto)
        {
            var postCategory = new PostCategory
            {
                CategoryId = postCategoryCreateDto.CategoryId,
                PostId = postCategoryCreateDto.PostId
            };
            _postCategoryDal.Add(postCategory);
            return new SuccessResult(Messages.CategoryAdded);
            
        }

        //******************************************************************

            //Tüm postları listelemek için
        public IDataResult<List<PostCardListDto>> GetAll()
        {
            return new SuccessDataResult<List<PostCardListDto>>(_postCategoryDal.GetAll().ToList());
        }

        public IDataResult<List<PostCardListDto>> GetByCategoryId(string categoryId)
        {
            return new SuccessDataResult<List<PostCardListDto>>(_postCategoryDal.GetAll(p => p.CategoryId == categoryId).ToList());
        }

        public IDataResult<List<PostCardListDto>> GetByUserId(string userId)
        {
            return new SuccessDataResult<List<PostCardListDto>>(_postCategoryDal.GetAll(p => p.UserId == userId).ToList());
        }

       
        

    }
}
