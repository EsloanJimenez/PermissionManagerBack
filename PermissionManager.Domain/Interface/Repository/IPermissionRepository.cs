using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Repository
{
    public interface IPermissionRepository : IBaseRepository<Permission, PermissionDTO>
    {
        Task<List<PermissionDTO>> GetPermission();
        Task<PermissionDTO> GetPermissionId(int id);
    }
}
