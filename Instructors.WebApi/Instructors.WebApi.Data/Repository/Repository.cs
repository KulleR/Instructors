using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Instructors.WebApi.Data.Models.Entity;
using Instructors.WebApi.Data.Repository.Interfaces;

namespace Instructors.WebApi.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private DatabaseContext DbContext { get; set; }

        public Repository() { }

        public Repository(DatabaseContext context)
        {
            DbContext = context;
        }

        public void Delete(TEntity entity)
        {
            DbContext.Remove(entity);
            DbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public int Save(TEntity entity)
        {
            DbContext.Add(entity);
            DbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            DbContext.Update(entity);
            DbContext.SaveChanges();
        }
    }
}
