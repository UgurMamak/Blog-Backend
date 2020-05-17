using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Application.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Application.Core.DataAccsess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        //IEntityRepositoryden implement edildi ve orda tanımlanan metoların görevleri burda verildi.
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        /*
        public void MultipleAdd(TEntity entity)
        {
            using (var context = new TContext())
            {
                var s = new TEntity();

                var sorgu = context.Set<TEntity>(){ entity};

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        */
        public  void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State =  EntityState.Deleted;
                 context.SaveChanges();
            }
        }

        //id ye göre silme işlemi
        public void DeleteById(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var entity=context.Set<TEntity>().Where(filter).ToList();
                foreach (var item in entity)
                {
                    context.Set<TEntity>().Remove(item);
                }
                context.SaveChanges();
            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
               
            }
        }


        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified; 
                context.SaveChanges();              
            }
        }
    }
}
