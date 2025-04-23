using PermissionManager.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Service
{
    public interface IPermissionService
    {
        Task<List<PermissionDTO>> GetAll();
        Task<PermissionDTO> GetById(int id);
        Task<PermissionDTO> Add(PermissionDTO permission);
        Task Update(PermissionDTO permission);
        Task Remove(int id);
    }
}
