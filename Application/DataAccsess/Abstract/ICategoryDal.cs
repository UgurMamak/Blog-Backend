using Application.Core.DataAccsess;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccsess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //sadece category tablosunun kullanacağı özellikler bu interface içinde tanımlabilir.
        //Join işlemi gibi
    }
}
