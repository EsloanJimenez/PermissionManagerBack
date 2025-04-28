using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
<<<<<<< HEAD
using System;
=======
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
<<<<<<< HEAD
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

=======
    public class PermissionService : IPermissionService
    {
        private readonly IBaseRepository<Permission> _repository;
        private readonly IMapper _mapper;

        public PermissionService(IBaseRepository<Permission> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
        public async Task<List<PermissionDTO>> GetAll()
        {
            var query = _repository.GetAll().Select(x => new PermissionDTO
            {
                PermissionId = x.PermissionId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PermissionDate = x.PermissionDate,
                PermissionTypeId = x.PermissionTypeId,

                Description = x.PermissionTypeNav.Description // esto deberia llamarse PermissionTypeDescription
            });
            var dtos = await query.ToListAsync();
            return dtos;
        }

        public async Task<PermissionDTO> GetById(int id)
        {
            var query = _repository.GetAll().Select(x => new PermissionDTO
            {
                PermissionId = x.PermissionId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PermissionDate = x.PermissionDate,
                PermissionTypeId = x.PermissionTypeId,
                Description = x.PermissionTypeNav.Description
            });

            var dto = await query.FirstOrDefaultAsync();
            return dto;
        }

<<<<<<< HEAD
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
=======
        public virtual async Task<PermissionDTO> Add(PermissionDTO dto)
        {
            var entity = _mapper.Map<Permission>(dto);
            await _repository.Add(entity);
            return _mapper.Map<PermissionDTO>(entity);
        }

        public virtual async Task Update(PermissionDTO dto)
        {
            var entity = _mapper.Map<Permission>(dto);
            await _repository.Update(entity);
        }

        public virtual async Task Remove(int id)
        {
            var entity = await _repository.GetById(id);
            await _repository.Remove(entity);
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
        }
    }
}
