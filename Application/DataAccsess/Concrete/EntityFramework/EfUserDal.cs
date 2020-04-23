using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.Persistence.EntityFramework
{

    public class EfUserDal : EfEntityRepositoryBase<User, BlogDbContext>, IUserDal
    {
        /*
        public IList<User> GetListDeneme()
        {
            using (var context = new BlogDbContext())
            {                
                var sorgu = context.Users.Include(c=>c.Posts).ToList();
                return sorgu;
            }
        }
        */
    }
}
