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
    public class PostService : IPostService
    {
        private IPostDal _postDal;
        private IPostCategoryService _postCategoryService;
        public PostService(IPostDal postDal, IPostCategoryService postCategoryService)
        {
            _postDal = postDal;
            _postCategoryService = postCategoryService;
        }

        [TransactionScopeAspect]
        public IDataResult<List<Post>> GetList()
        {          
            return new SuccessDataResult<List<Post>>(_postDal.GetList().ToList());
        }


        [TransactionScopeAspect]//+++
        public IResult Update(PostUpdateDto post)
        {
            var post2 = new Post {
                Content=post.Content,
                Title=post.Title,
                Updated=DateTime.Now,
                Id=post.Id,
                UserId=post.UserId
            };
           // _postDal.Update(post2);
            _postDal.Update2(post);
            //return new SuccessResult(Messages.PostUpdated);
            var postUpdate= new SuccessResult(Messages.PostUpdated);
           // var postCategory = new PostCategory {PostId=post.Id,CategoryId=post.CategoryId };
            var postCategory = new PostCategory {PostId=post.Id,CategoryId=post.CategoryId, Id=post.PostCategoryId };
            _postCategoryService.Update(postCategory);
            return new SuccessResult(Messages.PostUpdated);            
        }

        [TransactionScopeAspect]
        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }

        [TransactionScopeAspect]//+++
        public IDataResult<Post> Add(PostCreateDto postCreateDto, string imageName)
        {
            var post = new Post
            {
                Title = postCreateDto.Title,
                Content = postCreateDto.Content,
                ImageName = imageName,
                UserId = postCreateDto.UserId,
                Created=DateTime.Now
            };
            _postDal.Add(post);
            var postSave = new SuccessDataResult<Post>(post, Messages.UserRegistered);
            var postCategory = new PostCategoryCreateDto { PostId = postSave.Data.Id, CategoryId = postCreateDto.CategoryId };
            _postCategoryService.Add(postCategory);
            return new SuccessDataResult<Post>(post, Messages.PostAdded);
        }
       

        [TransactionScopeAspect]//+++(post detay işlemi)
        public IDataResult<List<PostListDto>> GetByPostId(string postId)
        {
            return new SuccessDataResult<List<PostListDto>>(_postDal.GetAll(p => p.PostId == postId).ToList());
        }

    }
}
