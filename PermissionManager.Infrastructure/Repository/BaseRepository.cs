<<<<<<< HEAD
﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Infrastructure.Context;
using System;
using System.Collections.Generic;
=======
﻿using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.Core;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Infrastructure.Context;
using System;
using System.Linq;
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Repository
{
<<<<<<< HEAD
    public class BaseRepository<TEntity, TDto> : IBaseRepository<TEntity, TDto> where TEntity : class
    {
        protected readonly AppPermissionContext _context;
        private DbSet<TEntity> _entities;
        private readonly IMapper _mapper;
        public BaseRepository(AppPermissionContext context, IMapper mapper)
=======
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseAuditory
    {
        private readonly AppPermissionContext _context;
        private readonly DbSet<TEntity> _entities;
        public BaseRepository(AppPermissionContext context)
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
        {
            _context = context;
            _entities = _context.Set<TEntity>();
            _mapper = mapper;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

<<<<<<< HEAD
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
=======
        public virtual async Task<TEntity> GetById(int id)
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
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
<<<<<<< HEAD
             _entities.Remove(entity);
            await _context.SaveChangesAsync();
=======
            entity.Deleted = true;
            entity.DeletedDate = DateTime.Now;

            await Update(entity);
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.AnyAsync(expression);
        }
    }
}
