using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task Save(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
