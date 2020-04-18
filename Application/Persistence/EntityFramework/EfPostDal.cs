using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.EntityFramework
{
   public class EfPostDal:EfEntityRepositoryBase<Post,BlogDbContext>,IPostDal
    {
    }
}
