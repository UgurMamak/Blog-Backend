using Application.Core.DataAccsess;
using Application.Core.Utilities.Results;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.UserDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccsess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); //
        void AddUserRole(UserForRegisterDto userForRegister, string userId);

        void Update2(UserUpdateDto userUpdateDto);
    }
}
