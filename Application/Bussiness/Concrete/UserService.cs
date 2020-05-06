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

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);

        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            //GetList() kullanıp where ile de çekebiliriz.
            return _userDal.Get(u => u.Email == email);
        }

        

        
        public IDataResult<List<User>> GetList()
        {
            //return new SuccessDataResult<List<PostCategory>>(_postCategoryDal.GetList(p => p.CategoryId == categoryId).ToList());
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
            //return new SuccessDataResult<List<User>>(_userDal.GetListDeneme().ToList());
        }
        


    }
}
