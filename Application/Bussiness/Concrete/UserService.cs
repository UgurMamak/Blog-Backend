using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Aspects.Autofac.Transaction;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.UserDtos;
using Application.Persistence.Entity;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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

        //**************
        public void AddUserRole(UserForRegisterDto userForRegister, string userId)
        {
            _userDal.AddUserRole(userForRegister, userId);
        }


        
        public IDataResult<List<UserListDto>> GetById(string userId)
        {
            var user = _userDal.GetList(s => s.Id == userId).ToList();
            var userListDto = user.Select(se => new UserListDto
            {
                Id=se.Id,
                Email = se.Email,
                ImageName =se.ImgName,
                FirstName=se.FirstName,
                LastName=se.LastName
            }).ToList();
         
            return new SuccessDataResult<List<UserListDto>>(userListDto);
        }
    
    /*
        public IDataResult<UserListDto> GetById(string userId)
        {
            var user = _userDal.Get(s => s.Id == userId);
            var userListDto = new UserListDto
            {
                Id = user.Id,
                Email = user.Email,
                ImageName = user.ImgName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return new SuccessDataResult<UserListDto>(userListDto);
        }

    */





        [TransactionScopeAspect]//+++
        public IDataResult<User> Update(UserUpdateDto userUpdateDto)
        {
            _userDal.Update2(userUpdateDto);
            return new SuccessDataResult<User>(Messages.UserUpdated);
        }




    }
}
