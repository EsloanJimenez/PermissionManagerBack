using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Infrastructure.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppPermissionContext _context;
        private DbSet<TEntity> _entities;
        public BaseRepository(AppPermissionContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetId(int id)
        {
            return await _entities.FindAsync(id);
        }


        public virtual async Task Save(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
        }
        public virtual async Task Remove(TEntity entity)
        {
             _entities.Remove(entity);
        }
        public async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.AnyAsync(expression);
        }
    }
}
