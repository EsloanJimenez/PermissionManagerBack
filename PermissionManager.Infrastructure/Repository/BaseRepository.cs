using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TDto> : IBaseRepository<TEntity, TDto> where TEntity : class
    {
        protected readonly AppPermissionContext _context;
        private DbSet<TEntity> _entities;
        private readonly IMapper _mapper;
        public BaseRepository(AppPermissionContext context, IMapper mapper)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
            _mapper = mapper;
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            var entity = await _entities.ToListAsync();
            return _mapper.Map<List<TDto>>(entity);
        }

        public virtual async Task<TDto> GetById(int id)
        {
            var entity = await _entities.FindAsync(id);

            if (entity is null)
                return default;

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TEntity> GetEntityById(int id)
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
             _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.AnyAsync(expression);
        }
    }
}
