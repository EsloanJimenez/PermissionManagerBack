using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permission = await _permissionService.GetAll();

                var permissionDTO = _mapper.Map<IEnumerable<PermissionDTO>>(permission);

                return Ok(permissionDTO);
            }catch(ArgumentException ex)
            {
                return BadRequest(new { messge = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO is null)
                    return BadRequest("La entidad no puede ser nula.");

                var permission = new Permission
                {
                    FirstName = permissionDTO.FirstName,
                    LastName = permissionDTO.LastName,
                    PermissionTypeId = permissionDTO.PermissionTypeId,
                    PermissionDate = permissionDTO.PermissionDate,
                };

                await _permissionService.Save(permission);
                return Ok(permission);
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(PermissionDTO permissionDTO, int id)
        {
            try
            {
                if (permissionDTO is null)
                    return BadRequest("La entidad no puede ser nula.");

                var permission = new Permission
                {
                    PermissionId = permissionDTO.PermissionId,
                    FirstName = permissionDTO.FirstName,
                    LastName = permissionDTO.LastName,
                    PermissionTypeId = permissionDTO.PermissionTypeId,
                    PermissionDate = permissionDTO.PermissionDate,
                };

                await _permissionService.Update(permission);

                return Ok(permission);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _permissionService.Remove(id);

                return NoContent();
            }catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
