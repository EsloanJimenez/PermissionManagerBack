using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.Core;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Infrastructure.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseAuditory
    {
        private readonly AppPermissionContext _context;
        private readonly DbSet<TEntity> _entities;
        public BaseRepository(AppPermissionContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            entity.Deleted = true;
            entity.DeletedDate = DateTime.Now;

            await Update(entity);
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.AnyAsync(expression);
        }
    }
}
