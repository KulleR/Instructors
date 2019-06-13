using System;
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
        /// Получить сущность по идентификатору. В ряде случаев использование GetOrThrow более предпочтительно.
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Сущность с указанным Id, если существует. Иначе - null.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Загрузка всех объектов данной сущности
        /// </summary>
        /// <returns>Неупорядоченный список всех объектов</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Сохранить объект сущность
        /// </summary>
        /// <param name="entity">Сохраняемый объект</param>
        Task<bool> SaveAsync(TEntity entity);

        /// <summary>
        /// Обновить объект сущность
        /// </summary>
        /// <param name="entity">Обновляемый объект</param>
        bool Update(TEntity entity);

        /// <summary>
        /// Удалить объект сущности
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        bool Delete(TEntity entity);
    }
}
