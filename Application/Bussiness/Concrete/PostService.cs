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
        private ICommentService _commentService;
        public PostService(IPostDal postDal, IPostCategoryService postCategoryService, ICommentService commentService)
        {
            _postDal = postDal;
            _postCategoryService = postCategoryService;
            _commentService = commentService;
        }

        [TransactionScopeAspect]
        public IDataResult<List<Post>> GetList()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetList().ToList());
        }


        [TransactionScopeAspect]//+++
        public IResult Update(PostUpdateDto post)
        {
            /*
            var post2 = new Post
            {
                Content = post.Content,
                Title = post.Title,
                Updated = DateTime.Now,
                Id = post.Id,
                UserId = post.UserId
            };*/

            _postDal.Update2(post);
            if(post.CategoryId!=null)
            {
                string[] category = post.CategoryId.Split("*");
                foreach (var item in category)
                {
                    if (item != "")
                    {
                        var postCategory = new PostCategoryCreateDto { PostId = post.Id, CategoryId = item };
                        _postCategoryService.Add(postCategory);
                    }
                }
            }
            

            //var postCategory2 = new PostCategory {PostId=post.Id,CategoryId=post.CategoryId, Id=post.PostCategoryId };
            // _postCategoryService.Update(postCategory2);
            return new SuccessResult(Messages.PostUpdated);
        }

        [TransactionScopeAspect]
        public IResult Delete(Post post)
        {
            _postCategoryService.DeleteByPostId(post.Id);
            _commentService.DeleteByPostId(post.Id);
            _postDal.DeleteById(w => w.Id == post.Id);
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
                Created = DateTime.Now
            };
            _postDal.Add(post);
            var postSave = new SuccessDataResult<Post>(post, Messages.UserRegistered);
            string[] category = postCreateDto.CategoryId.Split("*");
            foreach (var item in category)
            {
                if (item != "")
                {
                    var postCategory = new PostCategoryCreateDto { PostId = postSave.Data.Id, CategoryId = item };
                    _postCategoryService.Add(postCategory);
                }
            }
            return new SuccessDataResult<Post>(post, Messages.PostAdded);
        }


        [TransactionScopeAspect]//+++(post detay işlemi)
        public IDataResult<List<PostListDto2>> GetByPostId(string postId)
        {
            //return new SuccessDataResult<List<PostListDto>>(_postDal.GetAll(p => p.PostId == postId).ToList());
            return new SuccessDataResult<List<PostListDto2>>(_postDal.GetAll2(p => p.PostId == postId).ToList());
        }






    }
}
