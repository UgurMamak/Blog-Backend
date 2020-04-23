using Application.Core.DataAccsess;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccsess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
       //sadece post tablosuna ait özellikler burada tanımlanabilir.
    }
}
