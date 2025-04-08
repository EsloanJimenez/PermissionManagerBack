using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Repository
{
    public interface IpermissionTypeRepository : IBaseRepository<PermissionType>
    {
        Task<List<PermissionTypeDTO>> GetPermissionType();
        Task<PermissionTypeDTO> GetPermissionTypeId(int id);
    }
}
