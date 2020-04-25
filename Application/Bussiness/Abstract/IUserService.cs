using Application.Core.Utilities.Results;
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

        //operasyon ekledik.
        List<OperationClaim> GetClaims(User user); //user'ın sahip olduğu claimleri(yetkileri) rolleri getirmek için oluşturduk.
        void Add(User user);//Kullanıcı ekleme işlemi
        User GetByMail(string email);//kullanıcının maili vasıtasıyla bulmak için oluşturduk.



    }
}
