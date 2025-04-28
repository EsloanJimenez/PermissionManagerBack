using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
    public class PermissionService : BaseService<Permission, PermissionDTO>, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository) : base(permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task CreatePermision(PermissionDTO permissionDTO)
        {
            var permission = new Permission
            {
                FirstName = permissionDTO.FirstName,
                LastName = permissionDTO.LastName,
                PermissionTypeId = permissionDTO.PermissionTypeId,
                PermissionDate = permissionDTO.PermissionDate,
            };

            await base.Add(permission);
        }

        public async Task UpdatePermision(PermissionDTO permissionDTO)
        {
            var permission = new Permission
            {
                PermissionId = permissionDTO.PermissionId,
                FirstName = permissionDTO.FirstName,
                LastName = permissionDTO.LastName,
                PermissionTypeId = permissionDTO.PermissionTypeId,
                PermissionDate = permissionDTO.PermissionDate,
            };

            await Update(permission);
        }

        public async Task<List<PermissionDTO>> GetAll()
        {
            return await _permissionRepository.GetPermission();
        }

        public async Task<PermissionDTO> GetById(int id)
        {
            return await _permissionRepository.GetPermissionId(id);
        }

        public override async Task Update(Permission permission)
        {
            var permissionToUpdate = await _permissionRepository.GetEntityById(permission.PermissionId);

            permissionToUpdate.FirstName = permission.FirstName;
            permissionToUpdate.LastName = permission.LastName;
            permissionToUpdate.PermissionTypeId = permission.PermissionTypeId;
            permissionToUpdate.PermissionDate = permission.PermissionDate;

            permissionToUpdate.ModifyDate = DateTime.Now;

            await base.Update(permissionToUpdate);
        }

        public async Task Remove(Permission permission)
        {
            var permissionToDelete = await _permissionRepository.GetEntityById(permission.PermissionId);

            permissionToDelete.Deleted = true;
            permissionToDelete.DeletedDate = DateTime.Now;

            await base.Update(permissionToDelete);
        }
    }
}
