using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Domain.Interface.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Service
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IBaseRepository<PermissionType> _repository;
        private readonly IMapper _mapper;

        public PermissionTypeService(IBaseRepository<PermissionType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<PermissionTypeDTO>> GetAll()
        {
            var entities = await _repository.GetAll().ToListAsync();
            var dtos = _mapper.Map<List<PermissionTypeDTO>>(entities);
            return dtos;
        }

        public async Task<PermissionTypeDTO> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            var dto = _mapper.Map<PermissionTypeDTO>(entity);
            return dto;
        }

        public virtual async Task<PermissionTypeDTO> Add(PermissionTypeDTO dto)
        {
            var entity = _mapper.Map<PermissionType>(dto);
            await _repository.Add(entity);
            return _mapper.Map<PermissionTypeDTO>(entity);
        }

        public virtual async Task Update(PermissionTypeDTO dto)
        {
            var entity = _mapper.Map<PermissionType>(dto);
            await _repository.Update(entity);
        }

        public virtual async Task Remove(int id)
        {
            var entity = await _repository.GetById(id);
            await _repository.Remove(entity);
        }
    }
}
