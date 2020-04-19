using Application.Bussiness.Abstract;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Concrete
{
    class LikePostManager : ILikePostService
    {
        private ILikePostDal _likePostDal;
        public LikePostManager(ILikePostDal likePostDal)
        {
            _likePostDal = likePostDal;
        }
        public IResult Add(LikePost likePost)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(LikePost likePos)
        {
            throw new NotImplementedException();
        }

        public IDataResult<LikePost> GetById(string postId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LikePost>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(LikePost likePos)
        {
            throw new NotImplementedException();
        }
    }
}
