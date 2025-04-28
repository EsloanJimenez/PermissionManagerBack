using PermissionManager.Domain.DTO;
<<<<<<< HEAD
using PermissionManager.Domain.Entity;
=======
using System.Collections.Generic;
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
using System.Threading.Tasks;

namespace PermissionManager.Domain.Interface.Service
{
    public interface IPermissionService : IBaseService<Permission, PermissionDTO>
    {
<<<<<<< HEAD
        Task CreatePermision(PermissionDTO permissionDTO);
        Task UpdatePermision(PermissionDTO permissionDTO);
=======
        Task<List<PermissionDTO>> GetAll();
        Task<PermissionDTO> GetById(int id);
        Task<PermissionDTO> Add(PermissionDTO permission);
        Task Update(PermissionDTO permission);
        Task Remove(int id);
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
    }
}
