using Application.Core.DataAccsess.EntityFramework;
using Application.Core.Utilities.Results;
using Application.Core.Utilities.Security.Hashing;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.UserDtos;
using Application.Persistence.Entity;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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

        public void AddUserRole(UserForRegisterDto userForRegister, string userId)
        {
            using (var context = new BlogDbContext())
            {
                //gelen role bilgisine göre role'ün sahip olduğu Id'yi çektik.
                var result = context.OperationClaims.Where(w => w.Name == userForRegister.Role).Select(s => s.Id).Single();//RoleIdyi çeker.
                int deneme = Convert.ToInt32(result);

                //ekleme işlemi için nesne oluşturduk.
                var info = new UserOperationClaim
                {
                    UserId = userId,
                    OperationClaimId = Convert.ToInt32(result)
                };
                context.UserOperationClaims.Add(info);
                context.SaveChanges();
            }
        }


        public void Update2(UserUpdateDto userUpdateDto)
        {
            using (var context=new BlogDbContext())
            {
                var update = context.Users.SingleOrDefault(w=>w.Id==userUpdateDto.Id);

                

                if (userUpdateDto.FirstName != null) update.FirstName = userUpdateDto.FirstName;

                if (userUpdateDto.LastName != null) update.LastName = userUpdateDto.LastName;

                if (userUpdateDto.Image != null) update.ImgName = userUpdateDto.ImageName;
                
                if (userUpdateDto.Email != null) update.Email = userUpdateDto.Email;

                if(userUpdateDto.password!=null)
                {
                    byte[] passwordHash, passwordSalt; //işlem bitince bunlar oluşacak
                    HashingHelper.CreatePasswordHash(userUpdateDto.password, out passwordHash, out passwordSalt);
                    update.PasswordHash = passwordHash;
                    update.PasswordSalt = passwordSalt;
                }

                update.Updated = DateTime.Now;
                context.SaveChanges();
            }            
        }





    }
}
