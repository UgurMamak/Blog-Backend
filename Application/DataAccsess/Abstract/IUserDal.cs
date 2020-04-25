﻿using Application.Core.DataAccsess;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccsess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //  public IList<User> GetListDeneme();
        List<OperationClaim> GetClaims(User user); //
    }
}
