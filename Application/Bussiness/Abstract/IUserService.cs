using Application.Core.Utilities.Results;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.UserDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface IUserService
    {
        /*
        IDataResult<List<User>> GetList();//*****
        IDataResult<User> GetById(string userId);//***********
        //IResult Add(User user);//*****
        IResult Delete(User user);//*****
        IResult Update(User user);//*****
        */
		
		IDataResult<List<User>> GetList();//*****

        //operasyon ekledik.
        List<OperationClaim> GetClaims(User user); //user'ın sahip olduğu claimleri(yetkileri) rolleri getirmek için oluşturduk.
        void Add(User user);//Kullanıcı ekleme işlemi
        User GetByMail(string email);//kullanıcının maili vasıtasıyla bulmak için oluşturduk.

        void AddUserRole(UserForRegisterDto userForRegister, string userId);
        public IDataResult<List<UserListDto>> GetById(string userId);
      //  public IDataResult<UserListDto> GetById(string userId);

        IDataResult<User> Update(UserUpdateDto userUpdateDto);

    }
}
