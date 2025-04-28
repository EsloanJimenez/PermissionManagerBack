using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Service
{
    public interface IPermissionService : IBaseService<Permission, PermissionDTO>
    {
        Task CreatePermision(PermissionDTO permissionDTO);
        Task UpdatePermision(PermissionDTO permissionDTO);
    }

}
