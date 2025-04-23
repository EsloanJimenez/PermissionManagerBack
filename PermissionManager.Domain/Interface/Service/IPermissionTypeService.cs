using PermissionManager.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Service
{
    public interface IPermissionTypeService
    {
        Task<List<PermissionTypeDTO>> GetAll();
        Task<PermissionTypeDTO> GetById(int id);
        Task<PermissionTypeDTO> Add(PermissionTypeDTO permission);
        Task Update(PermissionTypeDTO permission);
        Task Remove(int id);
    }
}
