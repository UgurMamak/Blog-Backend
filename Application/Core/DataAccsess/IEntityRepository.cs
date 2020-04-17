using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//imported
using Application.Core.Entities;
namespace Application.Core.DataAccsess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //CRUD işlemleri tüm tablolarda olduğu için her yerde tek tek yazmak yerine IEntityRepository interface'i oluşturduk 
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);     

    }
}
