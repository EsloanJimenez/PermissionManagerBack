using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
using PermissionManager.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
    public class PermissionTypeService : BaseService<PermissionType>, IPermissionTypeService
    {
        private readonly IpermissionTypeRepository _permissionTypeRepository;
        public PermissionTypeService(IpermissionTypeRepository permissionTypeRepository, AppPermissionContext context) : base(permissionTypeRepository, context)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<List<PermissionTypeDTO>> GetAll()
        {
            return await _permissionTypeRepository.GetPermissionType();
        }

        public async Task<PermissionTypeDTO> GetById(int id)
        {
            return await _permissionTypeRepository.GetPermissionTypeId(id);
        }
    }
}
