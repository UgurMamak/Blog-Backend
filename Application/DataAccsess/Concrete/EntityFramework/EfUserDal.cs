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

        //Hangi kullanıcının hangi role sahip olduğunu bulmak için tabloları join işlemi ile birleştirdik.
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new BlogDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }


        }
    }
}
