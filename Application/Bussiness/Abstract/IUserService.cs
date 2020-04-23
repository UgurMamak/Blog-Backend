using Application.Core.Utilities.Results;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetList();
        IDataResult<User> GetById(string userId);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);


    


    }
}
