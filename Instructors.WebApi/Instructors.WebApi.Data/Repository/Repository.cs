using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool Delete(TEntity entity)
        {
            DbContext.Remove(entity);
            return DbContext.SaveChanges() > 0;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await DbContext.FindAsync<TEntity>(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public async Task<bool> SaveAsync(TEntity entity)
        {
            await DbContext.AddAsync(entity);
            return DbContext.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            DbContext.Update(entity);
            return DbContext.SaveChanges() > 0;
        }
    }
}
