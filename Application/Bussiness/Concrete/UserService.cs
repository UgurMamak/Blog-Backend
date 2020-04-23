using Application.Bussiness.Abstract;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Bussiness.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        private IPostDal _postDal;
        public UserService(IUserDal userDal, IPostDal postDal)
        {
            _userDal = userDal;
            _postDal = postDal;
        }

        public IDataResult<List<User>> GetList()
        {
            //return new SuccessDataResult<List<PostCategory>>(_postCategoryDal.GetList(p => p.CategoryId == categoryId).ToList());

            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
            //return new SuccessDataResult<List<User>>(_userDal.GetListDeneme().ToList());
        }

        public IDataResult<User> GetById(string userId)
        {
            throw new NotImplementedException();
        }


        public IResult Add(User user)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
