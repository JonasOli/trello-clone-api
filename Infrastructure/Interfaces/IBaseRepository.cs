using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(int id);
        Task Update(TEntity entity);

        Task<TEntity> GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);

        Task SaveChanges();
    }
}
