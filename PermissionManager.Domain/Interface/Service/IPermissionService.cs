using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Service
{
    public interface IPermissionService
    {
        Task<List<PermissionDTO>> GetAll();
        Task<PermissionDTO> GetById(int id);
        Task Save(Permission permission);
        Task Update(Permission permission);
        Task Remove(int id);
    }

}
