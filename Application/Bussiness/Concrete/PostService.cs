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
    public class PostService : IPostService
    {
        private IPostDal _postDal;
        public PostService(IPostDal postDal)
        {
            _postDal = postDal;
        }
        public IDataResult<List<Post>> GetList()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetList().ToList());
        }

        public IDataResult<Post> GetById(string postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == postId));
        }



        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
        /*
        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.CategoryAdded);
        }
        */

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }

        [TransactionScopeAspect]
        public IResult Add(PostCreateDto postCreateDto,string imageName)
        {
            var post = new Post
            {
                Title = postCreateDto.Title,
                Content = postCreateDto.Content,
                ImageName=imageName,
                UserId=postCreateDto.UserId
            };
            _postDal.Add(post);
            return new SuccessResult(Messages.PostAdded);
        }


    }
}
