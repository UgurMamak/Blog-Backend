using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
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
            return new SuccessDataResult<List<Post>>(_postDal.GetList().ToList()) ;
        }

        public IDataResult<Post> GetById(string postId)
        {            
            return new SuccessDataResult<Post>(_postDal.Get(p=>p.Id==postId));
        }

      

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.CategoryUpdated);
        }
        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.CategoryDeleted);
        }

       
    }
}
