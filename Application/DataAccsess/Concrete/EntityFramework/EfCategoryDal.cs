using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.DataAccsess.EntityFramework;
namespace Application.Persistence.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, BlogDbContext>, ICategoryDal
    {
        //EfEntityRepositoryBase interface'in de ki tüm metotlar burada geçerli
        //Icategorda ise sadece bu tabloya ait olabilecek metotlar yazılabilir.
    }
}
