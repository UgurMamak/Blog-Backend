using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos;
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, BlogDbContext>, IPostDal
    {
        //IPostdal'da tanımlaann metotlar buraya implement edilerek içerikleri yazılır.
        
    }
}
