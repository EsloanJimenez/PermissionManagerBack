using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IBaseRepository<Permission> _repository;
        private readonly IMapper _mapper;

        public PermissionService(IBaseRepository<Permission> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
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
        }
    }
}
