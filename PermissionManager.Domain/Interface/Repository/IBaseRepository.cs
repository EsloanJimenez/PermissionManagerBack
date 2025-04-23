using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
    }
}
