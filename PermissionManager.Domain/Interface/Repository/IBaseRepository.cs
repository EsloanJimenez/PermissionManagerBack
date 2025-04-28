using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
using System.Linq;
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity, TDto> where TEntity : class
    {
<<<<<<< HEAD
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TEntity> GetEntityById(int id);
=======
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
    }
}
