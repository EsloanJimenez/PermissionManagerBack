using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
using PermissionManager.Infrastructure.Context;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly AppPermissionContext _context;
        public BaseService(IBaseRepository<TEntity> repository, AppPermissionContext context)
        {
            _repository = repository;
            _context = context;
        }

        public virtual async Task Save(TEntity entity)
        {
            await _repository.Save(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
