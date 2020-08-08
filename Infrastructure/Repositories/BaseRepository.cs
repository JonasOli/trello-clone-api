using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _entityContext;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _entityContext = _context.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            _entityContext.Add(entity);

            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _entityContext.Remove(entity);

            await SaveChanges();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Entity don't exists!");
            }

            _entityContext.Remove(entityToDelete);

            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            var editedEntity = await _entityContext.FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (editedEntity == null)
            {
                throw new Exception("Entity don't exists!");
            }

            entity.UpdatedAt = DateTime.Now;

            editedEntity = entity;

            await SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entityContext;
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return _entityContext.Where(predicate);
        }

        public Task<TEntity> GetById(int id)
        {
            return _entityContext.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
