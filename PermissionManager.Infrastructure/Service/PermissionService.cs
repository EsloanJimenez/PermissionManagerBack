using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
using PermissionManager.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
    public class PermissionService : BaseService<Permission>, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository, AppPermissionContext context) : base(permissionRepository, context)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<List<PermissionDTO>> GetAll()
        {
            return await _permissionRepository.GetPermission();
        }

        public async Task<PermissionDTO> GetById(int id)
        {
            return await _permissionRepository.GetPermissionId(id);
        }

        public override async Task Save(Permission permission)
        {
            await base.Save(permission);
        }

        public override async Task Update(Permission permission)
        {
            var permissionToUpdate = await _permissionRepository.GetId(permission.PermissionId);

            permissionToUpdate.FirstName = permission.FirstName;
            permissionToUpdate.LastName = permission.LastName;
            permissionToUpdate.PermissionTypeId = permission.PermissionTypeId;
            permissionToUpdate.PermissionDate = permission.PermissionDate;

            permissionToUpdate.ModifyDate = DateTime.Now;

            await base.Update(permissionToUpdate);
        }

        public async Task Remove(int id)
        {
            var permissionToDelete = await _permissionRepository.GetId(id);

            permissionToDelete.Deleted = true;
            permissionToDelete.DeletedDate = DateTime.Now;

            await base.Update(permissionToDelete);
        }
    }
}
