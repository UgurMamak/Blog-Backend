using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Persistence.EntityFramework
{

    public class EfUserDal : EfEntityRepositoryBase<User, BlogDbContext>, IUserDal
    {
        
    }
}
