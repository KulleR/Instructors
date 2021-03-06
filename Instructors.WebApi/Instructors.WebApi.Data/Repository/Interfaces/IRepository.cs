﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instructors.WebApi.Data.Models.Entity;

namespace Instructors.WebApi.Data.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Get entity by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Entity with the specified Id, if exists. Else, null.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Loading all objects of this entity
        /// </summary>
        /// <returns>Unordered list of all objects</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Save entity object
        /// </summary>
        /// <param name="entity">Saved object</param>
        Task<bool> SaveAsync(TEntity entity);

        /// <summary>
        /// Update entity object
        /// </summary>
        /// <param name="entity">Updated object</param>
        bool Update(TEntity entity);

        /// <summary>
        /// Delete entity object
        /// </summary>
        /// <param name="entity">Deleted object</param>
        bool Delete(TEntity entity);
    }
}
